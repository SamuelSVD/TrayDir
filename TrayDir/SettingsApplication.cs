using System.Xml.Serialization;

namespace TrayDir
{
    [XmlRoot(ElementName = "Application")]
    public class SettingsApplication
    {
        [XmlAttribute]
        public bool MinimizeOnClose;
        [XmlAttribute]
        public bool StartMinimized;
    }
}
