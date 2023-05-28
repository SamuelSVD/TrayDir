﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreeSeparatorNode : ITreeNode {
		internal ITreeSeparatorNode(TrayInstanceNode tin) : base(tin) {
		}

		internal override void Refresh() {
			node.ImageIndex = IconUtils.QUESTION;
			node.ImageIndex = IconUtils.SEPARATOR;
			node.Text = Properties.Strings.Form_Separator;
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				return false;
			}
		}
	}
}
