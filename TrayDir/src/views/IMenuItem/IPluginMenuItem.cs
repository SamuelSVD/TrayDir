using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir {
	internal class IPluginMenuItem : IMenuItem {
		public IPluginMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
		}

		public override void AddToCollection(ToolStripItemCollection collection) {
			throw new NotImplementedException();
		}

		public override void ChildClear() {
			throw new NotImplementedException();
		}

		public override void ChildResetClicks() {
			throw new NotImplementedException();
		}

		public override void Load() {
			throw new NotImplementedException();
		}

		public override void MenuOpened() {
			throw new NotImplementedException();
		}

		protected override void showContextMenu() {
			throw new NotImplementedException();
		}
	}
}
