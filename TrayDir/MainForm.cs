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
        private SettingsForm settingsForm;
        public MainForm()
        {
            DirCount = 0;
            OptionCount = 0;
            settingsForm = new SettingsForm();
            InitializeComponent();
            InitializeOptions();
            InitializeTrayMenu();
            InitializePaths();
            if (Settings.getOptionBool("StartMinimized"))
            {
                allowVisible = false;
                HideApp(this, null);
            } else
            {
                allowVisible = true;
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
                TrayItem.ContextMenuStrip = new ContextMenuStrip();
            }
            else
            {
                TrayItem.ContextMenuStrip.Items.Clear();
            }
            TrayItem.ContextMenuStrip.Items.Add("Show", null, ShowApp);
            TrayItem.ContextMenuStrip.Items.Add("Hide", null, HideApp);

            TrayItem.ContextMenuStrip.Items.Add("-");

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
                        TrayItem.ContextMenuStrip.Items.Add(item);
                    }
                }
                else
                {
                    TrayItem.ContextMenuStrip.Items.Add(mi);
                }
            }
            else
            {
                foreach (string path in Settings.paths)
                {
                    TrayItem.ContextMenuStrip.Items.Add(AppUtils.RecursivePathFollow(path));
                }
            }
            TrayItem.ContextMenuStrip.Items.Add("-");

            TrayItem.ContextMenuStrip.Items.Add("Exit", null, ExitApp);
            TrayItem.ContextMenuStrip.Items[0].Visible = false;
            BuildExploreDropdown();
            InitializeTrayIcon();
            CheckIsAltered();
        }
        private void CheckIsAltered()
        {
            if (Settings.isAltered())
            {
                this.Text = "TrayDir*";
            } else
            {
                this.Text = "TrayDir";
            }
        }
        private void InitializeTrayIcon()
        {
            string iconPath = Settings.iconPath;
            if (AppUtils.PathIsFile(iconPath))
            {
                try
                {
                    TrayIconPathTextBox.Text = iconPath;
                    TrayItem.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                    IconDisplay.Image = TrayItem.Icon.ToBitmap();
                    this.Icon = TrayItem.Icon;
                    settingsForm.Icon = TrayItem.Icon;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading icon: " + e.Message);
                }
            }
            TrayTextTextBox.Text = Settings.iconText;
            TrayItem.Text = Settings.iconText;
        }
        private void HideApp(object Sender, EventArgs e)
        {
            Hide();
            TrayItem.ContextMenuStrip.Items[0].Visible = true;
            TrayItem.ContextMenuStrip.Items[1].Visible = false;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideApp(sender, e);
                TrayItem.ContextMenuStrip.Items[0].Visible = true;
                TrayItem.ContextMenuStrip.Items[1].Visible = false;
            }
        }
        private void AddPath(string text)
        {
            int n = DirCount;
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
            panel.Margin = new Padding(2,3,2,3);
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
                    Settings.paths[n] = textbox.Text;
                    InitializeTrayMenu();
                }
            });

            folderButton.Click += folderSelect;

            DirectoriesGroupLayout.Controls.Add(panel, 0, DirCount);
            DirectoriesGroupLayout.Controls.Add(fileButton, 1, DirCount);
            DirectoriesGroupLayout.Controls.Add(folderButton, 2, DirCount);
            DirCount += 1;
            DirectoriesGroupLayout.RowCount = DirCount;
            DirectoriesGroupLayout.Height = 0;
            Height = 0;
            foreach (RowStyle style in DirectoriesGroupLayout.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }
            InitializeTrayMenu();
            RemoveButton.Enabled = DirCount > 1;
        }
        private void AddOption(string name)
        {
            string text = AppUtils.SplitCamelCase(name);
            Label label = new Label();

            label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 55);
            label.Margin = new Padding(10, 5, 3, 5);
            label.Name = name+"Label";
            label.Size = new System.Drawing.Size(670, 25);
            label.TabIndex = 2;
            label.Text = text;

            CheckBox checkbox = new CheckBox(); 
            checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
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

            int n = settingsForm.OptionsGroupLayout.RowCount;
            settingsForm.OptionsGroupLayout.Controls.Add(label, 0, OptionCount);
            settingsForm.OptionsGroupLayout.Controls.Add(checkbox, 1, OptionCount);
            OptionCount += 1;
            settingsForm.OptionsGroupLayout.RowCount = OptionCount;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.paths.Add(".");
            AddPath(".");
            Settings.Alter();
            CheckIsAltered();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RemovePath();
            Settings.Alter();
            CheckIsAltered();
        }
        private void BrowseIcon(object sender, EventArgs e)
        {
            FileDialog.DereferenceLinks = false;
            FileDialog.InitialDirectory = TrayIconPathTextBox.Text;
            DialogResult d = IconFileDialog.ShowDialog();
            if (d == DialogResult.OK)
            {
                TrayIconPathTextBox.Text = IconFileDialog.FileName;
                Settings.iconPath = TrayIconPathTextBox.Text;
                InitializeTrayMenu();
                Settings.Alter();
                CheckIsAltered();
            }
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
            panel.Height = 0;
            Height = 100;
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
            CheckIsAltered();
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
                if (!IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose && Settings.getOptionBool("MinimizeOnClose"))
            {
                HideApp(this, null);
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
            TrayItem.ContextMenuStrip.Items[0].Visible = false;
            TrayItem.ContextMenuStrip.Items[1].Visible = true;
            Focus();
        }
        private void ExitApp(object sender, EventArgs e)
        {
            allowClose = true;
            Application.Exit();
        }

        private void TrayPropertiesBoxLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void TrayTextApplyButton_Click(object sender, EventArgs e)
        {
            Settings.iconText = TrayTextTextBox.Text;
            InitializeTrayIcon();
            Settings.Alter();
            CheckIsAltered();
        }
    }
}
