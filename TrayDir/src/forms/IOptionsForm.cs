using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class IOptionsForm : Form
    {
        TrayInstance instance;
        public IOptionsForm(TrayInstance instance)
        {
            InitializeComponent();
            this.instance = instance;
            Icon = instance.view.tray.notifyIcon.Icon;
            iconBox.Image = Icon.ToBitmap();

            EventHandler bClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                string newPath = TrayUtils.BrowseForIconPath(instance.iconPath);
                if (newPath != null)
                {
                    instance.iconPath = newPath;
                    instance.iconData = null;
                    resetButton.Enabled = true;
                    instance.view.tray.UpdateTrayIcon();
                    instance.view.tray.UpdateTrayIcon();
                    iconBox.Image = instance.view.tray.notifyIcon.Icon.ToBitmap();
                    MainForm.form.pd.Save();
                }
            });
            browseButton.Click += bClick;

            bClick = new EventHandler(delegate (object obj, EventArgs args)
            {

                instance.iconPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                instance.iconData = null;
                instance.view.tray.UpdateTrayIcon();
                iconBox.Image = instance.view.tray.notifyIcon.Icon.ToBitmap();
                MainForm.form.pd.Save();
                resetButton.Enabled = false;
            });
            resetButton.Click += bClick;
        }
    }
}
