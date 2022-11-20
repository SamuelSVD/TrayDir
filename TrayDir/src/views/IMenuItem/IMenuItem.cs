using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir {
	internal abstract partial class IMenuItem {
		internal TrayInstance instance;
		internal TrayInstanceNode tiNode;
		internal TrayInstanceItem tiItem;

		internal ToolStripMenuItem menuItem;
		internal List<IMenuItem> nodeChildren = new List<IMenuItem>();
		internal IMenuItem parent;
		internal Bitmap menuIcon;

		internal bool loadedIcon = false;
		internal bool enqueued = false;

		protected string alias {
			get {
				if (tiItem != null) {
					return tiItem.alias;
				}
				return null;
			}
		}
		protected int depth {
			get {
				int d = 1;
				if (parent != null) {
					d += parent.depth;
				}
				return d;
			}
		}

		internal IMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) {
			this.instance = instance;
			this.tiNode = tiNode;
			this.tiItem = tiItem;
			this.parent = parent;
		}
		internal abstract void ChildClear();
		internal void Clear() {
			ChildClear();
			menuIcon = null;
			enqueued = false;
			loadedIcon = false;
			if (menuItem != null) {
				menuItem.DropDownItems.Clear();
				menuItem.Image = null;
				menuItem.Text = "";
			}
		}
		protected void MenuSave() {
			IMenuItem mi = parent;
			instance.view.tray.notifyIcon.ContextMenuStrip.Show();
			while (mi != null) {
				mi.menuItem.DropDown.AutoClose = false;
				mi.menuItem.DropDown.Show();
				mi.menuItem.Enabled = false;
				mi = mi.parent;
			}
			instance.view.tray.notifyIcon.ContextMenuStrip.AutoClose = false;
			instance.view.tray.notifyIcon.ContextMenuStrip.Enabled = false;
		}
		private int _clicks = 0;
		internal void ResetClicks() {
			_clicks = 0;
			if (nodeChildren != null) {
				foreach (IMenuItem m in nodeChildren) {
					m.ResetClicks();
				}
			}
		}
		internal abstract void ChildResetClicks();
		protected abstract void showContextMenu(); /*{
		} */
		internal void UpdateVisibility() {
			if (tiItem != null) {
				menuItem.Visible = tiItem.visible;
			}
		}
		internal abstract void Load();/* {
			
		}*/
		internal void EnqueueImgLoad() {
			IMenuItemIconUtils.EnqueueIconLoad(this);
		}
		internal abstract void AddToCollection(ToolStripItemCollection collection);
		internal void RemoveChildren(List<IMenuItem> list) {
			while (list.Count > 0) {
				IMenuItem child = list[0];
				child.Clear();
				list.RemoveAt(0);
			}
			list.Clear();
		}
		internal void Refresh() {
			Clear();
			Load();
			UpdateVisibility();
		}
		internal abstract void MenuOpened();
	}
}
