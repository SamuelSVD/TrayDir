using System.Drawing;
using System.Windows.Forms;
using TrayDir.src.views;

namespace TrayDir {
	internal class IPluginMenuItem : IMenuItem {
		internal bool isPlugin { get { return (Item.TrayInstanceItem != null && Item.TrayInstanceItem.GetType() == typeof(TrayInstancePlugin)); } }
		internal IPluginMenuItem(TrayInstance instance, IItem item, IMenuItem parent) : base(instance, item, parent) {
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
				if (isPlugin) {
					TrayPlugin plugin = ((TrayInstancePlugin)Item.TrayInstanceItem).plugin;
					if (plugin != null) {
						if (plugin.name == null || plugin.name == string.Empty) {
							menuItem.Text = "(plugin item)";
						} else {
							menuItem.Text = string.Format("({0})", plugin.name);
						}
					} else {
						menuItem.Text = "(plugin item)";
					}
				}
			}
			menuItem.DropDownItems.Clear();
		}
		internal override void MenuOpened() {
			EnqueueImgLoad();
			UpdateVisibility();
		}
		protected override void showContextMenu() {
			if (isPlugin) {
				MenuSave();
				Point pt = System.Windows.Forms.Cursor.Position;
				ContextMenuStrip cmnu = new ContextMenuStrip();
				ToolStripItem tsi;
				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_Run);
				tsi.Click += Run;
				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_RunAdmin);
				tsi.Click += RunAs;
				tsi = cmnu.Items.Add(Properties.Strings.MenuItem_OpenFileExplorer);
				tsi.Click += Explore;
				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
		}
	}
}
