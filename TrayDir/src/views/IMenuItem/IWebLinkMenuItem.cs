using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class IWebLinkMenuItem : IMenuItem {
		public bool isWebLink { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstanceWebLink)); } }
		public IWebLinkMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
		}
		public override void AddToCollection(ToolStripItemCollection collection) {
			collection.Add(menuItem);
		}
		public override void ChildClear() {
		}
		public override void ChildResetClicks() {
		}
		public override void Load() {
			if (menuItem == null) {
				menuItem = new ToolStripMenuItem();
				menuItem.DropDownOpening += MenuItemDropDownOpening;
				menuItem.MouseDown += MenuItemClick;
				menuItem.Click += MenuItemClick;
			}
			bool useAlias = (alias != null && alias != string.Empty);
			if (useAlias) {
				menuItem.Text = alias;
			}
			menuItem.DropDownItems.Clear();
		}
		public override void MenuOpened() {
			EnqueueImgLoad();
			UpdateVisibility();
		}
		protected override void showContextMenu() {
			if (isWebLink) {
				MenuSave();
				Point pt = System.Windows.Forms.Cursor.Position;
				ContextMenuStrip cmnu = new ContextMenuStrip();
				ToolStripItem tsi;

				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_RunAll);
				tsi.Click += RunAll;

				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
		}
	}
}
