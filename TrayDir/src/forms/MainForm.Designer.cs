
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DirectoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.DirectoriesGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DirectoriesGroupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.MainFormTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.instanceTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DirectoriesGroupBox.SuspendLayout();
            this.DirectoriesGroupBoxLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainFormTableLayout.SuspendLayout();
            this.instanceTabs.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoriesGroupBox
            // 
            this.DirectoriesGroupBox.AutoSize = true;
            this.DirectoriesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectoriesGroupBox.Controls.Add(this.DirectoriesGroupBoxLayout);
            this.DirectoriesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoriesGroupBox.Location = new System.Drawing.Point(5, 10);
            this.DirectoriesGroupBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.DirectoriesGroupBox.Name = "DirectoriesGroupBox";
            this.DirectoriesGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.DirectoriesGroupBox.Size = new System.Drawing.Size(556, 52);
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
            this.DirectoriesGroupBoxLayout.Location = new System.Drawing.Point(2, 15);
            this.DirectoriesGroupBoxLayout.Margin = new System.Windows.Forms.Padding(0);
            this.DirectoriesGroupBoxLayout.Name = "DirectoriesGroupBoxLayout";
            this.DirectoriesGroupBoxLayout.RowCount = 2;
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DirectoriesGroupBoxLayout.Size = new System.Drawing.Size(552, 35);
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
            this.DirectoriesGroupLayout.Location = new System.Drawing.Point(2, 2);
            this.DirectoriesGroupLayout.Margin = new System.Windows.Forms.Padding(2);
            this.DirectoriesGroupLayout.Name = "DirectoriesGroupLayout";
            this.DirectoriesGroupLayout.RowCount = 1;
            this.DirectoriesGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DirectoriesGroupLayout.Size = new System.Drawing.Size(548, 1);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 27);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(385, 2);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(78, 23);
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
            this.RemoveButton.Location = new System.Drawing.Point(467, 2);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(79, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainFormTableLayout
            // 
            this.MainFormTableLayout.AutoSize = true;
            this.MainFormTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainFormTableLayout.ColumnCount = 1;
            this.MainFormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainFormTableLayout.Controls.Add(this.instanceTabs, 0, 3);
            this.MainFormTableLayout.Controls.Add(this.DirectoriesGroupBox, 0, 3);
            this.MainFormTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTableLayout.Location = new System.Drawing.Point(0, 24);
            this.MainFormTableLayout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MainFormTableLayout.Name = "MainFormTableLayout";
            this.MainFormTableLayout.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.MainFormTableLayout.RowCount = 4;
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.Size = new System.Drawing.Size(566, 190);
            this.MainFormTableLayout.TabIndex = 3;
            // 
            // instanceTabs
            // 
            this.instanceTabs.Controls.Add(this.tabPage1);
            this.instanceTabs.Controls.Add(this.tabPage2);
            this.instanceTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instanceTabs.Location = new System.Drawing.Point(8, 70);
            this.instanceTabs.Name = "instanceTabs";
            this.instanceTabs.SelectedIndex = 0;
            this.instanceTabs.Size = new System.Drawing.Size(550, 107);
            this.instanceTabs.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 81);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(542, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "    +";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.exploreToolStripMenuItem.Text = "Explore";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbout);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.rebuildToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.mainMenu.Size = new System.Drawing.Size(566, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.Save);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitApp);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // rebuildToolStripMenuItem
            // 
            this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            this.rebuildToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.rebuildToolStripMenuItem.Text = "Rebuild";
            this.rebuildToolStripMenuItem.Click += new System.EventHandler(this.Rebuild);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(566, 214);
            this.Controls.Add(this.MainFormTableLayout);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "TrayDir";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DirectoriesGroupBox.ResumeLayout(false);
            this.DirectoriesGroupBox.PerformLayout();
            this.DirectoriesGroupBoxLayout.ResumeLayout(false);
            this.DirectoriesGroupBoxLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainFormTableLayout.ResumeLayout(false);
            this.MainFormTableLayout.PerformLayout();
            this.instanceTabs.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion
        private System.Windows.Forms.GroupBox DirectoriesGroupBox;
        private System.Windows.Forms.TableLayoutPanel MainFormTableLayout;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TableLayoutPanel DirectoriesGroupLayout;
        private TableLayoutPanel DirectoriesGroupBoxLayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AddButton;
        private Button RemoveButton;
        private OpenFileDialog FileDialog;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem rebuildToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private TabControl instanceTabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}

