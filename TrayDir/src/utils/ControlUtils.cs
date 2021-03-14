using System;
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
            ov.label.Location = new System.Drawing.Point(10, 55);
            ov.label.Margin = new Padding(10, 5, 3, 5);
            ov.label.Name = name + "Label";
            ov.label.Size = new System.Drawing.Size(670, 25);
            ov.label.TabIndex = 2;
            ov.label.Text = text;

            if(Program.DEBUG) ov.label.BackColor = System.Drawing.Color.Orange;

            ov.checkbox = new CheckBox();
            ov.checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            ov.checkbox.AutoSize = true;
            ov.checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ov.checkbox.Location = new System.Drawing.Point(688, 9);
            ov.checkbox.Name = name + "CheckBox";
            ov.checkbox.Size = new System.Drawing.Size(116, 27);
            ov.checkbox.TabIndex = 1;
            ov.checkbox.UseVisualStyleBackColor = true;
            ov.checkbox.Checked = boxChecked;

            if (Program.DEBUG) ov.checkbox.BackColor = System.Drawing.Color.Red;

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
        public static TextBox AddPath(TableLayoutPanel tlp, int row, string text, TrayInstance instance, EventHandler fileSelect, EventHandler folderSelect)
        {
            int n = row;
            // 
            // textBox1
            // 
            TextBox textbox = new TextBox();
            textbox.BorderStyle = BorderStyle.None;
            textbox.Name = "textbox" + n.ToString();
            textbox.Dock = DockStyle.Fill;
            textbox.Margin = new Padding(10);
            textbox.AutoSize = true;
            textbox.ReadOnly = true;

            if (AppUtils.PathIsDirectory(text))
            {
                textbox.Text = new DirectoryInfo(text).FullName;
            }
            else if (AppUtils.PathIsFile(text))
            {
                textbox.Text = Path.GetFullPath(text);
            }
            else
            {
                textbox.Text = text;
            }
            // panel
            Panel panel = new Panel();
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Cursor = textbox.Cursor;
            panel.BackColor = textbox.BackColor;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(2, 3, 2, 3);
            panel.Name = "panel" + n.ToString();
            panel.Padding = new Padding(0);

            EventHandler textbox_select = new EventHandler(delegate (object obj, EventArgs args)
            {
                textbox.Select();
            });
            panel.Click += textbox_select;

            panel.Controls.Add(textbox);

            // 
            // fileButton
            // 
            Button fileButton = new Button();
            fileButton.AutoSize = true;
            fileButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fileButton.Name = "filebutton" + n.ToString();
            fileButton.TabIndex = 1;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Dock = DockStyle.Fill;

            fileButton.Click += fileSelect;

            //
            // folderButton
            //
            Button folderButton = new Button();
            folderButton.AutoSize = true;
            folderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            folderButton.Text = "Folder";
            folderButton.UseVisualStyleBackColor = true;
            folderButton.Dock = DockStyle.Fill;

            folderButton.Click += folderSelect;

            tlp.Controls.Add(panel, 0, row);
            tlp.Controls.Add(fileButton, 1, row);
            tlp.Controls.Add(folderButton, 2, row);
            tlp.RowCount = row + 1;
            tlp.Height = 0;
            tlp.RowStyles.Add(new RowStyle());

            foreach (RowStyle style in tlp.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }
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
                        style.Width = 70;
                        break;
                    case 1:
                        style.Width = 15;
                        break;
                    case 2:
                        style.Width = 15;
                        break;
                    default:
                        style.Width = 33;
                        break;
                }
            }
            return textbox;
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
                MainForm.form.pd.UpdateAllMenus();
                MainForm.form.pd.Save();
            });
            cb.Click += cbClick;
        }

    }
}
