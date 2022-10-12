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
			TrayInstanceVirtualFolder tivf = tin.GetVirtualFolder();
			if (tivf != null) {
				node.ImageIndex = IconUtils.FOLDER_BLUE;
				node.Text = tivf.alias;
				hidden = !tivf.visible;
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
