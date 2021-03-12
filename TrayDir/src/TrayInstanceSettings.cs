using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    [XmlRoot(ElementName = "TrayInstanceSettings")]
    public class TrayInstanceSettings
    {
        public List<string> paths;
        [XmlAttribute]
        public bool RunAsAdmin;
        [XmlAttribute]
        public bool ShowFileExtensions;
        [XmlAttribute]
        public bool ExploreFoldersInTrayMenu;
        [XmlAttribute]
        public bool ExpandFirstPath;
        [XmlAttribute]
        public string iconPath;
        [XmlAttribute]
        public string iconText;
        [XmlAttribute]
        public string InstanceName;
        public TrayInstanceSettings() : this("") { }
        public TrayInstanceSettings(string instanceName)
        {
            this.InstanceName = instanceName;
            Instantiate(instanceName);
        }
        private void Instantiate(string instanceName)
        {
            RunAsAdmin = false;
            ShowFileExtensions = true;
            ExploreFoldersInTrayMenu = false;
            paths = new List<string>();
            iconPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            iconText = "TrayDir";
        }
    }
}
