using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir {
	public abstract partial class IMenuItem {
		internal TrayInstance instance;
		internal TrayInstanceNode tiNode;
		internal TrayInstanceItem tiItem;

		public ToolStripMenuItem menuItem;
		public List<IMenuItem> nodeChildren = new List<IMenuItem>();
		public IMenuItem parent;
		public Bitmap menuIcon;

		public bool loadedIcon = false;
		public bool enqueued = false;
		protected bool assignedClickEvent = false;

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

		public IMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) {
			this.instance = instance;
			this.tiNode = tiNode;
			this.tiItem = tiItem;
			this.parent = parent;
		}
		public abstract void ChildClear();
		public void Clear() {
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
		public void ResetClicks() {
			_clicks = 0;
			if (nodeChildren != null) {
				foreach (IMenuItem m in nodeChildren) {
					m.ResetClicks();
				}
			}
		}
		public abstract void ChildResetClicks();
		protected abstract void showContextMenu(); /*{
		} */
		internal void UpdateVisibility() {
			if (tiItem != null) {
				menuItem.Visible = tiItem.visible;
			}
		}
		public abstract void Load();/* {
			
		}*/
		public void EnqueueImgLoad() {
			IMenuItemIconUtils.EnqueueIconLoad(this);
		}
		public abstract void AddToCollection(ToolStripItemCollection collection);
		internal void RemoveChildren(List<IMenuItem> list) {
			while (list.Count > 0) {
				IMenuItem child = list[0];
				child.Clear();
				list.RemoveAt(0);
			}
			list.Clear();
		}
		public void Refresh() {
			Clear();
			Load();
		}
		public abstract void MenuOpened();
	}
}
