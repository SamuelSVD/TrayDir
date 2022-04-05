using FolderSelect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir
{
	public partial class ITreeViewForm : Form
	{
		private List<ITreeNode> nodes;
		private bool selectedNodeNew = false;
		private ITreeNode selectedNode { get { return __selectedNode; } set { __selectedNode = value; UpdateButtonEnables(); } }
		private bool selectedIndentable { get { return selectedNode != null ? !selectedNode.isFirstChild && selectedNode.previousRelative.tin.type == TrayInstanceNode.NodeType.VirtualFolder : false; } }
		private bool selectedOutdentable { get { return selectedNode != null ? selectedNode.node.Parent != null : false; } }
		private bool selectedUpable { get { return selectedNode != null ? !selectedNode.isFirstChild : false; } }
		private bool selectedDownable { get { return selectedNode != null ? !selectedNode.isLastChild : false; } }
		private TabPage tp;
		private ITreeNode __selectedNode;
		private TrayInstance instance;
		private ContextMenu rightClickMenu;
		private MenuItem renameMenuItem;
		private MenuItem folderShortcutMenuItem;
		private MenuItem folderExpandMenuItem;
		private MenuItem openInExplorerMenuItem;
		private MenuItem openInCmdMenuItem;
		private MenuItem openInCmdAdminMenuItem;


		public ITreeViewForm(TrayInstance instance)
		{
			rightClickMenu = new ContextMenu();
			renameMenuItem = new MenuItem(Properties.Strings_en.Item_RenameItem, renameButton_Click);
			folderShortcutMenuItem = new MenuItem(Properties.Strings_en.Item_UseAsShortcut, folderShortcutMenuItem_click);
			folderExpandMenuItem = new MenuItem(Properties.Strings_en.Item_Expand, folderExpandMenuItem_click);
			openInExplorerMenuItem = new MenuItem(Properties.Strings_en.Item_OpenFileExplorer, openInExplorerMenuItem_click);
			openInCmdMenuItem = new MenuItem(Properties.Strings_en.Item_OpenCmd, openInCmdMenuItem_click);
			openInCmdAdminMenuItem = new MenuItem(Properties.Strings_en.Item_OpenCmdAdmin, openInCmdAdminMenuItem_click);
			rightClickMenu.MenuItems.Add(renameMenuItem);
			rightClickMenu.MenuItems.Add(folderShortcutMenuItem);
			rightClickMenu.MenuItems.Add(folderExpandMenuItem);
			rightClickMenu.MenuItems.Add(openInExplorerMenuItem);
			rightClickMenu.MenuItems.Add(openInCmdMenuItem);
			rightClickMenu.MenuItems.Add(openInCmdAdminMenuItem);
			this.instance = instance;
			InitializeComponent();
			nodes = new List<ITreeNode>();
			foreach (TrayInstanceNode tin in instance.nodes.children)
			{
				InitNodes(treeView2, tin, null);
			}
			treeView2.ExpandAll();
			TreeNode folder = new TreeNode();
			if (!IconUtils.initialized) {
				IconUtils.Init(upButton.Font.Height);
			}
			this.treeView2.ImageList = IconUtils.imageList;
			updateImage(upButton, IconUtils.UP);
			updateImage(downButton, IconUtils.DOWN);
			updateImage(indentButton, IconUtils.INDENT_IN);
			updateImage(outdentButton, IconUtils.INDENT_OUT);
			updateImage(newDocButton, IconUtils.DOCUMENT_NEW);
			updateImage(newFolderButton, IconUtils.FOLDER_NEW);
			updateImage(newPluginButton, IconUtils.RUNNABLE_NEW);
			updateImage(newVirtualFolderButton, IconUtils.FOLDER_BLUE_NEW);
			updateImage(newSeparatorButton, IconUtils.SEPARATOR);
			editButton.Image = IconUtils.EditImage;
			editButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			editButton.TextAlign = ContentAlignment.MiddleLeft;
			deleteButton.Image = IconUtils.DeleteImage;
			deleteButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			deleteButton.TextAlign = ContentAlignment.MiddleLeft;
			UpdateButtonEnables();
			foreach(ITreeNode n in nodes)
			{
				n.Refresh();
			}
		}
		public void setTabPage(TabPage tp)
		{
			this.tp = tp;
		}
		public Control GetControl()
		{
			return this.formTableLayoutPanel;
		}
		private ITreeNode InitNodes(TreeView tv, TrayInstanceNode tin, ITreeNode parent)
		{
			ITreeNode tn = new ITreeNode(tin);
			if (parent == null)
			{
				treeView2.Nodes.Add(tn.node);
			}
			if (tin.children.Count > 0)
			{
				foreach (TrayInstanceNode tinc in tin.children)
				{
					ITreeNode tnc = InitNodes(tv, tinc, tn);
					tn.node.Nodes.Add(tnc.node);
				}
			}
			nodes.Add(tn);
			return tn;
		}
		private void updateImage(Button b, int index)
		{
			b.Image = IconUtils.imageList.Images[index];
			b.Width = b.Height;
		}
		private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Text = e.Node.Text;
			foreach (ITreeNode itn in nodes)
			{
				if (e.Node == itn.node)
				{
					selectedNode = itn;
					break;
				}
			}
		}
		private void Save()
		{
			instance.Repair();
			instance.view.tray.Rebuild();
			MainForm.form.BuildExploreDropdown();
			ProgramData.pd.Save();
		}
		public void Rebuild()
		{
			foreach(ITreeNode itn in nodes) {
				itn.Refresh();
			}
		}
		private void upButton_Click(object sender, EventArgs e)
		{
			selectedNode.MoveUp();
			Save();
		}

		private void downButton_Click(object sender, EventArgs e)
		{
			selectedNode.MoveDown();
			Save();
		}

		private void indentButton_Click(object sender, EventArgs e)
		{
			selectedNode.MoveIn();
			Save();
		}

		private void outdentButton_Click(object sender, EventArgs e)
		{
			selectedNode.MoveOut();
			Save();
		}

		private void newDocButton_Click(object sender, EventArgs e)
		{
			selectedNodeNew = true;
			newPathButton_Click(sender, e);
			pathPropertiesButton_Click(null, null);
			selectedNode.Refresh();
			Save();
			selectedNodeNew = false;
		}

		private void newFolderButton_Click(object sender, EventArgs e)
		{
			selectedNodeNew = true;
			newPathButton_Click(sender, e);
			folderPropertiesButton_Click(null, null);
			selectedNode.Refresh();
			Save();
			selectedNodeNew = false;
		}
		private void newPathButton_Click(object sender, EventArgs e)
		{
			TrayInstancePath tip = new TrayInstancePath();
			instance.paths.Add(tip);
			int index = instance.paths.IndexOf(tip);
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.id = index;
			tin.type = TrayInstanceNode.NodeType.Path;
			tin.SetInstance(instance);
			ITreeNode itn = new ITreeNode(tin);
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
		}
		private void insertNode(ITreeNode itn)
		{
			TrayInstanceNode tin = itn.tin;
			if (selectedNode != null)
			{
				if (selectedNode.tin.type == TrayInstanceNode.NodeType.VirtualFolder)
				{
					selectedNode.tin.children.Add(tin);
					tin.parent = selectedNode.tin;
					selectedNode.node.Nodes.Add(itn.node);
				}
				else
				{
					TrayInstanceNode tinp = selectedNode.tin.parent;
					tinp.children.Insert(tinp.children.IndexOf(selectedNode.tin) + 1, tin);
					tin.parent = tinp;
					if (selectedNode.node.Parent != null)
					{
						TreeNode tnp = selectedNode.node.Parent;
						tnp.Nodes.Insert(tnp.Nodes.IndexOf(selectedNode.node) + 1, itn.node);
					}
					else
					{
						selectedNode.node.TreeView.Nodes.Insert(selectedNode.node.TreeView.Nodes.IndexOf(selectedNode.node) + 1, itn.node);
					}
				}
			}
			else
			{
				TrayInstanceNode tinp = instance.nodes;
				tinp.children.Add(tin);
				tin.parent = tinp;
				treeView2.Nodes.Add(itn.node);
			}
		}
		private void editButton_Click(object sender, EventArgs e) {
			ITreeNode itn = selectedNode;
			if (itn != null && itn.tin != null && itn.tin.type != TrayInstanceNode.NodeType.Separator) {
				switch (itn.tin.type) {
					case TrayInstanceNode.NodeType.Path:
						pathPropertiesButton_Click(sender, e);
						break;
					case TrayInstanceNode.NodeType.Plugin:
						pluginPropertiesButton_Click(sender, e);
						break;
					case TrayInstanceNode.NodeType.VirtualFolder:
						vFolderPropertiesButton_Click(sender, e);
						break;
				}
			}
		}
		private void pathPropertiesButton_Click(object sender, EventArgs e)
		{
			ITreeNode itn = selectedNode;
			IPathForm iff = new IPathForm(instance.paths[itn.tin.id]);
			if (selectedNodeNew) {
				iff.ShowDialogNewFile();
			}
			else {
				iff.ShowDialog();
			}
			itn.Refresh();
			itn.tin.instance.view.tray.Rebuild();
			Save();
		}
		private void folderPropertiesButton_Click(object sender, EventArgs e)
		{
			ITreeNode itn = selectedNode;
			IPathForm iff = new IPathForm(instance.paths[itn.tin.id]);
			if (selectedNodeNew) {
				iff.ShowDialogNewFolder();
			}
			else {
				iff.ShowDialog();
			}
			itn.Refresh();
			itn.tin.instance.view.tray.Rebuild();
			Save();
		}
		private void UpdateButtonEnables()
		{
			upButton.Enabled = selectedUpable;
			downButton.Enabled = selectedDownable;
			indentButton.Enabled = selectedIndentable;
			outdentButton.Enabled = selectedOutdentable;
			newDocButton.Enabled = true;
			newFolderButton.Enabled = true;
			newPluginButton.Enabled = true;
			newVirtualFolderButton.Enabled = true;
			deleteButton.Enabled = selectedNode != null;
			editButton.Enabled = selectedNode != null && selectedNode.tin.type != TrayInstanceNode.NodeType.Separator;
		}
		private void newVirtualFolderButton_Click(object sender, EventArgs e)
		{
			TrayInstanceVirtualFolder tip = new TrayInstanceVirtualFolder(Properties.Strings_en.VirtualFolder_New);
			instance.vfolders.Add(tip);
			int index = instance.vfolders.IndexOf(tip);
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.id = index;
			tin.type = TrayInstanceNode.NodeType.VirtualFolder;
			tin.SetInstance(instance);
			ITreeNode itn = new ITreeNode(tin);
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
			vFolderPropertiesButton_Click(sender, e);
		}
		private void renameButton_Click(object sender, EventArgs e)
		{
			string input = selectedNode.alias;
			if (InputDialog.ShowStringInputDialog(Properties.Strings_en.Form_EditDisplayName, ref input) == DialogResult.OK)
			{
				selectedNode.alias = input;
				Save();
			}
		}
		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				bool deleteNode = true;
				if (selectedNode.tin.type == TrayInstanceNode.NodeType.VirtualFolder && selectedNode.node.Nodes.Count > 0)
				{
					deleteNode = (MessageBox.Show(Properties.Strings_en.VirtualFolder_DeleteContents, "", MessageBoxButtons.OKCancel) == DialogResult.OK);
				}
				if (deleteNode)
				{
					selectedNode.Delete();
					Save();
				}
				if (treeView2.Nodes.Count == 0)
				{
					selectedNode = null;
				}
			}
		}
		private void treeView2_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
//            e.Cancel = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IOptionsForm optionsForm = new IOptionsForm(instance);
			optionsForm.ShowDialog();
			tp.Text = instance.instanceName;
			instance.view.tray.notifyIcon.Text = instance.instanceName;
		}
		private void RecursiveAddToInstance(TrayInstance recursive_instance, TrayInstanceNode tin, TrayInstanceNode parent)
		{
			TrayInstanceNode newTin = new TrayInstanceNode();
			newTin.type = tin.type;
			if (tin.type == TrayInstanceNode.NodeType.Path)
			{
				newTin.id = recursive_instance.paths.Count;
				recursive_instance.paths.Add(instance.paths[tin.id]);
			}
			if (tin.type == TrayInstanceNode.NodeType.VirtualFolder)
			{
				newTin.id = recursive_instance.vfolders.Count;
				recursive_instance.vfolders.Add(instance.vfolders[tin.id]);
			}
			if (tin.type == TrayInstanceNode.NodeType.Plugin)
			{
				if (recursive_instance.internalPlugins == null)
				{
					recursive_instance.internalPlugins = new List<TrayPlugin>();
				}
				newTin.id = recursive_instance.plugins.Count;
				TrayInstancePlugin ip = instance.plugins[tin.id].Copy();
				if (ip.plugin != null)
				{
					TrayPlugin tp = recursive_instance.getInternalPluginBySignature(ip.plugin.getSignature());
					if (tp == null)
					{
						recursive_instance.internalPlugins.Add(ip.plugin);
						tp = ip.plugin;
					}
					ip.id = recursive_instance.internalPlugins.IndexOf(tp);
				}
				recursive_instance.plugins.Add(ip);
			}
			if (parent == null)
			{
				recursive_instance.nodes.children.Add(newTin);
			} else
			{
				parent.children.Add(newTin);
			}
			foreach(TrayInstanceNode tinChild in tin.children)
			{
				RecursiveAddToInstance(recursive_instance, tinChild, newTin);
			}
		}
		private void CopyToClipboard()
		{
			TrayInstance copyInstance = new TrayInstance();
			RecursiveAddToInstance(copyInstance, selectedNode.tin, null);
			Clipboard.SetText(XMLUtils.XmlSerializeToString(copyInstance));
		}
		private void RecursiveLoadFromInstance(TrayInstance recursive_instance, TrayInstanceNode tin, ITreeNode parentNode)
		{
			TrayInstanceNode newTin = new TrayInstanceNode();
			newTin.type = tin.type;
			if (tin.type == TrayInstanceNode.NodeType.Path)
			{
				newTin.id = instance.paths.Count;
				instance.paths.Add(recursive_instance.paths[tin.id]);
			}
			else if (tin.type == TrayInstanceNode.NodeType.Plugin)
			{
				newTin.id = instance.plugins.Count;
				TrayInstancePlugin tip = recursive_instance.plugins[tin.id];
				TrayPlugin tp = recursive_instance.internalPlugins[tip.id];
				TrayPlugin gtp = instance.getGlobalPluginBySignature(tp.getSignature());
				if (gtp == null)
				{
					tip.id = ProgramData.pd.plugins.Count;
					ProgramData.pd.plugins.Add(tp);
				}
				else
				{
					tip.id = ProgramData.pd.plugins.IndexOf(gtp);
				}
				instance.plugins.Add(tip);
			}
			else if (tin.type == TrayInstanceNode.NodeType.VirtualFolder)
			{
				newTin.id = instance.vfolders.Count;
				instance.vfolders.Add(recursive_instance.vfolders[tin.id]);
			}
			newTin.SetInstance(instance);
			ITreeNode itn = new ITreeNode(newTin);
			if (parentNode != null) treeView2.SelectedNode = parentNode.node;
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
			foreach(TrayInstanceNode nodeChild in tin.children)
			{
				RecursiveLoadFromInstance(recursive_instance, nodeChild, itn);
			}
			itn.Refresh();
		}
		private void PasteFromClipboard()
		{
			try
			{
				TrayInstance copyInstance = (TrayInstance)XMLUtils.XmlDeserializeFromString(Clipboard.GetText(), typeof(TrayInstance));
				foreach(TrayInstanceNode tin in copyInstance.nodes.children)
				{
					RecursiveLoadFromInstance(copyInstance, tin, null);
				}
				Save();
			}
			catch
			{

			}

		}
		public void treeView2_KeyDown(object sender, KeyEventArgs e)
		{
			if (selectedNode != null) {
				if (e.KeyCode == Keys.Enter) {
					e.Handled = true;
					e.SuppressKeyPress = true;
					editButton_Click(sender, null);
				}
				if (e.KeyCode == Keys.F2) {
					renameButton_Click(sender, null);
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
				if (e.KeyCode == Keys.X) {
					if (e.Modifiers == Keys.Control) {
						CopyToClipboard();
						deleteButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
				if (e.KeyCode == Keys.C) {
					if (e.Modifiers == Keys.Control) {
						CopyToClipboard();
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
				if (e.KeyCode == Keys.N) {
					if (e.Modifiers == Keys.Control) {
						newDocButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
					if (e.Modifiers == (Keys.Control | Keys.Shift)) {
						newVirtualFolderButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
				if (e.KeyCode == Keys.E) {
					if (e.Modifiers == Keys.Control) {
						openInExplorerMenuItem_click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
				if (e.KeyCode == Keys.F) {
					if (e.Modifiers == Keys.Control) {
						newFolderButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
				if (e.KeyCode == Keys.Delete) {
					deleteButton_Click(sender, null);
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
				if (e.Modifiers == Keys.Control) {
					if (e.KeyCode == Keys.Up && selectedUpable) {
						upButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
					if (e.KeyCode == Keys.Down && selectedDownable) {
						downButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
					if (e.KeyCode == Keys.Left && selectedOutdentable) {
						outdentButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
					if (e.KeyCode == Keys.Right && selectedIndentable) {
						indentButton_Click(sender, null);
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
				}
			}
			if (e.KeyCode == Keys.V) {
				if (e.Modifiers == Keys.Control) {
					PasteFromClipboard();
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			if (e.KeyCode == Keys.Escape) {
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
		private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (selectedNode != null)
			{
				if (selectedNode.tin.type == TrayInstanceNode.NodeType.Plugin)
				{
					pluginPropertiesButton_Click(sender, e);
				}
				else if (selectedNode.tin.type == TrayInstanceNode.NodeType.Path) {
					pathPropertiesButton_Click(sender, e);
				}
				else if (selectedNode.tin.type == TrayInstanceNode.NodeType.VirtualFolder)
				{
					vFolderPropertiesButton_Click(sender, e);
				}
			}
		}
		private void folderShortcutMenuItem_click(object sender, EventArgs e)
		{
			instance.paths[selectedNode.tin.id].shortcut = true;
			selectedNode.Refresh();
			instance.view.tray.Rebuild();
		}
		private void folderExpandMenuItem_click(object sender, EventArgs e)
		{
			instance.paths[selectedNode.tin.id].shortcut = false;
			selectedNode.Refresh();
			instance.view.tray.Rebuild();
		}
		private void openInExplorerMenuItem_click(object sender, EventArgs e) {
			AppUtils.ExplorePath(instance.paths[selectedNode.tin.id].path);
		}
		private void openInCmdMenuItem_click(object sender, EventArgs e) {
			AppUtils.OpenCmdPath(instance.paths[selectedNode.tin.id].path);
		}
		private void openInCmdAdminMenuItem_click(object sender, EventArgs e) {
			AppUtils.OpenAdminCmdPath(instance.paths[selectedNode.tin.id].path);
		}
		private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right && selectedNode != null)
			{
				if (e.Node != null)
				{
					foreach (ITreeNode itn in nodes)
					{
						if (e.Node == itn.node)
						{
							selectedNode = itn;
							break;
						}
					}
				}
				if (selectedNode.tin.type == TrayInstanceNode.NodeType.Path)
				{
					TrayInstancePath path = instance.paths[selectedNode.tin.id];
					if (path.isDir)
					{
						folderShortcutMenuItem.Enabled = true;
						folderExpandMenuItem.Enabled = true;
						folderShortcutMenuItem.Visible = !path.shortcut;
						folderExpandMenuItem.Visible = path.shortcut;
					}
					else
					{
						folderShortcutMenuItem.Enabled = false;
						folderExpandMenuItem.Enabled = false;
						folderShortcutMenuItem.Visible = true;
						folderExpandMenuItem.Visible = false;
					}
					openInExplorerMenuItem.Enabled = true;
					openInCmdMenuItem.Enabled = true;
					openInCmdAdminMenuItem.Enabled = true;
				}
				else {
					folderShortcutMenuItem.Enabled = false;
					folderExpandMenuItem.Enabled = false;
					folderShortcutMenuItem.Visible = true;
					folderExpandMenuItem.Visible = false;
					openInExplorerMenuItem.Enabled = false;
					openInCmdMenuItem.Enabled = false;
					openInCmdAdminMenuItem.Enabled = false;
				}
				rightClickMenu.Show(treeView2, e.Location);
			}
		}

		private void newPluginButton_Click(object sender, EventArgs e)
		{
			TrayInstancePlugin tip = new TrayInstancePlugin();
			instance.plugins.Add(tip);
			int index = instance.plugins.IndexOf(tip);
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.id = index;
			tin.type = TrayInstanceNode.NodeType.Plugin;
			tin.SetInstance(instance);
			ITreeNode itn = new ITreeNode(tin);
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
			pluginPropertiesButton_Click(sender, e);
		}
		private void newSeparatorButton_Click(object sender, EventArgs e)
		{
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.type = TrayInstanceNode.NodeType.Separator;
			tin.SetInstance(instance);
			ITreeNode itn = new ITreeNode(tin);
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
			itn.Refresh();
			itn.tin.instance.view.tray.Rebuild();
			Save();
		}
		private void pluginPropertiesButton_Click(object sender, EventArgs e) {
			ITreeNode itn = selectedNode;
			IPluginForm ipf = new IPluginForm(instance.plugins[itn.tin.id]);
			ipf.ShowDialog();
			itn.Refresh();
			itn.tin.instance.view.tray.Rebuild();
			Save();
		}
		private void vFolderPropertiesButton_Click(object sender, EventArgs e) {
			ITreeNode itn = selectedNode;
			IVirtualFolderForm ivff = new IVirtualFolderForm(instance.vfolders[itn.tin.id]);
			ivff.ShowDialog();
			itn.Refresh();
			itn.tin.instance.view.tray.Rebuild();
			Save();
		}
		private void treeView2_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}
		private void treeView2_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}
		private void treeView2_DragOver(object sender, DragEventArgs e)
		{
			Point targetPoint = treeView2.PointToClient(new Point(e.X, e.Y));
			treeView2.SelectedNode = treeView2.GetNodeAt(targetPoint);
		}
		private void treeView2_DragDrop(object sender, DragEventArgs e)
		{
			Point targetPoint = treeView2.PointToClient(new Point(e.X, e.Y));
			TreeNode targetNode = treeView2.GetNodeAt(targetPoint);
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (string file in files) {
					Console.WriteLine(file);
					if (targetNode != null) {
						AddNewPathOverB(file, targetNode);
					} else {
						AddNewPath(file);
					}
				}
			} else {
				if (targetNode != null) {
					TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
					MoveAOverB(draggedNode, targetNode);
				}
			}
		}
		private ITreeNode CreatePathNode()
		{
			return CreatePathNode("");
		}
		private ITreeNode CreatePathNode(string path)
		{
			TrayInstancePath tip = new TrayInstancePath();
			tip.path = path;
			instance.paths.Add(tip);
			int index = instance.paths.IndexOf(tip);
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.id = index;
			tin.type = TrayInstanceNode.NodeType.Path;
			tin.SetInstance(instance);
			return new ITreeNode(tin);
		}
		private void AddNewPathOverB(string path, TreeNode B)
		{
			ITreeNode itn = CreatePathNode(path);
			itn.Refresh();
			nodes.Add(itn);
			MoveAOverB(itn.node, B);
			Save();
		}
		private void AddNewPath(string path)
		{
			ITreeNode itn = CreatePathNode(path);
			itn.Refresh();
			insertNode(itn);
			treeView2.SelectedNode = itn.node;
			selectedNode = itn;
			nodes.Add(itn);
			Save();
		}
		private void MoveAOverB(TreeNode A, TreeNode B)
		{
			if ((!A.Equals(B)) && (!ContainsNode(A, B))) {
				int targetNodeIndex;
				if (B.Parent != null) {
					targetNodeIndex = B.Parent.Nodes.IndexOf(B);
					A.Remove();
					B.Parent.Nodes.Insert(targetNodeIndex, A);
				} else {
					targetNodeIndex = treeView2.Nodes.IndexOf(B);
					A.Remove();
					treeView2.Nodes.Insert(targetNodeIndex, A);
				}
				TrayInstanceNode tA = TreeNodeToInstanceNode(A);
				TrayInstanceNode tB = TreeNodeToInstanceNode(B);
				if (tA != null && tB != null) {
					tA.MoveOverB(tB);
					Save();
				}
			}
		}
		private bool ContainsNode(TreeNode node1, TreeNode node2)
		{
			if (node2.Parent == null) return false;
			if (node2.Parent.Equals(node1)) return true;
			return ContainsNode(node1, node2.Parent);
		}
		private TrayInstanceNode TreeNodeToInstanceNode(TreeNode node)
		{
			foreach(ITreeNode n in nodes) {
				if (node.Equals(n.node)) {
					return n.tin;
				}
			}
			return null;
		}
	}
}
