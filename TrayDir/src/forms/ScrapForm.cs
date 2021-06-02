using FolderSelect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class ScrapForm : Form
    {
        private List<ITreeNode> nodes;
        private ITreeNode selectedNode { get { return __selectedNode; } set { __selectedNode = value; UpdateButtonEnables(); } }
        private ITreeNode __selectedNode;
        private TrayInstance instance;
        public ScrapForm(TrayInstance instance)
        {
            this.instance = instance;
            InitializeComponent();
            nodes = new List<ITreeNode>();
            foreach(TrayInstanceNode tin in instance.nodes.children)
            {
                InitNodes(treeView2, tin, null);
                
            }
            treeView2.ExpandAll();
            TreeNode folder = new TreeNode();
            LoadImages();
            updateImage(upButton, 5);
            updateImage(downButton, 6);
            updateImage(indentButton, 12);
            updateImage(outdentButton, 13);
            updateImage(newDocButton, 8);
            updateImage(newFolderButton,9);
            updateImage(newPluginButton,7);
            updateImage(newVirtualFolderButton,4);
            updateImage(deleteButton, 10);
            docPropertiesButton.Image = imageList1.Images[0];
            docPropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            docPropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
            folderPropertiesButton.Image = imageList1.Images[1];
            folderPropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            folderPropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
            runnablePropertiesButton.Image = imageList1.Images[3];
            runnablePropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            runnablePropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
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
                foreach(TrayInstanceNode tinc in tin.children)
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
            b.Image = imageList1.Images[index];
            b.Width = b.Height;
        }
        private void LoadImages()
        {
            imageList1.ImageSize = new Size(upButton.Font.Height, upButton.Font.Height);
            imageList1.Images.Add(TrayDir.Properties.Resources.document);
            imageList1.Images.Add(TrayDir.Properties.Resources.folder);
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_blue);
            imageList1.Images.Add(TrayDir.Properties.Resources.runnable);
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_blue_new);
            imageList1.Images.Add(TrayDir.Properties.Resources.up);
            imageList1.Images.Add(TrayDir.Properties.Resources.down);
            imageList1.Images.Add(TrayDir.Properties.Resources.runnable_new);
            imageList1.Images.Add(TrayDir.Properties.Resources.document_new);
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_new);
            imageList1.Images.Add(TrayDir.Properties.Resources.delete) ;
            imageList1.Images.Add(TrayDir.Properties.Resources.question);
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_in);
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_out);
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = e.Node.Text;
            foreach( ITreeNode itn in nodes)
            {
                if (e.Node == itn.node)
                {
                    selectedNode = itn;
                    break;
                }
            }
        }
        private void ScrapForm_Load(object sender, EventArgs e)
        {

        }

        private void upButton_Click(object sender, EventArgs e)
        {
            selectedNode.MoveUp();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            selectedNode.MoveDown();
        }

        private void indentButton_Click(object sender, EventArgs e)
        {
            selectedNode.MoveIn();
        }

        private void outdentButton_Click(object sender, EventArgs e)
        {
            selectedNode.MoveOut();
        }

        private void newDocButton_Click(object sender, EventArgs e)
        {
            newPathButton_Click(sender, e);
            docPropertiesButton_Click(null, null);
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            newPathButton_Click(sender, e);
            folderPropertiesButton_Click(null, null);
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
                    if (selectedNode.node.Parent != null)
                    {
                        selectedNode.node.Nodes.Add(itn.node);
                    }
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
        private void docPropertiesButton_Click(object sender, EventArgs e)
        {
            MainForm.form.fd.DereferenceLinks = false;
            string path = instance.paths[selectedNode.tin.id].path;
            if (path == null || path == "")
            {
                MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                MainForm.form.fd.InitialDirectory = path;
            }
            DialogResult d = MainForm.form.fd.ShowDialog();
            if (d == DialogResult.OK)
            {
                instance.paths[selectedNode.tin.id].path = MainForm.form.fd.FileName;
                selectedNode.Refresh();
                MainForm.form.BuildExploreDropdown();
                MainForm.form.pd.Save();
            }
        }

        private void folderPropertiesButton_Click(object sender, EventArgs e)
        {
            FolderSelectDialog fs = new FolderSelectDialog(this);
            string path = instance.paths[selectedNode.tin.id].path;
            if (path == null || path == "")
            {
                MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                MainForm.form.fd.InitialDirectory = path;
            }
            if (fs.ShowDialog())
            {
                instance.paths[selectedNode.tin.id].path = fs.FileName;
                selectedNode.Refresh();
                MainForm.form.BuildExploreDropdown();
                MainForm.form.pd.Save();
            }
        }
        private void UpdateButtonEnables()
        {
            upButton.Enabled = true;
            downButton.Enabled = true;
            indentButton.Enabled = true;
            outdentButton.Enabled = true;
            newDocButton.Enabled = true;
            newFolderButton.Enabled = true;
            newPluginButton.Enabled = true;
            newVirtualFolderButton.Enabled = true;
            deleteButton.Enabled = true;
            docPropertiesButton.Enabled = selectedNode.tin.type == TrayInstanceNode.NodeType.Path;
            folderPropertiesButton.Enabled = selectedNode.tin.type == TrayInstanceNode.NodeType.Path;
            runnablePropertiesButton.Enabled = selectedNode.tin.type == TrayInstanceNode.NodeType.Plugin;
        }
    }
}
