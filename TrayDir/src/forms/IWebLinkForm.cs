using System;
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
			urlTextBox.Text = model.URL;
			aliasEdit.Text = model.alias;
			hideItemCheckBox.Checked = !model.visible;
			urlTextBox.TooltipText = Properties.Strings.Tooltip_InvalidUrl;
			urlTextBox.TextChanged += urlTextBox_TextChanged;
		}
		private void urlTextBox_TextChanged(object sender, EventArgs e)
		{
			model.URL = urlTextBox.Text;
			ValidateURL();
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
        private void IWebLinkForm_Shown(object sender, EventArgs e) {
			ValidateURL();
        }
		private void ValidateURL() {
			urlTextBox.Valid = model.isValidURL;
		}
	}
}
