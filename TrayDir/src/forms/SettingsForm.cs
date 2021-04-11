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

        public void InitializeOptions()
        {
            OptionView ov;
            ov = ControlUtils.AddOption(OptionsGroupLayout, 0, "Minimize On Close", MainForm.form.pd.settings.app.MinimizeOnClose);
            ov.SetTooltip("When enabled, closing the window will not exit the application");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "MinimizeOnClose");

            ov = ControlUtils.AddOption(OptionsGroupLayout, 1, "Start Minimized", MainForm.form.pd.settings.app.StartMinimized);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "StartMinimized");

            ov = ControlUtils.AddOption(OptionsGroupLayout, 2, "Start With Windows", MainForm.form.pd.settings.app.StartWithWindows);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "StartWithWindows");

            ov = ControlUtils.AddOption(OptionsGroupLayout, 3, "Show Icons In Tray Menu", MainForm.form.pd.settings.app.ShowIconsInMenus);
            ov.SetTooltip("When enabled, each menu item will show the icon associated with the file linked");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, MainForm.form.pd.settings.app, "ShowIconsInMenus");
        }

    }
}
