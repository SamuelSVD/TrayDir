using System.Reflection;
using System.Windows.Forms;

namespace TrayDir
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			versionLabel.Text = string.Format(Properties.Strings.Version, Assembly.GetEntryAssembly().GetName().Version.ToString());
		}

		private void label2_Click(object sender, System.EventArgs e) {
			System.Diagnostics.Process.Start("https://samver.ca");
		}
	}
}
