using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace TrayDir
{
    class Settings
    {
        public static string config = "config.xml";
        //public static string iconPath = "";
        //public static string iconText = "TrayDir";

        public static OptionGroup settings;
        public static OptionGroup instanceSettings;

        private static bool _altered;
        public static void Init()
        {
            settings = new OptionGroup("Application");

            setOption("MinimizeOnClose", true);
            setOption("StartMinimized", false);

            instanceSettings = new OptionGroup("Instances");
            instanceSettings.setOption("default-instance|RunAsAdmin", false);
            instanceSettings.setOption("default-instance|ShowFileExtensions", true);
            instanceSettings.setOption("default-instance|ExploreFoldersInTrayMenu", false);
            instanceSettings.setOption("default-instance|paths|1", ".");
            instanceSettings.setOption("default-instance|iconPath", System.Reflection.Assembly.GetEntryAssembly().Location);
            instanceSettings.setOption("default-instance|iconText", "TrayDir");
            _altered = false;
        }
        public static void Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.Load(config);
                XmlElement root = doc.DocumentElement;
                LoadOptions(root);
                LoadPaths(root);
                LoadInstances(root);
                LoadAppConfig(root);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Loading Config:" + e.Message);
            }
        }
        private static void LoadOptions(XmlElement root)
        {
            try
            {
                XmlElement options = root.GetElementsByTagName("options")[0] as XmlElement;
                foreach (XmlElement option in options.GetElementsByTagName("option"))
                {
                    try
                    {
                        string name = option.GetAttribute("Name");
                        bool value = AppUtils.StrToBool(option.GetAttribute("Value"));
                        setOption(name, value);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error Parsing Option: " + e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Parsing Options: " + e.Message);
            }
        }
        private static void LoadPaths(XmlElement root)
        {
            try
            {
                XmlElement paths = root.GetElementsByTagName("paths")[0] as XmlElement;
                if (paths != null) {
                    XmlNodeList list = paths.GetElementsByTagName("path");
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            XmlElement path = (XmlElement)list[i];
                            try
                            {
                                string value = path.GetAttribute("Value");
                                setOption("default-instance|paths|" + i.ToString(), value);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Error Parsing Path: " + e.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Parsing Paths: " + e.Message);
            }
        }
        private static void LoadInstances(XmlElement root)
        {
            try
            {
                XmlElement paths = root.GetElementsByTagName("instances")[0] as XmlElement;
                XmlNodeList list = paths.GetElementsByTagName("option");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlElement path = (XmlElement)list[i];
                        try
                        {
                            string value = path.GetAttribute("Value");
                            setIOption(path.GetAttribute("name"), value);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error Parsing Path: " + e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Parsing Paths: " + e.Message);
            }
        }
        private static void LoadAppConfig(XmlElement root)
        {
            try
            {
                XmlElement appConfig = root.GetElementsByTagName("appconfig")[0] as XmlElement;
                XmlElement trayicon = appConfig.GetElementsByTagName("trayicon")[0] as XmlElement;
                setIOption("default-instance|iconPath", trayicon.GetAttribute("Value"));
                if (trayicon.Attributes != null && trayicon.Attributes["Text"] != null)
                {
                    setOption("default-instance|iconText", trayicon.GetAttribute("Text"));
                }
            }
            catch
            {
                //MessageBox.Show("Error Parsing Paths: " + e.Message);
            }
        }
        public static void Save()
        {
            try
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                xmlSettings.IndentChars = ("    ");
                xmlSettings.CloseOutput = true;
                xmlSettings.OmitXmlDeclaration = false;
                XmlWriter writer = XmlWriter.Create(config, xmlSettings);
                writer.WriteStartElement("TrayDir");
                writer.WriteStartElement("appconfig");
                writer.WriteStartElement("trayicon");
                writer.WriteAttributeString("Value", getIOptionStr("default-instance|iconPath"));
                writer.WriteAttributeString("Text", getIOptionStr("default-instance|iconText"));
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("options");
                List<Option> optionList = settings.asOptionList();
                for (int i = 0; i < optionList.Count; i++)
                {
                    writer.WriteStartElement("option");
                    writer.WriteAttributeString("Name", optionList[i].name);
                    writer.WriteAttributeString("Value", optionList[i].getValue_string());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                List<Option> instanceOption = instanceSettings.asOptionList();
                writer.WriteStartElement("instances");
                writer.WriteAttributeString("count", instanceSettings.getCategoryCount().ToString());
                for (int i = 0; i < instanceOption.Count; i++)
                {
                    writer.WriteStartElement("option");
                    writer.WriteAttributeString("name", instanceOption[i].name);
                    writer.WriteAttributeString("Value", instanceOption[i].getValue_string());
                    writer.WriteEndElement();
                };
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
                _altered = false;
            }
            catch (System.UnauthorizedAccessException e)
            {
                MessageBox.Show("Exception caught: " + e.Message);
            }
        }
        static string BoolToStr(bool value)
        {
            return value ? "1" : "0";
        }
        public static bool getOptionBool(string input)
        {
            return settings.getOptionValue_bool(input);
        }
        public static void setOption(string input, bool value)
        {
            settings.setOption(input, value);
        }
        public static string getOptionStr(string input)
        {
            return settings.getOptionValue_string(input);
        }
        public static void setOption(string input, string value)
        {
            settings.setOption(input, value);
        }
        public static bool getIOptionBool(string input)
        {
            return instanceSettings.getOptionValue_bool(input);
        }
        public static void setIOption(string input, bool value)
        {
            instanceSettings.setOption(input, value);
        }
        public static string getIOptionStr(string input)
        {
            return instanceSettings.getOptionValue_string(input);
        }
        public static void setIOption(string input, string value)
        {
            instanceSettings.setOption(input, value);
        }
        public static bool ConfirmClose()
        {
            if (_altered)
            {
                return (MessageBox.Show("Changes have not been saved. Continue closing?", "TrayDir", MessageBoxButtons.YesNo) == DialogResult.Yes);
            }
            else
            {
                return true;
            }
        }
        public static bool isAltered()
        {
            return _altered;
        }
        public static void Alter()
        {
            _altered = true;
        }
        public static OptionGroup getInstanceOptions(string instanceName)
        {
            return instanceSettings.getChild(instanceName);
    }
    }
}
