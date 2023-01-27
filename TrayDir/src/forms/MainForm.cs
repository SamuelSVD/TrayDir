using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TrayDir.utils;
using static TrayDir.SmartTabControl;

namespace TrayDir {
	public partial class MainForm : Form {
		public static MainForm form;
		private bool allowVisible;     // ContextMenu's Show command used
		private bool allowClose;       // ContextMenu's Exit command used
		public TrayInstance trayInstance { get { return pd.trayInstances[instanceTabs.SelectedIndex]; } }
		internal TrayInstance onShowInstance;
		public ProgramData pd;
		public FileDialog fd;
		public SmartTabControl instanceTabs;
		public CustomTabPage newTabTabPage;

		private bool loaded = false;
		private bool initializedMinSize = false;
		private bool exitNoPrompt = false;

		public MainForm() {
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;

			fd = new OpenFileDialog();
			pd = ProgramData.Load();
			if (pd.trayInstances.Count == 0) {
				pd.CreateDefaultInstance();
			}

			deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);

			pd.FixInstances();
			if (!Program.IGNORESTARTUP) pd.CheckStartup();
		}
		public void LoadProgram() {
			InitializeContent();
			BuildExploreDropdown();
			BuildRebuildDropdown();

			if (pd.settings.win.StartMinimized) {
				allowVisible = false;
				HideApp(this, null);
			} else {
				allowVisible = true;
			}
			if (pd.settings.win.CheckForUpdates) {
				UpdateUtils.CheckForUpdates();
			}
			if (pd.settings.app.ShowIconsInMenus) {
				iconLoadTimer.Start();
			}
			loaded = true;
			pd.RebuildAll();
		}
		private void InitializeContent() {
			CreateInstanceTabsLayout();
			InitializeInstanceTabs();
		}
		private void CreateInstanceTabsLayout() {
			instanceTabs = new SmartTabControl();
			instanceTabs.AllowDrop = true;
			instanceTabs.DragEnter += MainForm_DragEnter;
			instanceTabs.Dock = DockStyle.Fill;
			//instanceTabs.Anchor = (AnchorStyles)5;
			instanceTabs.Name = "instanceTabs";
			instanceTabs.SelectedIndex = 0;
			instanceTabs.TabIndex = 0;

			instanceTabs.Margin = new Padding(6);
			instanceTabs.SelectedIndexChanged += new EventHandler(instanceTabs_SelectedIndexChanged);
			// 
			// newTabTabPage
			// 
			newTabTabPage = new CustomTabPage("+");
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
			toolTip.SetToolTip(newTabTabPage, Properties.Strings.Tooltip_InsertInstance);

		}
		public void OnTabClick(object sender, SmartTabControl.TabClickedArgs tca) {
			TabPage tp = tca.TabPage;
			MouseEventArgs mea = tca.MouseEventArgs;
			if (tp != newTabTabPage) {
				if ((mea.Button == MouseButtons.Middle) && pd.trayInstances.Count > 1) {
					PromptDelete(instanceTabs.TabPages.IndexOf(tp));
				}
				if (mea.Button == MouseButtons.Left && mea.Clicks > 1) {
					Edit(this, null);
				}
			}
		}
		public void OnTabSwapped(object sender, SmartTabControl.TabSwappedArgs tsa) {
			TrayInstance ti = pd.trayInstances[tsa.aOriginalIndex];
			pd.trayInstances[tsa.aOriginalIndex] = pd.trayInstances[tsa.bOriginalIndex];
			pd.trayInstances[tsa.bOriginalIndex] = ti;
			pd.Save();
		}
		private void InitializeInstanceTabs() {
			for (int i = 0; i < pd.trayInstances.Count; i++) {
				TrayInstance instance = pd.trayInstances[i];
				AddInstanceTabPage(instance);
			}
			foreach (TrayInstance instance in ProgramData.pd.trayInstances) {
				instance.view.Rebuild();
			}
			instanceTabs.SelectedIndex = 0;
		}
		public void AddInstanceTabPage(TrayInstance instance) {
			CustomTabPage tp = new CustomTabPage(instance.instanceName);
			int i = instanceTabs.TabPages.IndexOf(newTabTabPage);
			instanceTabs.TabPages.Remove(newTabTabPage);
			instanceTabs.TabPages.Add(tp);
			instanceTabs.TabPages.Add(newTabTabPage);
			IView iv = new IView(instance, tp);
			instanceTabs.SelectedIndex = i;
			instanceTabs.MinimumSize = new Size((instance.view.p.MinimumSize.Width), (instance.view.p.MinimumSize.Height + instanceTabs.ItemSize.Height));
			if (!initializedMinSize) {
				Size temp = new Size(0, 0);
				temp.Width = instanceTabs.Width;
				temp.Height = mainMenu.Height;
				temp.Height += instance.view.p.MinimumSize.Height;
				temp.Height += instanceTabs.ItemSize.Height;
				temp.Height += tp.Height;
				temp.Height += instanceTabs.Margin.Top;
				temp.Height += instanceTabs.Margin.Bottom;
				this.Size = temp;
				this.MinimumSize = temp;
				initializedMinSize = true;
			}
			tp.Image = iv.tray.notifyIcon.Icon.ToBitmap();
		}
		public static void Init() {
			form = new MainForm();
		}
		public void HideApp(object Sender, EventArgs e) {
			Hide();
			pd.FormHidden();
		}
		private void MainForm_SizeChanged(object sender, EventArgs e) {
			if (loaded) {
				if (WindowState == FormWindowState.Minimized) {
					bool block = true;
					foreach (TrayInstance instance in pd.trayInstances) {
						if (!instance.settings.HideFromTray) {
							block = false;
							break;
						}
					}
					if (!block && pd.settings.win.HideOnMinimize) {
						HideApp(sender, e);
					}
					pd.FormHidden();
				} else {
					pd.FormShowed();
				}
			}
		}
		public void BuildRebuildDropdown() {
			rebuildToolStripMenuItem.DropDownItems.Clear();
			rebuildToolStripMenuItem.Click -= rebuildCurrentToolStripMenuItem_Click;

			if (pd.trayInstances.Count == 1) {
				rebuildToolStripMenuItem.Click += rebuildCurrentToolStripMenuItem_Click;
			} else {
				rebuildToolStripMenuItem.DropDownItems.Add(rebuildCurrentToolStripMenuItem);
				rebuildToolStripMenuItem.DropDownItems.Add(rebuildAllToolStripMenuItem);
			}
		}
		public void BuildExploreDropdown() {
			exploreToolStripMenuItem.DropDownItems.Clear();
			exploreToolStripMenuItem.Click -= ExploreClick;
			if (trayInstance.PathCount == 1) {
				exploreToolStripMenuItem.Click += ExploreClick;
			} else {
				foreach (TrayInstancePath p in trayInstance.paths) {
					string path = p.path;
					ToolStripMenuItem item = new ToolStripMenuItem();
					item.Size = new Size(359, 44);

					if (AppUtils.PathIsDirectory(path)) {
						item.Text = new DirectoryInfo(path).FullName;
					} else if (AppUtils.PathIsFile(path)) {
						item.Text = Path.GetFullPath(path);
					}

					EventHandler sel = new EventHandler(delegate (object obj, EventArgs args) {
						if (AppUtils.PathIsDirectory(path)) {
							AppUtils.ExplorePath(new DirectoryInfo(path).FullName);
						} else if (AppUtils.PathIsFile(path)) {
							AppUtils.ExplorePath(Path.GetFullPath(path));
						}
					});

					item.Click += sel;

					exploreToolStripMenuItem.DropDownItems.Add(item);
				}
			}
		}
		private void Save(object Sender, EventArgs e) {
			pd.Save();
		}

		private void ShowAbout(object sender, EventArgs e) {
			About aa = new About();
			aa.ShowDialog();
		}
		protected override void SetVisibleCore(bool value) {
			if (!allowVisible) {
				value = false;
				if (!IsHandleCreated) CreateHandle();
			}
			base.SetVisibleCore(value);
		}
		protected override void OnFormClosing(FormClosingEventArgs e) {
			bool block = true;
			foreach (TrayInstance instance in pd.trayInstances) {
				if (!instance.settings.HideFromTray) {
					block = false;
					break;
				}
			}
			if (!allowClose && pd.settings.win.MinimizeOnClose) {
				if (!block && !pd.settings.win.MinimizeOnClose) {
					HideApp(this, null);
				} else {
					WindowState = FormWindowState.Minimized;
				}
				e.Cancel = true;
			} else {
				if (!block && !exitNoPrompt && Visible && !Program.IGNORECLOSE) {
					switch (MessageBox.Show(Properties.Strings.Form_MinimizeToTray, Properties.Strings.Form_Exit, MessageBoxButtons.YesNo)) {
						case DialogResult.Yes:
							HideApp(this, null);
							e.Cancel = true;
							break;
						case DialogResult.No:
							foreach (TrayInstance i in pd.trayInstances) {
								i.view.tray.Hide();
							}
							break;
					}
				} else {
					foreach (TrayInstance i in pd.trayInstances) {
						i.view.tray.Hide();
					}
				}
			}
			base.OnFormClosing(e);
		}

		public void ShowApp(object sender, EventArgs e) {
			if (onShowInstance != null) {
				int i = pd.trayInstances.IndexOf(onShowInstance);
				if (i >= 0) {
					instanceTabs.SelectedIndex = i;
				}
				onShowInstance = null;
			}
			allowVisible = true;
			Visible = true;
			Show();
			Activate();
			Focus();
			TopMost = true;
			BringToFront();
			TopMost = false;
			WindowState = FormWindowState.Normal;
			pd.FormShowed();
			Invalidate();
			BuildExploreDropdown();
		}
		public void ExitApp(object sender, EventArgs e) {
			allowClose = true;
			exitNoPrompt = true;
			foreach (TrayInstance instance in pd.trayInstances) {
				instance.view.tray.Hide();
			}
			Application.Exit();
		}
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
			new SettingsForm().ShowDialog();
		}
		private void instanceTabs_SelectedIndexChanged(object sender, EventArgs e) {
			int index = ((TabControl)sender).SelectedIndex;
			if (((TabControl)sender).SelectedTab == newTabTabPage) {
				New(sender, e);
			}
			BuildExploreDropdown();
		}
		private void New(object sender, EventArgs e) {
			TrayInstance ti = new TrayInstance(Properties.Strings.Instance_NewInstance);
			pd.trayInstances.Add(ti);
			pd.FixInstances();
			AddInstanceTabPage(ti);
			deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			pd.Save();
			Edit(this, e);
			ti.view.tray.BuildTrayMenu();
			BuildRebuildDropdown();
		}
		private void Edit(object sender, EventArgs e) {
			string input = trayInstance.instanceName;
			if (InputDialog.ShowStringInputDialog(Properties.Strings.Form_EditName, ref input) == DialogResult.OK) {
				trayInstance.instanceName = input;
				instanceTabs.SelectedTab.Text = input;
				trayInstance.view.tray.SetText(input);
				pd.Save();
			}
		}

		private void DeleteCurrent(object sender, EventArgs e) {
			PromptDelete(instanceTabs.SelectedIndex);
		}
		private void PromptDelete(int i) {
			TrayInstance ti = pd.trayInstances[i];
			if (pd.trayInstances.Count > 1 && (DialogResult.Yes == MessageBox.Show(string.Format(Properties.Strings.Form_PromptDelete, ti.instanceName), Properties.Strings.Form_Close, MessageBoxButtons.YesNo))) {
				instanceTabs.TabPages.Remove(ti.view.InstanceTabPage);
				pd.trayInstances.Remove(ti);
				ti.view.tray.Hide();
				deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				BuildRebuildDropdown();
				pd.Save();
			}
		}
		private void exportToolStripMenuItem1_Click(object sender, EventArgs e) {
			AppUtils.ExportInstance(trayInstance);
		}
		private void importToolStripMenuItem_Click_1(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Tray Instance Export | *.tde";
			if (ofd.ShowDialog() == DialogResult.OK) {
				TrayInstance i = AppUtils.ImportInstance(ofd.FileName);
				if (i != null) {
					pd.trayInstances.Add(i);
					i.loadGlobalFromInternalPluginAndRereference();
					AddInstanceTabPage(i);
					deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
					archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
					BuildRebuildDropdown();
					pd.Save();
				} else {
					MessageBox.Show(Properties.Strings.Error_ImportFailed, Properties.Strings.Form_ImportFailed);
				}
			}
		}
		private void iconLoadTimer_Tick(object sender, EventArgs e) {
			IMenuItemIconUtils.AssignIcons();
		}
		private void rebuildCurrentToolStripMenuItem_Click(object sender, EventArgs e) {
			trayInstance.view?.Rebuild();
		}
		private void rebuildAllToolStripMenuItem_Click(object sender, EventArgs e) {
			pd.RebuildAll();
		}
		private void ExploreClick(object sender, EventArgs e) {
			string path = trayInstance.paths[0].path;
			if (AppUtils.PathIsDirectory(path)) {
				AppUtils.ExplorePath(new DirectoryInfo(path).FullName);
			} else if (AppUtils.PathIsFile(path)) {
				AppUtils.ExplorePath(Path.GetFullPath(path));
			}
		}
		private void changeIgnoreRegexToolStripMenuItem_Click(object sender, EventArgs e) {
			string input = trayInstance.ignoreRegex;
			if (InputDialog.ShowMultilineStringInputDialog(Properties.Strings.Form_EditIgnoreRegex, ref input) == DialogResult.OK) {
				trayInstance.ignoreRegex = input;
				trayInstance.view?.Rebuild();
				pd.Save();
			}
		}

		private void imgLoadTimer_Tick(object sender, EventArgs e) {
			if (IMenuItemIconUtils.PerformIconLoading()) {
				imgLoadTimer.Interval = 10;
			} else {
				imgLoadTimer.Interval = 1000;
			}
		}
		internal void pluginToolStripMenuItem_Click(object sender, EventArgs e) {
			new PluginManagerForm().ShowDialog();
			Save(sender, e);
		}

		private void archiveToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show(string.Format(Properties.Strings.Instance_Archive, trayInstance.instanceName), Properties.Strings.Form_Archive, MessageBoxButtons.OKCancel) == DialogResult.OK) {
				TrayInstance t = trayInstance;
				ProgramData.pd.trayInstances.Remove(t);
				ProgramData.pd.archivedInstances.Add(t);
				t.view.tray.Hide();
				instanceTabs.TabPages.Remove(instanceTabs.SelectedTab);
				deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				Save(sender, e);
			}
		}

		private void archiveManagerToolStripMenuItem_Click(object sender, EventArgs e) {
			InstanceManagerForm imf = new InstanceManagerForm();
			imf.ShowDialog();
			deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			Save(sender, e);
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			pd.SaveAs();
		}
		private void donateToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://www.paypal.com/donate/?business=QY2JZQHBAX65Y&no_recurring=0&item_name=I+make+open-source+software+tools%21+Every+donation+goes+a+long+way+to+support+continuing+to+develop+open-source+software%21+&currency_code=CAD");
		}
		private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
			string helpPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\traydir.chm";
			try {
				using (Stream input = new MemoryStream(Properties.Resource_Help.TrayDir))
				using (Stream output = File.Create(helpPath)) {
					input.CopyTo(output);
				}
			}
			catch { }
			Help.ShowHelp(this, helpPath);
		}
		private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) {
			string address = "contact@samver.ca";
			string subject = String.Format(Properties.Strings.Email_Subject, Program.RunningVersion);
			string body = Properties.Strings.Email_Body;
			string mailto = String.Format("mailto:{0}?subject={1}&body={2}", address, subject, body);
			AppUtils.ProcessStart(mailto);
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			trayInstance.view.treeviewForm.treeView2_KeyDown(sender, e);
		}
		internal void UpdateInstanceIcons() {
			for(int i = 0; i < ProgramData.pd.trayInstances.Count; i++) {
				TrayInstance ti = ProgramData.pd.trayInstances[i];
				CustomTabPage ctp = (CustomTabPage)instanceTabs.TabPages[i];
				ctp.Image = ti.view.tray.notifyIcon.Icon.ToBitmap();
			}
		}
		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show(Properties.Strings.Form_OpenConfigurationConfirmation, Properties.Strings.Form_OpenConfiguration, MessageBoxButtons.OKCancel) == DialogResult.OK) {
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = "TrayDir XML Export | *.xml";
				if (ofd.ShowDialog() == DialogResult.OK) {
					ProgramData pd = XMLUtils.LoadFromFile<ProgramData>(ofd.FileName);
					if (pd != null) {
						pd.initialized = true;
						pd.Save();
						Application.Restart();
						Environment.Exit(0);
					} else {
						MessageBox.Show(Properties.Strings.Error_ImportFailed, Properties.Strings.Form_ImportFailed);
					}
				}
			}
		}
	}
}
