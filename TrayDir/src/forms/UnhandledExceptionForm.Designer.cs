
namespace TrayDir.forms
{
    partial class UnhandledExceptionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnhandledExceptionForm));
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.reportButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox
			// 
			resources.ApplyResources(this.richTextBox, "richTextBox");
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.ReadOnly = true;
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// reportButton
			// 
			resources.ApplyResources(this.reportButton, "reportButton");
			this.reportButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.reportButton.Name = "reportButton";
			this.reportButton.UseVisualStyleBackColor = true;
			this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
			// 
			// UnhandledExceptionForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.Controls.Add(this.reportButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.richTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "UnhandledExceptionForm";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button reportButton;
	}
}