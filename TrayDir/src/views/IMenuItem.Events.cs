using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	public partial class IMenuItem {
		private void Run(object obj, EventArgs args) {
			AppUtils.Run(this);
		}
		private void RunAll(object obj, EventArgs args) {
			foreach (IMenuItem imi in nodeChildren) {
				if (imi.isDir || imi.isFile || imi.isPlugin) {
					AppUtils.Run(imi);
				} else if (imi.isVFolder) {
					imi.RunAll(obj, args);
				}
			}
		}
		private void Explore(object obj, EventArgs args) {
			AppUtils.Explore(this);
		}
		private void RunAs(object obj, EventArgs args) {
			AppUtils.RunAs(this);
		}
		private void OpenCmd(object obj, EventArgs args) {
			AppUtils.OpenCmd(this);
		}
		private void OpenAdminCmd(object obj, EventArgs args) {
			AppUtils.OpenAdminCmd(this);
		}
		public void MenuItemClick(object obj, MouseEventArgs args) {
			if (((MouseEventArgs)args).Button == MouseButtons.Right) {
				showContextMenu();
			} else {
				AppUtils.Open(this);
			}
		}
		public void MenuDestroy(object obj, EventArgs args) {
			IMenuItem mi = parent;
			while (mi != null) {
				mi.menuItem.DropDown.AutoClose = true;
				mi.menuItem.DropDown.Close();
				mi.menuItem.Enabled = true;
				mi = mi.parent;
			}
			instance.view.tray.notifyIcon.ContextMenuStrip.AutoClose = true;
			instance.view.tray.notifyIcon.ContextMenuStrip.Enabled = true;
			instance.view.tray.notifyIcon.ContextMenuStrip.Close();
		}
		public void MenuItemClick(object obj, EventArgs args) {
			_clicks += 1;
			if (_clicks == 2) {
				Run(obj, args);
				RunAll(obj, args);
			}
		}
		private void MenuItemDropDownOpening(object sender, EventArgs e) {
			if (menuItem.HasDropDownItems == false) {
				return; // not a drop down item
			}
			// Current bounds of the current monitor
			Rectangle Bounds = menuItem.GetCurrentParent().Bounds;
			Screen CurrentScreen = Screen.FromPoint(Bounds.Location);

			// Look how big our children are:
			int MaxWidth = 0;
			foreach (ToolStripItem subitem in menuItem.DropDownItems) {
				MaxWidth = Math.Max(subitem.Width, MaxWidth);
			}
			MaxWidth += 10; // Add a little wiggle room

			int FarRight = Bounds.Right + MaxWidth;
			int CurrentMonitorRight = CurrentScreen.Bounds.Right;

			if (FarRight > CurrentMonitorRight) {
				menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
			} else {
				menuItem.DropDownDirection = ToolStripDropDownDirection.Right;
			}
		}
		public void LoadChildrenIconEvent(Object obj, EventArgs args) {
			if (tiPath != null) {
				foreach (IMenuItem child in folderChildren) {
					child.EnqueueImgLoad();
				}
			}
		}
	}
}
