using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePath
    {
        [XmlAttribute]
        public string path;
        [XmlAttribute]
        public bool shortcut = false;
        [XmlAttribute]
        public string alias;
        public TrayInstancePath() : this("") { }
        public bool isDir { get { return AppUtils.PathIsDirectory(path); } }
        public bool isFile { get { return AppUtils.PathIsFile(path); } }
        public TrayInstancePath(string path)
        {
            this.path = path;
        }
        public TrayInstancePath Copy()
        {
            TrayInstancePath tip = new TrayInstancePath();
            tip.path = path;
            tip.shortcut = shortcut;
            tip.alias = alias;
            return tip;
        }
    }
}
