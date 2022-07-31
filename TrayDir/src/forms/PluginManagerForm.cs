using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrayDir.utils;
using Utils;

namespace TrayDir
{
	public partial class PluginManagerForm : Form
	{
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
		public void initializeTree()
		{
			plugins = new List<PluginNode>();
			treeView1.Nodes.Clear();
			imageList = new ImageList();
			imageList.Images.Clear();
			foreach(Bitmap image in IconUtils.imageList.Images) {
				imageList.Images.Add(image);
			}
			imageList.ImageSize = new System.Drawing.Size(closeButton.Font.Height, closeButton.Font.Height);
			treeView1.ImageList = imageList;
			foreach (TrayPlugin tp in ProgramData.pd.plugins)
			{
				PluginNode pn = new PluginNode();
				pn.tp = tp;
				plugins.Add(pn);
				treeView1.Nodes.Add(pn.node);
				pn.UpdateNode();
			}
			treeView1.Sort();
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
			treeView1.Sort();
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				PluginForm pf = new PluginForm(selectedNode);
				pf.ShowDialog();
				treeView1.Sort();
			}
		}
		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				if (MessageBox.Show(String.Format(Properties.Strings_en.Plugin_Delete, selectedNode.node.Text), Properties.Strings_en.Form_Delete, MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					bool used = false;
					int pid = ProgramData.pd.plugins.IndexOf(selectedNode.tp);
					foreach (TrayInstance ti in ProgramData.pd.trayInstances) {
						foreach (TrayInstancePlugin tip in ti.plugins) {
							used = used || (tip.plugin == selectedNode.tp);
						}
					}
					foreach (TrayInstance ti in ProgramData.pd.archivedInstances) {
						foreach (TrayInstancePlugin tip in ti.plugins) {
							used = used || (tip.plugin == selectedNode.tp);
						}
					}
					if (!used)
					{
						int i = ProgramData.pd.plugins.IndexOf(selectedNode.tp);
						ProgramData.pd.plugins.Remove(selectedNode.tp);
						treeView1.Nodes.Remove(selectedNode.node);
						ProgramData.pd.RemovedPlugin(i);
						ProgramData.pd.Save();
					}
					else
					{
						MessageBox.Show(Properties.Strings_en.Plugin_UnableToDelete);
					}
				}
			}
		}
		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			editButton_Click(sender, e);
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			editButton.Enabled = selectedNode != null;
			deleteButton.Enabled = selectedNode != null;
			exportButton.Enabled = selectedNode != null;
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Tray Plugin Export | *.tpe";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				TrayPlugin tp = AppUtils.ImportPlugin(ofd.FileName);
				if (tp != null)
				{
					bool imported = false;
					for(int i = 0; i < ProgramData.pd.plugins.Count; i++)
					{
						TrayPlugin tpc = ProgramData.pd.plugins[i];
						if (tpc.name == tp.name)
						{
							DialogResult dr = MessageBox.Show(Properties.Strings_en.Plugin_SameNameImport, Properties.Strings_en.Form_ImportConflict, MessageBoxButtons.YesNoCancel);
							if (dr == DialogResult.Yes)
							{
								ProgramData.pd.plugins[i] = tp;
								imported = true;
								break;
							} else if (dr == DialogResult.No) {
								continue;
							} else {
								imported = true;
								break;
							}
						}
					}
					if (!imported) {
						ProgramData.pd.plugins.Add(tp);
					}
					ProgramData.pd.Save();
				} else {
					MessageBox.Show(Properties.Strings_en.Error_ImportFailed, Properties.Strings_en.Form_ImportFailed);
				}
			}
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			AppUtils.ExportPlugin(selectedNode.tp);
		}

		private void PluginManagerForm_Shown(object sender, EventArgs e)
		{
			treeView1.SelectedNode = null;
			editButton.Enabled = false;
			deleteButton.Enabled = false;
			exportButton.Enabled = false;
		}

		private void PluginManagerForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/pluginmanager.htm");
		}
	}
}
