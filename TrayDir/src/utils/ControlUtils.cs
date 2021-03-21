using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    class ControlUtils
    {
        public static OptionView AddOption(TableLayoutPanel tlp, int row, string name, bool boxChecked)
        {
            OptionView ov = new OptionView();
            string text = AppUtils.SplitCamelCase(name);
            ov.label = new Label();

            ov.label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            ov.label.AutoSize = true;
            ov.label.Location = new Point(10, 55);
            ov.label.Margin = new Padding(10, 5, 3, 5);
            ov.label.Name = name + "Label";
            ov.label.Size = new Size(670, 25);
            ov.label.TabIndex = 2;
            ov.label.Text = text;

            if (Program.DEBUG) ov.label.BackColor = Color.Orange;

            ov.checkbox = new CheckBox();
            ov.checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            ov.checkbox.AutoSize = true;
            ov.checkbox.CheckAlign = ContentAlignment.MiddleCenter;
            ov.checkbox.Location = new Point(688, 9);
            ov.checkbox.Name = name + "CheckBox";
            ov.checkbox.Size = new Size(116, 27);
            ov.checkbox.TabIndex = 1;
            ov.checkbox.UseVisualStyleBackColor = true;
            ov.checkbox.Checked = boxChecked;

            if (Program.DEBUG) ov.checkbox.BackColor = Color.Red;

            tlp.Controls.Add(ov.label, 0, row);
            tlp.Controls.Add(ov.checkbox, 1, row);
            tlp.RowCount = row + 1;
            tlp.RowStyles.Add(new RowStyle());

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
                        style.Width = 90;
                        break;
                    case 1:
                        style.Width = 10;
                        break;
                    default:
                        style.Width = 50;
                        break;
                }
            }
            return ov;
        }
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

    }
}
