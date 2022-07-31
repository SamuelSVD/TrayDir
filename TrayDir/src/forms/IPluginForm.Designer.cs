
namespace TrayDir
{
    partial class IPluginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPluginForm));
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pluginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.hideItemCheckBox = new System.Windows.Forms.CheckBox();
			this.pathLabel = new System.Windows.Forms.Label();
			this.pluginComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.aliasEdit = new System.Windows.Forms.TextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pluginTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel4
			// 
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.closeButton, 1, 1);
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
			this.pluginTableLayoutPanel.Controls.Add(this.hideItemCheckBox, 0, 4);
			this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 2);
			this.pluginTableLayoutPanel.Controls.Add(this.pluginComboBox, 0, 3);
			this.pluginTableLayoutPanel.Controls.Add(this.label1, 0, 0);
			this.pluginTableLayoutPanel.Controls.Add(this.aliasEdit, 0, 1);
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
			// pathLabel
			// 
			resources.ApplyResources(this.pathLabel, "pathLabel");
			this.pathLabel.Name = "pathLabel";
			// 
			// pluginComboBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.pluginComboBox, 2);
			resources.ApplyResources(this.pluginComboBox, "pluginComboBox");
			this.pluginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.pluginComboBox.FormattingEnabled = true;
			this.pluginComboBox.Name = "pluginComboBox";
			this.pluginComboBox.Sorted = true;
			this.pluginComboBox.SelectedIndexChanged += new System.EventHandler(this.pluginComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// aliasEdit
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.aliasEdit, 2);
			resources.ApplyResources(this.aliasEdit, "aliasEdit");
			this.aliasEdit.Name = "aliasEdit";
			// 
			// closeButton
			// 
			resources.ApplyResources(this.closeButton, "closeButton");
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Name = "closeButton";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// IPluginForm
			// 
			this.AcceptButton = this.closeButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.Controls.Add(this.tableLayoutPanel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IPluginForm";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.IPluginForm_HelpButtonClicked);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IPluginForm_FormClosed);
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
        private System.Windows.Forms.ComboBox pluginComboBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aliasEdit;
		private System.Windows.Forms.CheckBox hideItemCheckBox;
	}
}