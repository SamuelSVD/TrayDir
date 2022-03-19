using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
	public partial class IPathForm : Form
	{
		TrayInstancePath tip;
		private bool editFileOnShow = false;
		private bool editFolderOnShow = false;
		public IPathForm(TrayInstancePath tip)
		{
			InitializeComponent();
			this.tip = tip;
			pathTextBox.Text = tip.path;
			aliasEdit.Text = tip.alias;
			shortcutCheckBox.Checked = tip.shortcut;
		}
		public void ShowDialogNewFile() {
			editFileOnShow = true;
			ShowDialog();
		}
		public void ShowDialogNewFolder() {
			editFolderOnShow = true;
			ShowDialog();
		}
		private void folderBrowseButton_Click(object sender, EventArgs e)
		{
			FolderSelectDialog fs = new FolderSelectDialog();
			string path = tip.path;
			if (path == null || path == "") {
				fs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			} else {
				fs.InitialDirectory = Path.GetDirectoryName(path);
			}
			if (fs.ShowDialog()) {
				pathTextBox.Text = fs.FileName;
			}
		}
		private void pathTextBox_TextChanged(object sender, EventArgs e)
		{
			tip.path = pathTextBox.Text;
		}
		private void fileBrowseButton_Click(object sender, EventArgs e)
		{
			MainForm.form.fd.DereferenceLinks = false;
			string path = tip.path;
			if (path == null || path == "") {
				MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			} else {
				MainForm.form.fd.InitialDirectory = Path.GetDirectoryName(path);
			}
			MainForm.form.fd.FileName = Path.GetFileName(path);
			DialogResult d = MainForm.form.fd.ShowDialog();
			if (d == DialogResult.OK) {
				pathTextBox.Text = MainForm.form.fd.FileName;
			}
		}
		private void shortcutCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			tip.shortcut = shortcutCheckBox.Checked;
		}

		private void IPathForm_Shown(object sender, EventArgs e) {
			if (editFileOnShow) {
				fileBrowseButton_Click(sender, e);
			} else if (editFolderOnShow) {
				folderBrowseButton_Click(sender, e);
			}
		}
		private void aliasEdit_TextChanged(object sender, EventArgs e)
		{
			tip.alias = aliasEdit.Text;
		}
	}
}
