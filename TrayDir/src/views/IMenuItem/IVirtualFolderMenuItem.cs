using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class IVirtualFolderMenuItem : IMenuItem {
		internal bool isVFolder { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstanceVirtualFolder)); } }
		internal IVirtualFolderMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
		}
		internal override void AddToCollection(ToolStripItemCollection collection) {
			collection.Add(menuItem);
		}
		internal override void ChildClear() {
		}
		internal override void ChildResetClicks() {
		}
		internal override void Load() {
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
		internal override void MenuOpened() {
			EnqueueImgLoad();
			UpdateVisibility();
		}
		protected override void showContextMenu() {
			if (isVFolder) {
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
