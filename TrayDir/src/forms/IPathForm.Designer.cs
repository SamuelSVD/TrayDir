
namespace TrayDir
{
    partial class IPathForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPathForm));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pluginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aliasEdit = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowseButton = new System.Windows.Forms.Button();
            this.shortcutCheckBox = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pluginTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.closeButton, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(380, 196);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.pluginTableLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 20, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(374, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Options";
            // 
            // pluginTableLayoutPanel
            // 
            this.pluginTableLayoutPanel.AutoSize = true;
            this.pluginTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pluginTableLayoutPanel.ColumnCount = 3;
            this.pluginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pluginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pluginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pluginTableLayoutPanel.Controls.Add(this.fileBrowseButton, 1, 4);
            this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 2);
            this.pluginTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.pluginTableLayoutPanel.Controls.Add(this.aliasEdit, 0, 1);
            this.pluginTableLayoutPanel.Controls.Add(this.pathTextBox, 0, 3);
            this.pluginTableLayoutPanel.Controls.Add(this.folderBrowseButton, 2, 4);
            this.pluginTableLayoutPanel.Controls.Add(this.shortcutCheckBox, 0, 5);
            this.pluginTableLayoutPanel.Location = new System.Drawing.Point(5, 20);
            this.pluginTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pluginTableLayoutPanel.Name = "pluginTableLayoutPanel";
            this.pluginTableLayoutPanel.RowCount = 6;
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pluginTableLayoutPanel.Size = new System.Drawing.Size(364, 128);
            this.pluginTableLayoutPanel.TabIndex = 6;
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowseButton.AutoSize = true;
            this.fileBrowseButton.Location = new System.Drawing.Point(205, 81);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.fileBrowseButton.TabIndex = 13;
            this.fileBrowseButton.Text = "File";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(3, 39);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(29, 13);
            this.pathLabel.TabIndex = 7;
            this.pathLabel.Text = "Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Display Name";
            // 
            // aliasEdit
            // 
            this.pluginTableLayoutPanel.SetColumnSpan(this.aliasEdit, 3);
            this.aliasEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.aliasEdit.Location = new System.Drawing.Point(3, 16);
            this.aliasEdit.Name = "aliasEdit";
            this.aliasEdit.Size = new System.Drawing.Size(358, 20);
            this.aliasEdit.TabIndex = 10;
            // 
            // pathTextBox
            // 
            this.pluginTableLayoutPanel.SetColumnSpan(this.pathTextBox, 3);
            this.pathTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathTextBox.Location = new System.Drawing.Point(3, 55);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(358, 20);
            this.pathTextBox.TabIndex = 11;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // folderBrowseButton
            // 
            this.folderBrowseButton.AutoSize = true;
            this.folderBrowseButton.Location = new System.Drawing.Point(286, 81);
            this.folderBrowseButton.Name = "folderBrowseButton";
            this.folderBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.folderBrowseButton.TabIndex = 12;
            this.folderBrowseButton.Text = "Folder";
            this.folderBrowseButton.UseVisualStyleBackColor = true;
            this.folderBrowseButton.Click += new System.EventHandler(this.folderBrowseButton_Click);
            // 
            // shortcutCheckBox
            // 
            this.shortcutCheckBox.AutoSize = true;
            this.shortcutCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pluginTableLayoutPanel.SetColumnSpan(this.shortcutCheckBox, 3);
            this.shortcutCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.shortcutCheckBox.Location = new System.Drawing.Point(2, 109);
            this.shortcutCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shortcutCheckBox.Name = "shortcutCheckBox";
            this.shortcutCheckBox.Size = new System.Drawing.Size(360, 17);
            this.shortcutCheckBox.TabIndex = 14;
            this.shortcutCheckBox.Text = "Use folder as shortcut";
            this.shortcutCheckBox.UseVisualStyleBackColor = true;
            this.shortcutCheckBox.CheckedChanged += new System.EventHandler(this.shortcutCheckBox_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(296, 170);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Apply";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // IPathForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(554, 320);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IPathForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Path";
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pluginTableLayoutPanel.ResumeLayout(false);
            this.pluginTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel pluginTableLayoutPanel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aliasEdit;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button folderBrowseButton;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.CheckBox shortcutCheckBox;
    }
}