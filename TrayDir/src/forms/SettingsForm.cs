﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace TrayDir {
	public partial class SettingsForm : Form {
		private TreeNode AppNode;
		private TreeNode WinNode;

		public SettingsForm() {
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			InitializeOptions();
			SettingsTabControl.Appearance = TabAppearance.FlatButtons;
			SettingsTabControl.ItemSize = new Size(0, 1);
			SettingsTabControl.SizeMode = TabSizeMode.Fixed;
			AppNode = new TreeNode("Application");
			WinNode = new TreeNode("Windows");
			CategoryTreeView.Nodes.Add(AppNode);
			CategoryTreeView.Nodes.Add(WinNode);

			Size a = AppGroupBox.Size;
			Size b = WinGroupBox.Size;
			Size c = SettingsTabControl.Size;
			int w = a.Width + AppGroupBox.Margin.Left * 2 + 20;
			w = w < (b.Width + AppGroupBox.Margin.Left * 2 + 20) ? (b.Width + AppGroupBox.Margin.Left * 2 + 20) : w;
			w = w < c.Width ? c.Width : w;
			int h = a.Height + AppGroupBox.Margin.Top * 2;
			h = h < (b.Height + AppGroupBox.Margin.Top * 2 + 20) ? (b.Height + AppGroupBox.Margin.Top * 2 + 20) : h;
			h = h < c.Height ? c.Height : h;
			SettingsTabControl.Size = new Size(w, h);

			this.ClientSize = FormTableLayoutPanel.Size;
		}
		private void CloseButtonClick(object sender, EventArgs e) {
			Close();
		}
		public void InitializeOptions() {
			InitializeAppSettings();
			InitializeWinSettings();
		}
		private void InitializeAppSettings() {
			// Application Options
			ControlUtils.AddCheckbox(
				AppGroupLayout,
				"ShowIconsInMenus",
				ProgramData.pd.settings.app,
				Properties.Strings.Form_ShowIconsInTrayMenu,
				ProgramData.pd.settings.app.ShowIconsInMenus,
				Properties.Strings.Tooltip_ShowIconsInTrayMenu
			);

			ControlUtils.AddCheckbox(
				AppGroupLayout,
				"CreateFoldersAsShortcuts",
				ProgramData.pd.settings.app,
				Properties.Strings.Form_CreateFoldersAsShortcuts,
				ProgramData.pd.settings.app.CreateFoldersAsShortcuts,
				Properties.Strings.Tooltip_CreateFoldersAsShortcuts
			);

			ControlUtils.AddCheckbox(
				AppGroupLayout,
				"ShowMenuOnLeftClick",
				ProgramData.pd.settings.app,
				Properties.Strings.Form_ShowMenuOnLeftClick,
				ProgramData.pd.settings.app.ShowMenuOnLeftClick,
				Properties.Strings.Tooltip_ShowMenuOnLeftClick
			);

			string[] s = new[] { "Folders Top", "Folders Bottom", "None" };

			ControlUtils.AddSimpleComboBox(
				AppGroupLayout,
				"MenuSorting",
				ProgramData.pd.settings.app,
				Properties.Strings.Form_MenuSorting,
				ProgramData.pd.settings.app.MenuSorting,
				Properties.Strings.Tooltip_MenuSorting,
				s
			);

			string[] s2 = new[] { "Yellow Folder", "Blue Folder" };
			ControlUtils.AddSimpleComboBox(
				AppGroupLayout,
				"VFolderIcon",
				ProgramData.pd.settings.app,
				Properties.Strings.Form_VirtualFolderMenuIcon,
				ProgramData.pd.settings.app.VFolderIcon,
				Properties.Strings.Tooltip_VirtualFolderMenuIcon,
				s2
			).combobox.SelectedIndexChanged += new EventHandler(delegate (object obj, EventArgs args) {
				foreach (TrayInstance ti in ProgramData.pd.trayInstances) {
					ti.view?.Rebuild();
				}
			});

			//This manual sizing was required due to AutoSize not working correctly when a combo box item was added to the table view
			AppGroupBox.AutoSize = false;
			foreach (int rh in AppGroupLayout.GetRowHeights()) {
				AppGroupBox.Height += rh;
			}
			AppGroupBox.Height += AppGroupLayout.Margin.Top * 2;

		}
		private void InitializeWinSettings() {
			// Windows Options
			ControlUtils.AddCheckbox(
				WinGroupLayout,
				"MinimizeOnClose",
				ProgramData.pd.settings.win,
				Properties.Strings.Form_MinimizeOnClose,
				ProgramData.pd.settings.win.MinimizeOnClose,
				Properties.Strings.Tooltip_MinimizeOnClose
			);

			ControlUtils.AddCheckbox(
				WinGroupLayout,
				"HideOnMinimize",
				ProgramData.pd.settings.win,
				Properties.Strings.Form_HideOnMinimize,
				ProgramData.pd.settings.win.HideOnMinimize,
				Properties.Strings.Tooltip_HideOnMinimize
			);

			ControlUtils.AddCheckbox(
				WinGroupLayout,
				"StartMinimized",
				ProgramData.pd.settings.win,
				Properties.Strings.Form_StartMinimized,
				ProgramData.pd.settings.win.StartMinimized,
				Properties.Strings.Tooltip_StartMinimized
			);

			ControlUtils.AddCheckbox(
				WinGroupLayout,
				"StartWithWindows",
				ProgramData.pd.settings.win,
				Properties.Strings.Form_StartWithWindows,
				ProgramData.pd.settings.win.StartWithWindows,
				Properties.Strings.Tooltip_StartWithWindows
			);

			ControlUtils.AddCheckbox(
				WinGroupLayout,
				"CheckForUpdates",
				ProgramData.pd.settings.win,
				Properties.Strings.Form_CheckForUpdatesOnStartup,
				ProgramData.pd.settings.win.CheckForUpdates,
				Properties.Strings.Tooltip_CheckForUpdatesOnStartup
			);
		}

		private void CategoryTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
			if (CategoryTreeView.SelectedNode == AppNode) {
				this.SettingsTabControl.SelectedTab = this.AppSettingsTabPage;
			} else if (CategoryTreeView.SelectedNode == WinNode) {
				this.SettingsTabControl.SelectedTab = this.WinSettingsTabPage;
			}
		}

		private void SettingsForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/programsettings.htm");
		}
	}
}
