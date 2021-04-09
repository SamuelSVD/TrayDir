using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public class IView
    {
        public Panel p;
        TableLayoutPanel tlp;

        public IOptionsView options;
        public IPathsView paths;
        private TrayInstance instance;

        public NotifyIcon notifyIcon;
        private EventHandler showForm;
        private EventHandler hideForm;
        private EventHandler exitForm;
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
            if (!(showForm is null))
            {
                notifyIcon.ContextMenuStrip.Items.Add("Show", null, showForm);
            }
            if (!(hideForm is null))
            {
                notifyIcon.ContextMenuStrip.Items.Add("Hide", null, hideForm);
            }

            notifyIcon.ContextMenuStrip.Items.Add("-");

            if (instance.settings.paths.Count == 1 && instance.settings.ExpandFirstPath)
            {
                String path = instance.settings.paths[0];
                ToolStripMenuItem mi = AppUtils.RecursivePathFollow(instance.settings, path);
                if (mi.DropDownItems.Count > 0)
                {
                    while (mi.DropDownItems.Count > 0)
                    {
                        ToolStripItem item = mi.DropDownItems[0];
                        mi.DropDownItems.RemoveAt(0);
                        notifyIcon.ContextMenuStrip.Items.Add(item);
                    }
                }
                else
                {
                    notifyIcon.ContextMenuStrip.Items.Add(mi);
                }
            }
            else
            {
                foreach (string path in instance.settings.paths)
                {
                    notifyIcon.ContextMenuStrip.Items.Add(AppUtils.RecursivePathFollow(instance.settings, path));
                }
            }
            notifyIcon.ContextMenuStrip.Items.Add("-");

            if (!(exitForm is null))
            {
                notifyIcon.ContextMenuStrip.Items.Add("Exit", null, exitForm);
            }
            notifyIcon.ContextMenuStrip.Items[0].Visible = false;
            UpdateTrayIcon();
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
            notifyIcon.ContextMenuStrip.Items[0].Visible = false;
            notifyIcon.ContextMenuStrip.Items[1].Visible = true;
        }
    }
}
