
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
			this.alwaysIncludePrefixCheckBox = new System.Windows.Forms.CheckBox();
			this.isBooleanCheckBox = new System.Windows.Forms.CheckBox();
			this.prefixTextBox = new System.Windows.Forms.TextBox();
			this.pathLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.parameterComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.requiredCheckBox = new System.Windows.Forms.CheckBox();
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
			this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 255);
			this.tableLayoutPanel4.TabIndex = 4;
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
			this.groupBox1.Size = new System.Drawing.Size(372, 220);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Plugin Options";
			// 
			// pluginTableLayoutPanel
			// 
			this.pluginTableLayoutPanel.AutoSize = true;
			this.pluginTableLayoutPanel.ColumnCount = 2;
			this.pluginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pluginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pluginTableLayoutPanel.Controls.Add(this.requiredCheckBox, 0, 8);
			this.pluginTableLayoutPanel.Controls.Add(this.alwaysIncludePrefixCheckBox, 0, 7);
			this.pluginTableLayoutPanel.Controls.Add(this.isBooleanCheckBox, 0, 6);
			this.pluginTableLayoutPanel.Controls.Add(this.prefixTextBox, 0, 5);
			this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 0);
			this.pluginTableLayoutPanel.Controls.Add(this.label2, 0, 4);
			this.pluginTableLayoutPanel.Controls.Add(this.parameterComboBox, 0, 1);
			this.pluginTableLayoutPanel.Controls.Add(this.label1, 0, 2);
			this.pluginTableLayoutPanel.Controls.Add(this.nameTextBox, 0, 3);
			this.pluginTableLayoutPanel.Location = new System.Drawing.Point(5, 20);
			this.pluginTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.pluginTableLayoutPanel.Name = "pluginTableLayoutPanel";
			this.pluginTableLayoutPanel.RowCount = 9;
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pluginTableLayoutPanel.Size = new System.Drawing.Size(362, 187);
			this.pluginTableLayoutPanel.TabIndex = 6;
			// 
			// alwaysIncludePrefixCheckBox
			// 
			this.alwaysIncludePrefixCheckBox.AutoSize = true;
			this.alwaysIncludePrefixCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.pluginTableLayoutPanel.SetColumnSpan(this.alwaysIncludePrefixCheckBox, 2);
			this.alwaysIncludePrefixCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.alwaysIncludePrefixCheckBox.Location = new System.Drawing.Point(3, 144);
			this.alwaysIncludePrefixCheckBox.Name = "alwaysIncludePrefixCheckBox";
			this.alwaysIncludePrefixCheckBox.Size = new System.Drawing.Size(356, 17);
			this.alwaysIncludePrefixCheckBox.TabIndex = 12;
			this.alwaysIncludePrefixCheckBox.Text = "Always include Prefix when executing plugin";
			this.alwaysIncludePrefixCheckBox.UseVisualStyleBackColor = true;
			this.alwaysIncludePrefixCheckBox.Click += new System.EventHandler(this.alwaysIncludePrefixCheckBox_Click);
			// 
			// isBooleanCheckBox
			// 
			this.isBooleanCheckBox.AutoSize = true;
			this.isBooleanCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.pluginTableLayoutPanel.SetColumnSpan(this.isBooleanCheckBox, 2);
			this.isBooleanCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.isBooleanCheckBox.Location = new System.Drawing.Point(3, 121);
			this.isBooleanCheckBox.Name = "isBooleanCheckBox";
			this.isBooleanCheckBox.Size = new System.Drawing.Size(356, 17);
			this.isBooleanCheckBox.TabIndex = 5;
			this.isBooleanCheckBox.Text = "Use Prefix as commandline flag";
			this.isBooleanCheckBox.UseVisualStyleBackColor = true;
			this.isBooleanCheckBox.CheckedChanged += new System.EventHandler(this.isBooleanCheckBox_CheckedChanged);
			// 
			// prefixTextBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.prefixTextBox, 2);
			this.prefixTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.prefixTextBox.Location = new System.Drawing.Point(3, 95);
			this.prefixTextBox.Name = "prefixTextBox";
			this.prefixTextBox.Size = new System.Drawing.Size(356, 20);
			this.prefixTextBox.TabIndex = 11;
			this.prefixTextBox.TextChanged += new System.EventHandler(this.prefixTextBox_TextChanged);
			// 
			// pathLabel
			// 
			this.pathLabel.AutoSize = true;
			this.pathLabel.Location = new System.Drawing.Point(3, 0);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(103, 13);
			this.pathLabel.TabIndex = 7;
			this.pathLabel.Text = "Choose a Parameter";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Parameter Prefix (optional)";
			// 
			// parameterComboBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.parameterComboBox, 2);
			this.parameterComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.parameterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.parameterComboBox.FormattingEnabled = true;
			this.parameterComboBox.Location = new System.Drawing.Point(3, 16);
			this.parameterComboBox.Name = "parameterComboBox";
			this.parameterComboBox.Size = new System.Drawing.Size(356, 21);
			this.parameterComboBox.Sorted = true;
			this.parameterComboBox.TabIndex = 8;
			this.parameterComboBox.SelectedIndexChanged += new System.EventHandler(this.parameterComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Parameter Name";
			// 
			// nameTextBox
			// 
			this.pluginTableLayoutPanel.SetColumnSpan(this.nameTextBox, 2);
			this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameTextBox.Location = new System.Drawing.Point(3, 56);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(356, 20);
			this.nameTextBox.TabIndex = 10;
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(294, 229);
			this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Apply";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// requiredCheckBox
			// 
			this.requiredCheckBox.AutoSize = true;
			this.requiredCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.pluginTableLayoutPanel.SetColumnSpan(this.requiredCheckBox, 2);
			this.requiredCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.requiredCheckBox.Location = new System.Drawing.Point(3, 167);
			this.requiredCheckBox.Name = "requiredCheckBox";
			this.requiredCheckBox.Size = new System.Drawing.Size(356, 17);
			this.requiredCheckBox.TabIndex = 13;
			this.requiredCheckBox.Text = "Paramter value required";
			this.requiredCheckBox.UseVisualStyleBackColor = true;
			this.requiredCheckBox.CheckedChanged += new System.EventHandler(this.requiredCheckBox_CheckedChanged);
			// 
			// PluginParameterForm
			// 
			this.AcceptButton = this.closeButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PluginParameterForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Plugin";
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