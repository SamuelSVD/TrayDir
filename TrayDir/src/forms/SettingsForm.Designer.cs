
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CategoryViewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.AppSettingsTabPage = new System.Windows.Forms.TabPage();
            this.AppGroupBox = new System.Windows.Forms.GroupBox();
            this.AppGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WinSettingsTabPage = new System.Windows.Forms.TabPage();
            this.WinGroupBox = new System.Windows.Forms.GroupBox();
            this.WinGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CategoryTreeView = new System.Windows.Forms.TreeView();
            this.FormTableLayoutPanel.SuspendLayout();
            this.ButtonTableLayoutPanel.SuspendLayout();
            this.CategoryViewTableLayoutPanel.SuspendLayout();
            this.SettingsTabControl.SuspendLayout();
            this.AppSettingsTabPage.SuspendLayout();
            this.AppGroupBox.SuspendLayout();
            this.WinSettingsTabPage.SuspendLayout();
            this.WinGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormTableLayoutPanel
            // 
            this.FormTableLayoutPanel.AutoSize = true;
            this.FormTableLayoutPanel.ColumnCount = 1;
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FormTableLayoutPanel.Controls.Add(this.ButtonTableLayoutPanel, 0, 1);
            this.FormTableLayoutPanel.Controls.Add(this.CategoryViewTableLayoutPanel, 0, 0);
            this.FormTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FormTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
            this.FormTableLayoutPanel.RowCount = 2;
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(397, 196);
            this.FormTableLayoutPanel.TabIndex = 0;
            // 
            // ButtonTableLayoutPanel
            // 
            this.ButtonTableLayoutPanel.AutoSize = true;
            this.ButtonTableLayoutPanel.ColumnCount = 3;
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.ButtonTableLayoutPanel.Controls.Add(this.CloseButton, 2, 0);
            this.ButtonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTableLayoutPanel.Location = new System.Drawing.Point(13, 164);
            this.ButtonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(13, 5, 13, 5);
            this.ButtonTableLayoutPanel.Name = "ButtonTableLayoutPanel";
            this.ButtonTableLayoutPanel.RowCount = 1;
            this.ButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ButtonTableLayoutPanel.Size = new System.Drawing.Size(371, 27);
            this.ButtonTableLayoutPanel.TabIndex = 7;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(316, 2);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(53, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // CategoryViewTableLayoutPanel
            // 
            this.CategoryViewTableLayoutPanel.AutoSize = true;
            this.CategoryViewTableLayoutPanel.ColumnCount = 2;
            this.CategoryViewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CategoryViewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CategoryViewTableLayoutPanel.Controls.Add(this.SettingsTabControl, 1, 0);
            this.CategoryViewTableLayoutPanel.Controls.Add(this.CategoryTreeView, 0, 0);
            this.CategoryViewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryViewTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.CategoryViewTableLayoutPanel.Name = "CategoryViewTableLayoutPanel";
            this.CategoryViewTableLayoutPanel.RowCount = 1;
            this.CategoryViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CategoryViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CategoryViewTableLayoutPanel.Size = new System.Drawing.Size(391, 153);
            this.CategoryViewTableLayoutPanel.TabIndex = 2;
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.AppSettingsTabPage);
            this.SettingsTabControl.Controls.Add(this.WinSettingsTabPage);
            this.SettingsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsTabControl.ItemSize = new System.Drawing.Size(1, 16);
            this.SettingsTabControl.Location = new System.Drawing.Point(136, 3);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(252, 147);
            this.SettingsTabControl.TabIndex = 1;
            // 
            // AppSettingsTabPage
            // 
            this.AppSettingsTabPage.Controls.Add(this.AppGroupBox);
            this.AppSettingsTabPage.Location = new System.Drawing.Point(4, 20);
            this.AppSettingsTabPage.Name = "AppSettingsTabPage";
            this.AppSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AppSettingsTabPage.Size = new System.Drawing.Size(244, 123);
            this.AppSettingsTabPage.TabIndex = 0;
            this.AppSettingsTabPage.Text = "tabPage1";
            this.AppSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // AppGroupBox
            // 
            this.AppGroupBox.AutoSize = true;
            this.AppGroupBox.Controls.Add(this.AppGroupLayout);
            this.AppGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AppGroupBox.Location = new System.Drawing.Point(3, 3);
            this.AppGroupBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.AppGroupBox.Name = "AppGroupBox";
            this.AppGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.AppGroupBox.Size = new System.Drawing.Size(238, 17);
            this.AppGroupBox.TabIndex = 5;
            this.AppGroupBox.TabStop = false;
            this.AppGroupBox.Text = "Application";
            // 
            // AppGroupLayout
            // 
            this.AppGroupLayout.AutoSize = true;
            this.AppGroupLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AppGroupLayout.ColumnCount = 2;
            this.AppGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AppGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AppGroupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppGroupLayout.Location = new System.Drawing.Point(2, 15);
            this.AppGroupLayout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AppGroupLayout.Name = "AppGroupLayout";
            this.AppGroupLayout.RowCount = 1;
            this.AppGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AppGroupLayout.Size = new System.Drawing.Size(234, 0);
            this.AppGroupLayout.TabIndex = 0;
            // 
            // WinSettingsTabPage
            // 
            this.WinSettingsTabPage.Controls.Add(this.WinGroupBox);
            this.WinSettingsTabPage.Location = new System.Drawing.Point(4, 20);
            this.WinSettingsTabPage.Name = "WinSettingsTabPage";
            this.WinSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WinSettingsTabPage.Size = new System.Drawing.Size(244, 123);
            this.WinSettingsTabPage.TabIndex = 1;
            this.WinSettingsTabPage.Text = "tabPage2";
            this.WinSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // WinGroupBox
            // 
            this.WinGroupBox.AutoSize = true;
            this.WinGroupBox.Controls.Add(this.WinGroupLayout);
            this.WinGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.WinGroupBox.Location = new System.Drawing.Point(3, 3);
            this.WinGroupBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.WinGroupBox.Name = "WinGroupBox";
            this.WinGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.WinGroupBox.Size = new System.Drawing.Size(238, 17);
            this.WinGroupBox.TabIndex = 6;
            this.WinGroupBox.TabStop = false;
            this.WinGroupBox.Text = "Windows";
            // 
            // WinGroupLayout
            // 
            this.WinGroupLayout.AutoSize = true;
            this.WinGroupLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WinGroupLayout.ColumnCount = 2;
            this.WinGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WinGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WinGroupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WinGroupLayout.Location = new System.Drawing.Point(2, 15);
            this.WinGroupLayout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.WinGroupLayout.Name = "WinGroupLayout";
            this.WinGroupLayout.RowCount = 1;
            this.WinGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WinGroupLayout.Size = new System.Drawing.Size(234, 0);
            this.WinGroupLayout.TabIndex = 0;
            // 
            // CategoryTreeView
            // 
            this.CategoryTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.CategoryTreeView.Location = new System.Drawing.Point(3, 3);
            this.CategoryTreeView.Name = "CategoryTreeView";
            this.CategoryTreeView.ShowRootLines = false;
            this.CategoryTreeView.Size = new System.Drawing.Size(127, 147);
            this.CategoryTreeView.TabIndex = 1;
            this.CategoryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CategoryTreeView_AfterSelect);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(463, 223);
            this.Controls.Add(this.FormTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(395, 56);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormTableLayoutPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.PerformLayout();
            this.ButtonTableLayoutPanel.ResumeLayout(false);
            this.ButtonTableLayoutPanel.PerformLayout();
            this.CategoryViewTableLayoutPanel.ResumeLayout(false);
            this.SettingsTabControl.ResumeLayout(false);
            this.AppSettingsTabPage.ResumeLayout(false);
            this.AppSettingsTabPage.PerformLayout();
            this.AppGroupBox.ResumeLayout(false);
            this.AppGroupBox.PerformLayout();
            this.WinSettingsTabPage.ResumeLayout(false);
            this.WinSettingsTabPage.PerformLayout();
            this.WinGroupBox.ResumeLayout(false);
            this.WinGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FormTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ButtonTableLayoutPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TableLayoutPanel CategoryViewTableLayoutPanel;
        public System.Windows.Forms.GroupBox AppGroupBox;
        public System.Windows.Forms.TableLayoutPanel AppGroupLayout;
        private System.Windows.Forms.TreeView CategoryTreeView;
        private System.Windows.Forms.TabControl SettingsTabControl;
        private System.Windows.Forms.TabPage AppSettingsTabPage;
        private System.Windows.Forms.TabPage WinSettingsTabPage;
        public System.Windows.Forms.GroupBox WinGroupBox;
        public System.Windows.Forms.TableLayoutPanel WinGroupLayout;
    }
}