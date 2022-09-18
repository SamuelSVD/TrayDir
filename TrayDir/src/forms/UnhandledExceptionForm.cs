using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir.forms
{
	public partial class UnhandledExceptionForm : Form
	{
		public RichTextBox richEdit
		{
			get
			{
				return richTextBox;
			}
		}
		public UnhandledExceptionForm()
		{
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
		}

		private void reportButton_Click(object sender, EventArgs e) {
			string address = "contact@samver.ca";
			string subject = String.Format(Properties.Strings.Email_Subject_Unexpected, Program.RunningVersion);
			string body = Properties.Strings.Email_Body;
			foreach (char c in richEdit.Text.Replace("\r\n", "\r").Replace("\n", "\r")) {
				int v = Convert.ToInt32(c);
				body += String.Format($"%{v:X2}");
			}
			string mailto = String.Format("mailto:{0}?subject={1}&body={2}", address, subject, body);
			AppUtils.ProcessStart(mailto);
		}
	}
}
