namespace TrayDir {
	public class TrayInstanceVirtualFolder : TrayInstanceItem {
		public TrayInstanceVirtualFolder() : this(string.Empty) { }
		public TrayInstanceVirtualFolder(string alias) {
			this.alias = alias;
		}
		public override object Copy() {
			TrayInstanceVirtualFolder tivf = new TrayInstanceVirtualFolder();
			tivf.alias = alias;
			return tivf;
		}
		public override void Apply(object model) {
			if (model.GetType() == typeof(TrayInstanceVirtualFolder)) {
				this.alias = ((TrayInstanceVirtualFolder)model).alias;
			}
		}
		public override bool Equals(object b) {
			if (b.GetType() == typeof(TrayInstanceVirtualFolder)) {
				TrayInstanceVirtualFolder a = this;
				bool equals = true;
				equals &= (a.alias == ((TrayInstanceVirtualFolder)b).alias);
				equals &= (a.visible == ((TrayInstanceVirtualFolder)b).visible);
				return equals;
			}
			return false;
		}
	}
}
