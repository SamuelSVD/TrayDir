using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstanceVirtualFolder : Model<TrayInstanceVirtualFolder>
	{
		[XmlAttribute]
		public string alias;
		[XmlAttribute]
		public bool visible = true;
		public TrayInstanceVirtualFolder() : this(string.Empty) { }
		public TrayInstanceVirtualFolder(string alias)
		{
			this.alias = alias;
		}
		public override TrayInstanceVirtualFolder Copy()
		{
			TrayInstanceVirtualFolder tivf = new TrayInstanceVirtualFolder();
			tivf.alias = alias;
			return tivf;
		}

		public override bool Equals(TrayInstanceVirtualFolder b) {
			TrayInstanceVirtualFolder a = this;
			bool equals = true;
			equals &= (a.alias == b.alias);
			equals &= (a.visible == b.visible);
			return equals;
		}
	}
}
