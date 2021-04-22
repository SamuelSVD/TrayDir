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
            ov = new OptionView("Minimize On Close", ProgramData.pd.settings.app.MinimizeOnClose);
            ov.AddTo(OptionsGroupLayout, 0);
            ov.SetTooltip("When enabled, closing the window will not exit the application");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "MinimizeOnClose");

            ov = new OptionView("Start Minimized", ProgramData.pd.settings.app.StartMinimized);
            ov.AddTo(OptionsGroupLayout, 1);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "StartMinimized");

            ov = new OptionView("Start With Windows", ProgramData.pd.settings.app.StartWithWindows);
            ov.AddTo(OptionsGroupLayout, 2);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "StartWithWindows");

            ov = new OptionView("Show Icons In Tray Menu", ProgramData.pd.settings.app.ShowIconsInMenus);
            ov.AddTo(OptionsGroupLayout, 3);
            ov.SetTooltip("When enabled, each menu item will show the icon associated with the file linked");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "ShowIconsInMenus");

            ov = new OptionView("Check For Updates on Startup", ProgramData.pd.settings.app.CheckForUpdates);
            ov.AddTo(OptionsGroupLayout, 4);
            ov.SetTooltip("When enabled, TrayDir will check for update on startup");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "CheckForUpdates");

            string[] s = new[] { "Folders Top", "Folders Bottom", "None" };
            ComboBoxView cbv = new ComboBoxView("Menu Sorting", s);
            cbv.AddTo(OptionsGroupLayout, 5);
            ControlUtils.SetComboBoxChangedEvent(cbv.combobox, ProgramData.pd.settings.app, "MenuSorting");
            cbv.SetTooltip("Set tray menu folder / file sorting");
            cbv.combobox.Text = ProgramData.pd.settings.app.MenuSorting;
        }
    }
}
