namespace TrayDir {
	partial class ValidateTextBox {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.TextBox = new System.Windows.Forms.TextBox();
			this.PictureBox = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(397, 22);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.TextBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.PictureBox, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 20);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 20);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// TextBox
			// 
			this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextBox.Location = new System.Drawing.Point(3, 3);
			this.TextBox.Name = "TextBox";
			this.TextBox.Size = new System.Drawing.Size(369, 13);
			this.TextBox.TabIndex = 0;
			this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// PictureBox
			// 
			this.PictureBox.BackColor = System.Drawing.Color.Transparent;
			this.PictureBox.BackgroundImage = global::TrayDir.Properties.Resources.error;
			this.PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.PictureBox.Location = new System.Drawing.Point(377, 2);
			this.PictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.PictureBox.MinimumSize = new System.Drawing.Size(16, 16);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Padding = new System.Windows.Forms.Padding(2);
			this.PictureBox.Size = new System.Drawing.Size(16, 16);
			this.PictureBox.TabIndex = 1;
			this.PictureBox.TabStop = false;
			this.PictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
			this.PictureBox.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
			// 
			// ValidateTextBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "ValidateTextBox";
			this.Size = new System.Drawing.Size(397, 22);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox TextBox;
		private System.Windows.Forms.PictureBox PictureBox;
	}
}
