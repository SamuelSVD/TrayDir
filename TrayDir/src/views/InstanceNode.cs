using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
    public class InstanceNode
    {
        public TreeNode node;
        public TrayInstance trayInstance;
        public Icon icon;
        public InstanceNode()
        {
            node = new TreeNode();
        }
        public void UpdateNode()
        {
            string s = "";
            if (trayInstance.instanceName == null || trayInstance.instanceName == "")
            {
                s += "<No Name>";
            } 
            else
            {
                s += trayInstance.instanceName;
            }
            node.Text = s;
        }
    }
}
