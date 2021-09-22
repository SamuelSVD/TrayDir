using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePlugin
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string alias;
        public List<TrayInstancePluginParameter> parameters;
    }
}
