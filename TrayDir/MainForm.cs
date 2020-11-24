using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class MainForm : Form
    {
        private int DirCount;
        private int OptionCount;
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used

        public MainForm()
        {
            DirCount = 0;
            OptionCount = 0;
            InitializeComponent();
            InitializeOptions();
            InitializeTrayMenu();
            InitializePaths();
            if (Settings.getOptionBool("StartMinimized"))
            {
                this.allowVisible = false;
                HideApp(this, null);
            } else
            {
                this.allowVisible = true;
            }
            PerformLayout();
            MaximizeBox = false;
        }
        public void InitializeOptions()
        {
            foreach (Option option in Settings.getOptions())
            {
                AddOption(option.name);
            }
        }
        public void InitializePaths()
        {
            if (Settings.paths.Count == 0)
            {
                Settings.paths.Add(".");
                AddPath(".");
            } else
            {
                foreach (string path in Settings.paths)
                {
                    AddPath(path);
                }
            }
            if (Settings.paths.Count == 1)
            {
                RemoveButton.Enabled = false;
            }
        }
        public void InitializeTrayMenu()
        {
            if (TrayItem.ContextMenuStrip is null)
            {
                this.TrayItem.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            }
            else
            {
                this.TrayItem.ContextMenuStrip.Items.Clear();
            }
            this.TrayItem.ContextMenuStrip.Items.Add("Show", null, this.ShowApp);
            this.TrayItem.ContextMenuStrip.Items.Add("Hide", null, this.HideApp);

            this.TrayItem.ContextMenuStrip.Items.Add("-");

            if (Settings.paths.Count == 1)
            {
                String path = Settings.paths[0];
                ToolStripMenuItem mi = AppUtils.RecursivePathFollow(path);
                if (mi.DropDownItems.Count > 0)
                {
                    while (mi.DropDownItems.Count > 0)
                    {
                        ToolStripItem item = mi.DropDownItems[0];
                        mi.DropDownItems.RemoveAt(0);
                        this.TrayItem.ContextMenuStrip.Items.Add(item);
                    }
                }
                else
                {
                    this.TrayItem.ContextMenuStrip.Items.Add(mi);
                }
            }
            else
            {
                foreach (string path in Settings.paths)
                {
                    this.TrayItem.ContextMenuStrip.Items.Add(AppUtils.RecursivePathFollow(path));
                }
            }
            this.TrayItem.ContextMenuStrip.Items.Add("-");

            this.TrayItem.ContextMenuStrip.Items.Add("Exit", null, ExitApp);
            this.TrayItem.ContextMenuStrip.Items[0].Visible = false;
            BuildExploreDropdown();
            InitializeTrayIcon();
        }
        private void InitializeTrayIcon()
        {
            string iconPath = Settings.iconPath;
            if (AppUtils.PathIsFile(iconPath))
            {
                try
                {
                    TrayItem.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading icon: " + e.Message);
                }
            }
        }
        private void HideApp(object Sender, EventArgs e)
        {
            this.Hide();
            this.TrayItem.ContextMenuStrip.Items[0].Visible = true;
            this.TrayItem.ContextMenuStrip.Items[1].Visible = false;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.HideApp(sender, e);
                this.TrayItem.ContextMenuStrip.Items[0].Visible = true;
                this.TrayItem.ContextMenuStrip.Items[1].Visible = false;
            }
        }
        private void AddPath(string text)
        {
            int n = DirCount;
            // 
            // textBox1
            // 
            TextBox textbox = new TextBox();
            textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            textbox.Location = new System.Drawing.Point(10, 5);
            textbox.Margin = new System.Windows.Forms.Padding(0);
            textbox.Name = "textbox" + n.ToString();
            textbox.Size = new System.Drawing.Size(651, 24);

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
            textbox.TabIndex = 0;
            textbox.ReadOnly = true;
            // panel
            Panel panel = new Panel();
            panel.AutoSize = true;
            panel.Cursor = textbox.Cursor;
            panel.BackColor = textbox.BackColor;
            panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel.Controls.Add(textbox);
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(5, 5);
            panel.Margin = new System.Windows.Forms.Padding(5);
            panel.Name = "panel" + n.ToString();
            panel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            panel.Size = new System.Drawing.Size(675, 45);
            panel.TabIndex = 5;
            
            EventHandler textbox_select = new EventHandler(delegate (object obj, EventArgs args)
            {
                textbox.Select();
            });

            panel.Click += textbox_select;

            // 
            // fileButton
            // 
            Button fileButton = new Button();
            fileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            fileButton.AutoSize = true;
            fileButton.Location = new System.Drawing.Point(690, 5);
            fileButton.Margin = new System.Windows.Forms.Padding(5);
            fileButton.Name = "filebutton" + n.ToString();
            fileButton.Padding = new System.Windows.Forms.Padding(5);
            fileButton.Size = new System.Drawing.Size(112, 45);
            fileButton.TabIndex = 1;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;

            EventHandler fileSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                FileDialog.DereferenceLinks = false;
                FileDialog.InitialDirectory = textbox.Text;
                DialogResult d = FileDialog.ShowDialog();
                if (d == DialogResult.OK)
                {
                    textbox.Text = FileDialog.FileName;
                    Settings.paths[n] = textbox.Text;
                    InitializeTrayMenu();
                }
            });

            fileButton.Click += fileSelect;

            // 
            // folderButton
            // 
            Button folderButton = new Button();
            folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            folderButton.AutoSize = true;
            folderButton.Location = new System.Drawing.Point(690, 5);
            folderButton.Margin = new System.Windows.Forms.Padding(5);
            folderButton.Name = "folderButton" + n.ToString();
            folderButton.Padding = new System.Windows.Forms.Padding(5);
            folderButton.Size = new System.Drawing.Size(112, 45);
            folderButton.TabIndex = 1;
            folderButton.Text = "Folder";
            folderButton.UseVisualStyleBackColor = true;

            EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                FolderSelectDialog fs = new FolderSelectDialog();
                fs.InitialDirectory = textbox.Text;
                if (fs.ShowDialog())
                {
                    textbox.Text = fs.FileName;
                    Settings.paths[n] = textbox.Text;
                    InitializeTrayMenu();
                }
            });

            folderButton.Click += folderSelect;

            this.DirectoriesGroupLayout.Controls.Add(panel, 0, DirCount);
            this.DirectoriesGroupLayout.Controls.Add(fileButton, 1, DirCount);
            this.DirectoriesGroupLayout.Controls.Add(folderButton, 2, DirCount);
            DirCount += 1;
            this.DirectoriesGroupLayout.RowCount = DirCount;
            Height = 0;
            InitializeTrayMenu();
            RemoveButton.Enabled = DirCount > 1;
        }
        private void AddOption(string name)
        {
            string text = AppUtils.SplitCamelCase(name);
            Label label = new Label();

            label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 55);
            label.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            label.Name = name+"Label";
            label.Size = new System.Drawing.Size(670, 25);
            label.TabIndex = 2;
            label.Text = text;

            CheckBox checkbox = new CheckBox(); 
            checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            checkbox.AutoSize = true;
            checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkbox.Location = new System.Drawing.Point(688, 9);
            checkbox.Name = name+"CheckBox";
            checkbox.Size = new System.Drawing.Size(116, 27);
            checkbox.TabIndex = 1;
            checkbox.UseVisualStyleBackColor = true;
            checkbox.Checked = Settings.getOptionBool(name);

            EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                Settings.setOptionBool(name,checkbox.Checked);
                InitializeTrayMenu();
            });

            checkbox.Click += folderSelect;

            int n = this.OptionsGroupLayout.RowCount;
            this.OptionsGroupLayout.Controls.Add(label, 0, OptionCount);
            this.OptionsGroupLayout.Controls.Add(checkbox, 1, OptionCount);
            OptionCount += 1;
            this.OptionsGroupLayout.RowCount = OptionCount;
            this.OptionsGroupBox.Height += label.Height + label.Padding.Top + label.Padding.Bottom;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.paths.Add(".");
            AddPath(".");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RemovePath();
        }
        public void RemovePath()
        {
            removerow(DirectoriesGroupLayout, DirCount-1);
            DirCount--;
            RemoveButton.Enabled = DirCount > 1;
        }
        public void removerow(TableLayoutPanel panel, int Rowindex)
        {
            var control = panel.GetControlFromPosition(2, Rowindex);
            panel.Controls.Remove(control);
            control = panel.GetControlFromPosition(1, Rowindex);
            panel.Controls.Remove(control);
            control = panel.GetControlFromPosition(0, Rowindex);
            panel.Controls.Remove(control);
            panel.RowCount = Rowindex;
            panel.Height -= 100;
            Height -= 100;
            Settings.paths.RemoveAt(Settings.paths.Count - 1);
            InitializeTrayMenu();
        }
        private void BuildExploreDropdown()
        {
            exploreToolStripMenuItem.DropDownItems.Clear();
            foreach (string path in Settings.paths)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Size = new System.Drawing.Size(359, 44);

                if (AppUtils.PathIsDirectory(path))
                {
                    item.Text = new DirectoryInfo(path).FullName;
                }
                else if (AppUtils.PathIsFile(path))
                {
                    item.Text = Path.GetFullPath(path);
                }

                EventHandler sel = new EventHandler(delegate (object obj, EventArgs args)
                {
                    if (AppUtils.PathIsDirectory(path))
                    {
                        AppUtils.ExplorePath(new DirectoryInfo(path).FullName);
                    }
                    else if (AppUtils.PathIsFile(path))
                    {
                        AppUtils.ExplorePath(Path.GetFullPath(path));
                    }
                });

                item.Click += sel;

                exploreToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void Save(object Sender, EventArgs e)
        {
            Settings.Save();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            About aa = new About();
            aa.Show();
        }
        private void Rebuild(object sender, EventArgs e)
        {
            InitializeTrayMenu();
        }
        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose && Settings.getOptionBool("MinimizeOnClose"))
            {
                this.HideApp(this, null);
                e.Cancel = true;
            } 
            else
            {
                if (!Settings.ConfirmClose())
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }

        private void ShowApp(object sender, EventArgs e)
        {
            allowVisible = true;
            Show();
            this.TrayItem.ContextMenuStrip.Items[0].Visible = false;
            this.TrayItem.ContextMenuStrip.Items[1].Visible = true;
            this.Focus();
        }
        private void ExitApp(object sender, EventArgs e)
        {
            allowClose = true;
            Application.Exit();
        }
    }
}
