
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
			resources.ApplyResources(this.FormTableLayoutPanel, "FormTableLayoutPanel");
			this.FormTableLayoutPanel.Controls.Add(this.ButtonTableLayoutPanel, 0, 1);
			this.FormTableLayoutPanel.Controls.Add(this.CategoryViewTableLayoutPanel, 0, 0);
			this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
			// 
			// ButtonTableLayoutPanel
			// 
			resources.ApplyResources(this.ButtonTableLayoutPanel, "ButtonTableLayoutPanel");
			this.ButtonTableLayoutPanel.Controls.Add(this.CloseButton, 2, 0);
			this.ButtonTableLayoutPanel.Name = "ButtonTableLayoutPanel";
			// 
			// CloseButton
			// 
			resources.ApplyResources(this.CloseButton, "CloseButton");
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
			// 
			// CategoryViewTableLayoutPanel
			// 
			resources.ApplyResources(this.CategoryViewTableLayoutPanel, "CategoryViewTableLayoutPanel");
			this.CategoryViewTableLayoutPanel.Controls.Add(this.SettingsTabControl, 1, 0);
			this.CategoryViewTableLayoutPanel.Controls.Add(this.CategoryTreeView, 0, 0);
			this.CategoryViewTableLayoutPanel.Name = "CategoryViewTableLayoutPanel";
			// 
			// SettingsTabControl
			// 
			resources.ApplyResources(this.SettingsTabControl, "SettingsTabControl");
			this.SettingsTabControl.Controls.Add(this.AppSettingsTabPage);
			this.SettingsTabControl.Controls.Add(this.WinSettingsTabPage);
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.SelectedIndex = 0;
			// 
			// AppSettingsTabPage
			// 
			resources.ApplyResources(this.AppSettingsTabPage, "AppSettingsTabPage");
			this.AppSettingsTabPage.Controls.Add(this.AppGroupBox);
			this.AppSettingsTabPage.Name = "AppSettingsTabPage";
			this.AppSettingsTabPage.UseVisualStyleBackColor = true;
			// 
			// AppGroupBox
			// 
			resources.ApplyResources(this.AppGroupBox, "AppGroupBox");
			this.AppGroupBox.Controls.Add(this.AppGroupLayout);
			this.AppGroupBox.Name = "AppGroupBox";
			this.AppGroupBox.TabStop = false;
			// 
			// AppGroupLayout
			// 
			resources.ApplyResources(this.AppGroupLayout, "AppGroupLayout");
			this.AppGroupLayout.Name = "AppGroupLayout";
			// 
			// WinSettingsTabPage
			// 
			resources.ApplyResources(this.WinSettingsTabPage, "WinSettingsTabPage");
			this.WinSettingsTabPage.Controls.Add(this.WinGroupBox);
			this.WinSettingsTabPage.Name = "WinSettingsTabPage";
			this.WinSettingsTabPage.UseVisualStyleBackColor = true;
			// 
			// WinGroupBox
			// 
			resources.ApplyResources(this.WinGroupBox, "WinGroupBox");
			this.WinGroupBox.Controls.Add(this.WinGroupLayout);
			this.WinGroupBox.Name = "WinGroupBox";
			this.WinGroupBox.TabStop = false;
			// 
			// WinGroupLayout
			// 
			resources.ApplyResources(this.WinGroupLayout, "WinGroupLayout");
			this.WinGroupLayout.Name = "WinGroupLayout";
			// 
			// CategoryTreeView
			// 
			resources.ApplyResources(this.CategoryTreeView, "CategoryTreeView");
			this.CategoryTreeView.Name = "CategoryTreeView";
			this.CategoryTreeView.ShowRootLines = false;
			this.CategoryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CategoryTreeView_AfterSelect);
			// 
			// SettingsForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.Controls.Add(this.FormTableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SettingsForm_HelpButtonClicked);
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