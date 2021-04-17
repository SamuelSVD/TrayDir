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
        public void UpdateTrayMenu()
        {
            if (notifyIcon.ContextMenuStrip is null)
            {
                notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            }
            else
            {
                notifyIcon.ContextMenuStrip.Items.Clear();
            }
            showMenuItem = MakeAndAddMenuItem(showMenuItem, "Show", false, showForm);
            hideMenuItem = MakeAndAddMenuItem(hideMenuItem, "Hide", true, hideForm);

            notifyIcon.ContextMenuStrip.Items.Add("-");

            foreach (string path in instance.settings.paths)
            {
                IMenuItem i;
                if (!pathMenuItems.TryGetValue(path, out i))
                {
                    i = new IMenuItem(instance, path);
                    i.Load();
                    pathMenuItems[path] = i;
                }
            }

            if (instance.settings.paths.Count == 1 && instance.settings.ExpandFirstPath)
            {
                IMenuItem i = pathMenuItems[instance.settings.paths[0]];
                if (i.menuItem.DropDownItems.Count > 0)
                {
                    while (i.menuItem.DropDownItems.Count > 0)
                    {
                        ToolStripItem item = i.menuItem.DropDownItems[0];
                        i.menuItem.DropDownItems.RemoveAt(0);
                        notifyIcon.ContextMenuStrip.Items.Add(item);
                    }
                }
                else
                {
                    notifyIcon.ContextMenuStrip.Items.Add(i.menuItem);
                }
            }
            else
            {
                foreach (string path in instance.settings.paths)
                {
                    IMenuItem i;
                    if (!pathMenuItems.TryGetValue(path, out i))
                    {
                        i = new IMenuItem(instance, path);
                        i.Load();
                        pathMenuItems[path] = i;
                    }
                    notifyIcon.ContextMenuStrip.Items.Add(i.menuItem);
                }
            }

            notifyIcon.ContextMenuStrip.Items.Add("-");
            exitMenuItem = MakeAndAddMenuItem(exitMenuItem, "Exit", true, exitForm);

            foreach(IMenuItem i in pathMenuItems.Values)
            {
                if (ProgramData.pd.settings.app.ShowIconsInMenus)
                {
                    i.LoadIcon();
                }
                else
                {
                    i.ClearIcon();
                }
            }

            UpdateTrayIcon();

            if (instance.settings.paths.Count == 1 && instance.settings.ExpandFirstPath)
            {
                pathMenuItems.Clear();
            }

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
