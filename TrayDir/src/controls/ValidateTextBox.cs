using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir {
	public partial class ValidateTextBox : UserControl {
		private ToolTip _toolTip = new ToolTip();
		private string _ToolTipText;
		public string TooltipText {
			get { return _ToolTipText; }
			set { _ToolTipText = value; }
		}
		public bool Valid {
			get { return !PictureBox.Visible; }
			set { PictureBox.Visible = !value; }
		}
		public ValidateTextBox() {
			InitializeComponent();
			TextChanged += onTextChanged;
		}
		private void PictureBox_MouseEnter(object sender, EventArgs e) {
			if (_ToolTipText != string.Empty) {
				_toolTip.Show(_ToolTipText, TextBox, TextBox.PointToClient(MousePosition).X + 2, TextBox.PointToClient(MousePosition).Y + 2);
			}
		}
		private void PictureBox_MouseLeave(object sender, EventArgs e) {
			_toolTip.Hide(TextBox);
		}
		private void onTextChanged(object sender, EventArgs e) {
			TextBox.Text = Text;
		}
		private void TextBox_TextChanged(object sender, EventArgs e) {
			Text = TextBox.Text;
		}
	}
}