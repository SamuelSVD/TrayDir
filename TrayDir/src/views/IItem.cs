using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TrayDir.src.views {
	internal class IItem {
		public ITreeNode TreeNode;
		public IMenuItem MenuItem;
		public TrayInstanceItem TrayInstanceItem;
		public TrayInstanceNode TrayInstanceNode;
		public IItem() {

		}
		internal void Delete() {
			if (TreeNode != null) {
				TreeNode.Delete();
			}
			if (MenuItem != null) {
				MenuItem.Delete();
			}
		}
	}
}
