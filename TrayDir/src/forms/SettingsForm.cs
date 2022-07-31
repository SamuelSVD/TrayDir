using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class SettingsForm : Form
	{
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
		private void CloseButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		public void InitializeOptions()
		{
			OptionView ov;

			// Application Options
			ov = new OptionView(Properties.Strings_en.Form_ShowIconsInTrayMenu, ProgramData.pd.settings.app.ShowIconsInMenus);
			ov.AddTo(AppGroupLayout, 0);
			ov.SetTooltip(Properties.Strings_en.Tooltip_ShowIconsInTrayMenu);
			ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.app, "ShowIconsInMenus");

			string[] s = new[] { "Folders Top", "Folders Bottom", "None" };
			ComboBoxView cbv = new ComboBoxView(Properties.Strings_en.Form_MenuSorting, s);
			cbv.AddTo(AppGroupLayout, 1);
			ControlUtils.SetComboBoxChangedEvent(cbv.combobox, ProgramData.pd.settings.app, "MenuSorting");
			cbv.SetTooltip(Properties.Strings_en.Tooltip_MenuSorting);
			cbv.combobox.Text = ProgramData.pd.settings.app.MenuSorting;

			string[] s2 = new[] { "Yellow Folder", "Blue Folder"};
			cbv = new ComboBoxView(Properties.Strings_en.Form_VirtualFolderMenuIcon, s2);
			cbv.combobox.Text = ProgramData.pd.settings.app.VFolderIcon;
			cbv.AddTo(AppGroupLayout, 2);
			ControlUtils.SetComboBoxChangedEvent(cbv.combobox, ProgramData.pd.settings.app, "VFolderIcon");
			cbv.combobox.SelectedIndexChanged += new EventHandler(delegate (object obj, EventArgs args) {
				foreach(TrayInstance ti in ProgramData.pd.trayInstances) {
					ti.view?.Rebuild();
				}
			});
			cbv.SetTooltip(Properties.Strings_en.Tooltip_VirtualFolderMenuIcon);

			// Windows Options
			ov = new OptionView(Properties.Strings_en.Form_MinimizeOnClose, ProgramData.pd.settings.win.MinimizeOnClose);
			ov.AddTo(WinGroupLayout, 0);
			ov.SetTooltip(Properties.Strings_en.Tooltip_MinimizeOnClose);
			ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "MinimizeOnClose");

			ov = new OptionView(Properties.Strings_en.Form_HideOnMinimize, ProgramData.pd.settings.win.HideOnMinimize);
			ov.AddTo(WinGroupLayout, 1);
			ov.SetTooltip(Properties.Strings_en.Tooltip_HideOnMinimize);
			ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "HideOnMinimize");

			ov = new OptionView(Properties.Strings_en.Form_StartMinimized, ProgramData.pd.settings.win.StartMinimized);
			ov.AddTo(WinGroupLayout, 2);
			ov.SetTooltip(Properties.Strings_en.Tooltip_StartMinimized);
			ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "StartMinimized");

			ov = new OptionView(Properties.Strings_en.Form_StartWithWindows, ProgramData.pd.settings.win.StartWithWindows);
			ov.AddTo(WinGroupLayout, 3);
			ov.SetTooltip(Properties.Strings_en.Tooltip_StartWithWindows);
			ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, ProgramData.pd.settings.win, "StartWithWindows");

			ov = new OptionView(Properties.Strings_en.Form_CheckForUpdatesOnStartup, ProgramData.pd.settings.win.CheckForUpdates);
			ov.AddTo(WinGroupLayout, 4);
			ov.SetTooltip(Properties.Strings_en.Tooltip_CheckForUpdatesOnStartup);
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

		private void SettingsForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/programsettings.htm");
		}
	}
}
