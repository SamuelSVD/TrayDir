using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstancePluginParameter : Model<TrayInstancePluginParameter>
	{
		[XmlAttribute]
		public string name = string.Empty;
		[XmlAttribute]
		public string value = string.Empty;
		public override TrayInstancePluginParameter Copy()
		{
			TrayInstancePluginParameter tipp = new TrayInstancePluginParameter();
			tipp.name = name;
			tipp.value = value;
			return tipp;
		}

		public override bool Equals(TrayInstancePluginParameter b) {
			TrayInstancePluginParameter a = this;
			bool equals = true;
			equals &= (a.name == b.name);
			equals &= (a.value == b.value);
			return equals;
		}
	}
}
