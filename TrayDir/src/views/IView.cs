using System;
using System.Windows.Forms;

namespace TrayDir
{
    public class IView
    {
        TableLayoutPanel tlp;

        IOptionView options;
        IPathView paths;
        private TrayInstance instance;

        private NotifyIcon notifyIcon;
        private EventHandler showForm;
        private EventHandler hideForm;
        private EventHandler exitForm;
        public IView(TrayInstance instance)
        {
            this.instance = instance;
            instance.view = this;
            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);

            options = new IOptionView(instance);
            tlp.Controls.Add(options.GetControl(), 0, 0);

            paths = new IPathView(instance);
            tlp.Controls.Add(paths.GetControl(), 0, 1);

            tlp.PerformLayout();

            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
        }
        public void setEventHandlers(EventHandler showForm, EventHandler hideForm, EventHandler exitForm)
        {
            this.showForm = showForm;
            this.hideForm = hideForm;
            this.exitForm = exitForm;
        }
        public Control GetControl()
        {
            return tlp;
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

            if (instance.settings.paths.Count == 1)
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
        private void UpdateTrayIcon()
        {
            if (AppUtils.PathIsFile(instance.iconPath))
            {
                try
                {
                    //SettingsForm.form.TrayIconPathTextBox.Text = iconPath;
                    notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(instance.iconPath);
                    //SettingsForm.form.IconDisplay.Image = notifyIcon.Icon.ToBitmap();
                    //SettingsForm.form.Icon = notifyIcon.Icon;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading icon: " + e.Message);
                }
            }
            //SettingsForm.form.TrayTextTextBox.Text = settings.iconText;
            notifyIcon.Text = instance.iconText;
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
        public bool BrowseForIcon()
        {
            string newPath = TrayUtils.BrowseForIconPath(instance.iconPath);
            if (newPath != null)
            {
                //SettingsForm.form.TrayIconPathTextBox.Text = newPath;
                //instance.iconText = SettingsForm.form.TrayIconPathTextBox.Text;
                UpdateTrayMenu();
                Settings.Alter();
                return true;
            }
            return false;
        }
    }
}
