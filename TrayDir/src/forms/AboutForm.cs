using System.Reflection;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            versionLabel.Text = "Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
