using FolderSelect;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrayDir
{
    public class IPathsView
    {
        public GroupBox pathsgb;
        public List<PathView> pathViews;
        public IPathsView(TrayInstance instance)
        {
            // Paths Group
            pathsgb = new GroupBox();
            pathsgb.Text = "Paths";
            ControlUtils.ConfigureGroupBox(pathsgb);

            TableLayoutPanel pathstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(pathstlp);
            pathsgb.Controls.Add(pathstlp);

            pathViews = new List<PathView>();
            for (int i = 0; i < instance.settings.paths.Count; i++)
            {
                string path = instance.settings.paths[i];
                int j = i;
                TextBox textbox = null;
                EventHandler fileSelect = new EventHandler(delegate (object obj, EventArgs args)
                {
                    MainForm.form.fd.DereferenceLinks = false;
                    MainForm.form.fd.InitialDirectory = textbox.Text;
                    DialogResult d = MainForm.form.fd.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        textbox.Text = MainForm.form.fd.FileName;
                        instance.settings.paths[j] = textbox.Text;
                        instance.view.UpdateTrayMenu();
                        MainForm.form.pd.Save();
                    }
                });
                EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
                {
                    FolderSelectDialog fs = new FolderSelectDialog();
                    fs.InitialDirectory = textbox.Text;
                    if (fs.ShowDialog())
                    {
                        textbox.Text = fs.FileName;
                        instance.settings.paths[j] = textbox.Text;
                        instance.view.UpdateTrayMenu();
                        MainForm.form.pd.Save();
                    }
                });
                PathView pv = ControlUtils.AddPath(pathstlp, i, path);
                pv.folderButton.Click += folderSelect;
                pv.fileButton.Click += fileSelect;
                pathViews.Add(pv);
            }
        }
        public Control GetControl()
        {
            return pathsgb;
        }
        public int GetHeight()
        {
            int height = 0;
            height += pathsgb.Padding.Bottom + pathsgb.Padding.Top + pathsgb.Margin.Top + pathsgb.Margin.Bottom + pathsgb.Bottom - pathsgb.Top;
            return height;
        }
    }
}
