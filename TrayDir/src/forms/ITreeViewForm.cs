using FolderSelect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class ITreeViewForm : Form
    {
        private List<ITreeNode> nodes;
        private ITreeNode selectedNode { get { return __selectedNode; } set { __selectedNode = value; UpdateButtonEnables(); } }
        private bool selectedIndentable { get { return selectedNode != null ? !selectedNode.isFirstChild && selectedNode.previousRelative.tin.type == TrayInstanceNode.NodeType.VirtualFolder : false; } }
        private bool selectedOutdentable { get { return selectedNode != null ? selectedNode.node.Parent != null : false; } }
        private bool selectedUpable { get { return selectedNode != null ? !selectedNode.isFirstChild : false; } }
        private bool selectedDownable { get { return selectedNode != null ? !selectedNode.isLastChild : false; } }
        private ITreeNode __selectedNode;
        private TrayInstance instance;
        private ContextMenu rightClickMenu;
        private MenuItem renameMenuItem;
        private MenuItem folderShortcutMenuItem;
        private MenuItem folderExpandMenuItem;

        public ITreeViewForm(TrayInstance instance)
        {
            rightClickMenu = new ContextMenu();
            renameMenuItem = new MenuItem("Rename Item", renameButton_Click);
            folderShortcutMenuItem = new MenuItem("Use folder link as shortcut", folderShortcutMenuItem_click);
            folderExpandMenuItem = new MenuItem("Expand folder in tray menu", folderExpandMenuItem_click);
            rightClickMenu.MenuItems.Add(renameMenuItem);
            rightClickMenu.MenuItems.Add(folderShortcutMenuItem);
            rightClickMenu.MenuItems.Add(folderExpandMenuItem);

            this.instance = instance;
            InitializeComponent();
            nodes = new List<ITreeNode>();
            foreach (TrayInstanceNode tin in instance.nodes.children)
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
            updateImage(newFolderButton, 9);
            updateImage(newPluginButton, 7);
            updateImage(newVirtualFolderButton, 4);
            updateImage(deleteButton, 10);
            docPropertiesButton.Image = imageList1.Images[0];
            docPropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            docPropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
            folderPropertiesButton.Image = imageList1.Images[1];
            folderPropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            folderPropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
            pluginPropertiesButton.Image = imageList1.Images[3];
            pluginPropertiesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            pluginPropertiesButton.TextAlign = ContentAlignment.MiddleLeft;
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
                foreach (TrayInstanceNode tinc in tin.children)
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
            imageList1.Images.Add(TrayDir.Properties.Resources.delete);        //10
            imageList1.Images.Add(TrayDir.Properties.Resources.question);       //11
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_in);      //12
            imageList1.Images.Add(TrayDir.Properties.Resources.indent_out);     //13
            imageList1.Images.Add(TrayDir.Properties.Resources.folder_shortcut);//14
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = e.Node.Text;
            foreach (ITreeNode itn in nodes)
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
            MainForm.form.BuildExploreDropdown();
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
                MainForm.form.fd.InitialDirectory = Path.GetDirectoryName(path);
            }
            MainForm.form.fd.FileName = Path.GetFileName(path);
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
                fs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                fs.InitialDirectory = Path.GetDirectoryName(path);
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
            newPluginButton.Enabled = true;
            newVirtualFolderButton.Enabled = true;
            deleteButton.Enabled = selectedNode != null;
            docPropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Path : false;
            folderPropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Path : false;
            pluginPropertiesButton.Enabled = selectedNode != null ? selectedNode.tin.type == TrayInstanceNode.NodeType.Plugin : false;
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
                if (treeView2.Nodes.Count == 0)
                {
                    selectedNode = null;
                }
            }
        }
        private void treeView2_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instance.view.optionsForm.ShowDialog();
        }
        private void RecursiveAddToInstance(TrayInstance recursive_instance, TrayInstanceNode tin, TrayInstanceNode parent)
        {
            TrayInstanceNode newTin = new TrayInstanceNode();
            newTin.type = tin.type;
            if (tin.type == TrayInstanceNode.NodeType.Path)
            {
                newTin.id = recursive_instance.paths.Count;
                recursive_instance.paths.Add(instance.paths[tin.id]);
            }
            if (tin.type == TrayInstanceNode.NodeType.VirtualFolder)
            {
                newTin.id = recursive_instance.vfolders.Count;
                recursive_instance.vfolders.Add(instance.vfolders[tin.id]);
            }
            if (tin.type == TrayInstanceNode.NodeType.Plugin)
            {
                newTin.id = recursive_instance.plugins.Count;
                recursive_instance.plugins.Add(instance.plugins[tin.id]);
            }
            if (parent == null)
            {
                recursive_instance.nodes.children.Add(newTin);
            } else
            {
                parent.children.Add(newTin);
            }
            foreach(TrayInstanceNode tinChild in tin.children)
            {
                RecursiveAddToInstance(recursive_instance, tinChild, newTin);
            }
        }
        private void CopyToClipboard()
        {
            TrayInstance copyInstance = new TrayInstance();
            RecursiveAddToInstance(copyInstance, selectedNode.tin, null);
            Clipboard.SetText(XMLUtils.XmlSerializeToString(copyInstance));
        }
        private void RecursiveLoadFromInstance(TrayInstance recursive_instance, TrayInstanceNode tin, ITreeNode parentNode)
        {
            TrayInstanceNode newTin = new TrayInstanceNode();
            newTin.type = tin.type;
            if (tin.type == TrayInstanceNode.NodeType.Path)
            {
                newTin.id = instance.paths.Count;
                instance.paths.Add(recursive_instance.paths[tin.id]);
            }
            else if (tin.type == TrayInstanceNode.NodeType.Plugin)
            {
                newTin.id = instance.plugins.Count;
                instance.plugins.Add(recursive_instance.plugins[tin.id]);
            }
            else if (tin.type == TrayInstanceNode.NodeType.VirtualFolder)
            {
                newTin.id = instance.vfolders.Count;
                instance.vfolders.Add(recursive_instance.vfolders[tin.id]);
            }
            newTin.SetInstance(instance);
            ITreeNode itn = new ITreeNode(newTin);
            if (parentNode != null) treeView2.SelectedNode = parentNode.node;
            insertNode(itn);
            treeView2.SelectedNode = itn.node;
            selectedNode = itn;
            nodes.Add(itn);
            foreach(TrayInstanceNode nodeChild in tin.children)
            {
                RecursiveLoadFromInstance(recursive_instance, nodeChild, itn);
            }
        }
        private void PasteFromClipboard()
        {
            try
            {
                TrayInstance copyInstance = (TrayInstance)XMLUtils.XmlDeserializeFromString(Clipboard.GetText(), typeof(TrayInstance));
                foreach(TrayInstanceNode tin in copyInstance.nodes.children)
                {
                    RecursiveLoadFromInstance(copyInstance, tin, null);
                }
                Save();
            }
            catch
            {

            }

        }
        public void treeView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedNode != null)
            {
                if (e.KeyCode == Keys.F2)
                {
                    renameButton_Click(sender, null);
                }
                if (e.KeyCode == Keys.C)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        CopyToClipboard();
                    }
                }
                if (e.KeyCode == Keys.V)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        PasteFromClipboard();
                    }
                }
                if (e.KeyCode == Keys.N)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        newDocButton_Click(sender, null);
                    }
                    if (e.Modifiers == (Keys.Control | Keys.Shift))
                    {
                        newVirtualFolderButton_Click(sender, null);
                    }
                }
                if (e.KeyCode == Keys.F)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        newFolderButton_Click(sender, null);
                    }
                }
                if (e.KeyCode == Keys.Delete)
                {
                    deleteButton_Click(sender, null);
                }
                if (e.Modifiers == Keys.Control)
                {
                    if (e.KeyCode == Keys.Up && selectedUpable)
                    {
                        upButton_Click(sender, null);
                    }
                    if (e.KeyCode == Keys.Down && selectedDownable)
                    {
                        downButton_Click(sender, null);
                    }
                    if (e.KeyCode == Keys.Left && selectedOutdentable)
                    {
                        outdentButton_Click(sender, null);
                    }
                    if (e.KeyCode == Keys.Right && selectedIndentable)
                    {
                        indentButton_Click(sender, null);
                    }
                }
            }
        }
        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (selectedNode != null)
            {
                renameButton_Click(sender, null);
            }
        }
        private void folderShortcutMenuItem_click(object sender, EventArgs e)
        {
            instance.paths[selectedNode.tin.id].shortcut = true;
            selectedNode.Refresh();
            instance.view.tray.Rebuild();
        }
        private void folderExpandMenuItem_click(object sender, EventArgs e)
        {
            instance.paths[selectedNode.tin.id].shortcut = false;
            selectedNode.Refresh();
            instance.view.tray.Rebuild();
        }
        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && selectedNode != null)
            {
                if (e.Node != null)
                {
                    foreach (ITreeNode itn in nodes)
                    {
                        if (e.Node == itn.node)
                        {
                            selectedNode = itn;
                            break;
                        }
                    }
                }
                if (selectedNode.tin.type == TrayInstanceNode.NodeType.Path)
                {
                    TrayInstancePath path = instance.paths[selectedNode.tin.id];
                    if (path.isDir)
                    {
                        folderShortcutMenuItem.Visible = !path.shortcut;
                        folderExpandMenuItem.Visible = path.shortcut;
                    } else
                    {
                        folderShortcutMenuItem.Visible = false;
                        folderExpandMenuItem.Visible = false;
                    }
                }
                rightClickMenu.Show(treeView2, e.Location);
            }
        }

        private void newPluginButton_Click(object sender, EventArgs e)
        {
            TrayInstancePlugin tip = new TrayInstancePlugin();
            instance.plugins.Add(tip);
            int index = instance.plugins.IndexOf(tip);
            TrayInstanceNode tin = new TrayInstanceNode();
            tin.id = index;
            tin.type = TrayInstanceNode.NodeType.Plugin;
            tin.SetInstance(instance);
            ITreeNode itn = new ITreeNode(tin);
            insertNode(itn);
            treeView2.SelectedNode = itn.node;
            selectedNode = itn;
            nodes.Add(itn);
            pluginPropertiesButton_Click(sender, e);
        }
        private void pluginPropertiesButton_Click(object sender, EventArgs e)
        {
            ITreeNode itn = selectedNode;
            IPluginForm ipf = new IPluginForm(instance.plugins[itn.tin.id]);
            ipf.ShowDialog();
            itn.Refresh();
        }
    }
}
