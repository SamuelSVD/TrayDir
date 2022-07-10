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

		private void label2_Click(object sender, System.EventArgs e) {
			System.Diagnostics.Process.Start("https://samver.ca");
		}
	}
}
