
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
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.OptionsGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1009, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.AutoSize = true;
            this.OptionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsGroupBox.Controls.Add(this.OptionsGroupLayout);
            this.OptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsGroupBox.Location = new System.Drawing.Point(20, 10);
            this.OptionsGroupBox.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.OptionsGroupBox.Size = new System.Drawing.Size(969, 64);
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
            this.OptionsGroupLayout.Location = new System.Drawing.Point(4, 28);
            this.OptionsGroupLayout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OptionsGroupLayout.Name = "OptionsGroupLayout";
            this.OptionsGroupLayout.RowCount = 1;
            this.OptionsGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsGroupLayout.Size = new System.Drawing.Size(961, 32);
            this.OptionsGroupLayout.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1009, 84);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.GroupBox OptionsGroupBox;
        public System.Windows.Forms.TableLayoutPanel OptionsGroupLayout;
    }
}