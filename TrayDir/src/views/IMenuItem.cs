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

        protected bool isDir = false;
        protected bool isFile = false;
        public string path;
        private bool loadedIcon;

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
            loadedIcon = true;
        }
        public bool LoadIcon()
        {
            bool ret = loadedIcon;
            if (loadedIcon && menuIcon != null)
            {
                menuItem.Image = menuIcon;
            }
            if (!loadedIcon && (imgLoadThread is null || !imgLoadThread.IsAlive))
            {
                imgLoadThread = new Thread(LoadIconThread);
                imgLoadThread.Start();
            }
            if (ret)
            {
                foreach (IMenuItem child in children)
                {
                    ret = ret && child.LoadIcon();
                }
            }
            return ret;
        }
        public bool ClearIcon()
        {
            if (menuItem.Image != null)
            {
                menuIcon = menuItem.Image;
                menuItem.Image = null;
            }
            foreach (IMenuItem child in children)
            {
                child.ClearIcon();
            }
            return true;
        }
    }
}
