using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TrayDir.utils;

namespace TrayDir {
	public class IMenuItem {
		private static Thread imgLoadThread;
		private static Thread mainThread;
		private static Semaphore imgLoadSemaphore;
		private static Queue<IMenuItem> imgLoadQueue;
		public static Semaphore urlLoadSemaphore;
		public static Queue<IMenuItem> urlLoadQueue;
		private TrayInstance instance;
		public ToolStripMenuItem menuItem;
		public List<IMenuItem> folderChildren = new List<IMenuItem>();
		public List<IMenuItem> nodeChildren = new List<IMenuItem>();
		public IMenuItem parent;
		List<IMenuItem> dirMenuItems = new List<IMenuItem>();
		List<IMenuItem> fileMenuItems = new List<IMenuItem>();

		public TrayInstancePath tiPath;
		public TrayInstanceVirtualFolder tiVirtualFolder;
		public TrayInstancePlugin tiPlugin;

		private Bitmap menuIcon;

		public bool isDir { get { return tiPath != null ? AppUtils.PathIsDirectory(tiPath.path) : false; } }
		public bool isFile { get { return tiPath != null ? AppUtils.PathIsFile(tiPath.path) : false; } } 
		public bool isVFolder { get { return tiVirtualFolder != null; } }
		public readonly bool isPlugin = false;
		private bool loadedIcon = false;
		private bool assignedClickEvent = false;
		private bool enqueued;
		private bool painted;

		private string alias
		{
			get
			{
				if (tiPath != null)
				{
					return tiPath.alias;
				}
				if (tiVirtualFolder != null)
				{
					return tiVirtualFolder.alias;
				}
				if (tiPlugin != null)
				{
					return tiPlugin.alias;
				}
				return null;
			}
		}
		protected int depth
		{
			get
			{
				int d = 1;
				if (parent != null)
				{
					d += parent.depth;
				}
				return d;
			}
		}
		private static void LoadIconThread()
		{
			Stopwatch s = new Stopwatch();
			s.Start();
			while (true && mainThread.IsAlive)
			{
				if (tryLoadIconThread(imgLoadSemaphore, imgLoadQueue))
				{
					s.Reset();
				}
				s.Stop();
				if (s.Elapsed.Seconds > 2)
				{
					break;
				}
				s.Start();
				Thread.Sleep(1);
			}
		}
		public static bool PerformIconLoading() {
			if (IMenuItem.urlLoadQueue != null && IMenuItem.urlLoadQueue.Count > 0) {
				IMenuItem.tryLoadIconThread(IMenuItem.urlLoadSemaphore, IMenuItem.urlLoadQueue);
				return true;
			}
			return false;
		}
		public static bool tryLoadIconThread(Semaphore sem, Queue<IMenuItem> queue)
		{
			sem.WaitOne();
			bool result = false;
			if (queue.Count > 0)
			{
				IMenuItem mi = queue.Dequeue();
				try
				{
					if (mi.menuIcon is null && mi.isFile)
					{
						string ext = Path.GetExtension(mi.tiPath.path);
						if (ext.Length == 0 || ext == ".ico" || ext == ".lnk" || ext == ".exe" || (queue != imgLoadQueue && ext == ".url"))
						{
							mi.menuIcon = Icon.ExtractAssociatedIcon(mi.tiPath.path).ToBitmap();
						} else if (queue == imgLoadQueue && ext == ".url")
						{
							urlLoadSemaphore.WaitOne();
							MainForm.form.imgLoadTimer.Enabled = true;
							urlLoadQueue.Enqueue(mi);
							urlLoadSemaphore.Release();
						}
						else
						{
							mi.menuIcon = IconUtils.lookupIcon(ext);
							if (mi.menuIcon == null)
							{
								mi.menuIcon = Icon.ExtractAssociatedIcon(mi.tiPath.path).ToBitmap();
								IconUtils.addIcon(ext, mi.menuIcon);
							}
						}
					}
					else if (mi.menuIcon is null && mi.isDir)
					{
						if (mi.tiPath != null && mi.tiPath.shortcut) {
							mi.menuIcon = new Bitmap(Properties.Resources.folder_shortcut);
						} else {
							mi.menuIcon = new Bitmap(Properties.Resources.folder);
						}
					}
					else if (mi.menuIcon is null && mi.tiVirtualFolder != null) {
						if (ProgramData.pd.settings.app.VFolderIcon != "Yellow Folder") {
							mi.menuIcon = new Bitmap(Properties.Resources.folder_blue);
						} else {
							mi.menuIcon = new Bitmap(Properties.Resources.folder);
						}
					}
					else if (mi.tiPlugin != null)
					{
						TrayPlugin tp = mi.tiPlugin.plugin;
						if (tp != null && AppUtils.PathIsFile(tp.path))
						{
							Bitmap i = IconUtils.lookupIcon(tp.getSignature());
							if (i == null)
							{
								i = Icon.ExtractAssociatedIcon(tp.path).ToBitmap();
								IconUtils.addIcon(tp.getSignature(), i);
							}
							mi.menuIcon = i;
						}
					}
				}
				catch { }
				mi.loadedIcon = true;
				result = true;
			}
			sem.Release();
			return result;
		}
		public IMenuItem(TrayInstance instance, TrayInstancePath path) : this(instance, path, null, null, null) { }
		public IMenuItem(TrayInstance instance, TrayInstancePlugin plugin) : this(instance, null, null, plugin, null) { }
		public IMenuItem(TrayInstance instance, TrayInstanceVirtualFolder virtualFolder) : this(instance, null, virtualFolder, null, null) { }
		public IMenuItem(TrayInstance instance, TrayInstancePath tiPath, TrayInstanceVirtualFolder tiVirtualFolder, TrayInstancePlugin tiPlugin, IMenuItem parent)
		{
			if (imgLoadSemaphore is null)
			{
				imgLoadSemaphore = new Semaphore(1, 1);
			}
			if (imgLoadQueue is null)
			{
				imgLoadQueue = new Queue<IMenuItem>();
			}
			if (urlLoadSemaphore is null)
			{
				urlLoadSemaphore = new Semaphore(1, 1);
			}
			if (urlLoadQueue is null)
			{
				urlLoadQueue = new Queue<IMenuItem>();
			}
			if (imgLoadThread is null)
			{
				mainThread = Thread.CurrentThread;
				imgLoadThread = new Thread(LoadIconThread);
				imgLoadThread.Start();
			}

			this.instance = instance;
			this.tiPath = tiPath;
			this.tiVirtualFolder = tiVirtualFolder;
			this.tiPlugin = tiPlugin;
			this.parent = parent;

			isPlugin = tiPlugin != null;
		}
		private void LoadFolderChildren(object sender, PaintEventArgs e)
		{
			if (!painted && isDir && !tiPath.shortcut) {
				MakeChildren();
				Load();
				menuItem.Invalidate();
			}
			painted = true;
		}
		private void MakeChildren()
		{
			if (isDir)
			{
				try
				{
					string[] dirpaths = Directory.GetFileSystemEntries(tiPath.path);
					foreach (string fp in dirpaths)
					{
						bool match = false;
						foreach(string regx in instance.regexList)
						{
							if (regx != "")
							{
								match = match || (Regex.Matches(fp, regx).Count > 0);
							}
							if (match) break;
						}
						if (!match)
						{
							folderChildren.Add(new IMenuItem(instance, new TrayInstancePath(fp), null, null, this));
						}
					}
				}
				catch { }
			}
		}
		public void MenuDestroy(object obj, EventArgs args)
		{
			IMenuItem mi = parent;
			while (mi != null)
			{
				mi.menuItem.DropDown.AutoClose = true;
				mi.menuItem.DropDown.Close();
				mi.menuItem.Enabled = true;
				mi = mi.parent;
			}
			instance.view.tray.notifyIcon.ContextMenuStrip.AutoClose = true;
			instance.view.tray.notifyIcon.ContextMenuStrip.Enabled = true;
			instance.view.tray.notifyIcon.ContextMenuStrip.Close();
		}
		private void MenuSave()
		{
			IMenuItem mi = parent;
			instance.view.tray.notifyIcon.ContextMenuStrip.Show();
			while (mi != null)
			{
				mi.menuItem.DropDown.AutoClose = false;
				mi.menuItem.DropDown.Show();
				mi.menuItem.Enabled = false;
				mi = mi.parent;
			}
			instance.view.tray.notifyIcon.ContextMenuStrip.AutoClose = false;
			instance.view.tray.notifyIcon.ContextMenuStrip.Enabled = false;
		}
		private void Run(object obj, EventArgs args)
		{
			if (isDir)
			{
				AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, false);
			}
			else if (isFile)
			{
				AppUtils.OpenPath(Path.GetFullPath(tiPath.path), false);
			} else if (isPlugin) {
				AppUtils.RunPlugin(tiPlugin, false);
			}
		}
		private void RunAll(object obj, EventArgs args)
		{
			foreach(IMenuItem imi in nodeChildren) {
				if (imi.isDir || imi.isFile || imi.isPlugin) {
					imi.Run(obj, args);
				} else if (imi.isVFolder) {
					imi.RunAll(obj, args);
				}
			}
		}
		private void Explore(object obj, EventArgs args)
		{
			if (isDir) {
				AppUtils.ExplorePath(new DirectoryInfo(tiPath.path).FullName);
			} else if (isFile) {
				AppUtils.ExplorePath(Path.GetFullPath(tiPath.path));
			} else if (isPlugin) {
				if (tiPlugin != null) {
					if (tiPlugin.plugin != null) {
						AppUtils.ExplorePath(tiPlugin.plugin.path);
					}
				}
			}
		}
		private void RunAs(object obj, EventArgs args)
		{
			if (isDir)
			{
				AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, true);
			}
			else if (isFile)
			{
				AppUtils.OpenPath(Path.GetFullPath(tiPath.path), true);
			}
			else if (isPlugin) {
				AppUtils.RunPlugin(tiPlugin, true);
			}
		}
		private void OpenCmd(object obj, EventArgs args)
		{
			if (isDir)
			{
				AppUtils.OpenCmdPath(new DirectoryInfo(tiPath.path).FullName);
			}
			else if (isFile)
			{
				AppUtils.OpenCmdPath(Path.GetFullPath(tiPath.path));
			}
		}
		private void OpenAdminCmd(object obj, EventArgs args)
		{
			if (isDir)
			{
				AppUtils.OpenAdminCmdPath(new DirectoryInfo(tiPath.path).FullName);
			}
			else if (isFile)
			{
				AppUtils.OpenAdminCmdPath(Path.GetFullPath(tiPath.path));
			}
		}
		public void MenuItemClick(object obj, MouseEventArgs args)
		{
			if (((MouseEventArgs)args).Button == MouseButtons.Right) {
				MenuSave();
				Point pt = System.Windows.Forms.Cursor.Position;
				ContextMenuStrip cmnu = new ContextMenuStrip();
				ToolStripItem tsi;
				if (isDir)
				{
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenFileExplorer);
					tsi.Click += Explore;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenCmd);
					tsi.Click += OpenCmd;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenCmdAdmin);
					tsi.Click += OpenAdminCmd;
				}
				else if (isFile)
				{
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_Run);
					tsi.Click += Run;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_RunAdmin);
					tsi.Click += RunAs;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenFileExplorer);
					tsi.Click += Explore;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenCmd);
					tsi.Click += OpenCmd;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenCmdAdmin);
					tsi.Click += OpenAdminCmd;
				} else if (isPlugin) {
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_Run);
					tsi.Click += Run;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_RunAdmin);
					tsi.Click += RunAs;
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_OpenFileExplorer);
					tsi.Click += Explore;
				} else if (isVFolder) {
					tsi = cmnu.Items.Add(Properties.Strings_en.MenuItem_RunAll);
					tsi.Click += RunAll;
				} else
				{
					MenuDestroy(null, null);
				}
				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
			else
			{
				if (isDir && (instance.settings.ExploreFoldersInTrayMenu || tiPath.shortcut))
				{
					AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, instance.settings.RunAsAdmin);
				}
				else if (isFile)
				{
					AppUtils.OpenPath(Path.GetFullPath(tiPath.path), instance.settings.RunAsAdmin);
				}
				else if (tiPlugin != null)
				{
					AppUtils.RunPlugin(tiPlugin, instance.settings.RunAsAdmin);
				}
			}
		}
		// Grabbed from https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
		private void submenu_DropDownOpening(object sender, EventArgs e)
		{
			if (menuItem.HasDropDownItems == false)
			{
				return; // not a drop down item
			}
			// Current bounds of the current monitor
			Rectangle Bounds = menuItem.GetCurrentParent().Bounds;
			Screen CurrentScreen = Screen.FromPoint(Bounds.Location);

			// Look how big our children are:
			int MaxWidth = 0;
			foreach (ToolStripItem subitem in menuItem.DropDownItems)
			{
				MaxWidth = Math.Max(subitem.Width, MaxWidth);
			}
			MaxWidth += 10; // Add a little wiggle room

			int FarRight = Bounds.Right + MaxWidth;
			int CurrentMonitorRight = CurrentScreen.Bounds.Right;

			if (FarRight > CurrentMonitorRight)
			{
				menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
			}
			else
			{
				menuItem.DropDownDirection = ToolStripDropDownDirection.Right;
			}
		}
		public void Load()
		{
			if (menuItem == null)
			{
				menuItem = new ToolStripMenuItem();
				menuItem.DropDownOpening += submenu_DropDownOpening;
				menuItem.Paint += LoadFolderChildren;
			}
			bool useAlias = (alias != null && alias != "");
			if (useAlias)
			{
				menuItem.Text = alias;
			}
			else
			{
				if (isDir)
				{
					menuItem.Text = new DirectoryInfo(tiPath.path).Name;
				}
				else if (isFile)
				{
					if (instance.settings.ShowFileExtensions)
					{
						menuItem.Text = Path.GetFileName(tiPath.path);
					}
					else
					{
						menuItem.Text = Path.GetFileNameWithoutExtension(tiPath.path);
					}
				}
				else if (tiPlugin != null)
				{
					TrayPlugin plugin = tiPlugin.plugin;
					if (plugin != null)
					{
						if (plugin.name == null || plugin.name == "")
						{
							menuItem.Text = "(plugin item)";
						}
						else
						{
							menuItem.Text = string.Format("({0})", plugin.name);
						}
					}
					else
					{
						menuItem.Text = "(plugin item)";
					}
				}
			}

			menuItem.DropDownItems.Clear();
			dirMenuItems.Clear();
			fileMenuItems.Clear();
			foreach (IMenuItem child in folderChildren)
			{
				child.Load();
				if (child.isDir)
				{
					dirMenuItems.Add(child);
				}
				if (child.isFile)
				{
					fileMenuItems.Add(child);
				}
			}
			if (isDir && tiPath.shortcut)
			{
				folderChildren.Clear();
				menuItem.DropDownItems.Clear();
			}
			if (folderChildren.Count == 0 && isDir && !tiPath.shortcut)
			{
				menuItem.DropDownItems.Add("(Empty)");
			}
			if (ProgramData.pd.settings.app.MenuSorting != "None")
			{
				if (ProgramData.pd.settings.app.MenuSorting == "Folders Top")
				{
					foreach (IMenuItem child in dirMenuItems)
					{
						menuItem.DropDownItems.Add(child.menuItem);
					}
					foreach (IMenuItem child in fileMenuItems)
					{
						menuItem.DropDownItems.Add(child.menuItem);
					}
				}
				else
				{
					foreach (IMenuItem child in fileMenuItems)
					{
						menuItem.DropDownItems.Add(child.menuItem);
					}
					foreach (IMenuItem child in dirMenuItems)
					{
						menuItem.DropDownItems.Add(child.menuItem);
					}
				}
			}
			else
			{
				foreach (IMenuItem child in folderChildren)
				{
					menuItem.DropDownItems.Add(child.menuItem);
				}
			}
			if (!assignedClickEvent)
			{
				menuItem.MouseDown += MenuItemClick;
				menuItem.DropDownOpened += LoadChildrenIconEvent;
				assignedClickEvent = true;
			}
		}

		public bool LoadIcon()
		{
			bool ret = loadedIcon;
			if (ProgramData.pd.settings.app.ShowIconsInMenus && loadedIcon && menuIcon != null)
			{
				if (menuItem.Image == null) {
					menuItem.Image = menuIcon;
				}
			} else if (menuItem != null)
			{
				menuItem.Image = null;
			}
			if (ret)
			{
				foreach (IMenuItem child in folderChildren)
				{
					ret = child.LoadIcon() && ret;
				}
			}
			return ret && (isDir || menuItem.Image != null || tiVirtualFolder != null);
		}
		public void EnqueueImgLoad()
		{
			if (!enqueued)
			{
				imgLoadSemaphore.WaitOne();
				imgLoadQueue.Enqueue(this);
				imgLoadSemaphore.Release();
				enqueued = true;
			}
			if (!imgLoadThread.IsAlive)
			{
				imgLoadThread = new Thread(LoadIconThread);
				imgLoadThread.Start();
			}
		}
		public void LoadChildrenIconEvent(Object obj, EventArgs args)
		{
			if (!imgLoadThread.IsAlive)
			{
				imgLoadThread = new Thread(LoadIconThread);
				imgLoadThread.Start();
			}
			foreach (IMenuItem child in folderChildren)
			{
				child.EnqueueImgLoad();
			}
		}
		public void AddToCollection(ToolStripItemCollection collection)
		{
			collection.Add(menuItem);

			if (folderChildren.Count != menuItem.DropDownItems.Count)
			{
				menuItem.DropDownItems.Clear();
				dirMenuItems.Clear();
				fileMenuItems.Clear();

				if (ProgramData.pd.settings.app.MenuSorting != "None")
				{
					if (ProgramData.pd.settings.app.MenuSorting == "Folders Top")
					{
						foreach (IMenuItem child in dirMenuItems)
						{
							menuItem.DropDownItems.Add(child.menuItem);
						}
						foreach (IMenuItem child in fileMenuItems)
						{
							menuItem.DropDownItems.Add(child.menuItem);
						}
					}
					else
					{
						foreach (IMenuItem child in fileMenuItems)
						{
							menuItem.DropDownItems.Add(child.menuItem);
						}
						foreach (IMenuItem child in dirMenuItems)
						{
							menuItem.DropDownItems.Add(child.menuItem);
						}
					}
				}
				else
				{
					foreach (IMenuItem child in folderChildren)
					{
						menuItem.DropDownItems.Add(child.menuItem);
					}
				}
			}
		}
		public void AddToCollectionExpanded(ToolStripItemCollection collection)
		{
			if (folderChildren.Count > 0)
			{
				if (folderChildren.Count != menuItem.DropDownItems.Count)
				{
					menuItem.DropDownItems.Clear();
				}
				dirMenuItems.Clear();
				fileMenuItems.Clear();

				foreach (IMenuItem child in folderChildren)
				{
					if (child.isDir)
					{
						dirMenuItems.Add(child);
					}
					else if (child.isFile)
					{
						fileMenuItems.Add(child);
					}
				}
				if (ProgramData.pd.settings.app.MenuSorting != "None")
				{
					if (ProgramData.pd.settings.app.MenuSorting == "Folders Top")
					{
						foreach (IMenuItem child in dirMenuItems)
						{
							collection.Add(child.menuItem);
						}
						foreach (IMenuItem child in fileMenuItems)
						{
							collection.Add(child.menuItem);
						}
					}
					else
					{
						foreach (IMenuItem child in fileMenuItems)
						{
							collection.Add(child.menuItem);
						}
						foreach (IMenuItem child in dirMenuItems)
						{
							collection.Add(child.menuItem);
						}
					}
				}
				else
				{
					foreach (IMenuItem child in folderChildren)
					{
						collection.Add(child.menuItem);
					}
				}
			}
			else
			{
				collection.Add(menuItem);
			}
		}
	}
}
