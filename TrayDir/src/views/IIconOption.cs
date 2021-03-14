using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir
{
    class IIconOption
    {
        OpenFileDialog iconFileDialog;
        Button browseButton;
        Button resetButton;
        TableLayoutPanel tlp;
        PictureBox picturebox;
        public IIconOption(TrayInstance instance)
        {
            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            iconFileDialog = new OpenFileDialog();
            browseButton = new Button();
            browseButton.Text = "Browse";
            browseButton.Anchor = AnchorStyles.None;

            EventHandler bClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                if (iconFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string iconPath = iconFileDialog.FileName;
                    instance.iconPath = iconPath;
                    Icon i = System.Drawing.Icon.ExtractAssociatedIcon(instance.iconPath);
                    instance.view.notifyIcon.Icon = i;
                    picturebox.Image = i.ToBitmap();
                    MainForm.form.pd.Save();
                    resetButton.Enabled = true;
                }
            });
            browseButton.Click += bClick;

            resetButton = new Button();
            resetButton.Text = "Reset";
            resetButton.Anchor = AnchorStyles.None;
            resetButton.Enabled = (instance.iconPath != System.Reflection.Assembly.GetEntryAssembly().Location);

            bClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                
                instance.iconPath = System.Reflection.Assembly.GetEntryAssembly().Location; ;
                Icon i = System.Drawing.Icon.ExtractAssociatedIcon(instance.iconPath);
                instance.view.notifyIcon.Icon = i;
                picturebox.Image = i.ToBitmap();
                MainForm.form.pd.Save();
                resetButton.Enabled = false;
            });
            resetButton.Click += bClick;

            picturebox = new PictureBox();
            picturebox.Image = System.Drawing.Icon.ExtractAssociatedIcon(instance.iconPath).ToBitmap();
            picturebox.Anchor = AnchorStyles.None;
            picturebox.Width = browseButton.Width;
            if (Program.DEBUG) picturebox.BackColor = Color.Purple;
            picturebox.BorderStyle = BorderStyle.FixedSingle;
            picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            tlp.Controls.Add(picturebox, 0, 0);
            tlp.Controls.Add(browseButton, 0, 1);
            tlp.Controls.Add(resetButton, 0, 2);

        }
        public Control GetControl()
        {
            return tlp;
        }
    }
}
