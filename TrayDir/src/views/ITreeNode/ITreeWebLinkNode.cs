using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeWebLinkNode : ITreeNode {
		internal ITreeWebLinkNode(TrayInstanceNode tin) : base(tin) {
		}

		internal override void Refresh() {
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
			}
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				TrayInstanceItem model = tin.GetWebLink();
				if (model != null) {
					return !model.visible;
				}
				return false;
			}
		}
	}
}
