using System;
using System.Windows.Forms;

namespace TrayDir
{
    static class Program
    {
        public static bool DEBUG = true;
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
            Application.Run(MainForm.form);
        }
    }
}
