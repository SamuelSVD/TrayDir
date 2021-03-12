using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    class ControlUtils
    {
        public static CheckBox AddOption(TableLayoutPanel tlp, int row, string name, bool boxChecked)
        {
            string text = AppUtils.SplitCamelCase(name);
            Label label = new Label();

            label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 55);
            label.Margin = new Padding(10, 5, 3, 5);
            label.Name = name + "Label";
            label.Size = new System.Drawing.Size(670, 25);
            label.TabIndex = 2;
            label.Text = text;

            CheckBox checkbox = new CheckBox();
            checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            checkbox.AutoSize = true;
            checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkbox.Location = new System.Drawing.Point(688, 9);
            checkbox.Name = name + "CheckBox";
            checkbox.Size = new System.Drawing.Size(116, 27);
            checkbox.TabIndex = 1;
            checkbox.UseVisualStyleBackColor = true;
            checkbox.Checked = boxChecked;

            tlp.Controls.Add(label, 0, row);
            tlp.Controls.Add(checkbox, 1, row);
            tlp.RowCount = row + 1;

            return checkbox;
        }
        public static void AddPath(TableLayoutPanel tlp, int row, string text, FileDialog fd, TrayInstance instance)
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

            EventHandler fileSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                fd.DereferenceLinks = false;
                fd.InitialDirectory = textbox.Text;
                DialogResult d = fd.ShowDialog();
                if (d == DialogResult.OK)
                {
                    textbox.Text = fd.FileName;
                    instance.settings.paths[n] = textbox.Text;
                    instance.UpdateTrayMenu();
                }
            });

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

            EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                FolderSelectDialog fs = new FolderSelectDialog();
                fs.InitialDirectory = textbox.Text;
                if (fs.ShowDialog())
                {
                    textbox.Text = fs.FileName;
                    instance.settings.paths[n] = textbox.Text;
                    instance.UpdateTrayMenu();
                }
            });

            folderButton.Click += folderSelect;

            tlp.Controls.Add(panel, 0, row);
            tlp.Controls.Add(fileButton, 1, row);
            tlp.Controls.Add(folderButton, 2, row);
            tlp.RowCount = row+1;
            tlp.Height = 0;
            foreach (RowStyle style in tlp.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }
            instance.UpdateTrayMenu();
        }

        public static void ConfigureGroupBox(GroupBox gb)
        {
            gb.Dock = DockStyle.Fill;
            gb.AutoSize = true;
            gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        public static void ConfigureTableLayoutPanel(TableLayoutPanel gb)
        {
            gb.Dock = DockStyle.Fill;
            gb.AutoSize = true;
            gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

    }
}
