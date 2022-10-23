using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeWebLinkNode : ITreeNode {
		public ITreeWebLinkNode(TrayInstanceNode tin) : base(tin) {
		}

		public override void Refresh() {
			bool hidden = false;
			node.ImageIndex = IconUtils.QUESTION;
			TrayInstanceWebLink tiwl = tin.GetWebLink();
			if (tiwl != null) {
				if (tiwl.isValidURL) {
					node.ImageIndex = IconUtils.WEBLINK;
				} else {
					node.ImageIndex = IconUtils.WEBLINK_ERROR;
				}
				node.Text = tiwl.alias;
				if (node.Text == "") node.Text = "(WebLink)";
				hidden = !tiwl.visible;
			}
			node.SelectedImageIndex = node.ImageIndex;
			if (hidden && node.TreeView != null) {
				ITreeNode.strikethroughFont = new Font(node.TreeView.Font.FontFamily, node.TreeView.Font.Size, FontStyle.Strikeout);
				node.NodeFont = strikethroughFont;
			} else {
				node.NodeFont = node.TreeView?.Font;
			}
		}
	}
}
