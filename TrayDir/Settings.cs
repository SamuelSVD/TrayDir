using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrayDir
{
    class Option
    {
        public string name;
        public bool value;
        public Option(string name, bool value)
        {
            this.name = name;
            this.value = value;
        }
    }
    class Settings
    {
        public static string config = "config.xml";
        private static Dictionary<string, Option> options;
        public static List<string> paths;
        public static void Init()
        {
            options = new Dictionary<string, Option>();
            Option option = new Option("RunAsAdmin", false);
            options.Add("RunAsAdmin", option);
            option = new Option("ShowFileExtensions", true);
            options.Add("ShowFileExtensions", option);
            paths = new List<string>();
            paths.Add(".");
            Load();
        }
        public static void Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.Load(config);
                XmlElement root = doc.DocumentElement;
                LoadOptions(root.GetElementsByTagName("options")[0] as XmlElement);
                LoadPaths(root.GetElementsByTagName("paths")[0] as XmlElement);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Loading Config" + e.Message);
            }
        }
        private static void LoadOptions(XmlElement options)
        {
            foreach(XmlElement option in options.GetElementsByTagName("option"))
            {
                try
                {
                    string name = option.GetAttribute("Name");
                    bool value = StrToBool(option.GetAttribute("Value"));
                    Option o = new Option(name, value);
                    Settings.options[name] = o;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Parsing Options: " + e.Message);
                }
            }
        }
        private static void LoadPaths(XmlElement paths)
        {
            XmlNodeList list = paths.GetElementsByTagName("path");
            if (list.Count > 0)
            {
                Settings.paths.Clear();
                foreach (XmlElement path in list)
                {
                    try
                    {
                        string value = path.GetAttribute("Value");
                        Settings.paths.Add(value);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error Parsing Options: " + e.Message);
                    }
                }
            }
        }
        public static void Save()
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = ("    ");
            xmlSettings.CloseOutput = true;
            xmlSettings.OmitXmlDeclaration = false;
            XmlWriter writer = XmlWriter.Create(config, xmlSettings);
            writer.WriteStartElement("TrayDir");
            writer.WriteStartElement("options");
            foreach (KeyValuePair<string, Option> option in options)
            {
                writer.WriteStartElement("option");
                writer.WriteAttributeString("Name", option.Key);
                writer.WriteAttributeString("Value", BoolToStr(option.Value.value));
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("paths");
            writer.WriteAttributeString("count", paths.Count.ToString());
            foreach( string path in paths)
            {
                writer.WriteStartElement("path");
                writer.WriteAttributeString("Value", path);
                writer.WriteEndElement();
                Console.WriteLine(path);
            };
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
        static string BoolToStr(bool value)
        {
            return value ? "1" : "0";
        }
        static bool StrToBool(string value)
        {
            return value == "1" ? true : false;
        }
        public static bool getOption(string input)
        {
            if (options.ContainsKey(input))
            {
                return options[input].value;
            } else
            {
                return false;
            }
        }
        public static void setOption(string input, bool value)
        {
            if (options.ContainsKey(input))
            {
                options[input].value = value;
            }
            else
            {
                Option o = new Option(input, value);
                options[input] = o;
            }
        }
        public static Dictionary<string, Option>.ValueCollection getOptions()
        {
            return options.Values;
        }
    }
}
