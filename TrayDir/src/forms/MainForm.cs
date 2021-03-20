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
        private TrayInstance trayInstance { get { return pd.trayInstances[instanceTabs.SelectedIndex]; } }
        public ProgramData pd;
        private IView instanceView;
        public FileDialog fd;
        public SmartTabControl instanceTabs;
        public TabPage newTabTabPage;

        //Event Handlers
        EventHandler exploreClick;
        public MainForm()
        {
            InitializeComponent();
            // 
            // instanceTabs
            //
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
            newTabTabPage.Location = new Point(8, 24);
            newTabTabPage.Margin = new Padding(6);
            newTabTabPage.Name = "newTabTabPage";
            newTabTabPage.Padding = new Padding(6);
            newTabTabPage.Size = new Size(1116, 47);
            newTabTabPage.TabIndex = 1;
            newTabTabPage.Text = "+";
            instanceTabs.Controls.Add(newTabTabPage);
            panel1.Controls.Add(instanceTabs);

            instanceTabs.OnTabClick += OnTabClick;

            fd = FileDialog;
            pd = ProgramData.Load();
            if (pd.trayInstances.Count == 0)
            {
                pd.CreateDefaultInstance();
            }

            deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
            pd.FixInstances();
            pd.Save();
            InitializeInstanceTabs();
            InitializeAllAssets();
            BuildExploreDropdown();

            /*instanceTabs.HeaderColor = Color.FromArgb(237, 238, 242);
            instanceTabs.ActiveColor = Color.FromArgb(1, 122, 204);
            instanceTabs.HorizontalLineColor = Color.FromArgb(1, 122, 204);
            instanceTabs.TextColor = Color.Black;
            instanceTabs.BackTabColor = Color.WhiteSmoke;*/
        }
        public void OnTabClick(object sender, SmartTabControl.TabClickedArgs tce)
        {
            TabPage tp = tce.TabPage;
            MouseEventArgs mea = tce.MouseEventArgs;
            if (tp != this.newTabTabPage)
            {
                if ((mea.Button == MouseButtons.Middle) && pd.trayInstances.Count > 1)
                {
                    PromptDelete(instanceTabs.TabPages.IndexOf(tp));
                }
            }
            //delete
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
            iv.notifyIcon.DoubleClick += ShowApp;
            EventHandler tabClose = new EventHandler(delegate (object obj, EventArgs args)
            {
                pd.trayInstances.Remove(instance);
                iv.Hide();
                deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
                pd.Save();
            });
            tp.ParentChanged += tabClose;
        }
        public static void Init()
        {
            form = new MainForm();
        }
        private void CheckIsAltered()
        {
            if (Settings.isAltered())
            {
                Text = "TrayDir*";
            }
            else
            {
                Text = "TrayDir";
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
        private void BuildExploreDropdown()
        {
            exploreToolStripMenuItem.DropDownItems.Clear();
            if (exploreClick != null)
            {
                exploreToolStripMenuItem.Click -= exploreClick;
            }
            if (trayInstance.settings.paths.Count == 1)
            {
                string path = trayInstance.settings.paths[0];

                exploreClick = new EventHandler(delegate (object obj, EventArgs args)
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

                exploreToolStripMenuItem.Click += exploreClick;
            }
            else
            {
                foreach (string path in trayInstance.settings.paths)
                {
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
            CheckIsAltered();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            About aa = new About();
            aa.Show();
        }
        private void Rebuild(object sender, EventArgs e)
        {
            pd.UpdateAllMenus();
            resizeForm();
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
                        i.view.Hide();
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
            Settings.Alter();
            CheckIsAltered();
        }
        private void MainForm_Load(object sender, EventArgs e) { }
        public void InitializeAllAssets()
        {
            if (pd.settings.app.StartMinimized)
            {
                allowVisible = false;
                HideApp(this, null);
            }
            else
            {
                allowVisible = true;
            }
            MaximizeBox = false;
        }
        private IView CreateViewFromInstance(TrayInstance instance, TabPage tp)
        {
            IView iv = new IView(instance);
            tp.Text = instance.instanceName;
            tp.Controls.Add(iv.GetControl());

            iv.setEventHandlers(ShowApp, HideApp, ExitApp);
            iv.UpdateTrayMenu();
            instanceView = iv;
            return iv;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            resizeForm();
            timer1.Interval = 100;
        }
        private void resizeForm()
        {
            if (instanceTabs.SelectedIndex >= 0)
            {
                if (Program.DEBUG) instanceTabs.SelectedTab.BackColor = Color.Orange;
                int tempHeight = instanceView.GetHeight();
                //tempHeight += mainMenu.Height;
                if (Program.DEBUG) Text = tempHeight.ToString();
                instanceTabs.Height = tempHeight + instanceTabs.ItemSize.Height;
            }
            panel1.PerformLayout();
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
                trayInstance.view.notifyIcon.Text = input;
                pd.Save();
            }
        }

        private void DeleteCurrent(object sender, EventArgs e)
        {
            PromptDelete(instanceTabs.SelectedIndex);
        }
        private void PromptDelete(int i)
        {
            TabPage tp = instanceTabs.TabPages[i];
            TrayInstance ti = pd.trayInstances[i];
            if (pd.trayInstances.Count > 1 && (DialogResult.Yes == MessageBox.Show("Do you want to delete <" + ti.instanceName + ">?", "Close", MessageBoxButtons.YesNo)))
            {
                instanceTabs.TabPages.RemoveAt(i);
            }
        }
    }
}
