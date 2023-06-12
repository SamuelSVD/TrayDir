using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrayDir.src.views;
using TrayDir.utils;

namespace TrayDir {
	public abstract class ITreeNode {
		protected static Font strikethroughFont;
		internal TreeNode node;
		internal IItem Item;
		internal static Dictionary<string, int> pluginIndex = new Dictionary<string, int>();
		internal int index {
			get {
				return node.Parent != null ? node.Parent.Nodes.IndexOf(node) : node.TreeView.Nodes.IndexOf(node);
			}
		}
		internal bool isFirstChild {
			get {
				return index == 0;
			}
		}
		internal bool isLastChild {
			get {
				return node.Parent != null ? node.Parent.Nodes.Count == index + 1 : node.TreeView.Nodes.Count == index + 1;
			}
		}
		internal ITreeNode previousRelative {
			get {
				if (!isFirstChild) {
					return Item.TrayInstanceNode.parent.children[index - 1].itn;
				}
				return null;
			}
		}
		internal ITreeNode nextRelative {
			get {
				if (!isLastChild) {
					return Item.TrayInstanceNode.parent.children[index + 1].itn;
				}
				return null;
			}
		}
		internal string alias {
			get {
				switch (Item.TrayInstanceNode.type) {
					case TrayInstanceNode.NodeType.Path:
						return Item.TrayInstanceNode.instance.paths[Item.TrayInstanceNode.id].alias;
					case TrayInstanceNode.NodeType.Plugin:
						return Item.TrayInstanceNode.instance.plugins[Item.TrayInstanceNode.id].alias;
					case TrayInstanceNode.NodeType.VirtualFolder:
						return Item.TrayInstanceNode.instance.vfolders[Item.TrayInstanceNode.id].alias;
					case TrayInstanceNode.NodeType.WebLink:
						return Item.TrayInstanceNode.instance.weblinks[Item.TrayInstanceNode.id].alias;
					default:
						return null;
				}
			}
			set {
				switch (Item.TrayInstanceNode.type) {
					case TrayInstanceNode.NodeType.Path:
						Item.TrayInstanceNode.instance.paths[Item.TrayInstanceNode.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.Plugin:
						Item.TrayInstanceNode.instance.plugins[Item.TrayInstanceNode.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.VirtualFolder:
						Item.TrayInstanceNode.instance.vfolders[Item.TrayInstanceNode.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.WebLink:
						Item.TrayInstanceNode.instance.weblinks[Item.TrayInstanceNode.id].alias = value;
						break;
					default:
						break;
				}
				Refresh();
			}
		}
		internal abstract bool Hidden { get; }
		internal ITreeNode(IItem item) {
			Item = item;
			Item.TreeNode = this;
			Item.TrayInstanceNode.itn = this;
			node = new TreeNode();
			Refresh();
		}
		internal abstract void Refresh();
		internal void MoveUp() {
			Item.TrayInstanceNode.MoveUp();

			if (node.Parent != null) {
				TreeNode parent = node.Parent;
				int index = parent.Nodes.IndexOf(node);
				if (index > 0) {
					parent.Nodes.RemoveAt(index);
					parent.Nodes.Insert(index - 1, node);
					node.TreeView.SelectedNode = node;
				} else if (index == 0) {
					//TODO
				}
			} else {
				TreeView tv = node.TreeView;
				int index = tv.Nodes.IndexOf(node);
				if (index > 0) {
					tv.Nodes.RemoveAt(index);
					tv.Nodes.Insert(index - 1, node);
					tv.SelectedNode = node;
				}
			}
		}
		internal void MoveDown() {
			Item.TrayInstanceNode.MoveDown();
			TreeNode parent = node.Parent;
			if (parent != null) {
				int index = parent.Nodes.IndexOf(node);
				if (index < parent.Nodes.Count - 1) {
					parent.Nodes.RemoveAt(index);
					parent.Nodes.Insert(index + 1, node);
					node.TreeView.SelectedNode = node;
				} else if (index == parent.Nodes.Count - 1) {
					MoveOut();
				}
			} else {
				TreeView tv = node.TreeView;
				int index = tv.Nodes.IndexOf(node);
				if (index < tv.Nodes.Count - 1) {
					tv.Nodes.RemoveAt(index);
					tv.Nodes.Insert(index + 1, node);
					tv.SelectedNode = node;
				}
			}
		}
		internal void MoveIn() {
			Item.TrayInstanceNode.MoveIn();

			TreeNode parent = node.Parent;
			if (parent != null) {
				int index = parent.Nodes.IndexOf(node);
				if (index > 0) {
					parent.Nodes.RemoveAt(index);
					parent.Nodes[index - 1].Nodes.Add(node);
				} else if (index == 0) {
				}
			} else {
				TreeView tv = node.TreeView;
				int index = tv.Nodes.IndexOf(node);
				if (index > 0) {
					parent = tv.Nodes[index - 1];
					tv.Nodes.RemoveAt(index);
					parent.Nodes.Add(node);
				}
			}
			node.TreeView.SelectedNode = node;
		}
		internal void MoveOut() {
			Item.TrayInstanceNode.MoveOut();

			TreeNode parent = node.Parent;
			if (parent != null) {
				int index = parent.Nodes.IndexOf(node);
				if (index >= 0) {
					TreeNode grandParent = parent.Parent;
					int parentindex;
					if (grandParent != null) {
						parentindex = grandParent.Nodes.IndexOf(parent);
						if (parentindex >= 0) {
							parent.Nodes.RemoveAt(index);
							grandParent.Nodes.Insert(parentindex + 1, node);
						}
					} else {
						TreeView tv = node.TreeView;
						parentindex = tv.Nodes.IndexOf(parent);
						if (parentindex >= 0) {
							parent.Nodes.RemoveAt(index);
							tv.Nodes.Insert(parentindex + 1, node);
						}
					}
				}
			}
			node.TreeView.SelectedNode = node;
		}
		internal void Delete() {
			Item.TrayInstanceNode.Delete();
			if (this.node.Parent != null) {
				node.Parent.Nodes.Remove(node);
			} else {
				node.TreeView?.Nodes.Remove(node);
			}
			switch (Item.TrayInstanceNode.type) {
				case TrayInstanceNode.NodeType.Path:
					Item.TrayInstanceNode.instance.paths.RemoveAt(Item.TrayInstanceNode.id);
					foreach (TrayInstanceNode n in Item.TrayInstanceNode.instance.nodes.GetAllChildNodes()) {
						if (n.type == Item.TrayInstanceNode.type && n.id > Item.TrayInstanceNode.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.Plugin:
					Item.TrayInstanceNode.instance.plugins.RemoveAt(Item.TrayInstanceNode.id);
					foreach (TrayInstanceNode n in Item.TrayInstanceNode.instance.nodes.GetAllChildNodes()) {
						if (n.type == Item.TrayInstanceNode.type && n.id > Item.TrayInstanceNode.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.VirtualFolder:
					Item.TrayInstanceNode.instance.vfolders.RemoveAt(Item.TrayInstanceNode.id);
					foreach (TrayInstanceNode n in Item.TrayInstanceNode.instance.nodes.GetAllChildNodes()) {
						if (n.type == Item.TrayInstanceNode.type && n.id > Item.TrayInstanceNode.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.WebLink:
					Item.TrayInstanceNode.instance.weblinks.RemoveAt(Item.TrayInstanceNode.id);
					foreach (TrayInstanceNode n in Item.TrayInstanceNode.instance.nodes.GetAllChildNodes()) {
						if (n.type == Item.TrayInstanceNode.type && n.id > Item.TrayInstanceNode.id) n.id--;
					}
					break;
			}
		}
		public void UpdateFont() {
			if (Hidden && node.TreeView != null) {
				if (strikethroughFont == null) {
					strikethroughFont = new Font(node.TreeView.Font.FontFamily, node.TreeView.Font.Size, FontStyle.Strikeout);
				}
				node.NodeFont = strikethroughFont;
			} else {
				if (node.TreeView != null) {
					node.NodeFont = node.TreeView?.Font;
					node.NodeFont = System.Windows.Forms.Control.DefaultFont;
				}
			}
		}
	}
}
