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
            //ControlUtils.AddPath(DirectoriesGroupLayout, DirCount, ".", FileDialog, trayInstance);
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
            //removerow(DirectoriesGroupLayout, DirCount - 1);
            DirCount--;
            //RemoveButton.Enabled = DirCount > 1;
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
        private GroupBox CreateInstancePathsGroupBox(TrayInstance instance)
        {
            // Paths Group
            GroupBox pathsgb = new GroupBox();
            pathsgb.Text = "Paths";
            ControlUtils.ConfigureGroupBox(pathsgb);

            TableLayoutPanel pathstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(pathstlp);
            pathsgb.Controls.Add(pathstlp);

            for (int i = 0; i < instance.settings.paths.Count; i++)
            {
                string path = instance.settings.paths[i];
                int j = i;
                TextBox textbox = null;
                EventHandler fileSelect = new EventHandler(delegate (object obj, EventArgs args)
                {
                    FileDialog.DereferenceLinks = false;
                    FileDialog.InitialDirectory = textbox.Text;
                    DialogResult d = FileDialog.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        textbox.Text = FileDialog.FileName;
                        instance.settings.paths[j] = textbox.Text;
                        instance.UpdateTrayMenu();
                        pd.Save();
                    }
                });
                EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
                {
                    FolderSelectDialog fs = new FolderSelectDialog();
                    fs.InitialDirectory = textbox.Text;
                    if (fs.ShowDialog())
                    {
                        textbox.Text = fs.FileName;
                        instance.settings.paths[j] = textbox.Text;
                        instance.UpdateTrayMenu();
                        pd.Save();
                    }
                });
                textbox = ControlUtils.AddPath(pathstlp, i, path, instance, fileSelect, folderSelect);
            }
            return pathsgb;
        }
        private void SetCheckboxCheckedEvent(CheckBox cb, TrayInstance instance, string settingName)
        {
            EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings[settingName] = cb.Checked;
                instance.UpdateTrayMenu();
                pd.Save();
            });
            cb.Click += cbClick;
        }
        private GroupBox CreateInstanceOptionsGroupBox(TrayInstance instance)
        {
            // Options Group
            GroupBox optionsgb = new GroupBox();
            optionsgb.Text = "Tray Options";
            ControlUtils.ConfigureGroupBox(optionsgb);
            
            TableLayoutPanel optionstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(optionstlp);
            optionsgb.Controls.Add(optionstlp);

            // Add options into table layout
            CheckBox cb;
            cb = ControlUtils.AddOption(optionstlp, 0, "Run As Admin", instance.settings.RunAsAdmin);
            SetCheckboxCheckedEvent(cb, instance, "RunAsAdmin");

            cb = ControlUtils.AddOption(optionstlp, 1, "Show File Extensions", instance.settings.ShowFileExtensions);
            SetCheckboxCheckedEvent(cb, instance, "ShowFileExtensions");

            cb = ControlUtils.AddOption(optionstlp, 2, "Explore Folders In TrayMenu", instance.settings.ExploreFoldersInTrayMenu);
            SetCheckboxCheckedEvent(cb, instance, "ExploreFoldersInTrayMenu");

            cb = ControlUtils.AddOption(optionstlp, 3, "Expand First Path", instance.settings.ExpandFirstPath);
            SetCheckboxCheckedEvent(cb, instance, "ExpandFirstPath");

            //ControlUtils.AddEmptyOption(optionstlp, 4);
            return optionsgb;
        }
        public void CreateViewFromInstance(TrayInstance instance, TabPage tp)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            tp.Controls.Add(tlp);

            tlp.Controls.Add(CreateInstanceOptionsGroupBox(instance), 0, 0);
            tlp.Controls.Add(CreateInstancePathsGroupBox(instance), 0, 1);

            tlp.PerformLayout();

            instance.setEventHandlers(ShowApp, HideApp, ExitApp);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            resizeForm();
        }
        private void resizeForm()
        {
            int tempHeight = 1;
            for (int i = 0; i < instanceTabs.TabPages[instanceTabs.SelectedIndex].Controls.Count; i++)
            {
                Control c = instanceTabs.TabPages[instanceTabs.SelectedIndex].Controls[i];
                tempHeight += c.Padding.Top + c.Padding.Bottom + c.Margin.Bottom + c.Margin.Top + c.Location.Y * 2;
                for (int j = 0; j < c.Controls.Count; j++)
                {
                    Control c2 = c.Controls[i];
                    tempHeight += c2.Padding.Top + c2.Padding.Bottom + c2.Margin.Bottom + c2.Margin.Top + c2.Height;
                }
            }
            instanceTabs.Height = tempHeight;
        }
    }
}
