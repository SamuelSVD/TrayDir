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
        private bool selectedIndentable { get { return selectedNode != null ? !selectedNode.isFirstChild && selectedNode.previousRelative.tin.type == TrayInstanceNode.NodeType.VirtualFolder : false; } }
        private bool selectedOutdentable { get { return selectedNode != null ? selectedNode.node.Parent != null : false; } }
        private bool selectedUpable { get { return selectedNode != null ? !selectedNode.isFirstChild : false; } }
        private bool selectedDownable {  get { return selectedNode != null ? !selectedNode.isLastChild : false; } }
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
            UpdateButtonEnables();
        }
        public Control GetControl()
        {
            return this.tableLayoutPanel1;
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
            imageList1.Images.Add(TrayDir.Properties.Resources.document);       //0
            imageList1.Images.Add(TrayDir.Properties.Resources.folder);         //1
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_blue);    //2
            imageList1.Images.Add(TrayDir.Properties.Resources.runnable);       //3
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_blue_new);//4
            imageList1.Images.Add(TrayDir.Properties.Resources.up);             //5
            imageList1.Images.Add(TrayDir.Properties.Resources.down);           //6
            imageList1.Images.Add(TrayDir.Properties.Resources.runnable_new);   //7
            imageList1.Images.Add(TrayDir.Properties.Resources.document_new);   //8
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_new);     //9
            imageList1.Images.Add(TrayDir.Properties.Resources.delete) ;        //10
            imageList1.Images.Add(TrayDir.Properties.Resources.question);       //11
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_in);      //12
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_out);     //13
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
        private void Save()
        {
            instance.Repair();
            instance.view.tray.Rebuild();
            ProgramData.pd.Save();
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
            newPathButton_Click(sender, e);
            docPropertiesButton_Click(null, null);
            Save();
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            newPathButton_Click(sender, e);
            folderPropertiesButton_Click(null, null);
            Save();
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
        private void docPropertiesButton_Click(object sender, EventArgs e)
        {
            ITreeNode itn = selectedNode;
            MainForm.form.fd.DereferenceLinks = false;
            string path = instance.paths[itn.tin.id].path;
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
                instance.paths[itn.tin.id].path = MainForm.form.fd.FileName;
                selectedNode.Refresh();
                MainForm.form.BuildExploreDropdown();
                Save();
            }
        }

        private void folderPropertiesButton_Click(object sender, EventArgs e)
        {
            ITreeNode itn = selectedNode;
            FolderSelectDialog fs = new FolderSelectDialog();
            string path = instance.paths[itn.tin.id].path;
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
                itn.Refresh();
                MainForm.form.BuildExploreDropdown();
                Save();
            }
        }
        private void UpdateButtonEnables()
        {
            upButton.Enabled = selectedUpable;
            downButton.Enabled = selectedDownable;
            indentButton.Enabled = selectedIndentable;
            outdentButton.Enabled = selectedOutdentable;
            renameButton.Enabled = selectedNode != null;
            newDocButton.Enabled = true;
            newFolderButton.Enabled = true;
            newPluginButton.Enabled = false;
            newVirtualFolderButton.Enabled = true;
            deleteButton.Enabled = selectedNode != null;
            docPropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Path : false;
            folderPropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Path : false;
            runnablePropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Plugin : false;
        }

        private void newVirtualFolderButton_Click(object sender, EventArgs e)
        {
            TrayInstanceVirtualFolder tip = new TrayInstanceVirtualFolder("New VFolder");
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
            Save();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            string input = selectedNode.alias;
            if (InputDialog.ShowStringInputDialog("Edit Display Name", ref input) == DialogResult.OK)
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
                    deleteNode = (MessageBox.Show("Delete virtual folder with its contents?", "", MessageBoxButtons.OKCancel) == DialogResult.OK);
                }
                if (deleteNode)
                {
                    selectedNode.Delete();
                    Save();
                }
            }
        }

        private void treeView2_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
