
using System;
using System.Windows.Forms;

namespace TrayDir
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DirectoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.DirectoriesGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DirectoriesGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayItem = new System.Windows.Forms.NotifyIcon(this.components);
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DirectoriesGroupBox.SuspendLayout();
            this.DirectoriesGroupBoxLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoriesGroupBox
            // 
            this.DirectoriesGroupBox.AutoSize = true;
            this.DirectoriesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectoriesGroupBox.Controls.Add(this.DirectoriesGroupBoxLayout);
            this.DirectoriesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoriesGroupBox.Location = new System.Drawing.Point(20, 55);
            this.DirectoriesGroupBox.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.DirectoriesGroupBox.Name = "DirectoriesGroupBox";
            this.DirectoriesGroupBox.Size = new System.Drawing.Size(1091, 117);
            this.DirectoriesGroupBox.TabIndex = 2;
            this.DirectoriesGroupBox.TabStop = false;
            this.DirectoriesGroupBox.Text = "Paths";
            // 
            // DirectoriesGroupBoxLayout
            // 
            this.DirectoriesGroupBoxLayout.AutoSize = true;
            this.DirectoriesGroupBoxLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectoriesGroupBoxLayout.ColumnCount = 1;
            this.DirectoriesGroupBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DirectoriesGroupBoxLayout.Controls.Add(this.DirectoriesGroupLayout, 0, 0);
            this.DirectoriesGroupBoxLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.DirectoriesGroupBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoriesGroupBoxLayout.Location = new System.Drawing.Point(3, 27);
            this.DirectoriesGroupBoxLayout.Name = "DirectoriesGroupBoxLayout";
            this.DirectoriesGroupBoxLayout.RowCount = 2;
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DirectoriesGroupBoxLayout.Size = new System.Drawing.Size(1085, 87);
            this.DirectoriesGroupBoxLayout.TabIndex = 1;
            // 
            // DirectoriesGroupLayout
            // 
            this.DirectoriesGroupLayout.AutoSize = true;
            this.DirectoriesGroupLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectoriesGroupLayout.ColumnCount = 3;
            this.DirectoriesGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.DirectoriesGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.DirectoriesGroupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.DirectoriesGroupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoriesGroupLayout.Location = new System.Drawing.Point(10, 10);
            this.DirectoriesGroupLayout.Margin = new System.Windows.Forms.Padding(10);
            this.DirectoriesGroupLayout.Name = "DirectoriesGroupLayout";
            this.DirectoriesGroupLayout.RowCount = 1;
            this.DirectoriesGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DirectoriesGroupLayout.Size = new System.Drawing.Size(1065, 1);
            this.DirectoriesGroupLayout.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.AddButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RemoveButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1065, 47);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(748, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(3);
            this.AddButton.Size = new System.Drawing.Size(153, 41);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(907, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(3);
            this.RemoveButton.Size = new System.Drawing.Size(155, 41);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainLayout
            // 
            this.MainLayout.AutoSize = true;
            this.MainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.OptionsGroupBox, 0, 0);
            this.MainLayout.Controls.Add(this.DirectoriesGroupBox, 0, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 48);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(5);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(1131, 160);
            this.MainLayout.TabIndex = 3;
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
            this.OptionsGroupBox.Size = new System.Drawing.Size(1091, 30);
            this.OptionsGroupBox.TabIndex = 3;
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
            this.OptionsGroupLayout.Location = new System.Drawing.Point(3, 27);
            this.OptionsGroupLayout.Margin = new System.Windows.Forms.Padding(5);
            this.OptionsGroupLayout.Name = "OptionsGroupLayout";
            this.OptionsGroupLayout.RowCount = 1;
            this.OptionsGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsGroupLayout.Size = new System.Drawing.Size(1085, 0);
            this.OptionsGroupLayout.TabIndex = 0;
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(113, 44);
            this.exploreToolStripMenuItem.Text = "Explore";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 44);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbout);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.rebuildToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1131, 48);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 44);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(199, 44);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.Save);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(199, 44);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitApp);
            // 
            // rebuildToolStripMenuItem
            // 
            this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            this.rebuildToolStripMenuItem.Size = new System.Drawing.Size(115, 44);
            this.rebuildToolStripMenuItem.Text = "Rebuild";
            this.rebuildToolStripMenuItem.Click += new System.EventHandler(this.Rebuild);
            // 
            // TrayItem
            // 
            this.TrayItem.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayItem.Icon")));
            this.TrayItem.Text = "TrayDir";
            this.TrayItem.Visible = true;
            this.TrayItem.DoubleClick += new System.EventHandler(this.ShowApp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1131, 208);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "TrayDir";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DirectoriesGroupBox.ResumeLayout(false);
            this.DirectoriesGroupBox.PerformLayout();
            this.DirectoriesGroupBoxLayout.ResumeLayout(false);
            this.DirectoriesGroupBoxLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion
        private System.Windows.Forms.GroupBox DirectoriesGroupBox;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TableLayoutPanel DirectoriesGroupLayout;
        private System.Windows.Forms.TableLayoutPanel OptionsGroupLayout;
        private System.Windows.Forms.NotifyIcon TrayItem;
        private TableLayoutPanel DirectoriesGroupBoxLayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AddButton;
        private Button RemoveButton;
        private OpenFileDialog FileDialog;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem rebuildToolStripMenuItem;
    }
}

