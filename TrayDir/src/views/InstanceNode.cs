using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
	public class InstanceNode
	{
		public TreeNode node;
		public TrayInstance instance;
		public Icon icon;
		public InstanceNode()
		{
			node = new TreeNode();
		}
		public void UpdateNode()
		{
			string s = string.Empty;
			if (instance.instanceName == null || instance.instanceName == string.Empty)
			{
				s += Properties.Strings.Node_NoName;
			}
			else
			{
				s += instance.instanceName;
			}
			node.Text = s;
			if (instance.iconData != null && instance.iconData.Length != 0) {
				try {
					icon = TrayUtils.BytesToIcon(instance.iconData);
				} catch { }
			}
		}
	}
}
