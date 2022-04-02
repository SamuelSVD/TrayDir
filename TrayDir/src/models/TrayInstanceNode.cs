using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstanceNode
	{
		public enum NodeType
		{
			Path,
			VirtualFolder,
			Plugin,
			Separator
		}
		[XmlAttribute]
		public NodeType type = NodeType.Path;
		[XmlAttribute]
		public int id;
		public List<TrayInstanceNode> children;

		[XmlIgnore]
		public TrayInstanceNode parent;
		[XmlIgnore]
		public TrayInstance instance;
		[XmlIgnore]
		public ITreeNode itn;
		[XmlIgnore]
		public TrayInstancePath __path;
		[XmlIgnore]
		public TrayInstanceVirtualFolder __vfolder;
		[XmlIgnore]
		public TrayInstancePlugin __plugin;

		public int NodeCount { get { int i = 0; if (type == NodeType.Path || type == NodeType.Plugin) i++; foreach (TrayInstanceNode tin in children) i += tin.NodeCount; return i; } }
		public int ParentIndex { get { if (parent == null) { return -1; } return parent.children.IndexOf(this); } }
		public TrayInstanceNode()
		{
			children = new List<TrayInstanceNode>();
		}
		public void SetInstance(TrayInstance instance)
		{
			this.instance = instance;
			foreach (TrayInstanceNode child in children)
			{
				child.SetInstance(instance);
			}
		}
		public void FixChildren()
		{
			foreach (TrayInstanceNode child in children)
			{
				child.parent = this;
				child.FixChildren();
			}
		}
		public void MoveUp()
		{
			if (parent != null)
			{
				int index = parent.children.IndexOf(this);
				if (index > 0)
				{
					parent.children.RemoveAt(index);
					parent.children.Insert(index - 1, this);
				}
				else if (index == 0)
				{
					//TODO
				}
			}
		}
		public void MoveDown()
		{
			if (parent != null)
			{
				int index = parent.children.IndexOf(this);
				if (index < parent.children.Count - 1)
				{
					parent.children.RemoveAt(index);
					parent.children.Insert(index + 1, this);
				}
				else if (index == parent.children.Count - 1)
				{
					MoveOut();
				}
			}
		}
		public void MoveIn()
		{
			if (parent != null)
			{
				int index = parent.children.IndexOf(this);
				if (index > 0)
				{
					TrayInstanceNode newParent = parent.children[index - 1];
					parent.children.RemoveAt(index);
					newParent.children.Add(this);
					parent = newParent;
				}
				else if (index == 0)
				{
				}
			}
		}
		public void MoveOut()
		{
			if (parent != null)
			{
				int index = parent.children.IndexOf(this);
				TrayInstanceNode grandparent = parent.parent;
				if (grandparent != null)
				{
					parent.children.RemoveAt(index);
					grandparent.children.Insert(parent.ParentIndex + 1, this);
					parent = grandparent;
				}
			}
		}
		public void Delete()
		{
			if (parent != null)
			{
				parent.children.Remove(this);
			}
		}
		public List<TrayInstanceNode> GetAllChildNodes()
		{
			List<TrayInstanceNode> allnodes = new List<TrayInstanceNode>();
			foreach (TrayInstanceNode child in children)
			{
				allnodes.Add(child);
				allnodes.AddRange(child.GetAllChildNodes());
			}
			return allnodes;
		}
		public TrayInstancePlugin GetPlugin()
		{
			if (instance.plugins.Count > id && id >= 0)
			{
				return instance.plugins[id];
			}
			return null;
		}
		public TrayInstanceNode Copy()
		{
			TrayInstanceNode tin = new TrayInstanceNode();
			tin.type = type;
			tin.id = id;
			foreach(TrayInstanceNode c in children)
			{
				tin.children.Add(c.Copy());
			}
			return tin;
		}
		public void MoveOverB(TrayInstanceNode B)
		{
			if ((!this.Equals(B)) && (!ContainsNode(this, B))) {
				int targetNodeIndex;
				if (B.parent != null) {
					targetNodeIndex = B.parent.children.IndexOf(B);
					if (this.parent != null) this.parent.children.Remove(this);
					B.parent.children.Insert(targetNodeIndex, this);
					parent = B.parent;
				}
			}
		}
		private bool ContainsNode(TrayInstanceNode node1, TrayInstanceNode node2)
		{
			if (node2.parent == null) return false;
			if (node2.parent.Equals(node1)) return true;
			return ContainsNode(node1, node2.parent);
		}
	}
}
