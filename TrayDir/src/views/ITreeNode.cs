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
    }
}
