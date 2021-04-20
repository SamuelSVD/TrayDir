using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace TrayDir
{
    public class IMenuItem
    {
        private TrayInstance instance;
        public ToolStripMenuItem menuItem;
        public List<IMenuItem> children;
        public IMenuItem parent;
        private Image menuIcon;
        private Thread imgLoadThread;

        public readonly bool isDir = false;
        public readonly bool isFile = false;
        public string path;
        private bool loadedIcon = false;

        private static List<string> pathsLoadedHistory;

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
        public IMenuItem(TrayInstance instance, string path) : this(instance, path, null) { }
        public IMenuItem(TrayInstance instance, string path, IMenuItem parent)
        {
            if (pathsLoadedHistory is null)
            {
                pathsLoadedHistory = new List<string>();
            }
            this.instance = instance;
            this.path = path;
            this.parent = parent;
            children = new List<IMenuItem>();
            isDir = AppUtils.PathIsDirectory(path);
            isFile = AppUtils.PathIsFile(path);
            MakeChildren();
        }
        private void MakeChildren()
        {
            if (isDir)
            {
                try
                {
                    string[] dirpaths = Directory.GetFileSystemEntries(path);
                    foreach (string fp in dirpaths)
                    {
                        children.Add(new IMenuItem(instance, fp, this));
                    }
                }
                catch { }
            }
        }
        public void MenuItemClick(object obj, EventArgs args)
        {
            if (isDir & instance.settings.ExploreFoldersInTrayMenu)
            {
                AppUtils.OpenPath(new DirectoryInfo(path).FullName, instance.settings.RunAsAdmin);
            }
            else if (isFile)
            {
                AppUtils.OpenPath(Path.GetFullPath(path), instance.settings.RunAsAdmin);
            }
        }
        public void Load()
        {
            if (menuItem == null)
            {
                menuItem = new ToolStripMenuItem();
            }
            if (isDir)
            {
                menuItem.Text = new DirectoryInfo(path).Name;
            }
            else if (isFile)
            {
                if (instance.settings.ShowFileExtensions)
                {
                    menuItem.Text = Path.GetFileName(path);
                }
                else
                {
                    menuItem.Text = Path.GetFileNameWithoutExtension(path);
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
            menuItem.Click += MenuItemClick;
        }
        private void LoadIconThread()
        {
            Thread.Sleep(1);
            if (isFile)
            {
                try
                {
                    menuIcon = Icon.ExtractAssociatedIcon(path).ToBitmap();
                }
                catch
                {
                }
            }
        }
        public bool LoadIcon()
        {
            bool ret = loadedIcon;
            if (menuIcon != null)
            {
                menuItem.Image = menuIcon;
            }
            if ((menuIcon == null) && (imgLoadThread is null))
            {
                imgLoadThread = new Thread(LoadIconThread);
                imgLoadThread.Start();
                pathsLoadedHistory.Add(instance.instanceName + " || " + path);
                if (path == "C:\\Users\\svd_m\\Desktop\\TrayDir\\Folder1\\f1\\1.txt")
                {
                    path = path;
                }
                if (path == "C:\\Users\\svd_m\\Desktop\\TrayDir\\Folder2\\2.txt")
                {
                    path = path;
                }
            }
            if (ret)
            {
                foreach (IMenuItem child in children)
                {
                    ret = child.LoadIcon() && ret;
                }
            }
            loadedIcon = true;
            return ret;
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
                    child.ClearIcon();
                }
            }
            loadedIcon = false;
            return ret;
        }
    }
}
