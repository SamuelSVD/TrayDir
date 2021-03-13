using System;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace TrayDir
{
    [XmlRoot(ElementName = "Instance")]
    public class TrayInstance
    {
        [XmlElement(ElementName = "Settings")]
        public TrayInstanceSettings settings;
        [XmlAttribute]
        public string iconPath;
        [XmlAttribute]
        public string iconText;
        [XmlAttribute]
        public string instanceName;
        private NotifyIcon notifyIcon;
        private EventHandler showForm;
        private EventHandler hideForm;
        private EventHandler exitForm;

        public TrayInstance() : this("New Instance") { }
        public TrayInstance(string instanceName) : this(instanceName, new TrayInstanceSettings())
        {
        }
        public TrayInstance(String instanceName, TrayInstanceSettings settings)
        {
            this.settings = settings;
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            //notifyIcon.DoubleClick += MainForm.form.ShowApp;
            iconPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            this.instanceName = instanceName;
            iconText = "TrayDir";
        }
        public bool BrowseForIcon()
        {
            string newPath = TrayUtils.BrowseForIconPath(iconPath);
            if (newPath != null)
            {
                SettingsForm.form.TrayIconPathTextBox.Text = newPath;
                iconText = SettingsForm.form.TrayIconPathTextBox.Text;
                UpdateTrayMenu();
                Settings.Alter();
                return true;
            }
            return false;
        }
        public void setEventHandlers(EventHandler showForm, EventHandler hideForm, EventHandler exitForm)
        {
            this.showForm = showForm;
            this.hideForm = hideForm;
            this.exitForm = exitForm;
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

            if (settings.paths.Count == 1)
            {
                String path = settings.paths[0];
                ToolStripMenuItem mi = AppUtils.RecursivePathFollow(settings, path);
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
                foreach (string path in settings.paths)
                {
                    notifyIcon.ContextMenuStrip.Items.Add(AppUtils.RecursivePathFollow(settings, path));
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
            if (AppUtils.PathIsFile(iconPath))
            {
                try
                {
                    //SettingsForm.form.TrayIconPathTextBox.Text = iconPath;
                    notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                    //SettingsForm.form.IconDisplay.Image = notifyIcon.Icon.ToBitmap();
                    //SettingsForm.form.Icon = notifyIcon.Icon;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading icon: " + e.Message);
                }
            }
            //SettingsForm.form.TrayTextTextBox.Text = settings.iconText;
            notifyIcon.Text = iconText;
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
