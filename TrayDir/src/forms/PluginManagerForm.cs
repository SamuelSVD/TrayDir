using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class PluginManagerForm : Form
    {
        public static PluginManagerForm form;
        List<PluginNode> plugins;
        private PluginNode selectedNode
        {
            get
            {
                TreeNode n = treeView1.SelectedNode;
                for (int i = 0; i < plugins.Count; i++)
                {
                    if (plugins[i].node == n) return plugins[i];
                }
                return null;
            }
        }
        public PluginManagerForm()
        {
            InitializeComponent();
            initializeTree();
        }
        public static void Init()
        {
            form = new PluginManagerForm();
        }
        public void initializeTree()
        {
            plugins = new List<PluginNode>();
            treeView1.Nodes.Clear();
            foreach (TrayPlugin tp in ProgramData.pd.plugins)
            {
                PluginNode pn = new PluginNode();
                pn.tp = tp;
                plugins.Add(pn);
                treeView1.Nodes.Add(pn.node);
                pn.UpdateNode();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            TrayPlugin tp = new TrayPlugin();
            PluginNode pn = new PluginNode();
            pn.tp = tp;
            plugins.Add(pn);
            treeView1.Nodes.Add(pn.node);
            ProgramData.pd.plugins.Add(tp);
            treeView1.SelectedNode = pn.node;
            editButton_Click(sender, e);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                PluginForm pf = new PluginForm(selectedNode);
                pf.ShowDialog();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                if (MessageBox.Show("Do you want to delete plugin: " + selectedNode.node.Text, "Delete plugin", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool used = false;
                    int pid = ProgramData.pd.plugins.IndexOf(selectedNode.tp);
                    foreach(TrayInstance ti in ProgramData.pd.trayInstances)
                    {
                        foreach(TrayInstancePlugin tip in ti.plugins)
                        {
                            used = used || (tip.plugin == selectedNode.tp);
                        }
                    }
                    if (!used)
                    {
                        ProgramData.pd.plugins.Remove(selectedNode.tp);
                        treeView1.Nodes.Remove(selectedNode.node);
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete. Plugin currently in use.");
                    }
                }
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            editButton_Click(sender, e);
        }
    }
}
