using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePluginParameter
    {
        [XmlAttribute]
        public string name = "";
        [XmlAttribute]
        public string value = "";
        public TrayInstancePluginParameter Copy()
        {
            TrayInstancePluginParameter tipp = new TrayInstancePluginParameter();
            tipp.name = name;
            tipp.value = value;
            return tipp;
        }
    }
}
