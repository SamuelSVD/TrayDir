using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TrayDir
{
    public class IMenuItem
    {
        private static Thread imgLoadThread;
        private static Thread mainThread;
        private static Semaphore imgLoadSemaphore;
        private static Queue<IMenuItem> imgLoadQueue;

        private TrayInstance instance;
        private TrayInstancePath tiPath;
        public ToolStripMenuItem menuItem;
        public List<IMenuItem> children;
        public IMenuItem parent;
        private Image menuIcon;

        public readonly bool isDir = false;
        public readonly bool isFile = false;
        private bool loadedIcon = false;
        private bool assignedClickEvent = false;
        private bool enqueued;

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
                imgLoadSemaphore.WaitOne();
                if (imgLoadQueue.Count > 0)
                {
                    IMenuItem mi = imgLoadQueue.Dequeue();
                    try
                    {
                        if (mi.menuIcon is null && mi.isFile)
                        {
                            mi.menuIcon = Icon.ExtractAssociatedIcon(mi.tiPath.path).ToBitmap();
                        }
                    }
                    catch { }
                    mi.loadedIcon = true;
                    s.Reset();
                }
                imgLoadSemaphore.Release();
                s.Stop();
                if (s.Elapsed.Seconds > 2)
                {
                    break;
                }
                s.Start();
                Thread.Sleep(10);
            }
        }
        public IMenuItem(TrayInstance instance, TrayInstancePath path) : this(instance, path, null) { }
        public IMenuItem(TrayInstance instance, TrayInstancePath tiPath, IMenuItem parent)
        {
            if (imgLoadSemaphore is null)
            {
                imgLoadSemaphore = new Semaphore(1, 1);
            }
            if (imgLoadQueue is null)
            {
                imgLoadQueue = new Queue<IMenuItem>();
            }
            if (imgLoadThread is null)
            {
                mainThread = Thread.CurrentThread;
                imgLoadThread = new Thread(LoadIconThread);
                imgLoadThread.Start();
            }

            this.instance = instance;
            this.tiPath = tiPath;
            this.parent = parent;
            children = new List<IMenuItem>();
            isDir = AppUtils.PathIsDirectory(tiPath.path);
            isFile = AppUtils.PathIsFile(tiPath.path);
            MakeChildren();
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
                            children.Add(new IMenuItem(instance, new TrayInstancePath(fp), this));
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
            instance.view.notifyIcon.ContextMenuStrip.AutoClose = true;
            instance.view.notifyIcon.ContextMenuStrip.Enabled = true;
            instance.view.notifyIcon.ContextMenuStrip.Close();
        }
        private void MenuSave()
        {
            IMenuItem mi = parent;
            instance.view.notifyIcon.ContextMenuStrip.Show();
            while (mi != null)
            {
                mi.menuItem.DropDown.AutoClose = false;
                mi.menuItem.DropDown.Show();
                mi.menuItem.Enabled = false;
                mi = mi.parent;
            }
            instance.view.notifyIcon.ContextMenuStrip.AutoClose = false;
            instance.view.notifyIcon.ContextMenuStrip.Enabled = false;
        }
        private void Run(object obj, EventArgs args)
        {
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
            {
                AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, false);
            }
            else if (isFile)
            {
                AppUtils.OpenPath(Path.GetFullPath(tiPath.path), false);
            }
        }
        private void Explore(object obj, EventArgs args)
        {
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
            {
                AppUtils.ExplorePath(new DirectoryInfo(tiPath.path).FullName);
            }
            else if (isFile)
            {
                AppUtils.ExplorePath(Path.GetFullPath(tiPath.path));
            }
        }
        private void RunAs(object obj, EventArgs args)
        {
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
            {
                AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, true);
            }
            else if (isFile)
            {
                AppUtils.OpenPath(Path.GetFullPath(tiPath.path), true);
            }
        }
        private void OpenCmd(object obj, EventArgs args)
        {
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
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
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
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
                    tsi = cmnu.Items.Add("Open in Explorer");
                    tsi.Click += Explore;
                    tsi = cmnu.Items.Add("Open in cmd");
                    tsi.Click += OpenCmd;
                    tsi = cmnu.Items.Add("Open in cmd (Administrator)");
                    tsi.Click += OpenAdminCmd;
                }
                else if (isFile)
                {
                    tsi = cmnu.Items.Add("Run");
                    tsi.Click += Run;
                    tsi = cmnu.Items.Add("Run (Administrator)");
                    tsi.Click += RunAs;
                    tsi = cmnu.Items.Add("Open in Explorer");
                    tsi.Click += Explore;
                    tsi = cmnu.Items.Add("Open in cmd");
                    tsi.Click += OpenCmd;
                    tsi = cmnu.Items.Add("Open in cmd (Administrator)");
                    tsi.Click += OpenAdminCmd;
                }
                else
                {
                    MenuDestroy(null, null);
                }
                cmnu.Show();
                cmnu.Location = pt;
                cmnu.Closing += MenuDestroy;
            }
            else
            {
                if (isDir & instance.settings.ExploreFoldersInTrayMenu)
                {
                    AppUtils.OpenPath(new DirectoryInfo(tiPath.path).FullName, instance.settings.RunAsAdmin);
                }
                else if (isFile)
                {
                    AppUtils.OpenPath(Path.GetFullPath(tiPath.path), instance.settings.RunAsAdmin);
                }
            }
        }
        public void Load()
        {
            if (menuItem == null)
            {
                menuItem = new ToolStripMenuItem();
            }
            bool useAlias = (tiPath.alias != null && tiPath.alias != "");

            if (useAlias)
            {
                menuItem.Text = tiPath.alias;
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
            }

            menuItem.DropDownItems.Clear();
            List<IMenuItem> dirMenuItems = new List<IMenuItem>();
            List<IMenuItem> fileMenuItems = new List<IMenuItem>();
            foreach (IMenuItem child in children)
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
            if (children.Count == 0 && isDir)
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
                foreach (IMenuItem child in children)
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
            if (loadedIcon && menuIcon != null)
            {
                menuItem.Image = menuIcon;
            }
            if (ret)
            {
                foreach (IMenuItem child in children)
                {
                    ret = child.LoadIcon() && ret;
                }
            }
            return ret && (isDir || menuItem.Image != null);
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
        }
        public void LoadChildrenIconEvent(Object obj, EventArgs args)
        {
            if (!imgLoadThread.IsAlive)
            {
                imgLoadThread = new Thread(LoadIconThread);
                imgLoadThread.Start();
            }
            foreach (IMenuItem child in children)
            {
                child.EnqueueImgLoad();
            }
        }
        public bool ClearIcon()
        {
            bool ret = !loadedIcon;
            if (menuItem.Image != null)
            {
                menuIcon = menuItem.Image;
                menuItem.Image = null;
            }
            if (ret)
            {
                foreach (IMenuItem child in children)
                {
                    ret = child.ClearIcon() && ret;
                }
            }
            loadedIcon = false;
            return ret;
        }
    }
}
