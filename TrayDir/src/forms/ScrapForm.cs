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
            treeView1.ExpandAll();
            foreach(TrayInstanceNode tin in MainForm.form.trayInstance.nodes)
            {
                ITreeNode tn = new ITreeNode(tin);
                treeView1.Nodes.Add(tn.node);
            }
            TreeNode folder = new TreeNode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
