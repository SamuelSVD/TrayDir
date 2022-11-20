using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class IWebLinkMenuItem : IMenuItem {
		internal bool isWebLink { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstanceWebLink)); } }
		internal IWebLinkMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
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
			} else {
				menuItem.Text = "(Web Link)";
			}
			menuItem.DropDownItems.Clear();
		}
		internal override void MenuOpened() {
			EnqueueImgLoad();
			UpdateVisibility();
		}
		protected override void showContextMenu() {
			if (isWebLink) {
				MenuSave();
				Point pt = System.Windows.Forms.Cursor.Position;
				ContextMenuStrip cmnu = new ContextMenuStrip();
				ToolStripItem tsi;

				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_Open);
				tsi.Click += Run;

				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
		}
	}
}
