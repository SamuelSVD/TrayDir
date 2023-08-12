
namespace TrayDir
{
    partial class IOptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOptionsForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.verticalSeparator1 = new TrayDir.VerticalSeparator();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.resetButton = new System.Windows.Forms.Button();
			this.iconBox = new System.Windows.Forms.PictureBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.hideFromTrayCheckBox = new System.Windows.Forms.CheckBox();
			this.expandFirstPathCheckBox = new System.Windows.Forms.CheckBox();
			this.exploreCheckBox = new System.Windows.Forms.CheckBox();
			this.showextensionsCheckBox = new System.Windows.Forms.CheckBox();
			this.runasCheckBox = new System.Windows.Forms.CheckBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.verticalSeparator1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.toolTip.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
			// 
			// verticalSeparator1
			// 
			resources.ApplyResources(this.verticalSeparator1, "verticalSeparator1");
			this.verticalSeparator1.LineColor = System.Drawing.Color.LightGray;
			this.verticalSeparator1.Name = "verticalSeparator1";
			this.toolTip.SetToolTip(this.verticalSeparator1, resources.GetString("verticalSeparator1.ToolTip"));
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.resetButton, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.iconBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.browseButton, 0, 1);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.toolTip.SetToolTip(this.tableLayoutPanel2, resources.GetString("tableLayoutPanel2.ToolTip"));
			// 
			// resetButton
			// 
			resources.ApplyResources(this.resetButton, "resetButton");
			this.resetButton.Name = "resetButton";
			this.toolTip.SetToolTip(this.resetButton, resources.GetString("resetButton.ToolTip"));
			this.resetButton.UseVisualStyleBackColor = true;
			// 
			// iconBox
			// 
			resources.ApplyResources(this.iconBox, "iconBox");
			this.iconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.iconBox.Name = "iconBox";
			this.iconBox.TabStop = false;
			this.toolTip.SetToolTip(this.iconBox, resources.GetString("iconBox.ToolTip"));
			// 
			// browseButton
			// 
			resources.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.Name = "browseButton";
			this.toolTip.SetToolTip(this.browseButton, resources.GetString("browseButton.ToolTip"));
			this.browseButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.hideFromTrayCheckBox, 0, 6);
			this.tableLayoutPanel3.Controls.Add(this.expandFirstPathCheckBox, 0, 5);
			this.tableLayoutPanel3.Controls.Add(this.exploreCheckBox, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.showextensionsCheckBox, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.runasCheckBox, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.nameLabel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.nameTextBox, 0, 1);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.toolTip.SetToolTip(this.tableLayoutPanel3, resources.GetString("tableLayoutPanel3.ToolTip"));
			// 
			// hideFromTrayCheckBox
			// 
			resources.ApplyResources(this.hideFromTrayCheckBox, "hideFromTrayCheckBox");
			this.hideFromTrayCheckBox.Name = "hideFromTrayCheckBox";
			this.toolTip.SetToolTip(this.hideFromTrayCheckBox, resources.GetString("hideFromTrayCheckBox.ToolTip"));
			this.hideFromTrayCheckBox.UseVisualStyleBackColor = true;
			this.hideFromTrayCheckBox.CheckedChanged += new System.EventHandler(this.hideFromTrayCheckBox_CheckedChanged);
			// 
			// expandFirstPathCheckBox
			// 
			resources.ApplyResources(this.expandFirstPathCheckBox, "expandFirstPathCheckBox");
			this.expandFirstPathCheckBox.Name = "expandFirstPathCheckBox";
			this.toolTip.SetToolTip(this.expandFirstPathCheckBox, resources.GetString("expandFirstPathCheckBox.ToolTip"));
			this.expandFirstPathCheckBox.UseVisualStyleBackColor = true;
			this.expandFirstPathCheckBox.CheckedChanged += new System.EventHandler(this.expandFirstPathCheckBox_CheckedChanged);
			// 
			// exploreCheckBox
			// 
			resources.ApplyResources(this.exploreCheckBox, "exploreCheckBox");
			this.exploreCheckBox.Name = "exploreCheckBox";
			this.toolTip.SetToolTip(this.exploreCheckBox, resources.GetString("exploreCheckBox.ToolTip"));
			this.exploreCheckBox.UseVisualStyleBackColor = true;
			this.exploreCheckBox.CheckedChanged += new System.EventHandler(this.exploreCheckBox_CheckedChanged);
			// 
			// showextensionsCheckBox
			// 
			resources.ApplyResources(this.showextensionsCheckBox, "showextensionsCheckBox");
			this.showextensionsCheckBox.Name = "showextensionsCheckBox";
			this.toolTip.SetToolTip(this.showextensionsCheckBox, resources.GetString("showextensionsCheckBox.ToolTip"));
			this.showextensionsCheckBox.UseVisualStyleBackColor = true;
			this.showextensionsCheckBox.CheckedChanged += new System.EventHandler(this.showextensionsCheckBox_CheckedChanged);
			// 
			// runasCheckBox
			// 
			resources.ApplyResources(this.runasCheckBox, "runasCheckBox");
			this.runasCheckBox.Name = "runasCheckBox";
			this.toolTip.SetToolTip(this.runasCheckBox, resources.GetString("runasCheckBox.ToolTip"));
			this.runasCheckBox.UseVisualStyleBackColor = true;
			this.runasCheckBox.CheckedChanged += new System.EventHandler(this.runasCheckBox_CheckedChanged);
			// 
			// nameLabel
			// 
			resources.ApplyResources(this.nameLabel, "nameLabel");
			this.nameLabel.Name = "nameLabel";
			this.toolTip.SetToolTip(this.nameLabel, resources.GetString("nameLabel.ToolTip"));
			// 
			// nameTextBox
			// 
			resources.ApplyResources(this.nameTextBox, "nameTextBox");
			this.nameTextBox.Name = "nameTextBox";
			this.toolTip.SetToolTip(this.nameTextBox, resources.GetString("nameTextBox.ToolTip"));
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			// 
			// closeButton
			// 
			resources.ApplyResources(this.closeButton, "closeButton");
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Name = "closeButton";
			this.toolTip.SetToolTip(this.closeButton, resources.GetString("closeButton.ToolTip"));
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.closeButton, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.toolTip.SetToolTip(this.tableLayoutPanel4, resources.GetString("tableLayoutPanel4.ToolTip"));
			// 
			// IOptionsForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.Controls.Add(this.tableLayoutPanel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IOptionsForm";
			this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.IOptionsForm_HelpButtonClicked);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IOptionsForm_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox iconBox;
        private VerticalSeparator verticalSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox runasCheckBox;
        private System.Windows.Forms.CheckBox exploreCheckBox;
        private System.Windows.Forms.CheckBox showextensionsCheckBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox expandFirstPathCheckBox;
        private System.Windows.Forms.CheckBox hideFromTrayCheckBox;
        private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameTextBox;
	}
}