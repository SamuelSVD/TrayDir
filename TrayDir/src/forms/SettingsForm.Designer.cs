
namespace TrayDir
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.TrayPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.TrayPropertiesBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TrayIconTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.IconDisplay = new System.Windows.Forms.PictureBox();
            this.IconBrowseButton = new System.Windows.Forms.Button();
            this.TrayIconPathPanel = new System.Windows.Forms.Panel();
            this.TrayIconPathTextBox = new System.Windows.Forms.TextBox();
            this.TrayTextTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TrayTextApplyButton = new System.Windows.Forms.Button();
            this.TrayTextCancelButton = new System.Windows.Forms.Button();
            this.TrayTextTextBoxPanel = new System.Windows.Forms.Panel();
            this.TrayTextTextBox = new System.Windows.Forms.TextBox();
            this.TrayHoverTextLabel = new System.Windows.Forms.Label();
            this.TrayIconLabel = new System.Windows.Forms.Label();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.IconFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TrayPropertiesGroupBox.SuspendLayout();
            this.TrayPropertiesBoxLayout.SuspendLayout();
            this.TrayIconTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconDisplay)).BeginInit();
            this.TrayIconPathPanel.SuspendLayout();
            this.TrayTextTableLayout.SuspendLayout();
            this.TrayTextTextBoxPanel.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TrayPropertiesGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OptionsGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 183);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 159);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(13, 5, 13, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(585, 27);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Location = new System.Drawing.Point(498, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TrayPropertiesGroupBox
            // 
            this.TrayPropertiesGroupBox.AutoSize = true;
            this.TrayPropertiesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayPropertiesGroupBox.Controls.Add(this.TrayPropertiesBoxLayout);
            this.TrayPropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayPropertiesGroupBox.Location = new System.Drawing.Point(10, 32);
            this.TrayPropertiesGroupBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.TrayPropertiesGroupBox.Name = "TrayPropertiesGroupBox";
            this.TrayPropertiesGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayPropertiesGroupBox.Size = new System.Drawing.Size(591, 117);
            this.TrayPropertiesGroupBox.TabIndex = 6;
            this.TrayPropertiesGroupBox.TabStop = false;
            this.TrayPropertiesGroupBox.Text = "Tray Properties";
            // 
            // TrayPropertiesBoxLayout
            // 
            this.TrayPropertiesBoxLayout.AutoSize = true;
            this.TrayPropertiesBoxLayout.ColumnCount = 1;
            this.TrayPropertiesBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TrayPropertiesBoxLayout.Controls.Add(this.TrayIconTableLayout, 0, 1);
            this.TrayPropertiesBoxLayout.Controls.Add(this.TrayTextTableLayout, 0, 3);
            this.TrayPropertiesBoxLayout.Controls.Add(this.TrayHoverTextLabel, 0, 2);
            this.TrayPropertiesBoxLayout.Controls.Add(this.TrayIconLabel, 0, 0);
            this.TrayPropertiesBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayPropertiesBoxLayout.Location = new System.Drawing.Point(2, 15);
            this.TrayPropertiesBoxLayout.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.TrayPropertiesBoxLayout.Name = "TrayPropertiesBoxLayout";
            this.TrayPropertiesBoxLayout.RowCount = 4;
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.Size = new System.Drawing.Size(587, 100);
            this.TrayPropertiesBoxLayout.TabIndex = 0;
            // 
            // TrayIconTableLayout
            // 
            this.TrayIconTableLayout.AutoSize = true;
            this.TrayIconTableLayout.ColumnCount = 3;
            this.TrayIconTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TrayIconTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TrayIconTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TrayIconTableLayout.Controls.Add(this.IconDisplay, 2, 0);
            this.TrayIconTableLayout.Controls.Add(this.IconBrowseButton, 1, 0);
            this.TrayIconTableLayout.Controls.Add(this.TrayIconPathPanel, 0, 0);
            this.TrayIconTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayIconTableLayout.Location = new System.Drawing.Point(2, 16);
            this.TrayIconTableLayout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TrayIconTableLayout.Name = "TrayIconTableLayout";
            this.TrayIconTableLayout.RowCount = 1;
            this.TrayIconTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrayIconTableLayout.Size = new System.Drawing.Size(583, 37);
            this.TrayIconTableLayout.TabIndex = 1;
            // 
            // IconDisplay
            // 
            this.IconDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconDisplay.Location = new System.Drawing.Point(497, 2);
            this.IconDisplay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IconDisplay.Name = "IconDisplay";
            this.IconDisplay.Size = new System.Drawing.Size(84, 33);
            this.IconDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconDisplay.TabIndex = 0;
            this.IconDisplay.TabStop = false;
            // 
            // IconBrowseButton
            // 
            this.IconBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IconBrowseButton.AutoSize = true;
            this.IconBrowseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.IconBrowseButton.Location = new System.Drawing.Point(410, 7);
            this.IconBrowseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IconBrowseButton.Name = "IconBrowseButton";
            this.IconBrowseButton.Size = new System.Drawing.Size(83, 23);
            this.IconBrowseButton.TabIndex = 1;
            this.IconBrowseButton.Text = "Browse";
            this.IconBrowseButton.UseVisualStyleBackColor = true;
            // 
            // TrayIconPathPanel
            // 
            this.TrayIconPathPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayIconPathPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconPathPanel.Controls.Add(this.TrayIconPathTextBox);
            this.TrayIconPathPanel.Location = new System.Drawing.Point(2, 8);
            this.TrayIconPathPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayIconPathPanel.Name = "TrayIconPathPanel";
            this.TrayIconPathPanel.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TrayIconPathPanel.Size = new System.Drawing.Size(404, 21);
            this.TrayIconPathPanel.TabIndex = 2;
            // 
            // TrayIconPathTextBox
            // 
            this.TrayIconPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrayIconPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayIconPathTextBox.Location = new System.Drawing.Point(2, 3);
            this.TrayIconPathTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayIconPathTextBox.MinimumSize = new System.Drawing.Size(8, 15);
            this.TrayIconPathTextBox.Name = "TrayIconPathTextBox";
            this.TrayIconPathTextBox.ReadOnly = true;
            this.TrayIconPathTextBox.Size = new System.Drawing.Size(398, 15);
            this.TrayIconPathTextBox.TabIndex = 0;
            // 
            // TrayTextTableLayout
            // 
            this.TrayTextTableLayout.AutoSize = true;
            this.TrayTextTableLayout.ColumnCount = 3;
            this.TrayTextTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TrayTextTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TrayTextTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TrayTextTableLayout.Controls.Add(this.TrayTextApplyButton, 0, 0);
            this.TrayTextTableLayout.Controls.Add(this.TrayTextCancelButton, 1, 0);
            this.TrayTextTableLayout.Controls.Add(this.TrayTextTextBoxPanel, 0, 0);
            this.TrayTextTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayTextTableLayout.Location = new System.Drawing.Point(2, 71);
            this.TrayTextTableLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayTextTableLayout.Name = "TrayTextTableLayout";
            this.TrayTextTableLayout.RowCount = 1;
            this.TrayTextTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrayTextTableLayout.Size = new System.Drawing.Size(583, 27);
            this.TrayTextTableLayout.TabIndex = 2;
            // 
            // TrayTextApplyButton
            // 
            this.TrayTextApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayTextApplyButton.AutoSize = true;
            this.TrayTextApplyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayTextApplyButton.Location = new System.Drawing.Point(410, 2);
            this.TrayTextApplyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayTextApplyButton.Name = "TrayTextApplyButton";
            this.TrayTextApplyButton.Size = new System.Drawing.Size(83, 23);
            this.TrayTextApplyButton.TabIndex = 3;
            this.TrayTextApplyButton.Text = "Apply";
            this.TrayTextApplyButton.UseVisualStyleBackColor = true;
            // 
            // TrayTextCancelButton
            // 
            this.TrayTextCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayTextCancelButton.AutoSize = true;
            this.TrayTextCancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayTextCancelButton.Location = new System.Drawing.Point(497, 2);
            this.TrayTextCancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayTextCancelButton.Name = "TrayTextCancelButton";
            this.TrayTextCancelButton.Size = new System.Drawing.Size(84, 23);
            this.TrayTextCancelButton.TabIndex = 1;
            this.TrayTextCancelButton.Text = "Cancel";
            this.TrayTextCancelButton.UseVisualStyleBackColor = true;
            // 
            // TrayTextTextBoxPanel
            // 
            this.TrayTextTextBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayTextTextBoxPanel.BackColor = System.Drawing.SystemColors.Window;
            this.TrayTextTextBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayTextTextBoxPanel.Controls.Add(this.TrayTextTextBox);
            this.TrayTextTextBoxPanel.Location = new System.Drawing.Point(2, 3);
            this.TrayTextTextBoxPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayTextTextBoxPanel.Name = "TrayTextTextBoxPanel";
            this.TrayTextTextBoxPanel.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TrayTextTextBoxPanel.Size = new System.Drawing.Size(404, 21);
            this.TrayTextTextBoxPanel.TabIndex = 2;
            // 
            // TrayTextTextBox
            // 
            this.TrayTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrayTextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayTextTextBox.Location = new System.Drawing.Point(2, 3);
            this.TrayTextTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TrayTextTextBox.MinimumSize = new System.Drawing.Size(8, 15);
            this.TrayTextTextBox.Name = "TrayTextTextBox";
            this.TrayTextTextBox.Size = new System.Drawing.Size(398, 15);
            this.TrayTextTextBox.TabIndex = 0;
            // 
            // TrayHoverTextLabel
            // 
            this.TrayHoverTextLabel.AutoSize = true;
            this.TrayHoverTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayHoverTextLabel.Location = new System.Drawing.Point(5, 56);
            this.TrayHoverTextLabel.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.TrayHoverTextLabel.Name = "TrayHoverTextLabel";
            this.TrayHoverTextLabel.Size = new System.Drawing.Size(580, 13);
            this.TrayHoverTextLabel.TabIndex = 3;
            this.TrayHoverTextLabel.Text = "Tray Hover Text";
            // 
            // TrayIconLabel
            // 
            this.TrayIconLabel.AutoSize = true;
            this.TrayIconLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayIconLabel.Location = new System.Drawing.Point(5, 0);
            this.TrayIconLabel.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.TrayIconLabel.Name = "TrayIconLabel";
            this.TrayIconLabel.Size = new System.Drawing.Size(580, 13);
            this.TrayIconLabel.TabIndex = 4;
            this.TrayIconLabel.Text = "Tray Icon";
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.AutoSize = true;
            this.OptionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsGroupBox.Controls.Add(this.OptionsGroupLayout);
            this.OptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsGroupBox.Location = new System.Drawing.Point(10, 5);
            this.OptionsGroupBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OptionsGroupBox.Size = new System.Drawing.Size(591, 17);
            this.OptionsGroupBox.TabIndex = 5;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // OptionsGroupLayout
            // 
            this.OptionsGroupLayout.AutoSize = true;
            this.OptionsGroupLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsGroupLayout.ColumnCount = 2;
            this.OptionsGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.OptionsGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.OptionsGroupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsGroupLayout.Location = new System.Drawing.Point(2, 15);
            this.OptionsGroupLayout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OptionsGroupLayout.Name = "OptionsGroupLayout";
            this.OptionsGroupLayout.RowCount = 1;
            this.OptionsGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsGroupLayout.Size = new System.Drawing.Size(587, 0);
            this.OptionsGroupLayout.TabIndex = 0;
            // 
            // IconFileDialog
            // 
            this.IconFileDialog.FileName = "IconFileDialog";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(590, 183);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.TrayPropertiesGroupBox.ResumeLayout(false);
            this.TrayPropertiesGroupBox.PerformLayout();
            this.TrayPropertiesBoxLayout.ResumeLayout(false);
            this.TrayPropertiesBoxLayout.PerformLayout();
            this.TrayIconTableLayout.ResumeLayout(false);
            this.TrayIconTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconDisplay)).EndInit();
            this.TrayIconPathPanel.ResumeLayout(false);
            this.TrayIconPathPanel.PerformLayout();
            this.TrayTextTableLayout.ResumeLayout(false);
            this.TrayTextTableLayout.PerformLayout();
            this.TrayTextTextBoxPanel.ResumeLayout(false);
            this.TrayTextTextBoxPanel.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.GroupBox OptionsGroupBox;
        public System.Windows.Forms.TableLayoutPanel OptionsGroupLayout;
        private System.Windows.Forms.GroupBox TrayPropertiesGroupBox;
        private System.Windows.Forms.TableLayoutPanel TrayPropertiesBoxLayout;
        private System.Windows.Forms.TableLayoutPanel TrayIconTableLayout;
        public System.Windows.Forms.PictureBox IconDisplay;
        private System.Windows.Forms.Button IconBrowseButton;
        private System.Windows.Forms.Panel TrayIconPathPanel;
        public System.Windows.Forms.TextBox TrayIconPathTextBox;
        private System.Windows.Forms.TableLayoutPanel TrayTextTableLayout;
        private System.Windows.Forms.Button TrayTextApplyButton;
        private System.Windows.Forms.Button TrayTextCancelButton;
        private System.Windows.Forms.Panel TrayTextTextBoxPanel;
        public System.Windows.Forms.TextBox TrayTextTextBox;
        private System.Windows.Forms.Label TrayHoverTextLabel;
        private System.Windows.Forms.Label TrayIconLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog IconFileDialog;
    }
}