using System.Xml.Serialization;

namespace TrayDir {
	public class TrayInstancePluginParameter : Model {
		[XmlAttribute]
		public string name = string.Empty;
		[XmlAttribute]
		public string value = string.Empty;
		public override object Copy() {
			TrayInstancePluginParameter tipp = new TrayInstancePluginParameter();
			tipp.name = name;
			tipp.value = value;
			return tipp;
		}
		public override void Apply(object model) {
			if (model.GetType() == typeof(TrayInstancePluginParameter)) {
				this.name = ((TrayInstancePluginParameter)model).name;
				this.value = ((TrayInstancePluginParameter)model).value;
			}
		}
		public override bool Equals(object b) {
			if (b.GetType() == typeof(TrayInstancePluginParameter)) {
				TrayInstancePluginParameter a = this;
				bool equals = true;
				equals &= (a.name == ((TrayInstancePluginParameter)b).name);
				equals &= (a.value == ((TrayInstancePluginParameter)b).value);
				return equals;
			}
			return false;
		}
	}
}
