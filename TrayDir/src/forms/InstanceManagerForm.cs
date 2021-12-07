using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class InstanceManagerForm : Form
    {
        public static InstanceManagerForm form;
        List<InstanceNode> instances;
        private InstanceNode selectedNode
        {
            get
            {
                TreeNode n = treeView1.SelectedNode;
                for (int i = 0; i < instances.Count; i++)
                {
                    if (instances[i].node == n) return instances[i];
                }
                return null;
            }
        }
        public InstanceManagerForm()
        {
            InitializeComponent();
            initializeTree();
        }
        public static void Init()
        {
            form = new InstanceManagerForm();
        }
        public void initializeTree()
        {
            instances = new List<InstanceNode>();
            treeView1.Nodes.Clear();
            foreach (TrayInstance tp in ProgramData.pd.archivedInstances)
            {
                InstanceNode pn = new InstanceNode();
                pn.trayInstance = tp;
                instances.Add(pn);
                treeView1.Nodes.Add(pn.node);
                pn.UpdateNode();
            }
            treeView1.Sort();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                if (MessageBox.Show("Do you want to restore instance: " + selectedNode.node.Text, "Restore", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    TrayInstance ti = selectedNode.trayInstance;
                    ti.FixPaths();
                    ti.FixNodes();
                    ProgramData.pd.trayInstances.Add(ti);
                    MainForm.form.AddInstanceTabPage(ti);
                    ProgramData.pd.archivedInstances.Remove(ti);
                    treeView1.Nodes.Remove(selectedNode.node);
                    treeView1.Sort();
                }
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                if (MessageBox.Show("Do you want to delete instance: " + selectedNode.node.Text, "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int pid = ProgramData.pd.archivedInstances.IndexOf(selectedNode.trayInstance);
                    ProgramData.pd.archivedInstances.Remove(selectedNode.trayInstance);
                    treeView1.Nodes.Remove(selectedNode.node);
                }
            }
        }
    }
}
