﻿
namespace TrayDir
{
    partial class PluginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.scriptCheckBox = new System.Windows.Forms.CheckBox();
			this.openIndirectCheckBox = new System.Windows.Forms.CheckBox();
			this.configureParamsButton = new System.Windows.Forms.Button();
			this.paramNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.pathLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.pathEdit = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameEdit = new System.Windows.Forms.TextBox();
			this.alwaysRunAsAdminCheckBox = new System.Windows.Forms.CheckBox();
			this.scriptText = new System.Windows.Forms.TextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paramNumericUpDown)).BeginInit();
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
			this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 361);
			this.tableLayoutPanel4.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Controls.Add(this.tableLayoutPanel3);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 20, 5, 0);
			this.groupBox1.Size = new System.Drawing.Size(372, 326);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Plugin Options";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.scriptCheckBox, 0, 11);
			this.tableLayoutPanel3.Controls.Add(this.openIndirectCheckBox, 0, 10);
			this.tableLayoutPanel3.Controls.Add(this.configureParamsButton, 1, 7);
			this.tableLayoutPanel3.Controls.Add(this.paramNumericUpDown, 0, 6);
			this.tableLayoutPanel3.Controls.Add(this.pathLabel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.label1, 0, 5);
			this.tableLayoutPanel3.Controls.Add(this.browseButton, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.pathEdit, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.nameLabel, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.nameEdit, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.alwaysRunAsAdminCheckBox, 0, 9);
			this.tableLayoutPanel3.Controls.Add(this.scriptText, 0, 12);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 20);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 13;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(362, 293);
			this.tableLayoutPanel3.TabIndex = 6;
			// 
			// scriptCheckBox
			// 
			this.scriptCheckBox.AutoSize = true;
			this.scriptCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tableLayoutPanel3.SetColumnSpan(this.scriptCheckBox, 2);
			this.scriptCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.scriptCheckBox.Location = new System.Drawing.Point(3, 198);
			this.scriptCheckBox.Name = "scriptCheckBox";
			this.scriptCheckBox.Size = new System.Drawing.Size(356, 17);
			this.scriptCheckBox.TabIndex = 11;
			this.scriptCheckBox.Text = "Configure plugin as script";
			this.scriptCheckBox.UseVisualStyleBackColor = true;
			this.scriptCheckBox.CheckedChanged += new System.EventHandler(this.scriptCheckBox_CheckedChanged);
			// 
			// openIndirectCheckBox
			// 
			this.openIndirectCheckBox.AutoSize = true;
			this.openIndirectCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tableLayoutPanel3.SetColumnSpan(this.openIndirectCheckBox, 2);
			this.openIndirectCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.openIndirectCheckBox.Location = new System.Drawing.Point(3, 175);
			this.openIndirectCheckBox.Name = "openIndirectCheckBox";
			this.openIndirectCheckBox.Size = new System.Drawing.Size(356, 17);
			this.openIndirectCheckBox.TabIndex = 10;
			this.openIndirectCheckBox.Text = "Run Plugin Indirectly";
			this.openIndirectCheckBox.UseVisualStyleBackColor = true;
			this.openIndirectCheckBox.Click += new System.EventHandler(this.openExternallyCheckBox_Click);
			// 
			// configureParamsButton
			// 
			this.configureParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.configureParamsButton.AutoSize = true;
			this.configureParamsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.SetColumnSpan(this.configureParamsButton, 2);
			this.configureParamsButton.Location = new System.Drawing.Point(241, 123);
			this.configureParamsButton.Name = "configureParamsButton";
			this.configureParamsButton.Size = new System.Drawing.Size(118, 23);
			this.configureParamsButton.TabIndex = 4;
			this.configureParamsButton.Text = "Configure Parameters";
			this.configureParamsButton.UseVisualStyleBackColor = true;
			this.configureParamsButton.Click += new System.EventHandler(this.configureParamsButton_Click);
			// 
			// paramNumericUpDown
			// 
			this.tableLayoutPanel3.SetColumnSpan(this.paramNumericUpDown, 2);
			this.paramNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.paramNumericUpDown.Location = new System.Drawing.Point(3, 97);
			this.paramNumericUpDown.Name = "paramNumericUpDown";
			this.paramNumericUpDown.Size = new System.Drawing.Size(356, 20);
			this.paramNumericUpDown.TabIndex = 5;
			this.paramNumericUpDown.ValueChanged += new System.EventHandler(this.paramNumericUpDown_ValueChanged);
			// 
			// pathLabel
			// 
			this.pathLabel.Location = new System.Drawing.Point(3, 0);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(29, 13);
			this.pathLabel.TabIndex = 7;
			this.pathLabel.Text = "Path";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Parameters";
			// 
			// browseButton
			// 
			this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.browseButton.Location = new System.Drawing.Point(284, 16);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(75, 23);
			this.browseButton.TabIndex = 8;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// pathEdit
			// 
			this.pathEdit.Location = new System.Drawing.Point(3, 16);
			this.pathEdit.Name = "pathEdit";
			this.pathEdit.ReadOnly = true;
			this.pathEdit.Size = new System.Drawing.Size(275, 20);
			this.pathEdit.TabIndex = 6;
			// 
			// nameLabel
			// 
			this.nameLabel.Location = new System.Drawing.Point(3, 42);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(35, 13);
			this.nameLabel.TabIndex = 4;
			this.nameLabel.Text = "Name";
			// 
			// nameEdit
			// 
			this.tableLayoutPanel3.SetColumnSpan(this.nameEdit, 2);
			this.nameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nameEdit.Location = new System.Drawing.Point(3, 58);
			this.nameEdit.Name = "nameEdit";
			this.nameEdit.Size = new System.Drawing.Size(356, 20);
			this.nameEdit.TabIndex = 4;
			// 
			// alwaysRunAsAdminCheckBox
			// 
			this.alwaysRunAsAdminCheckBox.AutoSize = true;
			this.alwaysRunAsAdminCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tableLayoutPanel3.SetColumnSpan(this.alwaysRunAsAdminCheckBox, 2);
			this.alwaysRunAsAdminCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.alwaysRunAsAdminCheckBox.Location = new System.Drawing.Point(3, 152);
			this.alwaysRunAsAdminCheckBox.Name = "alwaysRunAsAdminCheckBox";
			this.alwaysRunAsAdminCheckBox.Size = new System.Drawing.Size(356, 17);
			this.alwaysRunAsAdminCheckBox.TabIndex = 9;
			this.alwaysRunAsAdminCheckBox.Text = "Always Run As Admin";
			this.alwaysRunAsAdminCheckBox.UseVisualStyleBackColor = true;
			this.alwaysRunAsAdminCheckBox.CheckedChanged += new System.EventHandler(this.alwaysRunAsAdmin_CheckedChanged);
			// 
			// scriptText
			// 
			this.scriptText.AcceptsReturn = true;
			this.tableLayoutPanel3.SetColumnSpan(this.scriptText, 2);
			this.scriptText.Dock = System.Windows.Forms.DockStyle.Top;
			this.scriptText.Location = new System.Drawing.Point(3, 221);
			this.scriptText.Multiline = true;
			this.scriptText.Name = "scriptText";
			this.scriptText.Size = new System.Drawing.Size(356, 69);
			this.scriptText.TabIndex = 12;
			this.scriptText.TextChanged += new System.EventHandler(this.scriptText_TextChanged);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(294, 335);
			this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// PluginForm
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
			this.Name = "PluginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Plugin";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PluginForm_FormClosed);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.paramNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathEdit;
        private System.Windows.Forms.TextBox nameEdit;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown paramNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button configureParamsButton;
        private System.Windows.Forms.CheckBox alwaysRunAsAdminCheckBox;
        private System.Windows.Forms.CheckBox openIndirectCheckBox;
		private System.Windows.Forms.CheckBox scriptCheckBox;
		private System.Windows.Forms.TextBox scriptText;
	}
}