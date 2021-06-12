using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstanceNode
    {
        public enum NodeType
        {
            Path,
            VirtualFolder,
            Plugin
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

        public int NodeCount { get { int i = 0; if (type == NodeType.Path || type == NodeType.Plugin) i++;  foreach (TrayInstanceNode tin in children) i += tin.NodeCount; return i; } }
        public int ParentIndex { get { if (parent == null) { return -1; } return parent.children.IndexOf(this); } }
        public TrayInstanceNode()
        {
            children = new List<TrayInstanceNode>();
        }
        public void SetInstance(TrayInstance instance)
        {
            this.instance = instance;
            foreach(TrayInstanceNode child in children)
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
                } else if (index == 0)
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
                    grandparent.children.Insert(parent.ParentIndex+1, this);
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
            foreach(TrayInstanceNode child in children)
            {
                allnodes.Add(child);
                allnodes.AddRange(child.GetAllChildNodes());
            }
            return allnodes;
        }
    }
}
