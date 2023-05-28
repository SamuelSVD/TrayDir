using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;

namespace TrayDir {
	public abstract class ITreeNode {
		protected static Font strikethroughFont;
		internal TreeNode node;
		internal TrayInstanceNode tin;
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
					return tin.parent.children[index - 1].itn;
				}
				return null;
			}
		}
		internal ITreeNode nextRelative {
			get {
				if (!isLastChild) {
					return tin.parent.children[index + 1].itn;
				}
				return null;
			}
		}
		internal string alias {
			get {
				switch (tin.type) {
					case TrayInstanceNode.NodeType.Path:
						return tin.instance.paths[tin.id].alias;
					case TrayInstanceNode.NodeType.Plugin:
						return tin.instance.plugins[tin.id].alias;
					case TrayInstanceNode.NodeType.VirtualFolder:
						return tin.instance.vfolders[tin.id].alias;
					case TrayInstanceNode.NodeType.WebLink:
						return tin.instance.weblinks[tin.id].alias;
					default:
						return null;
				}
			}
			set {
				switch (tin.type) {
					case TrayInstanceNode.NodeType.Path:
						tin.instance.paths[tin.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.Plugin:
						tin.instance.plugins[tin.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.VirtualFolder:
						tin.instance.vfolders[tin.id].alias = value;
						break;
					case TrayInstanceNode.NodeType.WebLink:
						tin.instance.weblinks[tin.id].alias = value;
						break;
					default:
						break;
				}
				Refresh();
			}
		}
		internal abstract bool Hidden { get; }
		public ITreeNode(TrayInstanceNode tin) {
			this.tin = tin;
			tin.itn = this;
			node = new TreeNode();
			Refresh();
		}
		internal abstract void Refresh();
		internal void MoveUp() {
			tin.MoveUp();

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
			tin.MoveDown();
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
			tin.MoveIn();

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
			tin.MoveOut();

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
			tin.Delete();
			if (this.node.Parent != null) {
				node.Parent.Nodes.Remove(node);
			} else {
				node.TreeView?.Nodes.Remove(node);
			}
			switch (tin.type) {
				case TrayInstanceNode.NodeType.Path:
					tin.instance.paths.RemoveAt(tin.id);
					foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes()) {
						if (n.type == tin.type && n.id > tin.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.Plugin:
					tin.instance.plugins.RemoveAt(tin.id);
					foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes()) {
						if (n.type == tin.type && n.id > tin.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.VirtualFolder:
					tin.instance.vfolders.RemoveAt(tin.id);
					foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes()) {
						if (n.type == tin.type && n.id > tin.id) n.id--;
					}
					break;
				case TrayInstanceNode.NodeType.WebLink:
					tin.instance.weblinks.RemoveAt(tin.id);
					foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes()) {
						if (n.type == tin.type && n.id > tin.id) n.id--;
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
