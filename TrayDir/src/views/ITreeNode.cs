using System.Windows.Forms;

namespace TrayDir
{
    class ITreeNode
    {
        public TreeNode node;
        public TrayInstanceNode tin;
        public ITreeNode(TrayInstanceNode tin)
        {
            this.tin = tin;
            node = new TreeNode();
            Refresh();
        }
        public void Refresh()
        {
            TrayInstancePath tip = tin.instance.paths[tin.id];
            switch (tin.type)
            {
                case TrayInstanceNode.NodeType.Path:
                    if (tip.isDir)
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        node.Text = tin.instance.paths[tin.id].alias + "(" + tin.instance.paths[tin.id].path + ")";
                    }
                    else if (tip.isFile)
                    {
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.Text = tin.instance.paths[tin.id].alias + "(" + tin.instance.paths[tin.id].path + ")";
                    }
                    else
                    {
                        node.ImageIndex = 11;
                        node.SelectedImageIndex = 11;
                        node.Text = "ERR" + tin.instance.paths[tin.id].alias + "(" + tin.instance.paths[tin.id].path + ")";
                    }
                    break;
                case TrayInstanceNode.NodeType.VirtualFolder:
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
            } else
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
    }
}
