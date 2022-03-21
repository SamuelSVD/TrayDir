using System;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
	[XmlRoot(ElementName = "Application")]
	public class SettingsApplication : StringIndexable
	{
		[XmlAttribute]
		public bool ShowIconsInMenus = true;
		[XmlAttribute]
		public string MenuSorting = "Folders Top";
		[XmlAttribute]
		public string VFolderIcon = "Yellow Folder";
	}
}
