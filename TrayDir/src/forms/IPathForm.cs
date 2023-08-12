using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class IPathForm : Form
	{
		public TrayInstancePath model;
		private bool editFileOnShow = false;
		private bool editFolderOnShow = false;
		public IPathForm(TrayInstancePath tip)
		{
			InitializeComponent();
			pathTextBox.TextChanged += pathTextBox_TextChanged;
			pathTextBox.TooltipText = Properties.Strings.Tooltip_InvalidPath;
			this.Icon = Properties.Resources.file_exe;
			this.model = tip;
			pathTextBox.Text = model.path;
			aliasEdit.Text = model.alias;
			shortcutCheckBox.Checked = model.shortcut;
			hideItemCheckBox.Checked = !model.visible;
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
			string path = model.path;
			if (path == null || path == string.Empty) {
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
			model.path = pathTextBox.Text;
			pathTextBox.Valid = model.isFile || model.isDir;
		}
		private void fileBrowseButton_Click(object sender, EventArgs e)
		{
			MainForm.form.fd.DereferenceLinks = false;
			string path = model.path;
			if (path == null || path == string.Empty) {
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
			model.shortcut = shortcutCheckBox.Checked;
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
			model.alias = aliasEdit.Text;
		}

		private void hideItemCheckBox_CheckedChanged(object sender, EventArgs e) {
			model.visible = !hideItemCheckBox.Checked;
		}

		private void IPathForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/files.htm");
		}

        private void OkButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
        }
    }
}
