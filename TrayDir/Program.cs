using System;
using System.Windows.Forms;

namespace TrayDir
{
    static class Program
    {
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
            MainForm.form.InitializeAllAssets();
            Application.Run(MainForm.form);
        }
    }
}
