using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayPlugin
    {
        [XmlAttribute]
        public string path;
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int parameterCount;
        public string getSignature()
        {
            return string.Format("{0} ({1})", name, path);
        }
    }
}
