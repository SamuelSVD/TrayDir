using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
    [XmlRoot(ElementName = "TrayInstanceSettings")]
    public class TrayInstanceSettings : StringIndexable
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
        public TrayInstanceSettings() {
            RunAsAdmin = false;
            ShowFileExtensions = true;
            ExploreFoldersInTrayMenu = false;
            paths = new List<string>();
        }
    }
}
