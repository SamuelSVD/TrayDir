using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using TrayDir.forms;
using TrayDir.utils;

namespace TrayDir
{
	static class Program
	{
		public static bool DEBUG = false;
		public static bool IGNORESTARTUP = false;
		public static bool IGNORECLOSE = false;
		public static string RunningVersion {  get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length > 0) {
				IGNORESTARTUP = args[0] == "--ignorestartup";
				IGNORECLOSE = args[1] == "--ignoreclose";
			}
			bool running = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;
			if (IGNORESTARTUP || !running || MessageBox.Show(Properties.Strings.ProcessRunning,"TrayDir",MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					IMenuItemIconUtils.Init();
					MainForm.Init();
					ProgramData.pd.initialized = true;
					Application.Run(MainForm.form);
				}
				catch (Exception e)
				{
					UnhandledExceptionForm f = new UnhandledExceptionForm();
					f.richEdit.Text = "Unhandled exception."+ Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace;
					f.ShowDialog();
				}
			}
		}
	}
}
