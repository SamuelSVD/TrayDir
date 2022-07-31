
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
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.closeButton, 1, 1);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.tableLayoutPanel4.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Controls.Add(this.tableLayoutPanel3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
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
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// scriptCheckBox
			// 
			resources.ApplyResources(this.scriptCheckBox, "scriptCheckBox");
			this.tableLayoutPanel3.SetColumnSpan(this.scriptCheckBox, 2);
			this.scriptCheckBox.Name = "scriptCheckBox";
			this.scriptCheckBox.UseVisualStyleBackColor = true;
			this.scriptCheckBox.CheckedChanged += new System.EventHandler(this.scriptCheckBox_CheckedChanged);
			// 
			// openIndirectCheckBox
			// 
			resources.ApplyResources(this.openIndirectCheckBox, "openIndirectCheckBox");
			this.tableLayoutPanel3.SetColumnSpan(this.openIndirectCheckBox, 2);
			this.openIndirectCheckBox.Name = "openIndirectCheckBox";
			this.openIndirectCheckBox.UseVisualStyleBackColor = true;
			this.openIndirectCheckBox.Click += new System.EventHandler(this.openExternallyCheckBox_Click);
			// 
			// configureParamsButton
			// 
			resources.ApplyResources(this.configureParamsButton, "configureParamsButton");
			this.tableLayoutPanel3.SetColumnSpan(this.configureParamsButton, 2);
			this.configureParamsButton.Name = "configureParamsButton";
			this.configureParamsButton.UseVisualStyleBackColor = true;
			this.configureParamsButton.Click += new System.EventHandler(this.configureParamsButton_Click);
			// 
			// paramNumericUpDown
			// 
			this.tableLayoutPanel3.SetColumnSpan(this.paramNumericUpDown, 2);
			resources.ApplyResources(this.paramNumericUpDown, "paramNumericUpDown");
			this.paramNumericUpDown.Name = "paramNumericUpDown";
			this.paramNumericUpDown.ValueChanged += new System.EventHandler(this.paramNumericUpDown_ValueChanged);
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
			// browseButton
			// 
			resources.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.Name = "browseButton";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// pathEdit
			// 
			resources.ApplyResources(this.pathEdit, "pathEdit");
			this.pathEdit.Name = "pathEdit";
			this.pathEdit.ReadOnly = true;
			// 
			// nameLabel
			// 
			resources.ApplyResources(this.nameLabel, "nameLabel");
			this.nameLabel.Name = "nameLabel";
			// 
			// nameEdit
			// 
			this.tableLayoutPanel3.SetColumnSpan(this.nameEdit, 2);
			resources.ApplyResources(this.nameEdit, "nameEdit");
			this.nameEdit.Name = "nameEdit";
			// 
			// alwaysRunAsAdminCheckBox
			// 
			resources.ApplyResources(this.alwaysRunAsAdminCheckBox, "alwaysRunAsAdminCheckBox");
			this.tableLayoutPanel3.SetColumnSpan(this.alwaysRunAsAdminCheckBox, 2);
			this.alwaysRunAsAdminCheckBox.Name = "alwaysRunAsAdminCheckBox";
			this.alwaysRunAsAdminCheckBox.UseVisualStyleBackColor = true;
			this.alwaysRunAsAdminCheckBox.CheckedChanged += new System.EventHandler(this.alwaysRunAsAdmin_CheckedChanged);
			// 
			// scriptText
			// 
			this.scriptText.AcceptsReturn = true;
			this.tableLayoutPanel3.SetColumnSpan(this.scriptText, 2);
			resources.ApplyResources(this.scriptText, "scriptText");
			this.scriptText.Name = "scriptText";
			this.scriptText.TextChanged += new System.EventHandler(this.scriptText_TextChanged);
			// 
			// closeButton
			// 
			resources.ApplyResources(this.closeButton, "closeButton");
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Name = "closeButton";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// PluginForm
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
			this.Name = "PluginForm";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.PluginForm_HelpButtonClicked);
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