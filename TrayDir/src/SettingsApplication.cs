using System;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
    [XmlRoot(ElementName = "Application")]
    public class SettingsApplication
    {
        [XmlAttribute]
        public bool MinimizeOnClose = false;
        [XmlAttribute]
        public bool StartMinimized = false;
        [XmlAttribute]
        public bool StartWithWindows = true;
        [XmlAttribute]
        public bool ShowIconsInMenus = false;
        [XmlAttribute]
        public string MenuSorting = "Folders Top";
        [XmlAttribute]
        public bool CheckForUpdates = true;
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(SettingsApplication);
                FieldInfo myPropInfo = myType.GetField(propertyName);
                return myPropInfo.GetValue(this);
            }
            set
            {
                Type myType = typeof(SettingsApplication);
                FieldInfo myPropInfo = myType.GetField(propertyName);
                myPropInfo.SetValue(this, value);
            }
        }
    }
}
