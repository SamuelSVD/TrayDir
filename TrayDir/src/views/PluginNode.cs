using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
    public class PluginNode
    {
        public TreeNode node;
        public TrayPlugin tp;
        public Icon icon;
        public PluginNode()
        {
            node = new TreeNode();
        }
        public void UpdateNode()
        {
            string s = "";
            if (tp.name == null || tp.name == "")
            {
                //s += "<No Name>";
            } 
            else
            {
                s += tp.name;
            }
            if (tp.path == null || tp.path == "")
            {
                s += " (No Path Selected)";
            }
            else
            {
                s += " (" + tp.path + ")";
            }
            node.Text = s;
            if (AppUtils.PathIsFile(tp.path))
            {
                Bitmap i = IconUtils.lookupIcon(tp.getSignature());
                if (i == null)
                {
                    i = Icon.ExtractAssociatedIcon(tp.path).ToBitmap();
                    IconUtils.addIcon(tp.getSignature(), i);
                }
                node.TreeView.ImageList.Images.Add(i);
                node.ImageIndex = node.TreeView.ImageList.Images.Count - 1;
            } else
            {
                node.ImageIndex = - 1;
            }
            node.SelectedImageIndex = node.ImageIndex;
        }
    }
}
