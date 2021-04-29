using System;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
    [XmlRoot(ElementName = "Application")]
    public class SettingsApplication : StringIndexable
    {
        [XmlAttribute]
        public bool ShowIconsInMenus;
        [XmlAttribute]
        public string MenuSorting = "Folders Top";
    }
}
