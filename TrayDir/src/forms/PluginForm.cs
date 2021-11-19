using System;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class PluginForm : Form
    {
        private PluginNode plugin;
        public PluginForm(PluginNode plugin)
        {
            this.plugin = plugin;
            InitializeComponent();
            nameEdit.Text = plugin.tp.name;
            pathEdit.Text = plugin.tp.path;
            paramNumericUpDown.Value = plugin.tp.parameterCount;
            configureParamsButton.Enabled = plugin.tp.parameterCount > 0;
            alwaysRunAsAdminCheckBox.Checked = plugin.tp.AlwaysRunAsAdmin;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            plugin.tp.name = nameEdit.Text;
            plugin.UpdateNode();
            Close();
        }
        private void browseButton_Click(object sender, EventArgs e)
        {
            MainForm.form.fd.DereferenceLinks = false;
            string path = plugin.tp.path;
            if (path == null || path == "")
            {
                MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                MainForm.form.fd.InitialDirectory = Path.GetDirectoryName(path);
            }
            MainForm.form.fd.FileName = Path.GetFileName(path);
            DialogResult d = MainForm.form.fd.ShowDialog();
            if (d == DialogResult.OK)
            {
                plugin.tp.path = MainForm.form.fd.FileName;
                pathEdit.Text = plugin.tp.path;
                plugin.tp.name = Path.GetFileNameWithoutExtension(plugin.tp.path);
                nameEdit.Text = plugin.tp.name;
                plugin.UpdateNode();
            }
        }
        private void paramNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            plugin.tp.parameterCount = (int)paramNumericUpDown.Value;
            configureParamsButton.Enabled = plugin.tp.parameterCount > 0;
        }
        private void PluginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProgramData.pd.Save();
        }
        private void configureParamsButton_Click(object sender, EventArgs e) {
            PluginParameterForm ppf = new PluginParameterForm(plugin.tp);
            ppf.ShowDialog();
        }

        private void alwaysRunAsAdmin_CheckedChanged(object sender, EventArgs e) {
            plugin.tp.AlwaysRunAsAdmin = alwaysRunAsAdminCheckBox.Checked;
        }
    }
}
