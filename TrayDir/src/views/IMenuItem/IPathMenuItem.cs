using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TrayDir {
	internal class IPathMenuItem : IMenuItem {
		private List<IMenuItem> dirMenuItems = new List<IMenuItem>();
		private List<IMenuItem> fileMenuItems = new List<IMenuItem>();
		private List<IMenuItem> folderChildren = new List<IMenuItem>();
		private bool painted = false;
		internal bool isErr { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) ? !(Directory.Exists(((TrayInstancePath)tiItem).path) || File.Exists(((TrayInstancePath)tiItem).path)) : false; } }
		internal bool isDir { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) ? AppUtils.PathIsDirectory(((TrayInstancePath)tiItem).path) : false; } }
		internal bool isFile { get { return (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) ? AppUtils.PathIsFile(((TrayInstancePath)tiItem).path) : false; } }


		internal IPathMenuItem(TrayInstance instance, TrayInstanceNode tiNode, TrayInstanceItem tiItem, IMenuItem parent) : base(instance, tiNode, tiItem, parent) {
		}

		internal override void AddToCollection(ToolStripItemCollection collection) {
			collection.Add(menuItem);

			if (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) {
				if (folderChildren.Count != menuItem.DropDownItems.Count) {
					menuItem.DropDownItems.Clear();
					dirMenuItems.Clear();
					fileMenuItems.Clear();

					if (ProgramData.pd.settings.app.MenuSorting != "None") {
						if (ProgramData.pd.settings.app.MenuSorting == "Folders Top") {
							foreach (IMenuItem child in dirMenuItems) {
								menuItem.DropDownItems.Add(child.menuItem);
							}
							foreach (IMenuItem child in fileMenuItems) {
								menuItem.DropDownItems.Add(child.menuItem);
							}
						} else {
							foreach (IMenuItem child in fileMenuItems) {
								menuItem.DropDownItems.Add(child.menuItem);
							}
							foreach (IMenuItem child in dirMenuItems) {
								menuItem.DropDownItems.Add(child.menuItem);
							}
						}
					} else {
						foreach (IMenuItem child in folderChildren) {
							menuItem.DropDownItems.Add(child.menuItem);
						}
					}
				}
			}
		}
		internal void AddToCollectionExpanded(ToolStripItemCollection collection) {
			if (folderChildren.Count == 0) {
				MakeChildren();
				Load();
				LoadChildrenIconEvent(this, null);
			}
			if (folderChildren.Count > 0) {
				if (folderChildren.Count != menuItem.DropDownItems.Count) {
					menuItem.DropDownItems.Clear();
				}
				dirMenuItems.Clear();
				fileMenuItems.Clear();

				foreach (IPathMenuItem child in folderChildren) {
					if (child.isDir) {
						dirMenuItems.Add(child);
					} else if (child.isFile) {
						fileMenuItems.Add(child);
					}
				}
				if (ProgramData.pd.settings.app.MenuSorting != "None") {
					if (ProgramData.pd.settings.app.MenuSorting == "Folders Top") {
						foreach (IMenuItem child in dirMenuItems) {
							collection.Add(child.menuItem);
						}
						foreach (IMenuItem child in fileMenuItems) {
							collection.Add(child.menuItem);
						}
					} else {
						foreach (IMenuItem child in fileMenuItems) {
							collection.Add(child.menuItem);
						}
						foreach (IMenuItem child in dirMenuItems) {
							collection.Add(child.menuItem);
						}
					}
				} else {
					foreach (IMenuItem child in folderChildren) {
						collection.Add(child.menuItem);
					}
				}
			} else {
				collection.Add(menuItem);
			}
		}
		internal override void ChildClear() {
			RemoveChildren();
			painted = false;

		}
		internal override void ChildResetClicks() {
			if (folderChildren != null) {
				foreach (IMenuItem m in folderChildren) {
					m.ResetClicks();
				}
			}
			if (dirMenuItems != null) {
				foreach (IMenuItem m in dirMenuItems) {
					m.ResetClicks();
				}
			}
			if (fileMenuItems != null) {
				foreach (IMenuItem m in fileMenuItems) {
					m.ResetClicks();
				}
			}
		}
		internal override void Load() {
			if (menuItem == null) {
				menuItem = new ToolStripMenuItem();
				menuItem.DropDownOpening += MenuItemDropDownOpening;
				menuItem.DropDownOpening += LoadChildrenIconEvent;
				menuItem.Paint += LoadFolderChildren;
				menuItem.MouseDown += MenuItemClick;
				menuItem.Click += MenuItemClick;
			}
			bool useAlias = (alias != null && alias != string.Empty);
			if (useAlias) {
				menuItem.Text = alias;
			} else {
				if (isDir) {
					menuItem.Text = new DirectoryInfo(((TrayInstancePath)tiItem).path).Name;
				} else if (isFile) {
					if (instance.settings.ShowFileExtensions) {
						menuItem.Text = Path.GetFileName(((TrayInstancePath)tiItem).path);
					} else {
						menuItem.Text = Path.GetFileNameWithoutExtension(((TrayInstancePath)tiItem).path);
					}
				}
			}
			menuItem.DropDownItems.Clear();
			dirMenuItems?.Clear();
			fileMenuItems?.Clear();
			foreach (IMenuItem child in folderChildren) {
				child.Load();
				if (((IPathMenuItem)child).isDir) {
					dirMenuItems.Add(child);
				}
				if (((IPathMenuItem)child).isFile) {
					fileMenuItems.Add(child);
				}
			}
			if (isDir && ((TrayInstancePath)tiItem).shortcut) {
				folderChildren.Clear();
				menuItem.DropDownItems.Clear();
			}
			if (folderChildren.Count == 0 && isDir && !((TrayInstancePath)tiItem).shortcut) {
				menuItem.DropDownItems.Add("(Empty)");
			}
			if (ProgramData.pd.settings.app.MenuSorting != "None") {
				if (ProgramData.pd.settings.app.MenuSorting == "Folders Top") {
					foreach (IMenuItem child in dirMenuItems) {
						menuItem.DropDownItems.Add(child.menuItem);
					}
					foreach (IMenuItem child in fileMenuItems) {
						menuItem.DropDownItems.Add(child.menuItem);
					}
				} else {
					foreach (IMenuItem child in fileMenuItems) {
						menuItem.DropDownItems.Add(child.menuItem);
					}
					foreach (IMenuItem child in dirMenuItems) {
						menuItem.DropDownItems.Add(child.menuItem);
					}
				}
			} else {
				foreach (IMenuItem child in folderChildren) {
					menuItem.DropDownItems.Add(child.menuItem);
				}
			}
		}
		private void LoadFolderChildren(object sender, PaintEventArgs e) {
			if (!painted && isDir && !((TrayInstancePath)tiItem).shortcut) {
				painted = true;
				MakeChildren();
				Load();
				menuItem.Invalidate();
			}
			painted = true;
		}
		protected void LoadChildrenIconEvent(Object obj, EventArgs args) {
			if (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) {
				foreach (IMenuItem child in folderChildren) {
					child.EnqueueImgLoad();
				}
			}
		}
		private void MakeChildren() {
			if (isDir) {
				try {
					string[] dirpaths = Directory.GetFileSystemEntries(((TrayInstancePath)tiItem).path);
					DirectoryInfo di = new DirectoryInfo(((TrayInstancePath)tiItem).path);
					foreach (FileInfo fp in di.GetFiles()) {
						MakeFileChild(fp);
					}
					foreach (DirectoryInfo fp in di.GetDirectories()) {
						MakeDirChild(fp);
					}
				}
				catch { }
			}
		}
		private void MakeDirChild(DirectoryInfo fp) {
			if (isRegexMatch(fp.FullName)) return;
			if (!(ProgramData.pd.settings.win.ShowHiddenFiles) && fp.Attributes.HasFlag(FileAttributes.Hidden)) return;
			folderChildren.Add(new IPathMenuItem(instance, null, new TrayInstancePath(fp.FullName), this));
		}
		private void MakeFileChild(FileInfo fp) {
			if (isRegexMatch(fp.FullName)) return;
			if (!(ProgramData.pd.settings.win.ShowHiddenFiles) && fp.Attributes.HasFlag(FileAttributes.Hidden)) return;
			folderChildren.Add(new IPathMenuItem(instance, null, new TrayInstancePath(fp.FullName), this));
		}
		private bool isRegexMatch(string val) {
			bool match = false;
			foreach (string regx in instance.regexList) {
				if (regx != string.Empty) {
					match = match || (Regex.Matches(val, regx).Count > 0);
				}
				if (match) return true;
			}
			return false;
		}
		internal override void MenuOpened() {
			EnqueueImgLoad();
			UpdateVisibility();
			foreach (IMenuItem subchild in folderChildren) {
				subchild.EnqueueImgLoad();
			}
		}
		internal void RemoveChildren() {
			RemoveChildren(nodeChildren);
			if (tiItem != null && tiItem.GetType() == typeof(TrayInstancePath)) {
				RemoveChildren(folderChildren);
				RemoveChildren(dirMenuItems);
				RemoveChildren(fileMenuItems);
			}
			parent = null;
		}
		protected override void showContextMenu() {
			if (isFile || isDir) {
				MenuSave();
				Point pt = System.Windows.Forms.Cursor.Position;
				ContextMenuStrip cmnu = new ContextMenuStrip();
				ToolStripItem tsi;

				if (isFile) {
					tsi = cmnu.Items.Add(Properties.Strings.MenuItem_Run);
					tsi.Click += Run;
					tsi = cmnu.Items.Add(Properties.Strings.MenuItem_RunAdmin);
					tsi.Click += RunAs;
				}
				if (isDir || isFile) {
					tsi = cmnu.Items.Add(Properties.Strings.MenuItem_OpenFileExplorer);
					tsi.Click += Explore;
				}
				if (isDir || isFile) {
					tsi = cmnu.Items.Add(Properties.Strings.MenuItem_OpenCmd);
					tsi.Click += OpenCmd;
					tsi = cmnu.Items.Add(Properties.Strings.MenuItem_OpenCmdAdmin);
					tsi.Click += OpenAdminCmd;
				}
				cmnu.Show();
				cmnu.Location = pt;
				cmnu.Closing += MenuDestroy;
			}
		}

	}
}
