using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
	public partial class MainForm : Form
	{
		public static MainForm form;
		private bool allowVisible;     // ContextMenu's Show command used
		private bool allowClose;       // ContextMenu's Exit command used
		public TrayInstance trayInstance { get { return pd.trayInstances[instanceTabs.SelectedIndex]; } }
		private TrayInstance onShowInstance;
		public ProgramData pd;
		public FileDialog fd;
		public SmartTabControl instanceTabs;
		public TabPage newTabTabPage;

		private bool loaded = false;
		private bool initializedMinSize = false;

		public MainForm()
		{
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;

			fd = new OpenFileDialog();
			pd = ProgramData.Load();
			if (pd.trayInstances.Count == 0)
			{
				pd.CreateDefaultInstance();
			}

			deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);

			pd.FixInstances();
			if (!Program.IGNORESTARTUP) pd.CheckStartup();
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
			if (pd.settings.win.CheckForUpdates)
			{
				UpdateUtils.CheckForUpdates();
			}
			if (pd.settings.app.ShowIconsInMenus) {
				iconLoadTimer.Start();
			}
			loaded = true;
			pd.RebuildAll();
		}
		private void InitializeContent()
		{
			CreateInstanceTabsLayout();
			InitializeInstanceTabs();
		}
		private void CreateInstanceTabsLayout()
		{
			instanceTabs = new SmartTabControl();
			instanceTabs.AllowDrop = true;
			instanceTabs.DragEnter += MainForm_DragEnter;
			instanceTabs.DragDrop += MainForm_DragDrop;
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
			toolTip.SetToolTip(newTabTabPage, Properties.Strings_en.Tooltip_InsertInstance);

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
		public void AddInstanceTabPage(TrayInstance instance)
		{
			TabPage tp;
			tp = new TabPage(instance.instanceName);
			int i = instanceTabs.TabPages.IndexOf(newTabTabPage);
			instanceTabs.TabPages.Remove(newTabTabPage);
			instanceTabs.TabPages.Add(tp);
			instanceTabs.TabPages.Add(newTabTabPage);
			IView iv = CreateViewFromInstance(instance, tp);
			iv.tray.notifyIcon.DoubleClick += new EventHandler(delegate (object obj, EventArgs args)
			{
				if (((MouseEventArgs)args).Button == MouseButtons.Left)
				{
					onShowInstance = instance;
					ShowApp(obj, args);
				}
			});
			BuildRebuildDropdown();
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
			if (loaded)
			{
				if (WindowState == FormWindowState.Minimized)
				{
					bool block = true;
					foreach (TrayInstance instance in pd.trayInstances)
					{
						if (!instance.settings.HideFromTray)
						{
							block = false;
							break;
						}
					}
					if (!block && pd.settings.win.HideOnMinimize)
					{
						HideApp(sender, e);
					}
					pd.FormHidden();
				}
				else
				{
					pd.FormShowed();
				}
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
				if (!block && Visible) {
					switch (MessageBox.Show(Properties.Strings_en.Form_MinimizeToTray, Properties.Strings_en.Form_Exit, MessageBoxButtons.YesNo)) {
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
		public void ExitApp(object sender, EventArgs e)
		{
			allowClose = true;
			foreach (TrayInstance instance in pd.trayInstances)
			{
				instance.view.tray.Hide();
			}
			Application.Exit();
		}
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SettingsForm().ShowDialog();
		}
		private void MainForm_Load(object sender, EventArgs e) { }
		private IView CreateViewFromInstance(TrayInstance instance, TabPage tp)
		{
			IView iv = new IView(instance);
			iv.InstanceTabPage = tp;
			tp.Text = instance.instanceName;
			tp.Controls.Add(iv.GetControl());
			iv.treeviewForm.setTabPage(tp);

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
			if (loaded)
			{
				if (Visible)
				{
					timer1.Interval = 1000;
				}
				else
				{
					timer1.Interval = 100;
				}
			}
		}
		private void instanceTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = ((TabControl)sender).SelectedIndex;
			if (((TabControl)sender).SelectedTab == newTabTabPage)
			{
				New(sender, e);
			}
			BuildExploreDropdown();
		}
		private void New(object sender, EventArgs e)
		{
			TrayInstance ti = new TrayInstance(Properties.Strings_en.Instance_NewInstance);
			pd.trayInstances.Add(ti);
			pd.FixInstances();
			AddInstanceTabPage(ti);
			deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
			pd.Save();
			Edit(this, e);
		}
		private void Edit(object sender, EventArgs e)
		{
			string input = trayInstance.instanceName;
			if (InputDialog.ShowStringInputDialog(Properties.Strings_en.Form_EditName, ref input) == DialogResult.OK)
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
			if (pd.trayInstances.Count > 1 && (DialogResult.Yes == MessageBox.Show(string.Format(Properties.Strings_en.Form_PromptDelete, ti.instanceName), Properties.Strings_en.Form_Close, MessageBoxButtons.YesNo)))
			{
				instanceTabs.TabPages.Remove(ti.view.InstanceTabPage);
				pd.trayInstances.Remove(ti);
				ti.view.tray.Hide();
				deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
				BuildRebuildDropdown();
				pd.Save();
			}
		}
		private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AppUtils.ExportInstance(trayInstance);
		}
		private void importToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Tray Instance Export | *.tde";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				TrayInstance i = AppUtils.ImportInstance(ofd.FileName);
				if (i != null)
				{
					pd.trayInstances.Add(i);
					i.loadGlobalFromInternalPluginAndRereference();
					AddInstanceTabPage(i);
					deleteSelectedToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
					archiveToolStripMenuItem.Enabled = (pd.trayInstances.Count > 1);
					pd.Save();
				}
				else
				{
					MessageBox.Show(Properties.Strings_en.Error_ImportFailed, Properties.Strings_en.Form_ImportFailed);
				}
			}
		}
		private void iconLoadTimer_Tick(object sender, EventArgs e)
		{
			IMenuItemIconUtils.AssignIcons();
		}
		private void rebuildCurrentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			trayInstance.view.tray.Rebuild();
			trayInstance.view.treeviewForm.Rebuild();
		}
		private void rebuildAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pd.RebuildAll();
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
			if (InputDialog.ShowMultilineStringInputDialog(Properties.Strings_en.Form_EditIgnoreRegex, ref input) == DialogResult.OK)
			{
				trayInstance.ignoreRegex = input;
				trayInstance.view.tray.Rebuild();
				pd.Save();
			}
		}

		private void imgLoadTimer_Tick(object sender, EventArgs e)
		{
			if (IMenuItemIconUtils.PerformIconLoading()) {
				imgLoadTimer.Interval = 10;
			} else {
				imgLoadTimer.Interval = 1000;
			}
		}
		internal void pluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new PluginManagerForm().ShowDialog();
			Save(sender, e);
		}

		private void archiveToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show(string.Format(Properties.Strings_en.Instance_Archive, trayInstance.instanceName), Properties.Strings_en.Form_Archive, MessageBoxButtons.OKCancel) == DialogResult.OK) {
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
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pd.SaveAs();
		}
		private void donateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.paypal.com/donate/?business=QY2JZQHBAX65Y&no_recurring=0&item_name=I+make+open-source+software+tools%21+Every+donation+goes+a+long+way+to+support+continuing+to+develop+open-source+software%21+&currency_code=CAD");
		}
		private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			string helpPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\traydir.chm";
			try {
				using (Stream input = new MemoryStream(Properties.Resource_Help.TrayDir))
				using (Stream output = File.Create(helpPath)) {
					input.CopyTo(output);
				}
			}
			catch { }
			System.Diagnostics.Process.Start(helpPath);
		}
		private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) {
			string address = "contact@samver.ca";
			string subject = String.Format(Properties.Strings_en.Email_Subject, Program.RunningVersion);
			string body = Properties.Strings_en.Email_Body;
			string mailto = String.Format("mailto:{0}?subject={1}&body={2}", address, subject, body);
			AppUtils.ProcessStart(mailto);
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (string file in files) Console.WriteLine(file);
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			trayInstance.view.treeviewForm.treeView2_KeyDown(sender, e);
		}
	}
}
