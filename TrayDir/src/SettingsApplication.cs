using System;
using System.Reflection;
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
        [XmlAttribute]
        public bool StartWithWindows;
        [XmlAttribute]
        public bool ShowIconsInMenus;
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
