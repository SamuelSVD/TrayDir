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

        private static bool _altered;
        public static void Init()
        {
            settings = new OptionGroup("Application");
            setOption("MinimizeOnClose", false);
            setOption("StartMinimized", false);
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
                SettingsXML.XMLRead(root);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Loading Config:" + e.Message);
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
                SettingsXML.XMLWrite(writer);
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
    }
}
