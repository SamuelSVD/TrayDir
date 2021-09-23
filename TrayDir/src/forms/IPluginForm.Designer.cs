
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
            this.pathLabel = new System.Windows.Forms.Label();
            this.pluginComboBox = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 108);
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
            this.groupBox1.Size = new System.Drawing.Size(372, 73);
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
            this.pluginTableLayoutPanel.Controls.Add(this.pathLabel, 0, 0);
            this.pluginTableLayoutPanel.Controls.Add(this.pluginComboBox, 0, 1);
            this.pluginTableLayoutPanel.Location = new System.Drawing.Point(5, 20);
            this.pluginTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pluginTableLayoutPanel.Name = "pluginTableLayoutPanel";
            this.pluginTableLayoutPanel.RowCount = 2;
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginTableLayoutPanel.Size = new System.Drawing.Size(362, 40);
            this.pluginTableLayoutPanel.TabIndex = 6;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(84, 13);
            this.pathLabel.TabIndex = 7;
            this.pathLabel.Text = "Choose a Plugin";
            // 
            // pluginComboBox
            // 
            this.pluginTableLayoutPanel.SetColumnSpan(this.pluginComboBox, 2);
            this.pluginComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pluginComboBox.FormattingEnabled = true;
            this.pluginComboBox.Location = new System.Drawing.Point(3, 16);
            this.pluginComboBox.Name = "pluginComboBox";
            this.pluginComboBox.Size = new System.Drawing.Size(356, 21);
            this.pluginComboBox.Sorted = true;
            this.pluginComboBox.TabIndex = 8;
            this.pluginComboBox.SelectedIndexChanged += new System.EventHandler(this.pluginComboBox_SelectedIndexChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(294, 82);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // IPluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IPluginForm";
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
    }
}