using System;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace TrayDir
{
    [XmlRoot(ElementName = "Instance")]
    public class TrayInstance
    {
        [XmlElement(ElementName = "Settings")]
        public TrayInstanceSettings settings;
        [XmlAttribute]
        public string iconPath;
        public byte[] iconData;
        [XmlAttribute]
        public string instanceName;
        [XmlIgnore]
        public IView view;
        public static string defaultPath = "";
        public TrayInstance() : this("New Instance") { }
        public TrayInstance(string instanceName) : this(instanceName, new TrayInstanceSettings())
        {
        }
        public TrayInstance(String instanceName, TrayInstanceSettings settings)
        {
            defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.settings = settings;
            this.instanceName = instanceName;
        }
        public void AddPath(string path)
        {
            settings.paths.Add(path);
        }
    }
}
