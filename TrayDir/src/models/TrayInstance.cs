using System;
using System.Collections.Generic;
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
        [XmlAttribute]
        public string ignoreRegex = "";
        [XmlIgnore]
        public IView view;
        public List<TrayInstancePath> paths;

        public byte[] iconData;
        public static string defaultPath = "";
        public int PathCount { get { return paths.Count; } }
        public string[] regexList { get { return ignoreRegex.Split('\r', '\n'); } }
        public TrayInstance() : this("New Instance") { }
        public TrayInstance(string instanceName) : this(instanceName, new TrayInstanceSettings())
        {
        }
        public TrayInstance(String instanceName, TrayInstanceSettings settings)
        {
            defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.settings = settings;
            this.instanceName = instanceName;
            paths = new List<TrayInstancePath>();
        }
    }
}
