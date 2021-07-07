using System;
using System.Windows.Forms;

namespace TrayDir
{
    static class Program
    {
        public static bool DEBUG = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm.Init();
            SettingsForm.Init();
            ProgramData.pd.initialized = true;
            Application.Run(MainForm.form);
        }
    }
}
