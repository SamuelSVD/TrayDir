
namespace TrayDir
{
    partial class ITreeViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITreeViewForm));
			this.formTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.leftButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.downButton = new System.Windows.Forms.Button();
			this.outdentButton = new System.Windows.Forms.Button();
			this.upButton = new System.Windows.Forms.Button();
			this.indentButton = new System.Windows.Forms.Button();
			this.topButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.newDocButton = new System.Windows.Forms.Button();
			this.newFolderButton = new System.Windows.Forms.Button();
			this.newPluginButton = new System.Windows.Forms.Button();
			this.newVirtualFolderButton = new System.Windows.Forms.Button();
			this.newSeparatorButton = new System.Windows.Forms.Button();
			this.ContentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.editButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.formTableLayoutPanel.SuspendLayout();
			this.leftButtonsTableLayoutPanel.SuspendLayout();
			this.topButtonsTableLayoutPanel.SuspendLayout();
			this.ContentTableLayoutPanel.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// formTableLayoutPanel
			// 
			resources.ApplyResources(this.formTableLayoutPanel, "formTableLayoutPanel");
			this.formTableLayoutPanel.Controls.Add(this.leftButtonsTableLayoutPanel, 0, 1);
			this.formTableLayoutPanel.Controls.Add(this.topButtonsTableLayoutPanel, 1, 0);
			this.formTableLayoutPanel.Controls.Add(this.ContentTableLayoutPanel, 1, 1);
			this.formTableLayoutPanel.Name = "formTableLayoutPanel";
			// 
			// leftButtonsTableLayoutPanel
			// 
			resources.ApplyResources(this.leftButtonsTableLayoutPanel, "leftButtonsTableLayoutPanel");
			this.leftButtonsTableLayoutPanel.Controls.Add(this.downButton, 0, 4);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.outdentButton, 0, 3);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.upButton, 0, 0);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.indentButton, 0, 2);
			this.leftButtonsTableLayoutPanel.Name = "leftButtonsTableLayoutPanel";
			// 
			// downButton
			// 
			resources.ApplyResources(this.downButton, "downButton");
			this.downButton.Name = "downButton";
			this.toolTip.SetToolTip(this.downButton, resources.GetString("downButton.ToolTip"));
			this.downButton.UseVisualStyleBackColor = true;
			this.downButton.Click += new System.EventHandler(this.downButton_Click);
			// 
			// outdentButton
			// 
			resources.ApplyResources(this.outdentButton, "outdentButton");
			this.outdentButton.Name = "outdentButton";
			this.toolTip.SetToolTip(this.outdentButton, resources.GetString("outdentButton.ToolTip"));
			this.outdentButton.UseVisualStyleBackColor = true;
			this.outdentButton.Click += new System.EventHandler(this.outdentButton_Click);
			// 
			// upButton
			// 
			resources.ApplyResources(this.upButton, "upButton");
			this.upButton.Name = "upButton";
			this.toolTip.SetToolTip(this.upButton, resources.GetString("upButton.ToolTip"));
			this.upButton.UseVisualStyleBackColor = true;
			this.upButton.Click += new System.EventHandler(this.upButton_Click);
			// 
			// indentButton
			// 
			resources.ApplyResources(this.indentButton, "indentButton");
			this.indentButton.Name = "indentButton";
			this.toolTip.SetToolTip(this.indentButton, resources.GetString("indentButton.ToolTip"));
			this.indentButton.UseVisualStyleBackColor = true;
			this.indentButton.Click += new System.EventHandler(this.indentButton_Click);
			// 
			// topButtonsTableLayoutPanel
			// 
			resources.ApplyResources(this.topButtonsTableLayoutPanel, "topButtonsTableLayoutPanel");
			this.topButtonsTableLayoutPanel.Controls.Add(this.newDocButton, 0, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newFolderButton, 1, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newPluginButton, 2, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newVirtualFolderButton, 3, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newSeparatorButton, 4, 0);
			this.topButtonsTableLayoutPanel.Name = "topButtonsTableLayoutPanel";
			// 
			// newDocButton
			// 
			resources.ApplyResources(this.newDocButton, "newDocButton");
			this.newDocButton.Name = "newDocButton";
			this.toolTip.SetToolTip(this.newDocButton, resources.GetString("newDocButton.ToolTip"));
			this.newDocButton.UseVisualStyleBackColor = true;
			this.newDocButton.Click += new System.EventHandler(this.newDocButton_Click);
			// 
			// newFolderButton
			// 
			resources.ApplyResources(this.newFolderButton, "newFolderButton");
			this.newFolderButton.Name = "newFolderButton";
			this.toolTip.SetToolTip(this.newFolderButton, resources.GetString("newFolderButton.ToolTip"));
			this.newFolderButton.UseVisualStyleBackColor = true;
			this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
			// 
			// newPluginButton
			// 
			resources.ApplyResources(this.newPluginButton, "newPluginButton");
			this.newPluginButton.Name = "newPluginButton";
			this.toolTip.SetToolTip(this.newPluginButton, resources.GetString("newPluginButton.ToolTip"));
			this.newPluginButton.UseVisualStyleBackColor = true;
			this.newPluginButton.Click += new System.EventHandler(this.newPluginButton_Click);
			// 
			// newVirtualFolderButton
			// 
			resources.ApplyResources(this.newVirtualFolderButton, "newVirtualFolderButton");
			this.newVirtualFolderButton.Name = "newVirtualFolderButton";
			this.toolTip.SetToolTip(this.newVirtualFolderButton, resources.GetString("newVirtualFolderButton.ToolTip"));
			this.newVirtualFolderButton.UseVisualStyleBackColor = true;
			this.newVirtualFolderButton.Click += new System.EventHandler(this.newVirtualFolderButton_Click);
			// 
			// newSeparatorButton
			// 
			resources.ApplyResources(this.newSeparatorButton, "newSeparatorButton");
			this.newSeparatorButton.Name = "newSeparatorButton";
			this.toolTip.SetToolTip(this.newSeparatorButton, resources.GetString("newSeparatorButton.ToolTip"));
			this.newSeparatorButton.UseVisualStyleBackColor = true;
			this.newSeparatorButton.Click += new System.EventHandler(this.newSeparatorButton_Click);
			// 
			// ContentTableLayoutPanel
			// 
			resources.ApplyResources(this.ContentTableLayoutPanel, "ContentTableLayoutPanel");
			this.ContentTableLayoutPanel.Controls.Add(this.tableLayoutPanel5, 1, 0);
			this.ContentTableLayoutPanel.Controls.Add(this.treeView2, 0, 0);
			this.ContentTableLayoutPanel.Name = "ContentTableLayoutPanel";
			// 
			// tableLayoutPanel5
			// 
			resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
			this.tableLayoutPanel5.Controls.Add(this.editButton, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.deleteButton, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.button1, 0, 4);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			// 
			// editButton
			// 
			resources.ApplyResources(this.editButton, "editButton");
			this.editButton.Name = "editButton";
			this.toolTip.SetToolTip(this.editButton, resources.GetString("editButton.ToolTip"));
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// deleteButton
			// 
			resources.ApplyResources(this.deleteButton, "deleteButton");
			this.deleteButton.Name = "deleteButton";
			this.toolTip.SetToolTip(this.deleteButton, resources.GetString("deleteButton.ToolTip"));
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.toolTip.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// treeView2
			// 
			this.treeView2.AllowDrop = true;
			resources.ApplyResources(this.treeView2, "treeView2");
			this.treeView2.HideSelection = false;
			this.treeView2.Name = "treeView2";
			this.treeView2.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeCollapse);
			this.treeView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView2_ItemDrag);
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
			this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
			this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseDoubleClick);
			this.treeView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView2_DragDrop);
			this.treeView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView2_DragEnter);
			this.treeView2.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView2_DragOver);
			this.treeView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView2_KeyDown);
			// 
			// ITreeViewForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.formTableLayoutPanel);
			this.Name = "ITreeViewForm";
			this.formTableLayoutPanel.ResumeLayout(false);
			this.formTableLayoutPanel.PerformLayout();
			this.leftButtonsTableLayoutPanel.ResumeLayout(false);
			this.topButtonsTableLayoutPanel.ResumeLayout(false);
			this.ContentTableLayoutPanel.ResumeLayout(false);
			this.ContentTableLayoutPanel.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TableLayoutPanel formTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel topButtonsTableLayoutPanel;
        private System.Windows.Forms.Button newDocButton;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Button newPluginButton;
        private System.Windows.Forms.Button newVirtualFolderButton;
		private System.Windows.Forms.Button newSeparatorButton;
        private System.Windows.Forms.TableLayoutPanel leftButtonsTableLayoutPanel;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button indentButton;
        private System.Windows.Forms.TableLayoutPanel ContentTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button outdentButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}