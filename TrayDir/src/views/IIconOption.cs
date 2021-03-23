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
            iconFileDialog.DereferenceLinks = false;
            browseButton = new Button();
            browseButton.Text = "Browse";
            browseButton.Anchor = AnchorStyles.None;
            browseButton.AutoSize = true;
            browseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Dock = DockStyle.Fill;

            EventHandler bClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                string newPath = TrayUtils.BrowseForIconPath(instance.iconPath);
                if (newPath != null)
                {
                    instance.iconPath = newPath;
                    Icon i = Icon.ExtractAssociatedIcon(instance.iconPath);
                    instance.view.notifyIcon.Icon = i;
                    picturebox.Image = i.ToBitmap();
                    MainForm.form.pd.Save();
                    resetButton.Enabled = true;
                    instance.view.UpdateTrayMenu();
                }
            });
            browseButton.Click += bClick;

            resetButton = new Button();
            resetButton.Text = "Reset";
            resetButton.Anchor = AnchorStyles.None;
            resetButton.AutoSize = true;
            resetButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Dock = DockStyle.Fill;

            resetButton.Enabled = (instance.iconPath != System.Reflection.Assembly.GetEntryAssembly().Location);

            bClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                
                instance.iconPath = System.Reflection.Assembly.GetEntryAssembly().Location; ;
                Icon i = Icon.ExtractAssociatedIcon(instance.iconPath);
                instance.view.notifyIcon.Icon = i;
                picturebox.Image = i.ToBitmap();
                MainForm.form.pd.Save();
                resetButton.Enabled = false;
            });
            resetButton.Click += bClick;

            picturebox = new PictureBox();
            picturebox.Image = Icon.ExtractAssociatedIcon(instance.iconPath).ToBitmap();
            picturebox.Anchor = AnchorStyles.None;
            picturebox.Width = browseButton.Width;
            if (Program.DEBUG) picturebox.BackColor = Color.Purple;
            picturebox.BorderStyle = BorderStyle.FixedSingle;
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            picturebox.AutoSize = true;
            picturebox.Dock = DockStyle.Fill;


            tlp.Controls.Add(picturebox, 0, 0);
            tlp.Controls.Add(browseButton, 0, 1);
            tlp.Controls.Add(resetButton, 0, 2);

            for (int i = 0; i < 3; i++)
            {
                if (tlp.ColumnStyles.Count < i + 1)
                {
                    RowStyle rs = new RowStyle();
                    rs.SizeType = SizeType.AutoSize;
                    tlp.RowStyles.Add(rs);
                }
            }
        }
        public Control GetControl()
        {
            return tlp;
        }
    }
}
