using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class IWebLinkForm : Form
	{
		public TrayInstanceWebLink model;
		public IWebLinkForm(TrayInstanceWebLink tip)
		{
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			this.model = tip;
			pathTextBox.Text = model.URL;
			aliasEdit.Text = model.alias;
			hideItemCheckBox.Checked = !model.visible;
		}
		private void pathTextBox_TextChanged(object sender, EventArgs e)
		{
			model.URL = pathTextBox.Text;
		}
		private void aliasEdit_TextChanged(object sender, EventArgs e)
		{
			model.alias = aliasEdit.Text;
		}
		private void hideItemCheckBox_CheckedChanged(object sender, EventArgs e) {
			model.visible = !hideItemCheckBox.Checked;
		}
		private void IPathForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/weblinks.htm");
		}
        private void OkButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
        }
    }
}
