using System.Drawing;
using TrayDir.src.views;
using TrayDir.utils;

namespace TrayDir {
	internal class ITreePathNode : ITreeNode {
		internal ITreePathNode(IItem item) : base(item) { }
		internal override void Refresh() {
			node.ImageIndex = IconUtils.QUESTION;
			TrayInstancePath tip = Item.TrayInstanceNode.GetPath();
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
				node.Text += hasAlias ? alias : string.Empty;
				node.Text += hasAlias ? " (" + Item.TrayInstanceNode.instance.paths[Item.TrayInstanceNode.id].path + ")" : Item.TrayInstanceNode.instance.paths[Item.TrayInstanceNode.id].path;
			}
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				TrayInstanceItem model = Item.TrayInstanceNode.GetPath();
				if (model != null) {
					return !model.visible;
				}
				return false;
			}
		}
	}
}
