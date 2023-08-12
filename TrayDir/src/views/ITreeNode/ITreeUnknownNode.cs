using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeUnknownNode : ITreeNode {
		internal ITreeUnknownNode(IItem item) : base(item) {
		}

		internal override void Refresh() {
			node.ImageIndex = IconUtils.QUESTION;
			node.Text = Properties.Strings.Form_Error;
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				return false;
			}
		}
	}
}
