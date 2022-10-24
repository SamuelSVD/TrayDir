using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class InstanceManagerForm : Form
	{
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
			this.Icon = Properties.Resources.file_exe;
			initializeTree();
		}
		public void initializeTree()
		{
			instances = new List<InstanceNode>();
			treeView1.Nodes.Clear();
			imageList = new ImageList();
			imageList.ImageSize = new Size(closeButton.Font.Height, closeButton.Font.Height);
			imageList.Images.Clear();
			imageList.Images.Add(Properties.Resources.empty);
			treeView1.ImageList = imageList;
			foreach (TrayInstance tp in ProgramData.pd.archivedInstances)
			{
				InstanceNode pn = new InstanceNode();
				pn.instance = tp;
				instances.Add(pn);
				treeView1.Nodes.Add(pn.node);
				pn.UpdateNode();
				if (pn.icon != null) {
					imageList.Images.Add(pn.icon);
					pn.node.ImageIndex = imageList.Images.Count - 1;
					pn.node.SelectedImageIndex = imageList.Images.Count - 1;
				}
			}
			treeView1.Sort();
		}
		private void restoreButton_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				if (MessageBox.Show(string.Format(Properties.Strings.Instance_Restore, selectedNode.node.Text), Properties.Strings.Form_Restore, MessageBoxButtons.OKCancel) == DialogResult.OK) {
					TrayInstance ti = selectedNode.instance;
					ti.FixPaths();
					ti.FixNodes();
					ProgramData.pd.trayInstances.Add(ti);
					MainForm.form.AddInstanceTabPage(ti);
					ti.view.Rebuild();
					ProgramData.pd.archivedInstances.Remove(ti);
					treeView1.Nodes.Remove(selectedNode.node);
					treeView1.Sort();
					MainForm.form.BuildRebuildDropdown();
				}
			}
		}
		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				if (MessageBox.Show(string.Format(Properties.Strings.Instance_Delete, selectedNode.node.Text), Properties.Strings.Form_Delete, MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					int pid = ProgramData.pd.archivedInstances.IndexOf(selectedNode.instance);
					ProgramData.pd.archivedInstances.Remove(selectedNode.instance);
					treeView1.Nodes.Remove(selectedNode.node);
				}
			}
		}

		private void InstanceManagerForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/instance_archive.htm");
		}
	}
}
