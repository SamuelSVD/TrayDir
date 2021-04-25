using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public class IView
    {
        private TrayInstance instance;

        public Panel p;
        public TableLayoutPanel tlp;

        public IOptionsView options;
        public IPathsView paths;
        public Dictionary<string, IMenuItem> pathMenuItems;


        public NotifyIcon notifyIcon;

        private EventHandler showForm;
        private EventHandler hideForm;
        private EventHandler exitForm;

        private ToolStripMenuItem showMenuItem;
        private ToolStripMenuItem hideMenuItem;
        private ToolStripMenuItem exitMenuItem;

        public IView(TrayInstance instance)
        {
            this.instance = instance;
            instance.view = this;

            p = new Panel();
            p.Dock = DockStyle.Top;
            p.AutoSize = true;
            p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (Program.DEBUG) p.BackColor = Color.Violet;

            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            p.Controls.Add(tlp);

            options = new IOptionsView(instance);
            tlp.Controls.Add(options.GetControl(), 0, 0);

            paths = new IPathsView(instance);
            tlp.Controls.Add(paths.GetControl(), 0, 1);

            tlp.PerformLayout();

            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            UpdateTrayIcon();

            pathMenuItems = new Dictionary<string, IMenuItem>();
        }
        public void setEventHandlers(EventHandler showForm, EventHandler hideForm, EventHandler exitForm)
        {
            this.showForm = showForm;
            this.hideForm = hideForm;
            this.exitForm = exitForm;
        }
        public Control GetControl()
        {
            return p;
        }
        public int GetHeight()
        {
            int height = 0;
            height += tlp.Padding.Bottom + tlp.Padding.Top + tlp.Margin.Top + tlp.Margin.Bottom;
            height += options.GetHeight();
            height += paths.GetHeight();
            return height;
        }
        private ToolStripMenuItem MakeAndAddMenuItem(ToolStripMenuItem menuItem, string text, bool visible, EventHandler eh)
        {
            if (!(eh is null) && (menuItem == null))
            {
                menuItem = new ToolStripMenuItem(text, null, eh);
                menuItem.Visible = visible;
            }
            if (menuItem != null)
            {
                notifyIcon.ContextMenuStrip.Items.Add(menuItem);
            }
            return menuItem;
        }
        public void Rebuild()
        {
            pathMenuItems.Clear();
            UpdateTrayMenu();
        }
        public void MenuOpened(Object obj, EventArgs args)
        {
            if (instance.settings.ExpandFirstPath && instance.PathCount == 1)
            {
                foreach (IMenuItem child in pathMenuItems.Values)
                {
                    child.EnqueueImgLoad();
                    foreach (IMenuItem subchild in child.children)
                    {
                        subchild.EnqueueImgLoad();
                    }
                }
            } else
            {
                foreach (IMenuItem child in pathMenuItems.Values)
                {
                    child.EnqueueImgLoad();
                }
            }
            MainForm.form.iconLoadTimer.Start();
        }
        public void MenuClosed(Object obj, EventArgs args)
        {
            MainForm.form.iconLoadTimer.Stop();
        }
        public void UpdateTrayMenu()
        {
            if (notifyIcon.ContextMenuStrip is null)
            {
                notifyIcon.ContextMenuStrip = new ContextMenuStrip();
                notifyIcon.ContextMenuStrip.Opened += MenuOpened;
                notifyIcon.ContextMenuStrip.Closed += MenuClosed;
            }
            else
            {
                notifyIcon.ContextMenuStrip.Items.Clear();
            }
            showMenuItem = MakeAndAddMenuItem(showMenuItem, "Show", false, showForm);
            hideMenuItem = MakeAndAddMenuItem(hideMenuItem, "Hide", true, hideForm);

            notifyIcon.ContextMenuStrip.Items.Add("-");

            foreach (TrayInstancePath tiPath in instance.paths)
            {
                IMenuItem mi;
                string ID = tiPath.GetHashCode().ToString();
                if (!pathMenuItems.TryGetValue(ID, out mi))
                {
                    mi = new IMenuItem(instance, tiPath);
                    pathMenuItems[ID] = mi;
                }
            }
            foreach (IMenuItem mi in pathMenuItems.Values)
            {
                mi.Load();
            }

            if (instance.PathCount == 1 && instance.settings.ExpandFirstPath)
            {
                string ID = instance.paths[0].GetHashCode().ToString();
                IMenuItem mi = pathMenuItems[ID];
                if (mi.children.Count > 0)
                {
                    if (mi.children.Count != mi.menuItem.DropDownItems.Count)
                    {
                        mi.menuItem.DropDownItems.Clear();
                    }
                    List<IMenuItem> dirMenuItems = new List<IMenuItem>();
                    List<IMenuItem> fileMenuItems = new List<IMenuItem>();

                    foreach (IMenuItem child in mi.children)
                    {
                        if (child.isDir)
                        {
                            dirMenuItems.Add(child);
                        } else if (child.isFile)
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
                                notifyIcon.ContextMenuStrip.Items.Add(child.menuItem);
                            }
                            foreach (IMenuItem child in fileMenuItems)
                            {
                                notifyIcon.ContextMenuStrip.Items.Add(child.menuItem);
                            }
                        }
                        else
                        {
                            foreach (IMenuItem child in fileMenuItems)
                            {
                                notifyIcon.ContextMenuStrip.Items.Add(child.menuItem);
                            }
                            foreach (IMenuItem child in dirMenuItems)
                            {
                                notifyIcon.ContextMenuStrip.Items.Add(child.menuItem);
                            }
                        }
                    }
                    else
                    {
                        foreach (IMenuItem child in mi.children)
                        {
                            notifyIcon.ContextMenuStrip.Items.Add(child.menuItem);
                        }
                    }
                }
                else
                {
                    notifyIcon.ContextMenuStrip.Items.Add(mi.menuItem);
                }
            }
            else
            {
                foreach (TrayInstancePath tiPath in instance.paths)
                {
                    IMenuItem mi;
                    string ID = tiPath.GetHashCode().ToString();
                    if (!pathMenuItems.TryGetValue(ID, out mi))
                    {
                        mi = new IMenuItem(instance, tiPath);
                        mi.Load();
                        pathMenuItems[ID] = mi;
                    }
                    notifyIcon.ContextMenuStrip.Items.Add(mi.menuItem);

                    if (mi.children.Count != mi.menuItem.DropDownItems.Count)
                    {
                        mi.menuItem.DropDownItems.Clear();
                        List<IMenuItem> dirMenuItems = new List<IMenuItem>();
                        List<IMenuItem> fileMenuItems = new List<IMenuItem>();

                        if (ProgramData.pd.settings.app.MenuSorting != "None")
                        {
                            if (ProgramData.pd.settings.app.MenuSorting == "Folders Top")
                            {
                                foreach (IMenuItem child in dirMenuItems)
                                {
                                    mi.menuItem.DropDownItems.Add(child.menuItem);
                                }
                                foreach (IMenuItem child in fileMenuItems)
                                {
                                    mi.menuItem.DropDownItems.Add(child.menuItem);
                                }
                            }
                            else
                            {
                                foreach (IMenuItem child in fileMenuItems)
                                {
                                    mi.menuItem.DropDownItems.Add(child.menuItem);
                                }
                                foreach (IMenuItem child in dirMenuItems)
                                {
                                    mi.menuItem.DropDownItems.Add(child.menuItem);
                                }
                            }
                        }
                        else
                        {
                            foreach (IMenuItem child in mi.children)
                            {
                                mi.menuItem.DropDownItems.Add(child.menuItem);
                            }
                        }
                    }
                }
            }

            notifyIcon.ContextMenuStrip.Items.Add("-");
            exitMenuItem = MakeAndAddMenuItem(exitMenuItem, "Exit", true, exitForm);

            UpdateTrayIcon();
        }
        public bool UpdateMenuIcons()
        {
            bool ret = true;
            foreach (IMenuItem i in pathMenuItems.Values)
            {
                if (ProgramData.pd.settings.app.ShowIconsInMenus)
                {
                    ret = i.LoadIcon() && ret;
                }
                else
                {
                    ret = i.ClearIcon() && ret;
                }
            }
            return ret;
        }
        public void UpdateTrayIcon()
        {
            Icon i = this.GetInstanceIcon();
            if (i != null && ((instance.iconPath != null) || (instance.iconData == null)))
            {
                notifyIcon.Icon = i;
                instance.iconData = TrayUtils.IconToBytes(i);
                instance.iconPath = null;
            }
            notifyIcon.Text = instance.instanceName;
            notifyIcon.Icon = i;
        }
        public Icon GetInstanceIcon()
        {
            Icon i;
            try
            {
                if (instance.iconData != null)
                {
                    i = TrayUtils.BytesToIcon(instance.iconData);
                }
                else if (AppUtils.PathIsFile(instance.iconPath))
                {
                    i = Icon.ExtractAssociatedIcon(instance.iconPath);
                }
                else
                {
                    i = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading icon: " + e.Message);
                i = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            return i;
        }
        public void Hide()
        {
            notifyIcon.Visible = false;
        }
        public void SetFormHiddenMenu()
        {
            notifyIcon.ContextMenuStrip.Items[0].Visible = true;
            notifyIcon.ContextMenuStrip.Items[1].Visible = false;
        }
        public void SetFormShownMenu()
        {
            showMenuItem.Visible = false;
            hideMenuItem.Visible = true;
        }
    }
}
