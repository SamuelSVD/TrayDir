using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class MainForm : Form
    {
        public static MainForm form;
        private int DirCount;
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used
        private TrayInstance trayInstance;
        public ProgramData pd;
        public MainForm()
        {
            InitializeComponent();
            pd = ProgramData.Load();
            if (pd.trayInstances.Count == 0)
            {
                pd.CreateDefaultInstance();
            }
            trayInstance = pd.trayInstances[0];
            pd.Save();
            InitializeAllAssets();
        }
        public static void Init()
        {
            form = new MainForm();

        }
        public void InitializePaths()
        {
            foreach (TrayInstance instance in pd.trayInstances) {
                instance.setEventHandlers(ShowApp, HideApp, ExitApp);
            }
            if (trayInstance.settings.paths.Count == 0)
            {
                trayInstance.settings.paths.Add(".");
                AddPath(".");
            }
            else
            {
                foreach (string path in trayInstance.settings.paths)
                {
                    AddPath(path);
                }
            }
            if (trayInstance.settings.paths.Count == 1)
            {
                RemoveButton.Enabled = false;
            }
        }
        private void CheckIsAltered()
        {
            if (Settings.isAltered())
            {
                this.Text = "TrayDir*";
            }
            else
            {
                this.Text = "TrayDir";
            }
        }
        public void HideApp(object Sender, EventArgs e)
        {
            Hide();
            pd.FormHidden();
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideApp(sender, e);
                pd.FormHidden();
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
                FileDialog.DereferenceLinks = false;
                FileDialog.InitialDirectory = textbox.Text;
                DialogResult d = FileDialog.ShowDialog();
                if (d == DialogResult.OK)
                {
                    textbox.Text = FileDialog.FileName;
                    trayInstance.settings.paths[n] = textbox.Text;
                    trayInstance.UpdateTrayMenu();
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
                    trayInstance.settings.paths[n] = textbox.Text;
                    trayInstance.UpdateTrayMenu();
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
            trayInstance.UpdateTrayMenu();
            RemoveButton.Enabled = DirCount > 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            trayInstance.AddPath(".");
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
        public void RemovePath()
        {
            removerow(DirectoriesGroupLayout, DirCount - 1);
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
            trayInstance.settings.paths.RemoveAt(trayInstance.settings.paths.Count - 1);
            trayInstance.UpdateTrayMenu();
        }
        private void BuildExploreDropdown()
        {
            exploreToolStripMenuItem.DropDownItems.Clear();
            foreach (string path in trayInstance.settings.paths)
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
            pd.Save();
            CheckIsAltered();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            About aa = new About();
            aa.Show();
        }
        private void Rebuild(object sender, EventArgs e)
        {
            trayInstance.UpdateTrayMenu();
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
            if (!allowClose && pd.settings.app.MinimizeOnClose)
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
                else
                {
                    foreach (TrayInstance i in pd.trayInstances)
                    {
                        i.Hide();
                    }
                }
            }
            base.OnFormClosing(e);
        }

        public void ShowApp(object sender, EventArgs e)
        {
            allowVisible = true;
            Show();
            Focus();
            pd.FormShowed();
        }
        public void ExitApp(object sender, EventArgs e)
        {
            allowClose = true;
            Application.Exit();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.form.ShowDialog();
        }
        private void TrayTextApplyButton_Click(object sender, EventArgs e)
        {
            trayInstance.settings.iconText = SettingsForm.form.TrayTextTextBox.Text;
            Settings.Alter();
            CheckIsAltered();
        }
        private void MainForm_Load(object sender, EventArgs e) { }
        public void InitializeAllAssets()
        {
            DirCount = 0;
            trayInstance.UpdateTrayMenu();
            InitializePaths();
            if (pd.settings.app.StartMinimized)
            {
                allowVisible = false;
                HideApp(this, null);
            }
            else
            {
                allowVisible = true;
            }
            PerformLayout();
            MaximizeBox = false;
        }
    }
}
