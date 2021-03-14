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

        //Event Handlers
        EventHandler exploreClick;
        public MainForm()
        {
            InitializeComponent();
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
