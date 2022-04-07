using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstancePluginParameter
	{
		[XmlAttribute]
		public string name = string.Empty;
		[XmlAttribute]
		public string value = string.Empty;
		public TrayInstancePluginParameter Copy()
		{
			TrayInstancePluginParameter tipp = new TrayInstancePluginParameter();
			tipp.name = name;
			tipp.value = value;
			return tipp;
		}
	}
}
