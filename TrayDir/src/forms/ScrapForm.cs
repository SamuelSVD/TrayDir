using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class ScrapForm : Form
    {
        private List<ITreeNode> nodes;
        private ITreeNode selectedNode;
        public ScrapForm()
        {
            InitializeComponent();
            nodes = new List<ITreeNode>();
            foreach(TrayInstanceNode tin in MainForm.form.trayInstance.nodes.children)
            {
                ITreeNode tn = new ITreeNode(tin);
                treeView2.Nodes.Add(tn.node);
                nodes.Add(tn);
            }
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
    }
}
