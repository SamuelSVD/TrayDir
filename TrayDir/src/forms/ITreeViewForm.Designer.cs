
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
			this.formTableLayoutPanel.AutoSize = true;
			this.formTableLayoutPanel.ColumnCount = 2;
			this.formTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.formTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.formTableLayoutPanel.Controls.Add(this.leftButtonsTableLayoutPanel, 0, 1);
			this.formTableLayoutPanel.Controls.Add(this.topButtonsTableLayoutPanel, 1, 0);
			this.formTableLayoutPanel.Controls.Add(this.ContentTableLayoutPanel, 1, 1);
			this.formTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.formTableLayoutPanel.Name = "formTableLayoutPanel";
			this.formTableLayoutPanel.RowCount = 2;
			this.formTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.formTableLayoutPanel.Size = new System.Drawing.Size(358, 229);
			this.formTableLayoutPanel.TabIndex = 13;
			// 
			// leftButtonsTableLayoutPanel
			// 
			this.leftButtonsTableLayoutPanel.AutoSize = true;
			this.leftButtonsTableLayoutPanel.ColumnCount = 1;
			this.leftButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.leftButtonsTableLayoutPanel.Controls.Add(this.downButton, 0, 4);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.outdentButton, 0, 3);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.upButton, 0, 0);
			this.leftButtonsTableLayoutPanel.Controls.Add(this.indentButton, 0, 2);
			this.leftButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftButtonsTableLayoutPanel.Location = new System.Drawing.Point(0, 29);
			this.leftButtonsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.leftButtonsTableLayoutPanel.Name = "leftButtonsTableLayoutPanel";
			this.leftButtonsTableLayoutPanel.RowCount = 5;
			this.leftButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.leftButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.leftButtonsTableLayoutPanel.Size = new System.Drawing.Size(26, 200);
			this.leftButtonsTableLayoutPanel.TabIndex = 0;
			// 
			// downButton
			// 
			this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.downButton.ImageIndex = 5;
			this.downButton.Location = new System.Drawing.Point(3, 90);
			this.downButton.Name = "downButton";
			this.downButton.Size = new System.Drawing.Size(20, 23);
			this.downButton.TabIndex = 14;
			this.toolTip.SetToolTip(this.downButton, "Move item down");
			this.downButton.UseVisualStyleBackColor = true;
			this.downButton.Click += new System.EventHandler(this.downButton_Click);
			// 
			// outdentButton
			// 
			this.outdentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.outdentButton.ImageIndex = 5;
			this.outdentButton.Location = new System.Drawing.Point(3, 61);
			this.outdentButton.Name = "outdentButton";
			this.outdentButton.Size = new System.Drawing.Size(20, 23);
			this.outdentButton.TabIndex = 14;
			this.toolTip.SetToolTip(this.outdentButton, "Move item out");
			this.outdentButton.UseVisualStyleBackColor = true;
			this.outdentButton.Click += new System.EventHandler(this.outdentButton_Click);
			// 
			// upButton
			// 
			this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.upButton.ImageIndex = 5;
			this.upButton.Location = new System.Drawing.Point(3, 3);
			this.upButton.Name = "upButton";
			this.upButton.Size = new System.Drawing.Size(20, 23);
			this.upButton.TabIndex = 0;
			this.toolTip.SetToolTip(this.upButton, "Move item up");
			this.upButton.UseVisualStyleBackColor = true;
			this.upButton.Click += new System.EventHandler(this.upButton_Click);
			// 
			// indentButton
			// 
			this.indentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.indentButton.Location = new System.Drawing.Point(3, 32);
			this.indentButton.Name = "indentButton";
			this.indentButton.Size = new System.Drawing.Size(20, 23);
			this.indentButton.TabIndex = 2;
			this.toolTip.SetToolTip(this.indentButton, "Move item into Virtual Folder");
			this.indentButton.UseVisualStyleBackColor = true;
			this.indentButton.Click += new System.EventHandler(this.indentButton_Click);
			// 
			// topButtonsTableLayoutPanel
			// 
			this.topButtonsTableLayoutPanel.AutoSize = true;
			this.topButtonsTableLayoutPanel.ColumnCount = 6;
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topButtonsTableLayoutPanel.Controls.Add(this.newDocButton, 0, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newFolderButton, 1, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newPluginButton, 2, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newVirtualFolderButton, 3, 0);
			this.topButtonsTableLayoutPanel.Controls.Add(this.newSeparatorButton, 4, 0);
			this.topButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topButtonsTableLayoutPanel.Location = new System.Drawing.Point(26, 0);
			this.topButtonsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.topButtonsTableLayoutPanel.Name = "topButtonsTableLayoutPanel";
			this.topButtonsTableLayoutPanel.RowCount = 1;
			this.topButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.topButtonsTableLayoutPanel.Size = new System.Drawing.Size(332, 29);
			this.topButtonsTableLayoutPanel.TabIndex = 1;
			// 
			// newDocButton
			// 
			this.newDocButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newDocButton.Location = new System.Drawing.Point(3, 3);
			this.newDocButton.Name = "newDocButton";
			this.newDocButton.Size = new System.Drawing.Size(26, 23);
			this.newDocButton.TabIndex = 0;
			this.toolTip.SetToolTip(this.newDocButton, "Insert New File Item");
			this.newDocButton.UseVisualStyleBackColor = true;
			this.newDocButton.Click += new System.EventHandler(this.newDocButton_Click);
			// 
			// newFolderButton
			// 
			this.newFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newFolderButton.Location = new System.Drawing.Point(35, 3);
			this.newFolderButton.Name = "newFolderButton";
			this.newFolderButton.Size = new System.Drawing.Size(23, 23);
			this.newFolderButton.TabIndex = 1;
			this.toolTip.SetToolTip(this.newFolderButton, "Insert New Folder Item");
			this.newFolderButton.UseVisualStyleBackColor = true;
			this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
			// 
			// newPluginButton
			// 
			this.newPluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newPluginButton.Location = new System.Drawing.Point(64, 3);
			this.newPluginButton.Name = "newPluginButton";
			this.newPluginButton.Size = new System.Drawing.Size(23, 23);
			this.newPluginButton.TabIndex = 2;
			this.toolTip.SetToolTip(this.newPluginButton, "Insert New Plugin Item");
			this.newPluginButton.UseVisualStyleBackColor = true;
			this.newPluginButton.Click += new System.EventHandler(this.newPluginButton_Click);
			// 
			// newVirtualFolderButton
			// 
			this.newVirtualFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newVirtualFolderButton.Location = new System.Drawing.Point(93, 3);
			this.newVirtualFolderButton.Name = "newVirtualFolderButton";
			this.newVirtualFolderButton.Size = new System.Drawing.Size(20, 23);
			this.newVirtualFolderButton.TabIndex = 3;
			this.toolTip.SetToolTip(this.newVirtualFolderButton, "Insert New Virtual Folder Item");
			this.newVirtualFolderButton.UseVisualStyleBackColor = true;
			this.newVirtualFolderButton.Click += new System.EventHandler(this.newVirtualFolderButton_Click);
			// 
			// newSeparatorButton
			// 
			this.newSeparatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newSeparatorButton.Location = new System.Drawing.Point(119, 3);
			this.newSeparatorButton.Name = "newSeparatorButton";
			this.newSeparatorButton.Size = new System.Drawing.Size(23, 23);
			this.newSeparatorButton.TabIndex = 4;
			this.toolTip.SetToolTip(this.newSeparatorButton, "Insert New Separator Item");
			this.newSeparatorButton.UseVisualStyleBackColor = true;
			this.newSeparatorButton.Click += new System.EventHandler(this.newSeparatorButton_Click);
			// 
			// ContentTableLayoutPanel
			// 
			this.ContentTableLayoutPanel.AutoSize = true;
			this.ContentTableLayoutPanel.ColumnCount = 2;
			this.ContentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ContentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.ContentTableLayoutPanel.Controls.Add(this.tableLayoutPanel5, 1, 0);
			this.ContentTableLayoutPanel.Controls.Add(this.treeView2, 0, 0);
			this.ContentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentTableLayoutPanel.Location = new System.Drawing.Point(26, 29);
			this.ContentTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.ContentTableLayoutPanel.Name = "ContentTableLayoutPanel";
			this.ContentTableLayoutPanel.RowCount = 1;
			this.ContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ContentTableLayoutPanel.Size = new System.Drawing.Size(332, 200);
			this.ContentTableLayoutPanel.TabIndex = 2;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.AutoSize = true;
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.Controls.Add(this.editButton, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.deleteButton, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.button1, 0, 4);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(248, 3);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 5;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(81, 194);
			this.tableLayoutPanel5.TabIndex = 0;
			// 
			// editButton
			// 
			this.editButton.AutoSize = true;
			this.editButton.Location = new System.Drawing.Point(3, 3);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(75, 23);
			this.editButton.TabIndex = 0;
			this.editButton.Text = "Edit";
			this.toolTip.SetToolTip(this.editButton, "Edit selected item");
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.AutoSize = true;
			this.deleteButton.Location = new System.Drawing.Point(3, 32);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 1;
			this.deleteButton.Text = "Delete";
			this.toolTip.SetToolTip(this.deleteButton, "Delete selected item");
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(3, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Options";
			this.toolTip.SetToolTip(this.button1, "Open instance options");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// treeView2
			// 
			this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView2.HideSelection = false;
			this.treeView2.Location = new System.Drawing.Point(3, 3);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(239, 194);
			this.treeView2.TabIndex = 1;
			this.treeView2.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeCollapse);
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
			this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
			this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseDoubleClick);
			this.treeView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView2_KeyDown);
			// 
			// ITreeViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(358, 229);
			this.Controls.Add(this.formTableLayoutPanel);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ITreeViewForm";
			this.Text = "ScrapForm";
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