using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TrayDir
{
    public class Settings
    {
        [XmlElement(ElementName = "Application")]
        public SettingsApplication app;
        public static string config = "config.xml";

        public Settings()
        {
            app = new SettingsApplication();
        }
        private static bool _altered;
        public static void Init()
        {
            _altered = false;
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
