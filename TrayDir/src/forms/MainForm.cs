using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class MainForm : Form
    {
        public static MainForm form;
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used
        private int prevHeight;
        public TrayInstance trayInstance { get { return pd.trayInstances[instanceTabs.SelectedIndex]; } }
        private TrayInstance onShowInstance;
        public ProgramData pd;
        public FileDialog fd;
        public SmartTabControl instanceTabs;
        public TabPage newTabTabPage;

        public MainForm()
        {
            InitializeComponent();

            fd = new OpenFileDialog();
            pd = ProgramData.Load();
            if (pd.trayInstances.Count == 0)
            {
                pd.CreateDefaultInstance();
            }

            deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);

            pd.FixInstances();
            pd.CheckStartup();
            pd.Save();
            InitializeContent();
            BuildExploreDropdown();
            BuildRebuildDropdown();

            if (pd.settings.win.StartMinimized)
            {
                allowVisible = false;
                HideApp(this, null);
            }
            else
            {
                allowVisible = true;
            }
            MaximizeBox = false;
            if (pd.settings.win.CheckForUpdates)
            {
                UpdateUtils.CheckForUpdates();
            }
        }
        private void InitializeContent()
        {
            CreateInstanceTabsLayout();
            InitializeInstanceTabs();
            UpdateInstanceTabs();
        }
        private void CreateInstanceTabsLayout()
        {
            instanceTabs = new SmartTabControl();
            instanceTabs.AllowDrop = true;
            instanceTabs.Dock = DockStyle.Top;
            instanceTabs.Name = "instanceTabs";
            instanceTabs.SelectedIndex = 0;
            instanceTabs.TabIndex = 0;

            instanceTabs.Margin = new Padding(6);
            instanceTabs.SelectedIndexChanged += new EventHandler(instanceTabs_SelectedIndexChanged);
            // 
            // newTabTabPage
            // 
            newTabTabPage = new TabPage();
            newTabTabPage.BackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            newTabTabPage.Name = "newTabTabPage";
            newTabTabPage.Text = "+";
            instanceTabs.Controls.Add(newTabTabPage);
            instanceTabs.IgnoreDragTabPages.Add(newTabTabPage);
            panel1.Controls.Add(instanceTabs);
            panel1.Dock = DockStyle.Fill;
            if (Program.DEBUG) panel1.BackColor = Color.Cyan;

            instanceTabs.OnTabClick += OnTabClick;
            instanceTabs.OnTabsSwapped += OnTabSwapped;

        }
        public void OnTabClick(object sender, SmartTabControl.TabClickedArgs tca)
        {
            TabPage tp = tca.TabPage;
            MouseEventArgs mea = tca.MouseEventArgs;
            if (tp != newTabTabPage)
            {
                if ((mea.Button == MouseButtons.Middle) && pd.trayInstances.Count > 1)
                {
                    PromptDelete(instanceTabs.TabPages.IndexOf(tp));
                }
                if (mea.Button == MouseButtons.Left && mea.Clicks > 1)
                {
                    Edit(this, null);
                }
            }
            resizeForm();
        }
        public void UpdateInstanceTabs()
        {
            foreach (TrayInstance ti in pd.trayInstances)
            {
                ti.view.paths.FixPaths();
            }
        }
        public void OnTabSwapped(object sender, SmartTabControl.TabSwappedArgs tsa)
        {
            TrayInstance ti = pd.trayInstances[tsa.aOriginalIndex];
            pd.trayInstances[tsa.aOriginalIndex] = pd.trayInstances[tsa.bOriginalIndex];
            pd.trayInstances[tsa.bOriginalIndex] = ti;
            pd.Save();
        }
        private void InitializeInstanceTabs()
        {
            for (int i = 0; i < pd.trayInstances.Count; i++)
            {
                TrayInstance instance = pd.trayInstances[i];
                AddInstanceTabPage(instance);
            }
            instanceTabs.SelectedIndex = 0;
        }
        private void AddInstanceTabPage(TrayInstance instance)
        {
            TabPage tp;
            tp = new TabPage(instance.instanceName);
            int i = instanceTabs.TabPages.IndexOf(newTabTabPage);
            instanceTabs.TabPages.Remove(newTabTabPage);
            instanceTabs.TabPages.Add(tp);
            instanceTabs.TabPages.Add(newTabTabPage);
            instanceTabs.SelectedIndex = i;
            IView iv = CreateViewFromInstance(instance, tp);
            iv.tray.notifyIcon.DoubleClick += new EventHandler(delegate (object obj, EventArgs args)
            {
                onShowInstance = instance;
                ShowApp(obj, args);
            });
            BuildRebuildDropdown();
        }
        public static void Init()
        {
            form = new MainForm();
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
        public void BuildRebuildDropdown()
        {
            rebuildToolStripMenuItem.DropDownItems.Clear();
            rebuildToolStripMenuItem.Click -= rebuildCurrentToolStripMenuItem_Click;

            if (pd.trayInstances.Count == 1)
            {
                rebuildToolStripMenuItem.Click += rebuildCurrentToolStripMenuItem_Click;
            }
            else
            {
                rebuildToolStripMenuItem.DropDownItems.Add(rebuildCurrentToolStripMenuItem);
                rebuildToolStripMenuItem.DropDownItems.Add(rebuildAllToolStripMenuItem);
            }
        }
        public void BuildExploreDropdown()
        {
            exploreToolStripMenuItem.DropDownItems.Clear();
            exploreToolStripMenuItem.Click -= ExploreClick;
            if (trayInstance.PathCount == 1)
            {
                exploreToolStripMenuItem.Click += ExploreClick;
            }
            else
            {
                foreach (TrayInstancePath p in trayInstance.paths)
                {
                    string path = p.path;
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Size = new Size(359, 44);

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
        }
        private void Save(object Sender, EventArgs e)
        {
            pd.Save();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            About aa = new About();
            aa.ShowDialog();
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
            if (!allowClose && pd.settings.win.MinimizeOnClose)
            {
                HideApp(this, null);
                e.Cancel = true;
            }
            else
            {
                foreach (TrayInstance i in pd.trayInstances)
                {
                    i.view.tray.Hide();
                }
            }
            base.OnFormClosing(e);
        }

        public void ShowApp(object sender, EventArgs e)
        {
            if (onShowInstance != null)
            {
                int i = pd.trayInstances.IndexOf(onShowInstance);
                if (i >= 0)
                {
                    instanceTabs.SelectedIndex = i;
                }
                onShowInstance = null;
            }
            allowVisible = true;
            Visible = true;
            Show();
            Focus();
            BringToFront();
            WindowState = FormWindowState.Normal;
            pd.FormShowed();
            Invalidate();
            BuildExploreDropdown();
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
        private void MainForm_Load(object sender, EventArgs e) { }
        private IView CreateViewFromInstance(TrayInstance instance, TabPage tp)
        {
            IView iv = new IView(instance);
            iv.InstanceTabPage = tp;
            tp.Text = instance.instanceName;
            tp.Controls.Add(iv.GetControl());

            iv.tray.setEventHandlers(new EventHandler(delegate (Object obj, EventArgs args)
            {
                onShowInstance = instance;
                ShowApp(obj, args);
            }), HideApp, ExitApp);
            iv.tray.BuildTrayMenu();
            return iv;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                timer1.Interval = 1000;
            }
            else
            {
                timer1.Interval = 100;
            }
            resizeForm();
        }
        private void resizeForm()
        {
            if (Visible && instanceTabs.SelectedIndex >= 0)
            {
                if (Program.DEBUG) instanceTabs.SelectedTab.BackColor = Color.Red;
                if (trayInstance.view != null)
                {
                    instanceTabs.SelectedTab.ClientSize = new Size(instanceTabs.SelectedTab.ClientSize.Width, trayInstance.view.p.Size.Height);
                    instanceTabs.ClientSize = new Size(instanceTabs.ClientSize.Width, instanceTabs.SelectedTab.ClientSize.Height + instanceTabs.SelectedTab.Top + instanceTabs.Margin.Bottom);
                    if (prevHeight == 0 || prevHeight > instanceTabs.ClientSize.Height)
                    {
                        ClientSize = new Size(ClientSize.Width, instanceTabs.Height + mainMenu.Height);
                    }
                    prevHeight = instanceTabs.ClientSize.Height;
                }
            }
            PerformLayout();
        }
        private void instanceTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if (((TabControl)sender).SelectedTab == newTabTabPage)
            {
                New(sender, e);
            }
            BuildExploreDropdown();
            resizeForm();
        }
        private void New(object sender, EventArgs e)
        {
            TrayInstance ti = new TrayInstance("New Instance");
            pd.trayInstances.Add(ti);
            pd.FixInstances();
            AddInstanceTabPage(ti);
            deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
            pd.Save();
            Edit(this, e);
        }
        private void Edit(object sender, EventArgs e)
        {
            string input = trayInstance.instanceName;
            if (InputDialog.ShowStringInputDialog("Edit Name", ref input) == DialogResult.OK)
            {
                trayInstance.instanceName = input;
                instanceTabs.SelectedTab.Text = input;
                trayInstance.view.tray.notifyIcon.Text = input;
                pd.Save();
            }
        }

        private void DeleteCurrent(object sender, EventArgs e)
        {
            PromptDelete(instanceTabs.SelectedIndex);
        }
        private void PromptDelete(int i)
        {
            TrayInstance ti = pd.trayInstances[i];
            if (pd.trayInstances.Count > 1 && (DialogResult.Yes == MessageBox.Show("Do you want to delete <" + ti.instanceName + ">?", "Close", MessageBoxButtons.YesNo)))
            {
                instanceTabs.TabPages.Remove(ti.view.InstanceTabPage);
                pd.trayInstances.Remove(ti);
                ti.view.tray.Hide();
                deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
                BuildRebuildDropdown();
                pd.Save();
            }
        }
        public void SwapPaths(int a, int b)
        {
            TrayInstancePath sa = trayInstance.paths[a];
            trayInstance.paths[a] = trayInstance.paths[b];
            trayInstance.paths[b] = sa;
            trayInstance.view.paths.FixPaths();
            trayInstance.view.tray.BuildTrayMenu();
            pd.Save();
            BuildExploreDropdown();
        }
        public void RemovePath(int i)
        {
            trayInstance.paths.RemoveAt(i);
            trayInstance.view.paths.FixPaths();
            trayInstance.view.tray.BuildTrayMenu();
            pd.Save();
            BuildExploreDropdown();
        }
        public void InsertPath(int i)
        {
            trayInstance.paths.Insert(i, new TrayInstancePath(TrayInstance.defaultPath));
            trayInstance.view.paths.FixPaths();
            trayInstance.view.tray.BuildTrayMenu();
            pd.Save();
            BuildExploreDropdown();
        }
        public void EditPath(int i)
        {
            string input = trayInstance.paths[i].alias;
            if (InputDialog.ShowStringInputDialog("Edit Display Name", ref input) == DialogResult.OK)
            {
                trayInstance.paths[i].alias = input;
                trayInstance.view.tray.BuildTrayMenu();
                pd.Save();
            }
        }


        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppUtils.ExportInstance(trayInstance);
        }

        private void importToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TrayInstance i = AppUtils.ImportInstance();
            if (i != null)
            {
                pd.trayInstances.Add(i);
                AddInstanceTabPage(i);
                pd.Save();
            }
            else
            {
                MessageBox.Show("Error: Unable to import file.", "Import failed");
            }
        }

        private void iconLoadTimer_Tick(object sender, EventArgs e)
        {
            bool ret = true;
            foreach(TrayInstance ti in pd.trayInstances)
            {
                ret = ti.view.tray.UpdateMenuIcons() && ret;
            }
            if (ret)
            {
                iconLoadTimer.Stop();
            }
        }

        private void rebuildCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayInstance.view.tray.Rebuild();
            resizeForm();
        }

        private void rebuildAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pd.RebuildAll();
            resizeForm();
        }
        private void ExploreClick(object sender, EventArgs e)
        {
            string path = trayInstance.paths[0].path;
            if (AppUtils.PathIsDirectory(path))
            {
                AppUtils.ExplorePath(new DirectoryInfo(path).FullName);
            }
            else if (AppUtils.PathIsFile(path))
            {
                AppUtils.ExplorePath(Path.GetFullPath(path));
            }
        }

        private void changeIgnoreRegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = trayInstance.ignoreRegex;
            if (InputDialog.ShowMultilineStringInputDialog("Edit Ignore Regex", ref input) == DialogResult.OK)
            {
                trayInstance.ignoreRegex = input;
                trayInstance.view.tray.Rebuild();
                pd.Save();
            }
        }

        private void scrapformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScrapForm f = new ScrapForm(trayInstance);
            f.ShowDialog();
        }
    }
}
