using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class SettingsForm : Form
    {
        public static SettingsForm form;
        private TreeNode AppNode;
        private TreeNode WinNode;

        public SettingsForm()
        {
            InitializeComponent();
            InitializeOptions();
            SettingsTabControl.Appearance = TabAppearance.FlatButtons;
            SettingsTabControl.ItemSize = new Size(0, 1);
            SettingsTabControl.SizeMode = TabSizeMode.Fixed;
            AppNode = new TreeNode("Application");
            WinNode = new TreeNode("Windows");
            CategoryTreeView.Nodes.Add(AppNode);
            CategoryTreeView.Nodes.Add(WinNode);

            this.ClientSize = FormTableLayoutPanel.Size;
        }
        public static void Init()
        {
            if (form is null)
            {
                form = new SettingsForm();
            }
        }
        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public void InitializeOptions()
        {
            OptionView ov;

            // Application Options
            ov = new OptionView("Show Icons In Tray Menu", ProgramData.pd.settings.app.ShowIconsInMenus);
            ov.AddTo(AppGroupLayout, 0);
            ov.SetTooltip("When enabled, each menu item will show the icon associated with the file linked");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "ShowIconsInMenus");

            string[] s = new[] { "Folders Top", "Folders Bottom", "None" };
            ComboBoxView cbv = new ComboBoxView("Menu Sorting", s);
            cbv.AddTo(AppGroupLayout, 1);
            ControlUtils.SetComboBoxChangedEvent(cbv.combobox, ProgramData.pd.settings.app, "MenuSorting");
            cbv.SetTooltip("Set tray menu folder / file sorting");
            cbv.combobox.Text = ProgramData.pd.settings.app.MenuSorting;

            string[] s2 = new[] { "Yellow Folder", "Blue Folder"};
            cbv = new ComboBoxView("Virtual Folder Menu Icon", s2);
            cbv.AddTo(AppGroupLayout, 2);
            ControlUtils.SetComboBoxChangedEvent(cbv.combobox, ProgramData.pd.settings.app, "VFolderIcon");
            cbv.combobox.SelectedIndexChanged += new EventHandler(delegate (object obj, EventArgs args) {
                foreach(TrayInstance ti in ProgramData.pd.trayInstances) {
                    ti.view.tray.Rebuild();
                }
            });
            cbv.SetTooltip("When virtual folders choose between a yellow folder or blue folder icon");
            cbv.combobox.Text = ProgramData.pd.settings.app.VFolderIcon;

            // Windows Options
            ov = new OptionView("Minimize On Close", ProgramData.pd.settings.win.MinimizeOnClose);
            ov.AddTo(WinGroupLayout, 0);
            ov.SetTooltip("When enabled, closing the window will not exit the application");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "MinimizeOnClose");

            ov = new OptionView("Hide On Minimize", ProgramData.pd.settings.win.HideOnMinimize);
            ov.AddTo(WinGroupLayout, 1);
            ov.SetTooltip("When enabled, minimizing the window will hide the application");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "HideOnMinimize");

            ov = new OptionView("Start Minimized", ProgramData.pd.settings.win.StartMinimized);
            ov.AddTo(WinGroupLayout, 2);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "StartMinimized");

            ov = new OptionView("Start With Windows", ProgramData.pd.settings.win.StartWithWindows);
            ov.AddTo(WinGroupLayout, 3);
            ov.SetTooltip("When enabled, the application will always start hidden, only visible in system tray");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "StartWithWindows");

            ov = new OptionView("Check For Updates on Startup", ProgramData.pd.settings.win.CheckForUpdates);
            ov.AddTo(WinGroupLayout, 4);
            ov.SetTooltip("When enabled, TrayDir will check for update on startup");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "CheckForUpdates");
        }

        private void CategoryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (CategoryTreeView.SelectedNode == AppNode)
            {
                this.SettingsTabControl.SelectedTab = this.AppSettingsTabPage;
            }
            else if (CategoryTreeView.SelectedNode == WinNode)
            {
                this.SettingsTabControl.SelectedTab = this.WinSettingsTabPage;
            }
        }
    }
}
