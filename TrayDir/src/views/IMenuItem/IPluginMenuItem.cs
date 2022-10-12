using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class IPluginMenuItem : IMenuItem {
		public bool isPlugin { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstancePlugin)); } }
		public IPluginMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
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
			}
			bool useAlias = (alias != null && alias != string.Empty);
			if (useAlias) {
				menuItem.Text = alias;
			} else {
				if (isPlugin) {
					TrayPlugin plugin = ((TrayInstancePlugin)tiItem).plugin;
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
			if (!assignedClickEvent) {
				menuItem.MouseDown += MenuItemClick;
				menuItem.Click += MenuItemClick;
				assignedClickEvent = true;
			}
		}
		public override void MenuOpened() {
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
