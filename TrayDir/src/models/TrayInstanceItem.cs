using System.Xml.Serialization;

namespace TrayDir {
	public abstract class TrayInstanceItem : Model {
		[XmlAttribute]
		public bool visible = true;
		[XmlAttribute]
		public string alias;
	}
}
