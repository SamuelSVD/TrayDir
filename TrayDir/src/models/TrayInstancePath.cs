using System;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstancePath : Model<TrayInstancePath>
	{
		[XmlAttribute]
		public string path;
		[XmlAttribute]
		public bool shortcut = false;
		[XmlAttribute]
		public string alias;
		[XmlAttribute]
		public bool visible = true;
		public TrayInstancePath() : this(string.Empty) { }
		public bool isDir { get { return AppUtils.PathIsDirectory(path); } }
		public bool isFile { get { return AppUtils.PathIsFile(path); } }
		public TrayInstancePath(string path)
		{
			this.path = path;
		}
		public override TrayInstancePath Copy()
		{
			TrayInstancePath tip = new TrayInstancePath();
			tip.path = path;
			tip.shortcut = shortcut;
			tip.alias = alias;
			return tip;
		}
		public override void Apply(TrayInstancePath model) {
			this.path = model.path;
			this.shortcut = model.shortcut;
			this.alias = model.alias;
		}
		public override bool Equals(TrayInstancePath b) {
			TrayInstancePath a = this;
			bool equals = true;
			equals &= (a.path == b.path);
			equals &= (a.shortcut == b.shortcut);
			equals &= (a.alias == b.alias);
			equals &= (a.visible == b.visible);
			return equals;
		}
	}
}
