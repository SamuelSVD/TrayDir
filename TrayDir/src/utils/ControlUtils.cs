using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrayDir {
	internal class ControlUtils {
		internal static CheckBoxOptionView AddCheckbox(TableLayoutPanel panel, string settingName, StringIndexable settingGroup, string controlText, bool initialValue, string tooltipText) {
			CheckBoxOptionView ov = new CheckBoxOptionView(controlText, initialValue);
			if (panel.Controls.Count == 0) {
				ov.AddTo(panel, 0);
			} else {
				ov.AddTo(panel, panel.RowCount);
			}
			ov.SetTooltip(tooltipText);
			SetCheckboxCheckedEvent(ov.checkbox, settingGroup, settingName);
			return ov;
		}
		internal static ComboBoxView AddSimpleComboBox(TableLayoutPanel panel, string settingName, StringIndexable settingGroup, string controlText, string initalValue, string tooltipText, Dictionary<string, string> comboboxOptions) {
			ComboBoxView cbv = new ComboBoxView(controlText, comboboxOptions, settingGroup, settingName);
			if (panel.Controls.Count == 0) {
				cbv.AddTo(panel, 0);
			} else {
				cbv.AddTo(panel, panel.RowCount);
			}
			cbv.SetTooltip(tooltipText);
			cbv.combobox.Text = initalValue;
			return cbv;
		}
		internal static void AddEmptyOption(TableLayoutPanel tlp, int row) {
			tlp.RowStyles.Add(new RowStyle());
			tlp.RowStyles[row].Height = 0;
			tlp.RowCount = row + 1;
		}

		internal static void ConfigureGroupBox(GroupBox gb) {
			gb.Dock = DockStyle.Top;
			gb.AutoSize = true;
			gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}
		internal static void ConfigureTableLayoutPanel(TableLayoutPanel gb) {
			gb.Dock = DockStyle.Top;
			gb.AutoSize = true;
			gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}
		internal static void SetCheckboxCheckedEvent(CheckBox cb, TrayInstance instance, string settingName) {
			EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args) {
				instance.settings[settingName] = cb.Checked;
				instance.view.tray.BuildTrayMenu();
				MainForm.form.pd.Save();
			});
			cb.Click += cbClick;
		}
		internal static void SetCheckboxCheckedEvent(CheckBox cb, StringIndexable settings, string settingName) {
			EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args) {
				settings[settingName] = cb.Checked;

				MainForm.form.pd.Update();
				MainForm.form.pd.Save();
				if (!MainForm.form.iconLoadTimer.Enabled) {
					MainForm.form.iconLoadTimer.Start();
				}
			});
			cb.Click += cbClick;
		}
	}
}
