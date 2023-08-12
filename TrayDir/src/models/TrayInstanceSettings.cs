using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir {
	[XmlRoot(ElementName = "TrayInstanceSettings")]
	public class TrayInstanceSettings : StringIndexable {
		public List<string> paths;
		[XmlAttribute]
		public bool RunAsAdmin;
		[XmlAttribute]
		public bool ShowFileExtensions;
		[XmlAttribute]
		public bool ExploreFoldersInTrayMenu;
		[XmlAttribute]
		public bool ExpandFirstPath;
		[XmlAttribute]
		public bool HideFromTray;
		public TrayInstanceSettings() {
			RunAsAdmin = false;
			ShowFileExtensions = true;
			ExploreFoldersInTrayMenu = false;
			HideFromTray = false;
			paths = new List<string>();
		}
		public TrayInstanceSettings Copy() {
			TrayInstanceSettings tis = new TrayInstanceSettings();
			tis.RunAsAdmin = RunAsAdmin;
			tis.ShowFileExtensions = ShowFileExtensions;
			tis.ExploreFoldersInTrayMenu = ExploreFoldersInTrayMenu;
			tis.ExpandFirstPath = ExpandFirstPath;
			tis.HideFromTray = HideFromTray;
			if (paths != null) {
				foreach (string path in paths) {
					tis.paths.Add(path);
				}
			}
			return tis;
		}
	}
}
