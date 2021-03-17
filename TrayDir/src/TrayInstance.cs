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
        [XmlAttribute]
        public string instanceName;
        [XmlIgnore]
        public IView view;
        public TrayInstance() : this("New Instance") { }
        public TrayInstance(string instanceName) : this(instanceName, new TrayInstanceSettings())
        {
        }
        public TrayInstance(String instanceName, TrayInstanceSettings settings)
        {
            this.settings = settings;
            iconPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            this.instanceName = instanceName;
        }
        public void AddPath(string path)
        {
            this.settings.paths.Add(path);
        }
    }
}
