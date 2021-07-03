
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.verticalSeparator1 = new TrayDir.VerticalSeparator();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.exploreCheckBox = new System.Windows.Forms.CheckBox();
            this.showextensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.runasCheckBox = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
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
            this.groupBox1.Size = new System.Drawing.Size(271, 178);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // verticalSeparator1
            // 
            this.verticalSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalSeparator1.LineColor = System.Drawing.Color.LightGray;
            this.verticalSeparator1.Location = new System.Drawing.Point(173, 3);
            this.verticalSeparator1.Name = "verticalSeparator1";
            this.verticalSeparator1.Size = new System.Drawing.Size(5, 141);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(181, 0);
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
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.exploreCheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.showextensionsCheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.runasCheckBox, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(170, 69);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // exploreCheckBox
            // 
            this.exploreCheckBox.AutoSize = true;
            this.exploreCheckBox.Location = new System.Drawing.Point(3, 49);
            this.exploreCheckBox.Name = "exploreCheckBox";
            this.exploreCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exploreCheckBox.Size = new System.Drawing.Size(164, 17);
            this.exploreCheckBox.TabIndex = 3;
            this.exploreCheckBox.Text = "Explore Folders In Tray Menu";
            this.exploreCheckBox.UseVisualStyleBackColor = true;
            this.exploreCheckBox.CheckedChanged += new System.EventHandler(this.exploreCheckBox_CheckedChanged);
            // 
            // showextensionsCheckBox
            // 
            this.showextensionsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showextensionsCheckBox.AutoSize = true;
            this.showextensionsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showextensionsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.showextensionsCheckBox.Name = "showextensionsCheckBox";
            this.showextensionsCheckBox.Size = new System.Drawing.Size(164, 17);
            this.showextensionsCheckBox.TabIndex = 2;
            this.showextensionsCheckBox.Text = "Show File Extensions";
            this.showextensionsCheckBox.UseVisualStyleBackColor = true;
            this.showextensionsCheckBox.CheckedChanged += new System.EventHandler(this.showextensionsCheckBox_CheckedChanged);
            // 
            // runasCheckBox
            // 
            this.runasCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runasCheckBox.AutoSize = true;
            this.runasCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.runasCheckBox.Location = new System.Drawing.Point(3, 3);
            this.runasCheckBox.Name = "runasCheckBox";
            this.runasCheckBox.Size = new System.Drawing.Size(164, 17);
            this.runasCheckBox.TabIndex = 1;
            this.runasCheckBox.Text = "Run As Administrator";
            this.runasCheckBox.UseVisualStyleBackColor = true;
            this.runasCheckBox.CheckedChanged += new System.EventHandler(this.runasCheckBox_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(193, 184);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(277, 210);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instance Options";
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
    }
}