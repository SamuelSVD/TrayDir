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
			string s = string.Empty;
			if (tp.name != null && tp.name != string.Empty)
			{
				s += tp.name;
			}
			if (tp.path == null || tp.path == string.Empty)
			{
				s += Properties.Strings_en.Node_NoPathSelected;
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
				if (tp.isScript) {
					node.ImageIndex = IconUtils.RUNNABLE;
				} else {
					node.ImageIndex = IconUtils.QUESTION;
				}
			}
			node.SelectedImageIndex = node.ImageIndex;
		}
	}
}
