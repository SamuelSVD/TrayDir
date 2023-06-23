
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
			this.hideItemCheckBox = new System.Windows.Forms.CheckBox();
			this.fileBrowseButton = new System.Windows.Forms.Button();
			this.pathLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.aliasEdit = new System.Windows.Forms.TextBox();
			this.folderBrowseButton = new System.Windows.Forms.Button();
			this.shortcutCheckBox = new System.Windows.Forms.CheckBox();
			this.pathTextBox = new TrayDir.ValidateTextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pluginTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel4
			// 
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.OkButton, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.FormCancelButton, 1, 1);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.tableLayoutPanel4.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Controls.Add(this.pluginTableLayoutPanel);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// pluginTableLayoutPanel
			// 
			resources.ApplyResources(this.pluginTableLayoutPanel, "pluginTableLayoutPanel");
			this.pluginTableLayoutPanel.Controls.Add(this.hideItemCheckBox, 0, 6);
			this.pluginTableLayoutPanel.Controls.Add(this.fileBrowseButton, 1, 4);
			this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 2);
			this.pluginTableLayoutPanel.Controls.Add(this.label1, 0, 0);
			this.pluginTableLayoutPanel.Controls.Add(this.aliasEdit, 0, 1);
			this.pluginTableLayoutPanel.Controls.Add(this.folderBrowseButton, 2, 4);
			this.pluginTableLayoutPanel.Controls.Add(this.shortcutCheckBox, 0, 5);
			this.pluginTableLayoutPanel.Controls.Add(this.pathTextBox, 0, 3);
			this.pluginTableLayoutPanel.Name = "pluginTableLayoutPanel";
			// 
			// hideItemCheckBox
			// 
			resources.ApplyResources(this.hideItemCheckBox, "hideItemCheckBox");
			this.pluginTableLayoutPanel.SetColumnSpan(this.hideItemCheckBox, 3);
			this.hideItemCheckBox.Name = "hideItemCheckBox";
			this.hideItemCheckBox.UseVisualStyleBackColor = true;
			this.hideItemCheckBox.CheckedChanged += new System.EventHandler(this.hideItemCheckBox_CheckedChanged);
			// 
			// fileBrowseButton
			// 
			resources.ApplyResources(this.fileBrowseButton, "fileBrowseButton");
			this.fileBrowseButton.Name = "fileBrowseButton";
			this.fileBrowseButton.UseVisualStyleBackColor = true;
			this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
			// 
			// pathLabel
			// 
			resources.ApplyResources(this.pathLabel, "pathLabel");
			this.pathLabel.Name = "pathLabel";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// aliasEdit
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.aliasEdit, 3);
			resources.ApplyResources(this.aliasEdit, "aliasEdit");
			this.aliasEdit.Name = "aliasEdit";
			this.aliasEdit.TextChanged += new System.EventHandler(this.aliasEdit_TextChanged);
			// 
			// folderBrowseButton
			// 
			resources.ApplyResources(this.folderBrowseButton, "folderBrowseButton");
			this.folderBrowseButton.Name = "folderBrowseButton";
			this.folderBrowseButton.UseVisualStyleBackColor = true;
			this.folderBrowseButton.Click += new System.EventHandler(this.folderBrowseButton_Click);
			// 
			// shortcutCheckBox
			// 
			resources.ApplyResources(this.shortcutCheckBox, "shortcutCheckBox");
			this.pluginTableLayoutPanel.SetColumnSpan(this.shortcutCheckBox, 3);
			this.shortcutCheckBox.Name = "shortcutCheckBox";
			this.shortcutCheckBox.UseVisualStyleBackColor = true;
			this.shortcutCheckBox.CheckedChanged += new System.EventHandler(this.shortcutCheckBox_CheckedChanged);
			// 
			// pathTextBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.pathTextBox, 3);
			resources.ApplyResources(this.pathTextBox, "pathTextBox");
			this.pathTextBox.Name = "pathTextBox";
			this.pathTextBox.TooltipText = null;
			this.pathTextBox.Valid = false;
			// 
			// OkButton
			// 
			resources.ApplyResources(this.OkButton, "OkButton");
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// FormCancelButton
			// 
			resources.ApplyResources(this.FormCancelButton, "FormCancelButton");
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// IPathForm
			// 
			this.AcceptButton = this.OkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.Controls.Add(this.tableLayoutPanel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IPathForm";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.IPathForm_HelpButtonClicked);
			this.Shown += new System.EventHandler(this.IPathForm_Shown);
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
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button folderBrowseButton;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.CheckBox shortcutCheckBox;
		private System.Windows.Forms.CheckBox hideItemCheckBox;
        private System.Windows.Forms.Button FormCancelButton;
		private ValidateTextBox pathTextBox;
	}
}