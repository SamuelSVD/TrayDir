using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayPlugin
    {
        [XmlAttribute]
        public string path;
        [XmlAttribute]
        public string name;
    }
}
