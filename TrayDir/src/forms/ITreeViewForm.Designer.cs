
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.downButton = new System.Windows.Forms.Button();
            this.outdentButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.indentButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.newDocButton = new System.Windows.Forms.Button();
            this.newFolderButton = new System.Windows.Forms.Button();
            this.newPluginButton = new System.Windows.Forms.Button();
            this.newVirtualFolderButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.docPropertiesButton = new System.Windows.Forms.Button();
            this.folderPropertiesButton = new System.Windows.Forms.Button();
            this.pluginPropertiesButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folder_blue.png");
            this.imageList1.Images.SetKeyName(3, "runnable.png");
            this.imageList1.Images.SetKeyName(4, "g4566.png");
            this.imageList1.Images.SetKeyName(5, "up.png");
            this.imageList1.Images.SetKeyName(6, "down.png");
            this.imageList1.Images.SetKeyName(7, "runnable_new.png");
            this.imageList1.Images.SetKeyName(8, "g1.png");
            this.imageList1.Images.SetKeyName(9, "folder_new.png");
            this.imageList1.Images.SetKeyName(10, "delete.png");
            this.imageList1.Images.SetKeyName(11, "question.png");
            this.imageList1.Images.SetKeyName(12, "folder_shortcut.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 236);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.downButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.outdentButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.upButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.indentButton, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(26, 207);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.ImageIndex = 5;
            this.downButton.Location = new System.Drawing.Point(3, 90);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(20, 23);
            this.downButton.TabIndex = 14;
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
            this.indentButton.UseVisualStyleBackColor = true;
            this.indentButton.Click += new System.EventHandler(this.indentButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.newDocButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.newFolderButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.newPluginButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.newVirtualFolderButton, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.deleteButton, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(26, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 29);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // newDocButton
            // 
            this.newDocButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newDocButton.Location = new System.Drawing.Point(3, 3);
            this.newDocButton.Name = "newDocButton";
            this.newDocButton.Size = new System.Drawing.Size(26, 23);
            this.newDocButton.TabIndex = 0;
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
            this.newVirtualFolderButton.UseVisualStyleBackColor = true;
            this.newVirtualFolderButton.Click += new System.EventHandler(this.newVirtualFolderButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(119, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.treeView2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(26, 29);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(408, 207);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.docPropertiesButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.folderPropertiesButton, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.pluginPropertiesButton, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.renameButton, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(323, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(82, 201);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // docPropertiesButton
            // 
            this.docPropertiesButton.AutoSize = true;
            this.docPropertiesButton.Location = new System.Drawing.Point(3, 3);
            this.docPropertiesButton.Name = "docPropertiesButton";
            this.docPropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.docPropertiesButton.TabIndex = 0;
            this.docPropertiesButton.Text = "File";
            this.docPropertiesButton.UseVisualStyleBackColor = true;
            this.docPropertiesButton.Click += new System.EventHandler(this.docPropertiesButton_Click);
            // 
            // folderPropertiesButton
            // 
            this.folderPropertiesButton.AutoSize = true;
            this.folderPropertiesButton.Location = new System.Drawing.Point(3, 32);
            this.folderPropertiesButton.Name = "folderPropertiesButton";
            this.folderPropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.folderPropertiesButton.TabIndex = 1;
            this.folderPropertiesButton.Text = "Folder";
            this.folderPropertiesButton.UseVisualStyleBackColor = true;
            this.folderPropertiesButton.Click += new System.EventHandler(this.folderPropertiesButton_Click);
            // 
            // pluginPropertiesButton
            // 
            this.pluginPropertiesButton.Location = new System.Drawing.Point(3, 61);
            this.pluginPropertiesButton.Name = "pluginPropertiesButton";
            this.pluginPropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.pluginPropertiesButton.TabIndex = 2;
            this.pluginPropertiesButton.Text = "Plugin";
            this.pluginPropertiesButton.UseVisualStyleBackColor = true;
            this.pluginPropertiesButton.Click += new System.EventHandler(this.pluginPropertiesButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(3, 90);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 3;
            this.renameButton.Text = "Rename...";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Options...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.HideSelection = false;
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.ShowPlusMinus = false;
            this.treeView2.Size = new System.Drawing.Size(314, 201);
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
            this.ClientSize = new System.Drawing.Size(480, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ITreeViewForm";
            this.Text = "ScrapForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button newDocButton;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Button newPluginButton;
        private System.Windows.Forms.Button newVirtualFolderButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button indentButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button docPropertiesButton;
        private System.Windows.Forms.Button folderPropertiesButton;
        private System.Windows.Forms.Button pluginPropertiesButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button outdentButton;
        private System.Windows.Forms.Button button1;
    }
}