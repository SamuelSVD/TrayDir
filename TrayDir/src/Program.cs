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
		public static string RunningVersion {  get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }
		[STAThread]
		static void Main()
		{
			bool running = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;
			if (!running || MessageBox.Show(Properties.Strings_en.ProcessRunning,"TrayDir",MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					IMenuItemIconUtils.Init();
					MainForm.Init();
					SettingsForm.Init();
					ProgramData.pd.initialized = true;
					Application.Run(MainForm.form);
				}
				catch (Exception e)
				{
					UnhandledExceptionForm f = new UnhandledExceptionForm();
					f.richEdit.Text = "Unhandled exception.\n" + e.Message + "\n" + e.StackTrace;
					f.ShowDialog();
				}
			}
		}
	}
}
