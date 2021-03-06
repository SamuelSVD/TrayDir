﻿using System;
using System.Drawing;
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

            runasCheckBox.Checked = instance.settings.RunAsAdmin;
            showextensionsCheckBox.Checked = instance.settings.ShowFileExtensions;
            exploreCheckBox.Checked = instance.settings.ExploreFoldersInTrayMenu;
            expandFirstPathCheckBox.Checked = instance.settings.ExpandFirstPath;
            hideFromTrayCheckBox.Checked = instance.settings.HideFromTray;
        }
        private void runasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            instance.settings.RunAsAdmin = runasCheckBox.Checked;
        }
        private void showextensionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            instance.settings.ShowFileExtensions = showextensionsCheckBox.Checked;
            instance.view.tray.BuildTrayMenu();
        }
        private void exploreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            instance.settings.ExploreFoldersInTrayMenu = exploreCheckBox.Checked;
        }
        private void IOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProgramData.pd.Save();
        }
        private void expandFirstPathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            instance.settings.ExpandFirstPath = expandFirstPathCheckBox.Checked;
            instance.view.tray.BuildTrayMenu();
        }

        private void hideFromTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            instance.settings.HideFromTray = hideFromTrayCheckBox.Checked;
            if (instance.settings.HideFromTray)
            {
                instance.view.tray.Hide();
            }
            else
            {
                instance.view.tray.Show();
            }
        }
    }
}
