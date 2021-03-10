using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace TrayDir
{
    public class TrayInstance
    {
        [XmlElement(ElementName = "Settings")]
        public TrayInstanceSettings settings;

        public string instanceName { get { return settings.InstanceName; } set { settings.InstanceName = value; } }
        public string iconPath { get { return settings.iconPath; } set { settings.iconPath = value; } }
        private NotifyIcon notifyIcon;
        public TrayInstance() : this("default-instance") { }
        public TrayInstance(string instanceName) : this(new TrayInstanceSettings(instanceName))
        {
        }
        public TrayInstance(TrayInstanceSettings settings)
        {
            this.settings = settings;
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            //notifyIcon.DoubleClick += MainForm.form.ShowApp;
        }
        public bool BrowseForIcon()
        {
            string newPath = TrayUtils.BrowseForIconPath(iconPath);
            if (newPath != null)
            {
                SettingsForm.form.TrayIconPathTextBox.Text = newPath;
                settings.iconText = SettingsForm.form.TrayIconPathTextBox.Text;
                UpdateTrayMenu();
                Settings.Alter();
                return true;
            }
            return false;
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
            notifyIcon.ContextMenuStrip.Items.Add("Show", null, MainForm.form.ShowApp);
            notifyIcon.ContextMenuStrip.Items.Add("Hide", null, MainForm.form.HideApp);

            notifyIcon.ContextMenuStrip.Items.Add("-");

            if (settings.paths.Count == 1)
            {
                String path = settings.paths[0];
                /*ToolStripMenuItem mi = AppUtils.RecursivePathFollow(instances[0].settings, path);
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
                }*/
            }
            else
            {
                foreach (string path in settings.paths)
                {
                    notifyIcon.ContextMenuStrip.Items.Add(AppUtils.RecursivePathFollow(settings, path));
                }
            }
            notifyIcon.ContextMenuStrip.Items.Add("-");

            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, MainForm.form.ExitApp);
            notifyIcon.ContextMenuStrip.Items[0].Visible = false;
            UpdateTrayIcon();
        }
        private void UpdateTrayIcon()
        {
            string iconPath = settings.iconPath;
            if (AppUtils.PathIsFile(iconPath))
            {
                try
                {
                    SettingsForm.form.TrayIconPathTextBox.Text = iconPath;
                    notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                    SettingsForm.form.IconDisplay.Image = notifyIcon.Icon.ToBitmap();
                    SettingsForm.form.Icon = notifyIcon.Icon;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading icon: " + e.Message);
                }
            }
            SettingsForm.form.TrayTextTextBox.Text = settings.iconText;
            notifyIcon.Text = settings.iconText;
        }
        public void AddPath(string path)
        {
            this.settings.paths.Add(path);
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
