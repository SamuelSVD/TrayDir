using System.Reflection;
using System.Windows.Forms;

namespace TrayDir
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			versionLabel.Text = string.Format(Properties.Strings_en.Version, Assembly.GetEntryAssembly().GetName().Version.ToString());
		}
	}
}
