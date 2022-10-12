namespace TrayDir {
	public class TrayInstanceWebLink : TrayInstanceItem {
		public string URL = "";
		public override void Apply(object model) {
			if (model.GetType() == typeof(TrayInstanceWebLink)) {
				this.URL = ((TrayInstanceWebLink)model).URL;
				this.alias = ((TrayInstanceWebLink)model).alias;
			}
		}
		public override object Copy() {
			TrayInstanceWebLink tiu = new TrayInstanceWebLink();
			tiu.URL = this.URL;
			tiu.alias = this.alias;
			return tiu;
		}
		public override bool Equals(object b) {
			if (b.GetType() == typeof(TrayInstanceWebLink)) {
				TrayInstanceWebLink a = this;
				bool equals = true;
				equals &= this.URL == ((TrayInstanceWebLink)b).URL;
				equals &= this.alias == ((TrayInstanceWebLink)b).alias;
				return equals;
			}
			return false;
		}
	}
}
