using System.Xml.Serialization;

namespace TrayDir {
	public class TrayInstancePath : TrayInstanceItem {
		[XmlAttribute]
		public string path;
		[XmlAttribute]
		public bool shortcut = false;
		public TrayInstancePath() : this(string.Empty) { }
		public bool isDir { get { return AppUtils.PathIsDirectory(path); } }
		public bool isFile { get { return AppUtils.PathIsFile(path); } }
		public TrayInstancePath(string path) {
			this.path = path;
		}
		public override object Copy() {
			TrayInstancePath tip = new TrayInstancePath();
			tip.path = path;
			tip.shortcut = shortcut;
			tip.alias = alias;
			tip.visible = visible;
			return tip;
		}
		public override void Apply(object model) {
			if (model.GetType() == typeof(TrayInstancePath)) {
				this.path = ((TrayInstancePath)model).path;
				this.shortcut = ((TrayInstancePath)model).shortcut;
				this.alias = ((TrayInstancePath)model).alias;
				this.visible = ((TrayInstancePath)model).visible;
			}
		}
		public override bool Equals(object b) {
			if (b.GetType() == typeof(TrayInstancePath)) {
				TrayInstancePath a = this;
				bool equals = true;
				equals &= (a.path == ((TrayInstancePath)b).path);
				equals &= (a.shortcut == ((TrayInstancePath)b).shortcut);
				equals &= (a.alias == ((TrayInstancePath)b).alias);
				equals &= (a.visible == ((TrayInstancePath)b).visible);
				return equals;
			}
			return false;
		}
	}
}
