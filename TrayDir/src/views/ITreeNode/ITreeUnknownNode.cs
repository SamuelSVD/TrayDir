using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeUnknownNode : ITreeNode {
		public ITreeUnknownNode(TrayInstanceNode tin) : base(tin) {
		}

		public override void Refresh() {
			bool hidden = false;
			node.ImageIndex = IconUtils.QUESTION;
			node.Text = Properties.Strings.Form_Error;
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
