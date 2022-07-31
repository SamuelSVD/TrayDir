using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
	public class ITray
	{
		public NotifyIcon notifyIcon;

		private TrayInstance instance;
		private List<IMenuItem> pathMenuItems;
		private List<IMenuItem> virtualFolderMenuItems;
		private List<IMenuItem> pluginMenuItems;
		
		private ToolStripMenuItem showMenuItem;
		private ToolStripMenuItem hideMenuItem;
		private ToolStripMenuItem exitMenuItem;

		private EventHandler showForm;
		private EventHandler hideForm;
		private EventHandler exitForm;

		public List<IMenuItem> menuItems {
			get {
				List<IMenuItem> iml = new List<IMenuItem>();
				iml.AddRange(pathMenuItems);
				iml.AddRange(virtualFolderMenuItems);
				iml.AddRange(pluginMenuItems);
				return iml;
			}
		}
		public Icon icon {
			get { return notifyIcon.Icon; }
			set { notifyIcon.Icon = value; }
		}

		public ITray(TrayInstance instance)
		{
			this.instance = instance;
			notifyIcon = new NotifyIcon();
			notifyIcon.Visible = !instance.settings.HideFromTray;
			UpdateTrayIcon();
			pathMenuItems = new List<IMenuItem>();
			virtualFolderMenuItems = new List<IMenuItem>();
			pluginMenuItems = new List<IMenuItem>();
		}

		private ToolStripMenuItem MakeAndAddMenuItem(ToolStripMenuItem menuItem, string text, bool visible, EventHandler eh)
		{
			if (!(eh is null) && (menuItem == null))
			{
				menuItem = new ToolStripMenuItem(text, null, eh);
				menuItem.Visible = visible;
			}
			if (menuItem != null)
			{
				notifyIcon.ContextMenuStrip.Items.Add(menuItem);
			}
			return menuItem;
		}
		public void setEventHandlers(EventHandler showForm, EventHandler hideForm, EventHandler exitForm)
		{
			this.showForm = showForm;
			this.hideForm = hideForm;
			this.exitForm = exitForm;
		}
		public void Rebuild()
		{
			if (MainForm.form != null) {
				ClearList(pathMenuItems);
				ClearList(pluginMenuItems);
				ClearList(virtualFolderMenuItems);
				BuildTrayMenu();
				GC.Collect();
			}
		}
		private void ClearList(List<IMenuItem> list) {
			foreach (IMenuItem item in list) {
				item.RemoveChildren();
			}
			list.Clear();
		}
		public void MenuOpened(Object obj, EventArgs args)
		{
			IMenuItemIconUtils.AssignIcons();
			if (instance.settings.ExpandFirstPath && instance.PathCount == 1)
			{
				foreach (IMenuItem child in pathMenuItems)
				{
					child.EnqueueImgLoad();
					child.menuItem.Visible = child.tiPath != null && child.tiPath.visible;
					foreach (IMenuItem subchild in child.folderChildren)
					{
						subchild.EnqueueImgLoad();
					}
				}
			}
			else
			{
				foreach (IMenuItem child in pathMenuItems)
				{
					child.EnqueueImgLoad();
				}
			}
			foreach(IMenuItem child in pluginMenuItems)
			{
				child.EnqueueImgLoad();
			}
			foreach (IMenuItem child in virtualFolderMenuItems)
			{
				child.EnqueueImgLoad();
			}
			MainForm.form.iconLoadTimer.Start();
		}
		public void MenuClosed(Object obj, EventArgs args)
		{
			MainForm.form.iconLoadTimer.Stop();
		}
		public void RefreshPluginMenuItemList()
		{
			foreach (TrayInstancePlugin tiPlugin in instance.plugins)
			{
				bool miFound = false;
				foreach (IMenuItem mi in pluginMenuItems)
				{
					if (mi.tiPlugin == tiPlugin) miFound = true;
				}
				if (!miFound)
				{
					IMenuItem mi = new IMenuItem(instance, null, tiPlugin);
					pluginMenuItems.Add(mi);
				}
			}
			List<IMenuItem> deletable = new List<IMenuItem>();
			foreach (IMenuItem mi in pluginMenuItems)
			{
				bool miFound = false;
				foreach (TrayInstancePlugin tiPlugin in instance.plugins)
				{
					if (mi.tiPlugin == tiPlugin) miFound = true;
				}
				if (miFound)
				{
					mi.Load();
				}
				else
				{
					deletable.Add(mi);
				}
			}
			foreach (IMenuItem mi in deletable)
			{
				pluginMenuItems.Remove(mi);
			}
		}
		public void RefreshVirtualFolderMenuItemList()
		{
			foreach (TrayInstanceVirtualFolder tiVirtualFolder in instance.vfolders)
			{
				bool miFound = false;
				foreach (IMenuItem mi in virtualFolderMenuItems)
				{
					if (mi.tiVirtualFolder == tiVirtualFolder) miFound = true;
				}
				if (!miFound)
				{
					IMenuItem mi = new IMenuItem(instance, null, tiVirtualFolder);
					virtualFolderMenuItems.Add(mi);
				}
			}
			List<IMenuItem> deletable = new List<IMenuItem>();
			foreach (IMenuItem mi in virtualFolderMenuItems)
			{
				bool miFound = false;
				foreach (TrayInstanceVirtualFolder tiVirtualFolder in instance.vfolders)
				{
					if (mi.tiVirtualFolder == tiVirtualFolder) miFound = true;
				}
				if (miFound)
				{
					mi.Load();
				}
				else
				{
					deletable.Add(mi);
				}
			}
			foreach (IMenuItem mi in deletable)
			{
				virtualFolderMenuItems.Remove(mi);
			}
		}
		public void RefreshPathMenuItemList()
		{
			foreach (TrayInstancePath tiPath in instance.paths)
			{
				bool miFound = false;
				foreach (IMenuItem mi in pathMenuItems)
				{
					if (mi.tiPath == tiPath) miFound = true;
				}
				if (!miFound)
				{
					IMenuItem mi = new IMenuItem(instance, null, tiPath);
					pathMenuItems.Add(mi);
				}
			}
			List<IMenuItem> deletable = new List<IMenuItem>();
			foreach (IMenuItem mi in pathMenuItems)
			{
				bool miFound = false;
				foreach (TrayInstancePath tiPath in instance.paths)
				{
					if (mi.tiPath == tiPath) miFound = true;
				}
				if (miFound)
				{
					mi.Load();
				}
				else
				{
					deletable.Add(mi);
				}
			}
			foreach (IMenuItem mi in deletable)
			{
				pathMenuItems.Remove(mi);
			}
		}
		public void BuildTrayMenu()
		{
			if (notifyIcon.ContextMenuStrip is null)
			{
				notifyIcon.ContextMenuStrip = new ContextMenuStrip();
				notifyIcon.ContextMenuStrip.Opened += MenuOpened;
				notifyIcon.ContextMenuStrip.Closed += MenuClosed;
			}
			else
			{
				notifyIcon.ContextMenuStrip.Items.Clear();
			}

			//            notifyIcon.ContextMenuStrip.AutoClose = true;

			showMenuItem = MakeAndAddMenuItem(showMenuItem, Properties.Strings_en.MenuItem_Show, false, showForm);
			hideMenuItem = MakeAndAddMenuItem(hideMenuItem, Properties.Strings_en.MenuItem_Hide, true, hideForm);

			notifyIcon.ContextMenuStrip.Items.Add("-");

			RefreshPathMenuItemList();
			RefreshVirtualFolderMenuItemList();
			RefreshPluginMenuItemList();

			AddTrayTree(instance.nodes.children, notifyIcon.ContextMenuStrip.Items, null);

			notifyIcon.ContextMenuStrip.Items.Add("-");
			exitMenuItem = MakeAndAddMenuItem(exitMenuItem, Properties.Strings_en.MenuItem_Exit, true, exitForm);

			UpdateTrayIcon();

			foreach (IMenuItem mi in menuItems) {
				mi.EnqueueImgLoad();
				mi.UpdateVisibility();
			}
		}
		private void AddTrayTree(List<TrayInstanceNode> nodes, ToolStripItemCollection collection, IMenuItem parent)
		{
			foreach(TrayInstanceNode node in nodes)
			{
				switch(node.type) {
					case TrayInstanceNode.NodeType.Path:
						if (node.id < instance.paths.Count) {
							foreach(IMenuItem mi in pathMenuItems)
							{
								if (mi.tiPath == instance.paths[node.id])
								{
									mi.tiNode = node;
									if (parent != null) parent.nodeChildren.Add(mi);
									if (!mi.tiPath.shortcut && (instance.settings.ExpandFirstPath && nodes.Count == 1 && collection == notifyIcon.ContextMenuStrip.Items))
									{
										mi.AddToCollectionExpanded(collection);
									}
									else
									{
										mi.AddToCollection(collection);
									}
									break;
								}
							}
						}
						break;
					case TrayInstanceNode.NodeType.Plugin:
						if (node.id < instance.plugins.Count) {
							foreach (IMenuItem mi in pluginMenuItems) {
								if (mi.tiPlugin == instance.plugins[node.id]) {
									mi.tiNode = node;
									if (parent != null) parent.nodeChildren.Add(mi);
									mi.AddToCollection(collection);
									AddTrayTree(node.children, mi.menuItem.DropDownItems, mi);
									break;
								}
							}
						}
						break;
					case TrayInstanceNode.NodeType.VirtualFolder:
						if (node.id < instance.vfolders.Count) {
							foreach (IMenuItem mi in virtualFolderMenuItems) {
								if (mi.tiVirtualFolder == instance.vfolders[node.id]) {
									mi.tiNode = node;
									if (parent != null) parent.nodeChildren.Add(mi);
									mi.AddToCollection(collection);
									AddTrayTree(node.children, mi.menuItem.DropDownItems, mi);
									break;
								}
							}
						}
						break;
					case TrayInstanceNode.NodeType.Separator:
						collection.Add("-");
						break;
				}
			}
		}
		public void UpdateTrayIcon()
		{
			Icon i = this.GetInstanceIcon();
			if (i != null && ((instance.iconPath != null && instance.iconPath != string.Empty) || (instance.iconData == null)))
			{
				notifyIcon.Icon = i;
				instance.iconData = TrayUtils.IconToBytes(i);
			}
			instance.iconPath = null;
			notifyIcon.Text = instance.instanceName;
			notifyIcon.Icon = i;
		}
		public void Hide()
		{
			notifyIcon.Visible = false;
		}
		public void Show()
		{
			notifyIcon.Visible = true;
		}
		public void SetFormHiddenMenu()
		{
			notifyIcon.ContextMenuStrip.Items[0].Visible = true;
			notifyIcon.ContextMenuStrip.Items[1].Visible = false;
		}
		public void SetFormShownMenu()
		{
			showMenuItem.Visible = false;
			hideMenuItem.Visible = true;
		}
		public Icon GetInstanceIcon()
		{
			Icon i;
			try
			{
				if (instance.iconData != null)
				{
					i = TrayUtils.BytesToIcon(instance.iconData);
				}
				else if (AppUtils.PathIsFile(instance.iconPath))
				{
					i = Icon.ExtractAssociatedIcon(instance.iconPath);
				}
				else
				{
					i = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(String.Format(Properties.Strings_en.Form_ErrorLoadingIcon, e.Message));
				i = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);
			}
			return i;
		}

		internal void SetText(string text) {
			notifyIcon.Text = text;
		}
	}
}
