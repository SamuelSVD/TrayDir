using FolderSelect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public class IPathsView
    {
        public GroupBox pathsgb;
        public List<PathView> pathViews;
        private TrayInstance instance;
        private TableLayoutPanel pathstlp;
        public IPathsView(TrayInstance instance)
        {
            this.instance = instance;
            // Paths Group
            pathsgb = new GroupBox();
            pathsgb.Text = "Paths";
            ControlUtils.ConfigureGroupBox(pathsgb);

            pathstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(pathstlp);
            pathsgb.Controls.Add(pathstlp);

            pathViews = new List<PathView>();
            FixPaths();
        }
        public Control GetControl()
        {
            return pathsgb;
        }
        public void AddPath(int i)
        {
            int j = i;
            PathView pv = ControlUtils.AddPath(pathstlp, i);
            pv.trayInstancePath = instance.paths[i];
            string text = instance.paths[i].path;
            if (AppUtils.PathIsDirectory(text))
            {
                pv.textbox.Text = new DirectoryInfo(text).FullName;
            }
            else if (AppUtils.PathIsFile(text))
            {
                pv.textbox.Text = Path.GetFullPath(text);
            }
            else
            {
                pv.textbox.Text = text;
            }

            pv.SetEvents(instance, i);
            pathViews.Add(pv);
        }
        public void RemovePath(int i)
        {
            if (i < pathViews.Count)
            {
                PathView pv = pathViews[pathViews.Count - 1];
                pv.RemoveFromControl(pathstlp);
                pathViews.Remove(pv);
            }
            FixPaths();
        }
        public void FixPaths()
        {
            int p = instance.PathCount;
            int v = pathViews.Count;
            while (p < v)
            {
                p = instance.PathCount;
                v = pathViews.Count;
                RemovePath(v-1);
            }
            while (p > v)
            {
                AddPath(v);
                p = instance.PathCount;
                v = pathViews.Count;
            }
            for(int i = 0; i < pathViews.Count; i++)
            {
                PathView pv = pathViews[i];
                pv.upButton.Enabled = (pathViews.Count != 1) && (i > 0);
                pv.downButton.Enabled = (pathViews.Count != 1) && (i < pathViews.Count - 1);
                pv.deleteButton.Enabled = pathViews.Count != 1;
                pv.SetEvents(instance, i);

                string text = instance.paths[i].path;
                if (AppUtils.PathIsDirectory(text))
                {
                    pv.textbox.Text = new DirectoryInfo(text).FullName;
                }
                else if (AppUtils.PathIsFile(text))
                {
                    pv.textbox.Text = Path.GetFullPath(text);
                }
                else
                {
                    pv.textbox.Text = text;
                }
            }
        }
    }
}
