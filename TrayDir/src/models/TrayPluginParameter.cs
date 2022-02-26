using System.Xml.Serialization;

namespace TrayDir {
    public class TrayPluginParameter {
        [XmlAttribute]
        public string name = "";
        [XmlAttribute]
        public string prefix = "";
        [XmlAttribute]
        public bool alwaysIncludePrefix = false;
        [XmlAttribute]
        public bool isBoolean = false;
        public string getSignature() {
            return string.Format("{0}, {1}, {2}", name, prefix, isBoolean);
        }
    }
}
