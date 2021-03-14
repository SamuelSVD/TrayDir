using System;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class SettingsForm : Form
    {
        public static SettingsForm form;
        public static void Init()
        {
            if (form is null)
            {
                form = new SettingsForm();
                form.InitializeComponent();
                form.InitializeOptions();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.form.pd.Save();
        }

        public void InitializeOptions()
        {
            OptionView ov;
            ov = ControlUtils.AddOption(OptionsGroupLayout, 0, "Minimize On Close", MainForm.form.pd.settings.app.MinimizeOnClose);
            ov.SetTooltip("When enabled, closing the window will not exit the application");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "MinimizeOnClose");

            ov = ControlUtils.AddOption(OptionsGroupLayout, 1, "Start Minimized", MainForm.form.pd.settings.app.StartMinimized);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "StartMinimized");
        }

    }
}
