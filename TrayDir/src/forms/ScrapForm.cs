using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class ScrapForm : Form
    {
        public ScrapForm()
        {
            InitializeComponent();
            foreach(TrayInstanceNode tin in MainForm.form.trayInstance.nodes)
            {
                ITreeNode tn = new ITreeNode(tin);
                treeView2.Nodes.Add(tn.node);
            }
            TreeNode folder = new TreeNode();
            LoadImages();
            updateImage(upB, 5);
            updateImage(downB, 6);
            updateImage(newFileB, 8);
            updateImage(newFolderB,9);
            updateImage(newPluginB,7);
            updateImage(newVFolderB,4);
            updateImage(button13, 10);
            button18.Image = imageList1.Images[0];
            button18.TextImageRelation = TextImageRelation.ImageBeforeText;
            button18.TextAlign = ContentAlignment.MiddleLeft;
            button19.Image = imageList1.Images[1];
            button19.TextImageRelation = TextImageRelation.ImageBeforeText;
            button19.TextAlign = ContentAlignment.MiddleLeft;
            button11.Image = imageList1.Images[3];
            button11.TextImageRelation = TextImageRelation.ImageBeforeText;
            button11.TextAlign = ContentAlignment.MiddleLeft;
        }
        private void updateImage(Button b, int index)
        {
            b.Image = imageList1.Images[index];
            b.Width = b.Height;
        }
        private void LoadImages()
        {
            imageList1.ImageSize = new Size(upB.Font.Height, upB.Font.Height);
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ScrapForm_Load(object sender, EventArgs e)
        {

        }
    }
}
