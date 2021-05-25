using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir.src.models
{
    class TrayInstancePlugin
    {
        [XmlAttribute]
        public string plugin;
        public Dictionary<string,string> parameters;
    }
}
