using System.Drawing;
using TrayDir.utils;

namespace TrayDir {
	internal class ITreePathNode : ITreeNode {
		public ITreePathNode(TrayInstanceNode tin) : base(tin) { }
		public override void Refresh() {
			bool hidden = false;
			node.ImageIndex = IconUtils.QUESTION;
			TrayInstancePath tip = tin.GetPath();
			if (tip != null) {
				bool hasAlias = alias != null && alias != string.Empty;
				if (tip.isDir) {
					if (tip.shortcut) {
						node.ImageIndex = IconUtils.FOLDER_SHORTCUT;
					} else {
						node.ImageIndex = IconUtils.FOLDER;
					}
					node.Text = string.Empty;
				} else if (tip.isFile) {
					node.ImageIndex = IconUtils.DOCUMENT;
					node.Text = string.Empty;
				} else {
					node.ImageIndex = IconUtils.QUESTION;
					node.Text = Properties.Strings.Node_Error;
				}
				hidden = !tip.visible;
				node.Text += hasAlias ? alias : string.Empty;
				node.Text += hasAlias ? " (" + tin.instance.paths[tin.id].path + ")" : tin.instance.paths[tin.id].path;
			}
			node.SelectedImageIndex = node.ImageIndex;
			if (hidden) {
				ITreeNode.strikethroughFont = new Font(node.TreeView.Font.FontFamily, node.TreeView.Font.Size, FontStyle.Strikeout);
				node.NodeFont = strikethroughFont;
			} else {
				node.NodeFont = node.TreeView?.Font;
			}
		}
	}
}
