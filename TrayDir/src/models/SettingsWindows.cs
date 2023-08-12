using System.Xml.Serialization;

namespace TrayDir {
	[XmlRoot(ElementName = "Windows")]

	public class SettingsWindows : StringIndexable {
		[XmlAttribute]
		public bool MinimizeOnClose = true;
		[XmlAttribute]
		public bool HideOnMinimize = true;
		[XmlAttribute]
		public bool StartMinimized = false;
		[XmlAttribute]
		public bool StartWithWindows = false;
		[XmlAttribute]
		public bool CheckForUpdates = true;
		[XmlAttribute]
		public bool ShowHiddenFiles = false;
	}
}
