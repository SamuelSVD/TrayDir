using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class IVirtualFolderForm : Form
	{
		Dictionary<string, int> pluginIndex = new Dictionary<string, int>();
		List<Control> labels = new List<Control>();
		List<Control> controls = new List<Control>();
		TrayInstanceVirtualFolder model;
		public IVirtualFolderForm(TrayInstanceVirtualFolder tivf)
		{
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			this.model = tivf;
			aliasEdit.Text = model.alias;
			hideItemCheckBox.Checked = !model.visible;
		}
		private void IPluginForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			model.alias = aliasEdit.Text;
		}

		private void hideItemCheckBox_CheckedChanged(object sender, EventArgs e) {
			model.visible = !hideItemCheckBox.Checked;
		}

		private void IVirtualFolderForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/vfolders.htm");
		}

        private void OkButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
        }
    }
}
