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
        public static PathView AddPath(TableLayoutPanel tlp, int row)
        {
            int n = row;
            PathView pv = new PathView();

            tlp.Controls.Add(pv.panel, 1, row);
            tlp.Controls.Add(pv.fileButton, 2, row);
            tlp.Controls.Add(pv.folderButton, 3, row);

            tlp.RowCount = row + 1;
            tlp.Height = 0;
            //tlp.RowStyles.Add(new RowStyle());

            ConfigurePathTableStyles(tlp, 0);
            pv.ResizeButtons(pv.fileButton.Height);
            tlp.Controls.Add(pv.buttonsPanel, 0, row);

            return pv;
        }

        private static void ConfigurePathTableStyles(TableLayoutPanel tlp, int buttonWidth)
        {
            RowStyle rs = new RowStyle();
            rs.SizeType = SizeType.AutoSize;
            tlp.RowStyles.Add(rs);
            for (int i = 0; i < 3; i++)
            {
                if (tlp.ColumnStyles.Count < (i + 1))
                {
                    tlp.ColumnStyles.Add(new ColumnStyle());
                }
                ColumnStyle style = tlp.ColumnStyles[i];
                style.SizeType = SizeType.Percent;
                switch (i)
                {
                    case 0:
                        style.SizeType = SizeType.AutoSize;
                        style.Width = 5;
                        break;
                    case 1:
                        style.SizeType = SizeType.Percent;
                        style.Width = 65;
                        break;
                    case 2:
                        style.SizeType = SizeType.Percent;
                        style.Width = 15;
                        break;
                    default:
                        style.SizeType = SizeType.Percent;
                        style.Width = 15;
                        break;
                }
            }
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
                instance.view.UpdateTrayMenu();
                MainForm.form.pd.Save();
            });
            cb.Click += cbClick;
        }
        public static void SetCheckboxCheckedEvent(CheckBox cb, SettingsApplication settings, string settingName)
        {
            EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                settings[settingName] = cb.Checked;

                MainForm.form.pd.Update();
                MainForm.form.pd.Save();
            });
            cb.Click += cbClick;
        }
        public static void SetComboBoxChangedEvent(ComboBox cb, SettingsApplication settings, string settingName)
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
