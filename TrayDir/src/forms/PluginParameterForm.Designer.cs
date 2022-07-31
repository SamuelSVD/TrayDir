
namespace TrayDir
{
    partial class PluginParameterForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginParameterForm));
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pluginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.requiredCheckBox = new System.Windows.Forms.CheckBox();
			this.alwaysIncludePrefixCheckBox = new System.Windows.Forms.CheckBox();
			this.isBooleanCheckBox = new System.Windows.Forms.CheckBox();
			this.prefixTextBox = new System.Windows.Forms.TextBox();
			this.pathLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.parameterComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
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
			this.pluginTableLayoutPanel.Controls.Add(this.requiredCheckBox, 0, 8);
			this.pluginTableLayoutPanel.Controls.Add(this.alwaysIncludePrefixCheckBox, 0, 7);
			this.pluginTableLayoutPanel.Controls.Add(this.isBooleanCheckBox, 0, 6);
			this.pluginTableLayoutPanel.Controls.Add(this.prefixTextBox, 0, 5);
			this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 0);
			this.pluginTableLayoutPanel.Controls.Add(this.label2, 0, 4);
			this.pluginTableLayoutPanel.Controls.Add(this.parameterComboBox, 0, 1);
			this.pluginTableLayoutPanel.Controls.Add(this.label1, 0, 2);
			this.pluginTableLayoutPanel.Controls.Add(this.nameTextBox, 0, 3);
			this.pluginTableLayoutPanel.Name = "pluginTableLayoutPanel";
			// 
			// requiredCheckBox
			// 
			resources.ApplyResources(this.requiredCheckBox, "requiredCheckBox");
			this.pluginTableLayoutPanel.SetColumnSpan(this.requiredCheckBox, 2);
			this.requiredCheckBox.Name = "requiredCheckBox";
			this.requiredCheckBox.UseVisualStyleBackColor = true;
			this.requiredCheckBox.CheckedChanged += new System.EventHandler(this.requiredCheckBox_CheckedChanged);
			// 
			// alwaysIncludePrefixCheckBox
			// 
			resources.ApplyResources(this.alwaysIncludePrefixCheckBox, "alwaysIncludePrefixCheckBox");
			this.pluginTableLayoutPanel.SetColumnSpan(this.alwaysIncludePrefixCheckBox, 2);
			this.alwaysIncludePrefixCheckBox.Name = "alwaysIncludePrefixCheckBox";
			this.alwaysIncludePrefixCheckBox.UseVisualStyleBackColor = true;
			this.alwaysIncludePrefixCheckBox.Click += new System.EventHandler(this.alwaysIncludePrefixCheckBox_Click);
			// 
			// isBooleanCheckBox
			// 
			resources.ApplyResources(this.isBooleanCheckBox, "isBooleanCheckBox");
			this.pluginTableLayoutPanel.SetColumnSpan(this.isBooleanCheckBox, 2);
			this.isBooleanCheckBox.Name = "isBooleanCheckBox";
			this.isBooleanCheckBox.UseVisualStyleBackColor = true;
			this.isBooleanCheckBox.CheckedChanged += new System.EventHandler(this.isBooleanCheckBox_CheckedChanged);
			// 
			// prefixTextBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.prefixTextBox, 2);
			resources.ApplyResources(this.prefixTextBox, "prefixTextBox");
			this.prefixTextBox.Name = "prefixTextBox";
			this.prefixTextBox.TextChanged += new System.EventHandler(this.prefixTextBox_TextChanged);
			// 
			// pathLabel
			// 
			resources.ApplyResources(this.pathLabel, "pathLabel");
			this.pathLabel.Name = "pathLabel";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// parameterComboBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.parameterComboBox, 2);
			resources.ApplyResources(this.parameterComboBox, "parameterComboBox");
			this.parameterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.parameterComboBox.FormattingEnabled = true;
			this.parameterComboBox.Name = "parameterComboBox";
			this.parameterComboBox.Sorted = true;
			this.parameterComboBox.SelectedIndexChanged += new System.EventHandler(this.parameterComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// nameTextBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.nameTextBox, 2);
			resources.ApplyResources(this.nameTextBox, "nameTextBox");
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			// 
			// closeButton
			// 
			resources.ApplyResources(this.closeButton, "closeButton");
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Name = "closeButton";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// PluginParameterForm
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
			this.Name = "PluginParameterForm";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.PluginParameterForm_HelpButtonClicked);
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
        private System.Windows.Forms.ComboBox parameterComboBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isBooleanCheckBox;
        private System.Windows.Forms.CheckBox alwaysIncludePrefixCheckBox;
		private System.Windows.Forms.CheckBox requiredCheckBox;
	}
}