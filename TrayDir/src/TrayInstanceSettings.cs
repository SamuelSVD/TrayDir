using System;
using System.Collections.Generic;
using System.Reflection;
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
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(TrayInstanceSettings);
                FieldInfo myPropInfo = myType.GetField(propertyName);
                return myPropInfo.GetValue(this);
            }
            set
            {
                Type myType = typeof(TrayInstanceSettings);
                FieldInfo myPropInfo = myType.GetField(propertyName);
                myPropInfo.SetValue(this, value);
            }
        }
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
