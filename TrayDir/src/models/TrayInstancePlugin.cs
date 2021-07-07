using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePlugin
    {
        [XmlAttribute]
        public string plugin;
        [XmlAttribute]
        public string alias;
        public List<TrayInstancePluginParameter> parameters;
    }
}
