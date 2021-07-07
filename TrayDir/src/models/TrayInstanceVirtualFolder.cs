using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstanceVirtualFolder
    {
        [XmlAttribute]
        public string alias;
        public TrayInstanceVirtualFolder() : this("") { }
        public TrayInstanceVirtualFolder(string alias)
        {
            this.alias = alias;
        }
    }
}
