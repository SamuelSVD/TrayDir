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
        public VisualStudioTabControl.VisualStudioTabControl instanceTabs;
        public TabPage newTabTabPage;

        //Event Handlers
        EventHandler exploreClick;
        public MainForm()
        {
            InitializeComponent();
            // 
            // instanceTabs
            // 
            instanceTabs = new VisualStudioTabControl.VisualStudioTabControl();
            this.instanceTabs.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.instanceTabs.AllowDrop = true;
            this.instanceTabs.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.instanceTabs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.instanceTabs.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.instanceTabs.ClosingMessage = "Delete this instance?";
            this.instanceTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.instanceTabs.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.instanceTabs.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.instanceTabs.ItemSize = new System.Drawing.Size(240, 16);
            this.instanceTabs.Location = new System.Drawing.Point(0, 0);
            this.instanceTabs.Margin = new System.Windows.Forms.Padding(6);
            this.instanceTabs.Name = "instanceTabs";
            this.instanceTabs.SelectedIndex = 0;
            this.instanceTabs.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.instanceTabs.ShowClosingButton = false;
            this.instanceTabs.ShowClosingMessage = true;
            this.instanceTabs.Size = new System.Drawing.Size(1132, 79);
            this.instanceTabs.TabIndex = 0;
            this.instanceTabs.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.instanceTabs.SelectedIndexChanged += new System.EventHandler(this.instanceTabs_SelectedIndexChanged);
            // 
            // newTabTabPage
            // 
            newTabTabPage = new TabPage();
            this.newTabTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.newTabTabPage.Location = new System.Drawing.Point(8, 24);
            this.newTabTabPage.Margin = new System.Windows.Forms.Padding(6);
            this.newTabTabPage.Name = "newTabTabPage";
            this.newTabTabPage.Padding = new System.Windows.Forms.Padding(6);
            this.newTabTabPage.Size = new System.Drawing.Size(1116, 47);
            this.newTabTabPage.TabIndex = 1;
            this.newTabTabPage.Text = "+";
            this.instanceTabs.Controls.Add(this.newTabTabPage);
            this.panel1.Controls.Add(this.instanceTabs);

            EventHandler closeTab = new EventHandler(delegate
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete this instance?", "Close", MessageBoxButtons.YesNo))
                {
                    this.instanceTabs.TabPages.RemoveAt(instanceTabs.SelectedIndex);
                }
            });

            instanceTabs.CloseClicked += closeTab;
            instanceTabs.OnMiddleClick += closeTab;

            fd = FileDialog;
            pd = ProgramData.Load();
            if (pd.trayInstances.Count == 0)
            {
                pd.CreateDefaultInstance();
            }
            if (pd.trayInstances.Count > 1)
            {
                instanceTabs.ShowClosingButton = true;
            }
            pd.FixInstances();
            pd.Save();
            InitializeInstanceTabs();
            InitializeAllAssets();
            BuildExploreDropdown();

            instanceTabs.HeaderColor = Color.FromArgb(237, 238, 242);
            instanceTabs.ActiveColor = Color.FromArgb(1, 122, 204);
            instanceTabs.HorizontalLineColor = Color.FromArgb(1, 122, 204);
            instanceTabs.TextColor = Color.Black;
            instanceTabs.BackTabColor = Color.WhiteSmoke;
        }
        private void InitializeInstanceTabs()
        {
            for (int i = 0; i < pd.trayInstances.Count; i++)
            {
                TrayInstance instance = pd.trayInstances[i];
                AddInstanceTabPage(instance);
            }
        }
        private void AddInstanceTabPage(TrayInstance instance)
        {
            TabPage tp;
            tp = new TabPage(instance.instanceName);
            instanceTabs.TabPages.Remove(newTabTabPage);
            instanceTabs.TabPages.Add(tp);
            instanceTabs.TabPages.Add(newTabTabPage);
            IView iv = CreateViewFromInstance(instance, tp);
            iv.notifyIcon.DoubleClick += ShowApp;
            EventHandler tabClose = new EventHandler(delegate (object obj, EventArgs args)
            {
                pd.trayInstances.Remove(instance);
                iv.Hide();
                instanceTabs.ShowClosingButton = (pd.trayInstances.Count > 1);
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
            //trayInstance.iconText = SettingsForm.form.TrayTextTextBox.Text;
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
                int tempHeight = instanceView.GetHeight() + 6;
                //tempHeight += mainMenu.Height;
                if (Program.DEBUG) Text = tempHeight.ToString();
                instanceTabs.Height = tempHeight;
            }
            panel1.PerformLayout();
        }
        private void instanceTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if (((TabControl)sender).SelectedTab == newTabTabPage)
            {
                TrayInstance ti = new TrayInstance("New Instance");
                pd.trayInstances.Add(ti);
                pd.FixInstances();
                AddInstanceTabPage(ti);
                instanceTabs.SelectedIndex = index;
                if (pd.trayInstances.Count > 1)
                {
                    instanceTabs.ShowClosingButton = true;
                }
                pd.Save();
            }
            BuildExploreDropdown();
            resizeForm();
        }
    }
}
