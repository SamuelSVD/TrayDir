﻿using System;
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
			urlErrorPictureBox.Visible = !model.isValidURL;
		}

		private void urlErrorPictureBox_MouseLeave(object sender, EventArgs e) {
			urlToolTip.Hide(urlTextBox);
		}

		private void urlErrorPictureBox_MouseEnter(object sender, EventArgs e) {
			urlToolTip.Show(Properties.Strings.Tooltip_InvalidUrl, urlTextBox, urlTextBox.PointToClient(MousePosition).X+2, urlTextBox.PointToClient(MousePosition).Y+2);
		}
	}
}
