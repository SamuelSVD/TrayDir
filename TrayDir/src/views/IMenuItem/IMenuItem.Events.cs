using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	public abstract partial class IMenuItem {
		protected void Run(object obj, EventArgs args) {
			AppUtils.Run(this);
		}
		protected void RunAll(object obj, EventArgs args) {
			foreach (IMenuItem imi in nodeChildren) {
				if (imi.GetType() == typeof(IPathMenuItem) || (imi.GetType() == typeof(IPluginMenuItem))) {
					AppUtils.Run(imi);
				} else if (imi.GetType() == typeof(IVirtualFolderMenuItem) && ((IVirtualFolderMenuItem)imi).isVFolder) {
					imi.RunAll(obj, args);
				}
			}
		}
		protected void Explore(object obj, EventArgs args) {
			AppUtils.Explore(this);
		}
		protected void RunAs(object obj, EventArgs args) {
			AppUtils.RunAs(this);
		}
		protected void OpenCmd(object obj, EventArgs args) {
			AppUtils.OpenCmd(this);
		}
		protected void OpenAdminCmd(object obj, EventArgs args) {
			AppUtils.OpenAdminCmd(this);
		}
		protected void MenuItemClick(object obj, MouseEventArgs args) {
			if (((MouseEventArgs)args).Button == MouseButtons.Right) {
				showContextMenu();
			} else {
				AppUtils.Open(this);
			}
		}
		protected void MenuDestroy(object obj, EventArgs args) {
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
		protected void MenuItemClick(object obj, EventArgs args) {
			_clicks += 1;
			if (_clicks == 2) {
				Run(obj, args);
				RunAll(obj, args);
			}
		}
		protected void MenuItemDropDownOpening(object sender, EventArgs e) {
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
	}
}
