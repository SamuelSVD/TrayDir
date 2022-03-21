using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
	class ControlUtils
	{
		public static void AddEmptyOption(TableLayoutPanel tlp, int row)
		{
			tlp.RowStyles.Add(new RowStyle());
			tlp.RowStyles[row].Height = 0;
			tlp.RowCount = row + 1;
		}


		public static void ConfigureGroupBox(GroupBox gb)
		{
			gb.Dock = DockStyle.Top;
			gb.AutoSize = true;
			gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}
		public static void ConfigureTableLayoutPanel(TableLayoutPanel gb)
		{
			gb.Dock = DockStyle.Top;
			gb.AutoSize = true;
			gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}
		public static void SetCheckboxCheckedEvent(CheckBox cb, TrayInstance instance, string settingName)
		{
			EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
			{
				instance.settings[settingName] = cb.Checked;
				instance.view.tray.BuildTrayMenu();
				MainForm.form.pd.Save();
			});
			cb.Click += cbClick;
		}
		public static void SetCheckboxCheckedEvent(CheckBox cb, StringIndexable settings, string settingName)
		{
			EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
			{
				settings[settingName] = cb.Checked;

				MainForm.form.pd.Update();
				MainForm.form.pd.Save();
				if (!MainForm.form.iconLoadTimer.Enabled)
				{
					MainForm.form.iconLoadTimer.Start();
				}
			});
			cb.Click += cbClick;
		}
		public static void SetComboBoxChangedEvent(ComboBox cb, StringIndexable settings, string settingName)
		{
			EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
			{
				settings[settingName] = cb.SelectedItem;

				MainForm.form.pd.Update();
				MainForm.form.pd.Save();
			});
			cb.SelectedIndexChanged += cbClick;
		}
	}
}
