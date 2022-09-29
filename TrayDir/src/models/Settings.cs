using System.Xml;
using System.Xml.Serialization;

namespace TrayDir {
	public class Settings {
		[XmlElement(ElementName = "Application")]
		public SettingsApplication app;
		public SettingsWindows win;
		public static string config = "config.xml";

		public Settings() {
			app = new SettingsApplication();
			win = new SettingsWindows();
		}
	}
}
