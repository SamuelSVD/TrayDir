using System;
using System.Xml.Serialization;

namespace TrayDir
{
	[XmlRoot(ElementName = "Windows")]

	public class SettingsWindows : StringIndexable
	{
		[XmlAttribute]
		public bool MinimizeOnClose = true;
		[XmlAttribute]
		public bool HideOnMinimize = true;
		[XmlAttribute]
		public bool StartMinimized = false;
		[XmlAttribute]
		public bool StartWithWindows = true;
		[XmlAttribute]
		public bool CheckForUpdates = true;
	}
}
