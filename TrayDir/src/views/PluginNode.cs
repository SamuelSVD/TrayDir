using System.Drawing;
using System.Windows.Forms;

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
        }
    }
}
