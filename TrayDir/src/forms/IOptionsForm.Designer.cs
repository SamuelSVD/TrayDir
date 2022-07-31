
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
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
			this.groupBox1.Size = new System.Drawing.Size(341, 206);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tray Options";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.verticalSeparator1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 175);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// verticalSeparator1
			// 
			this.verticalSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
			this.verticalSeparator1.LineColor = System.Drawing.Color.LightGray;
			this.verticalSeparator1.Location = new System.Drawing.Point(243, 3);
			this.verticalSeparator1.Name = "verticalSeparator1";
			this.verticalSeparator1.Size = new System.Drawing.Size(5, 169);
			this.verticalSeparator1.TabIndex = 4;
			this.verticalSeparator1.Text = "verticalSeparator1";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.resetButton, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.iconBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.browseButton, 0, 1);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(251, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(81, 141);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(3, 113);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 25);
			this.resetButton.TabIndex = 3;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			// 
			// iconBox
			// 
			this.iconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.iconBox.Location = new System.Drawing.Point(3, 3);
			this.iconBox.Name = "iconBox";
			this.iconBox.Padding = new System.Windows.Forms.Padding(3);
			this.iconBox.Size = new System.Drawing.Size(75, 75);
			this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.iconBox.TabIndex = 1;
			this.iconBox.TabStop = false;
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(3, 84);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(75, 23);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = global::TrayDir.Properties.Strings_en.Form_Browse;
			this.browseButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.hideFromTrayCheckBox, 0, 6);
			this.tableLayoutPanel3.Controls.Add(this.expandFirstPathCheckBox, 0, 5);
			this.tableLayoutPanel3.Controls.Add(this.exploreCheckBox, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.showextensionsCheckBox, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.runasCheckBox, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.nameLabel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.nameTextBox, 0, 1);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 7;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 152);
			this.tableLayoutPanel3.TabIndex = 6;
			// 
			// hideFromTrayCheckBox
			// 
			this.hideFromTrayCheckBox.AutoSize = true;
			this.hideFromTrayCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.hideFromTrayCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.hideFromTrayCheckBox.Location = new System.Drawing.Point(3, 132);
			this.hideFromTrayCheckBox.Name = "hideFromTrayCheckBox";
			this.hideFromTrayCheckBox.Size = new System.Drawing.Size(234, 17);
			this.hideFromTrayCheckBox.TabIndex = 8;
			this.hideFromTrayCheckBox.Text = global::TrayDir.Properties.Strings_en.Form_HideFromTray;
			this.toolTip.SetToolTip(this.hideFromTrayCheckBox, global::TrayDir.Properties.Strings_en.Tooltip_HideFromTray);
			this.hideFromTrayCheckBox.UseVisualStyleBackColor = true;
			this.hideFromTrayCheckBox.CheckedChanged += new System.EventHandler(this.hideFromTrayCheckBox_CheckedChanged);
			// 
			// expandFirstPathCheckBox
			// 
			this.expandFirstPathCheckBox.AutoSize = true;
			this.expandFirstPathCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.expandFirstPathCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.expandFirstPathCheckBox.Location = new System.Drawing.Point(3, 109);
			this.expandFirstPathCheckBox.Name = "expandFirstPathCheckBox";
			this.expandFirstPathCheckBox.Size = new System.Drawing.Size(234, 17);
			this.expandFirstPathCheckBox.TabIndex = 7;
			this.expandFirstPathCheckBox.Text = global::TrayDir.Properties.Strings_en.Form_ExpandFirstPath;
			this.toolTip.SetToolTip(this.expandFirstPathCheckBox, global::TrayDir.Properties.Strings_en.Tooltip_ExpandFirstPath);
			this.expandFirstPathCheckBox.UseVisualStyleBackColor = true;
			this.expandFirstPathCheckBox.CheckedChanged += new System.EventHandler(this.expandFirstPathCheckBox_CheckedChanged);
			// 
			// exploreCheckBox
			// 
			this.exploreCheckBox.AutoSize = true;
			this.exploreCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.exploreCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.exploreCheckBox.Location = new System.Drawing.Point(3, 86);
			this.exploreCheckBox.Name = "exploreCheckBox";
			this.exploreCheckBox.Size = new System.Drawing.Size(234, 17);
			this.exploreCheckBox.TabIndex = 3;
			this.exploreCheckBox.Text = global::TrayDir.Properties.Strings_en.Form_OpenFoldersInFileExplorerOnClick;
			this.toolTip.SetToolTip(this.exploreCheckBox, global::TrayDir.Properties.Strings_en.Tooltip_OpenFoldersInFileExplorerOnClick);
			this.exploreCheckBox.UseVisualStyleBackColor = true;
			this.exploreCheckBox.CheckedChanged += new System.EventHandler(this.exploreCheckBox_CheckedChanged);
			// 
			// showextensionsCheckBox
			// 
			this.showextensionsCheckBox.AutoSize = true;
			this.showextensionsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.showextensionsCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.showextensionsCheckBox.Location = new System.Drawing.Point(3, 63);
			this.showextensionsCheckBox.Name = "showextensionsCheckBox";
			this.showextensionsCheckBox.Size = new System.Drawing.Size(234, 17);
			this.showextensionsCheckBox.TabIndex = 2;
			this.showextensionsCheckBox.Text = global::TrayDir.Properties.Strings_en.Form_ShowFileExtensions;
			this.toolTip.SetToolTip(this.showextensionsCheckBox, global::TrayDir.Properties.Strings_en.Tooltip_ShowFileExtensions);
			this.showextensionsCheckBox.UseVisualStyleBackColor = true;
			this.showextensionsCheckBox.CheckedChanged += new System.EventHandler(this.showextensionsCheckBox_CheckedChanged);
			// 
			// runasCheckBox
			// 
			this.runasCheckBox.AutoSize = true;
			this.runasCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.runasCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.runasCheckBox.Location = new System.Drawing.Point(3, 40);
			this.runasCheckBox.Name = "runasCheckBox";
			this.runasCheckBox.Size = new System.Drawing.Size(234, 17);
			this.runasCheckBox.TabIndex = 1;
			this.runasCheckBox.Text = global::TrayDir.Properties.Strings_en.Form_RunAsAdministrator;
			this.toolTip.SetToolTip(this.runasCheckBox, global::TrayDir.Properties.Strings_en.Tooltip_RunAsAdministrator);
			this.runasCheckBox.UseVisualStyleBackColor = true;
			this.runasCheckBox.CheckedChanged += new System.EventHandler(this.runasCheckBox_CheckedChanged);
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(2, 0);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(35, 13);
			this.nameLabel.TabIndex = 9;
			this.nameLabel.Text = "Name";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameTextBox.Location = new System.Drawing.Point(2, 15);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(236, 20);
			this.nameTextBox.TabIndex = 10;
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(263, 212);
			this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = global::TrayDir.Properties.Strings_en.Form_Close;
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.closeButton, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(347, 238);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// IOptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(648, 441);
			this.Controls.Add(this.tableLayoutPanel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IOptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Instance Options";
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