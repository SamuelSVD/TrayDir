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
            InitializeInstanceTabs();
        }
        private void InitializeInstanceTabs()
        {
            for (int i = 0; i < pd.trayInstances.Count; i++)
            {
                TrayInstance instance = pd.trayInstances[i];
                TabPage tp;
                if (i == 0)
                {
                    tp = instanceTabs.TabPages[0];
                    tp.Text = instance.instanceName;
                }
                else
                {
                    tp = new TabPage(instance.instanceName);
                    instanceTabs.TabPages.Add(tp);
                }
                CreateViewFromInstance(instance, tp);
            }
        }
        public static void Init()
        {
            form = new MainForm();
        }
        public void InitializePaths()
        {
            foreach (TrayInstance instance in pd.trayInstances)
            {
                instance.setEventHandlers(ShowApp, HideApp, ExitApp);
            }
            if (trayInstance.settings.paths.Count == 0)
            {
                trayInstance.settings.paths.Add(".");
                ControlUtils.AddPath(DirectoriesGroupLayout, 0, ".", FileDialog, trayInstance);
                DirCount++;
            }
            else
            {
                for (int i = 0; i < trayInstance.settings.paths.Count; i++)
                {
                    string path = trayInstance.settings.paths[i];
                    ControlUtils.AddPath(DirectoriesGroupLayout, i, path, FileDialog, trayInstance);
                    DirCount++;
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
        private void button1_Click(object sender, EventArgs e)
        {
            trayInstance.AddPath(".");
            ControlUtils.AddPath(DirectoriesGroupLayout, DirCount, ".", FileDialog, trayInstance);
            DirCount++;
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
        public void CreateViewFromInstance(TrayInstance instance, TabPage tp)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            tp.Controls.Add(tlp);

            // Paths Group
            GroupBox pathsgb = new GroupBox();
            pathsgb.Text = "Paths";
            ControlUtils.ConfigureGroupBox(pathsgb);
            tlp.Controls.Add(pathsgb, 0, 0);

            TableLayoutPanel pathstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(pathstlp);
            pathsgb.Controls.Add(pathstlp);

            for (int i = 0; i < instance.settings.paths.Count; i++)
            {
                string path = instance.settings.paths[i];
                ControlUtils.AddPath(pathstlp, i, path, FileDialog, instance);
                //TODO Continue here
                int j = 1 / (instance.settings.paths.Count - instance.settings.paths.Count);
            }
            // Options Group
            GroupBox optionsgb = new GroupBox();
            optionsgb.Text = "Tray Options";
            ControlUtils.ConfigureGroupBox(optionsgb);
            tlp.Controls.Add(optionsgb, 0, 1);

            TableLayoutPanel optionstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(optionstlp);
            optionsgb.Controls.Add(optionstlp);

            // Add options into table layout
            EventHandler cbClick;
            CheckBox cb1;
            cb1 = ControlUtils.AddOption(optionstlp, 0, "Run As Admin", instance.settings.RunAsAdmin);
            cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings.RunAsAdmin = cb1.Checked;
                instance.UpdateTrayMenu();
                pd.Save();
            });
            cb1.Click += cbClick;

            CheckBox cb2;
            cb2 = ControlUtils.AddOption(optionstlp, 1, "Show File Extensions", instance.settings.ShowFileExtensions);
            cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings.ShowFileExtensions = cb2.Checked;
                instance.UpdateTrayMenu();
                pd.Save();
            });
            cb2.Click += cbClick;

            CheckBox cb3;
            cb3 = ControlUtils.AddOption(optionstlp, 2, "Explore Folders In TrayMenu", instance.settings.ExploreFoldersInTrayMenu);
            cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings.ExploreFoldersInTrayMenu = cb3.Checked;
                instance.UpdateTrayMenu();
                pd.Save();
            });
            cb3.Click += cbClick;

            CheckBox cb4;
            cb4 = ControlUtils.AddOption(optionstlp, 3, "Expand First Path", instance.settings.ExpandFirstPath);
            cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings.ExpandFirstPath = cb4.Checked;
                instance.UpdateTrayMenu();
                pd.Save();
            });
            cb4.Click += cbClick;
        }
    }
}
