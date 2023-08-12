using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class InstanceNode {
		internal TreeNode node;
		internal TrayInstance instance;
		internal Icon icon;
		internal InstanceNode() {
			node = new TreeNode();
		}
		internal void UpdateNode() {
			string s = string.Empty;
			if (instance.instanceName == null || instance.instanceName == string.Empty) {
				s += Properties.Strings.Node_NoName;
			} else {
				s += instance.instanceName;
			}
			node.Text = s;
			if (instance.iconData != null && instance.iconData.Length != 0) {
				try {
					icon = TrayUtils.BytesToIcon(instance.iconData);
				}
				catch { }
			}
		}
	}
}
