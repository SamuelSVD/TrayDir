using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePlugin
    {
        [XmlAttribute]
        public int id = -1;
        [XmlAttribute]
        public string alias;
        public List<TrayInstancePluginParameter> parameters = new List<TrayInstancePluginParameter>();
        [XmlIgnore]
        public TrayPlugin plugin
        {
            get
            {
                if (id >= 0 && id < ProgramData.pd.plugins.Count)
                {
                    return ProgramData.pd.plugins[id];
                }
                return null;
            }
        }
        public TrayInstancePlugin Copy()
        {
            TrayInstancePlugin tip = new TrayInstancePlugin();
            tip.id = id;
            tip.alias = alias;
            foreach(TrayInstancePluginParameter tipp in parameters)
            {
                tip.parameters.Add(tipp.Copy());
            }
            return tip;
        }
    }
}
