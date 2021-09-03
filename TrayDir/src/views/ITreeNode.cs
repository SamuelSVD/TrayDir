using System.Windows.Forms;

namespace TrayDir
{
    public class ITreeNode
    {
        public TreeNode node;
        public TrayInstanceNode tin;
        public int index
        {
            get
            {
                return node.Parent != null ? node.Parent.Nodes.IndexOf(node) : node.TreeView.Nodes.IndexOf(node);
            }
        }
        public bool isFirstChild
        {
            get
            {
                return index == 0;
            }
        }
        public bool isLastChild
        {
            get
            {
                return node.Parent != null ? node.Parent.Nodes.Count == index + 1 : node.TreeView.Nodes.Count == index + 1;
            }
        }
        public ITreeNode previousRelative
        {
            get
            {
                if (!isFirstChild)
                {
                    return tin.parent.children[index - 1].itn;
                }
                return null;
            }
        }
        public ITreeNode nextRelative
        {
            get
            {
                if (!isLastChild)
                {
                    return tin.parent.children[index + 1].itn;
                }
                return null;
            }
        }
        public string alias
        {
            get
            {
                switch (tin.type)
                {
                    case TrayInstanceNode.NodeType.Path:
                        return tin.instance.paths[tin.id].alias;
                    case TrayInstanceNode.NodeType.Plugin:
                        return tin.instance.plugins[tin.id].alias;
                    case TrayInstanceNode.NodeType.VirtualFolder:
                        return tin.instance.vfolders[tin.id].alias;
                    default:
                        return null;
                }
            }
            set
            {
                switch (tin.type)
                {
                    case TrayInstanceNode.NodeType.Path:
                        tin.instance.paths[tin.id].alias = value;
                        break;
                    case TrayInstanceNode.NodeType.Plugin:
                        tin.instance.plugins[tin.id].alias = value;
                        break;
                    case TrayInstanceNode.NodeType.VirtualFolder:
                        tin.instance.vfolders[tin.id].alias = value;
                        break;
                    default:
                        break;
                }
                Refresh();
            }
        }
        public ITreeNode(TrayInstanceNode tin)
        {
            this.tin = tin;
            tin.itn = this;
            node = new TreeNode();
            Refresh();
        }
        public void Refresh()
        {
            switch (tin.type)
            {
                case TrayInstanceNode.NodeType.Path:
                    TrayInstancePath tip = tin.instance.paths[tin.id];
                    bool hasAlias = alias != null && alias != "";
                    if (tip.isDir)
                    {
                        if (tip.shortcut)
                        {
                            node.ImageIndex = 14;
                            node.SelectedImageIndex = 14;
                        } else
                        {
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                        }
                        node.Text = "";
                    }
                    else if (tip.isFile)
                    {
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.Text = "";
                    }
                    else
                    {
                        node.ImageIndex = 11;
                        node.SelectedImageIndex = 11;
                        node.Text = "ERROR: ";
                    }

                    node.Text += hasAlias ? alias : "";
                    node.Text += hasAlias ? " (" + tin.instance.paths[tin.id].path + ")" : tin.instance.paths[tin.id].path;

                    break;
                case TrayInstanceNode.NodeType.VirtualFolder:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    node.Text = tin.instance.vfolders[tin.id].alias;
                    break;
                case TrayInstanceNode.NodeType.Plugin:
                    break;
                default:
                    break;
            }
        }
        public void MoveUp()
        {
            tin.MoveUp();

            if (node.Parent != null)
            {
                TreeNode parent = node.Parent;
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                    node.TreeView.SelectedNode = node;
                }
                else if (index == 0)
                {
                    //TODO
                }
            } else
            {
                TreeView tv = node.TreeView;
                int index = tv.Nodes.IndexOf(node);
                if (index > 0)
                {
                    tv.Nodes.RemoveAt(index);
                    tv.Nodes.Insert(index - 1, node);
                    tv.SelectedNode = node;
                }
            }
        }
        public void MoveDown()
        {
            tin.MoveDown();
            TreeNode parent = node.Parent;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                    node.TreeView.SelectedNode = node;
                }
                else if (index == parent.Nodes.Count - 1)
                {
                    MoveOut();
                }
            }
            else
            {
                TreeView tv = node.TreeView;
                int index = tv.Nodes.IndexOf(node);
                if (index < tv.Nodes.Count - 1)
                {
                    tv.Nodes.RemoveAt(index);
                    tv.Nodes.Insert(index + 1, node);
                    tv.SelectedNode = node;
                }
            }
        }
        public void MoveIn()
        {
            tin.MoveIn();

            TreeNode parent = node.Parent;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes[index - 1].Nodes.Add(node);
                }
                else if (index == 0)
                {
                }
            } 
            else
            {
                TreeView tv = node.TreeView;
                int index = tv.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent = tv.Nodes[index - 1];
                    tv.Nodes.RemoveAt(index);
                    parent.Nodes.Add(node);
                }
            }
            node.TreeView.SelectedNode = node;
        }
        public void MoveOut()
        {
            tin.MoveOut();

            TreeNode parent = node.Parent;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index >= 0)
                {
                    TreeNode grandParent = parent.Parent;
                    int parentindex;
                    if (grandParent != null)
                    {
                        parentindex = grandParent.Nodes.IndexOf(parent);
                        if (parentindex >= 0)
                        {
                            parent.Nodes.RemoveAt(index);
                            grandParent.Nodes.Insert(parentindex+1, node);
                        }
                    }
                    else
                    {
                        TreeView tv = node.TreeView;
                        parentindex = tv.Nodes.IndexOf(parent);
                        if (parentindex >= 0)
                        {
                            parent.Nodes.RemoveAt(index);
                            tv.Nodes.Insert(parentindex+1, node);
                        }
                    }
                }
            }
            node.TreeView.SelectedNode = node;
        }

        public void Delete()
        {
            tin.Delete();
            if (this.node.Parent != null)
            {
                node.Parent.Nodes.Remove(node);
            }
            else
            {
                node.TreeView.Nodes.Remove(node);
            }
            switch(tin.type)
            {
                case TrayInstanceNode.NodeType.Path:
                    tin.instance.paths.RemoveAt(tin.id);
                    foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes())
                    {
                        if (n.type == tin.type && n.id > tin.id) n.id--;
                    }
                    break;
                case TrayInstanceNode.NodeType.Plugin:
                    tin.instance.plugins.RemoveAt(tin.id);
                    foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes())
                    {
                        if (n.type == tin.type && n.id > tin.id) n.id--;
                    }
                    break;
                case TrayInstanceNode.NodeType.VirtualFolder:
                    tin.instance.vfolders.RemoveAt(tin.id);
                    foreach (TrayInstanceNode n in tin.instance.nodes.GetAllChildNodes())
                    {
                        if (n.type == tin.type && n.id > tin.id) n.id--;
                    }
                    break;
            }
        }
    }
}
