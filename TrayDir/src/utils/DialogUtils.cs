using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class InputDialog {
		internal static DialogResult ShowStringInputDialog(string text, ref string input) {
			Size size = new Size(500, 50);
			Form inputBox = new Form();
			inputBox.Icon = MainForm.form.Icon;

			inputBox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			inputBox.AutoSize = true;
			inputBox.AutoSizeMode = AutoSizeMode.GrowOnly;
			inputBox.Text = text;
			inputBox.Height = 10;

			TableLayoutPanel tlp = new TableLayoutPanel();
			ControlUtils.ConfigureTableLayoutPanel(tlp);
			inputBox.Controls.Add(tlp);

			TextBox textBox = new TextBox();
			textBox.Size = new Size(size.Width - 10, 23);
			textBox.Dock = DockStyle.Top;
			textBox.Text = input;
			tlp.Controls.Add(textBox, 0, 0);
			tlp.SetColumnSpan(textBox, 3);

			Button okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Text = "&OK";
			okButton.AutoSize = true;
			okButton.Dock = DockStyle.Top;
			tlp.Controls.Add(okButton, 1, 1);

			Button cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Text = "&Cancel";
			cancelButton.AutoSize = true;
			cancelButton.Dock = DockStyle.Top;
			tlp.Controls.Add(cancelButton, 2, 1);

			for (int i = 0; i < 3; i++) {
				ColumnStyle cs = new ColumnStyle();
				switch (i) {
					case 0:
						cs.SizeType = SizeType.Percent;
						cs.Width = 60;
						break;
					default:
						cs.SizeType = SizeType.AutoSize;
						cs.Width = 35;
						break;
				}
				tlp.ColumnStyles.Add(cs);
			}

			inputBox.AcceptButton = okButton;
			inputBox.CancelButton = cancelButton;

			inputBox.PerformLayout();
			inputBox.StartPosition = FormStartPosition.CenterParent;
			DialogResult result = inputBox.ShowDialog();
			input = textBox.Text;
			return result;
		}
		internal static DialogResult ShowMultilineStringInputDialog(string text, ref string input) {
			Size size = new Size(500, 50);
			Form inputBox = new Form();

			inputBox.Icon = MainForm.form.Icon;
			inputBox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			inputBox.AutoSize = true;
			inputBox.AutoSizeMode = AutoSizeMode.GrowOnly;
			inputBox.Text = text;
			inputBox.Height = 10;

			TableLayoutPanel tlp = new TableLayoutPanel();
			ControlUtils.ConfigureTableLayoutPanel(tlp);
			inputBox.Controls.Add(tlp);

			TextBox textBox = new TextBox();
			textBox.Size = new Size(size.Width - 10, 23);
			textBox.Dock = DockStyle.Fill;
			textBox.Text = input;


			textBox.Multiline = true;
			textBox.ScrollBars = ScrollBars.Vertical;
			textBox.AcceptsReturn = true;

			tlp.Controls.Add(textBox, 0, 0);
			tlp.SetColumnSpan(textBox, 3);

			Button okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Text = "&OK";
			okButton.AutoSize = true;
			okButton.Dock = DockStyle.Top;
			tlp.Controls.Add(okButton, 1, 1);

			Button cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Text = "&Cancel";
			cancelButton.AutoSize = true;
			cancelButton.Dock = DockStyle.Top;
			tlp.Controls.Add(cancelButton, 2, 1);

			tlp.ColumnStyles.Clear();
			for (int i = 0; i < 3; i++) {
				ColumnStyle cs = new ColumnStyle();
				switch (i) {
					case 0:
						cs.SizeType = SizeType.Percent;
						cs.Width = 60;
						break;
					default:
						cs.SizeType = SizeType.AutoSize;
						cs.Width = 35;
						break;
				}
				tlp.ColumnStyles.Add(cs);
			}

			tlp.RowStyles.Clear();
			for (int i = 0; i < 2; i++) {
				RowStyle rs = new RowStyle();
				switch (i) {
					case 0:
						rs.SizeType = SizeType.Percent;
						rs.Height = 75;
						break;
					default:
						rs.SizeType = SizeType.Percent;
						rs.Height = 25;
						break;
				}
				tlp.RowStyles.Add(rs);
			}

			inputBox.CancelButton = cancelButton;

			inputBox.PerformLayout();
			inputBox.StartPosition = FormStartPosition.CenterParent;
			DialogResult result = inputBox.ShowDialog();
			input = textBox.Text;
			return result;
		}
	}
}
