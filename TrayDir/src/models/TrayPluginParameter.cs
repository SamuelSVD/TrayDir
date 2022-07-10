using System.Xml.Serialization;

namespace TrayDir {
	public class TrayPluginParameter {
		[XmlAttribute]
		public string name = string.Empty;
		[XmlAttribute]
		public string prefix = string.Empty;
		[XmlAttribute]
		public bool alwaysIncludePrefix = false;
		[XmlAttribute]
		public bool isBoolean = false;
		[XmlAttribute]
		public bool required = false;
		public string getSignature() {
			return string.Format("{0}, {1}, {2}", name, prefix, isBoolean);
		}
	}
}
