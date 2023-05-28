using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeVirtualFolderNode : ITreeNode {
		internal ITreeVirtualFolderNode(TrayInstanceNode tin) : base(tin) { }
		internal override void Refresh() {
			bool hidden = false;
			node.ImageIndex = IconUtils.QUESTION;
			TrayInstanceVirtualFolder tivf = tin.GetVirtualFolder();
			if (tivf != null) {
				node.ImageIndex = IconUtils.FOLDER_BLUE;
				node.Text = tivf.alias;
				hidden = !tivf.visible;
			}
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				TrayInstanceItem model = tin.GetVirtualFolder();
				if (model != null) {
					return !model.visible;
				}
				return false;
			}
		}
	}
}
