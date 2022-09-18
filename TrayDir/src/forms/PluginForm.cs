using System;
using System.IO;
using System.Windows.Forms;
using Utils;

namespace TrayDir {
	public partial class PluginForm : Form
	{
		private PluginNode plugin;
		public PluginForm(PluginNode plugin)
		{
			this.plugin = plugin;
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			nameEdit.Text = plugin.tp.name;
			pathEdit.Text = plugin.tp.path;
			paramNumericUpDown.Value = plugin.tp.parameterCount;
			configureParamsButton.Enabled = plugin.tp.parameterCount > 0;
			alwaysRunAsAdminCheckBox.Checked = plugin.tp.AlwaysRunAsAdmin;
			openIndirectCheckBox.Checked = plugin.tp.OpenIndirect;
			scriptCheckBox.Checked = plugin.tp.isScript;
			scriptText.Text = plugin.tp.scriptText;
			updateEnabled();
		}
		private void updateEnabled() {
			pathEdit.Enabled = !scriptCheckBox.Checked;
			browseButton.Enabled = !scriptCheckBox.Checked;
			openIndirectCheckBox.Enabled = !scriptCheckBox.Checked;
			scriptText.Enabled = scriptCheckBox.Checked;
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
			if (path == null || path == string.Empty)
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

		private void openExternallyCheckBox_Click(object sender, EventArgs e) {
			plugin.tp.OpenIndirect = openIndirectCheckBox.Checked;
		}

		private void scriptCheckBox_CheckedChanged(object sender, EventArgs e) {
			plugin.tp.isScript = scriptCheckBox.Checked;
			updateEnabled();
		}

		private void scriptText_TextChanged(object sender, EventArgs e) {
			plugin.tp.scriptText = scriptText.Text;
		}
		private void PluginForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/plugins.htm");
		}
	}
}
