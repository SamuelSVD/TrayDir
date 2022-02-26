using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayPlugin
    {
        [XmlAttribute]
        public string path;
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int parameterCount;
        [XmlAttribute]
        public bool AlwaysRunAsAdmin = false;
        [XmlAttribute]
        public bool OpenIndirect = false;
        [XmlAttribute]
        public string Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public List<TrayPluginParameter> parameters = new List<TrayPluginParameter>();
        public string getSignature()
        {
            string sig = string.Format("{0} ({1})", name, path);
            return sig;
        }
    }
}
