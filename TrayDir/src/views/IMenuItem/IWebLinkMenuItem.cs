using System;
using System.Drawing;
using System.Windows.Forms;
using TrayDir.src.views;

namespace TrayDir {
	internal class IWebLinkMenuItem : IMenuItem {
		internal bool isWebLink { get { return (Item.TrayInstanceItem != null && Item.TrayInstanceItem.GetType() == typeof(TrayInstanceWebLink)); } }
		internal IWebLinkMenuItem(TrayInstance instance, IItem item, IMenuItem parent) : base(instance, item, parent) {
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
				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_CopyLink);
				tsi.Click += CopyHyperlink;

				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
		}
		protected void CopyHyperlink(object obj, EventArgs args) {
			Clipboard.SetText(Item.TrayInstanceNode.GetWebLink().URL);
		}
	}
}
