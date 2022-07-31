
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
			this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.instanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archiveManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.changeIgnoreRegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rebuildCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rebuildAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.iconList = new System.Windows.Forms.ImageList(this.components);
			this.imgLoadTimer = new System.Windows.Forms.Timer(this.components);
			this.iconLoadTimer = new System.Windows.Forms.Timer(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// exploreToolStripMenuItem
			// 
			resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
			this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
			this.exploreToolStripMenuItem.Click += new System.EventHandler(this.ExploreClick);
			// 
			// aboutToolStripMenuItem
			// 
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbout);
			// 
			// mainMenu
			// 
			resources.ApplyResources(this.mainMenu, "mainMenu");
			this.mainMenu.BackColor = System.Drawing.SystemColors.Window;
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.instanceToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.rebuildToolStripMenuItem,
            this.pluginToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.mainMenu.Name = "mainMenu";
			this.toolTip.SetToolTip(this.mainMenu, resources.GetString("mainMenu.ToolTip"));
			// 
			// fileToolStripMenuItem
			// 
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem1});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			// 
			// saveToolStripMenuItem1
			// 
			resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
			this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
			this.saveToolStripMenuItem1.Click += new System.EventHandler(this.Save);
			// 
			// saveAsToolStripMenuItem
			// 
			resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitApp);
			// 
			// instanceToolStripMenuItem
			// 
			resources.ApplyResources(this.instanceToolStripMenuItem, "instanceToolStripMenuItem");
			this.instanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInstanceToolStripMenuItem,
            this.editNameToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.archiveToolStripMenuItem,
            this.archiveManagerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.changeIgnoreRegexToolStripMenuItem});
			this.instanceToolStripMenuItem.Name = "instanceToolStripMenuItem";
			// 
			// newInstanceToolStripMenuItem
			// 
			resources.ApplyResources(this.newInstanceToolStripMenuItem, "newInstanceToolStripMenuItem");
			this.newInstanceToolStripMenuItem.Name = "newInstanceToolStripMenuItem";
			this.newInstanceToolStripMenuItem.Click += new System.EventHandler(this.New);
			// 
			// editNameToolStripMenuItem
			// 
			resources.ApplyResources(this.editNameToolStripMenuItem, "editNameToolStripMenuItem");
			this.editNameToolStripMenuItem.Name = "editNameToolStripMenuItem";
			this.editNameToolStripMenuItem.Click += new System.EventHandler(this.Edit);
			// 
			// deleteSelectedToolStripMenuItem
			// 
			resources.ApplyResources(this.deleteSelectedToolStripMenuItem, "deleteSelectedToolStripMenuItem");
			this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
			this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrent);
			// 
			// exportToolStripMenuItem
			// 
			resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			// 
			// importToolStripMenuItem
			// 
			resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click_1);
			// 
			// exportToolStripMenuItem1
			// 
			resources.ApplyResources(this.exportToolStripMenuItem1, "exportToolStripMenuItem1");
			this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
			this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			// 
			// archiveToolStripMenuItem
			// 
			resources.ApplyResources(this.archiveToolStripMenuItem, "archiveToolStripMenuItem");
			this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
			this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
			// 
			// archiveManagerToolStripMenuItem
			// 
			resources.ApplyResources(this.archiveManagerToolStripMenuItem, "archiveManagerToolStripMenuItem");
			this.archiveManagerToolStripMenuItem.Name = "archiveManagerToolStripMenuItem";
			this.archiveManagerToolStripMenuItem.Click += new System.EventHandler(this.archiveManagerToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			// 
			// changeIgnoreRegexToolStripMenuItem
			// 
			resources.ApplyResources(this.changeIgnoreRegexToolStripMenuItem, "changeIgnoreRegexToolStripMenuItem");
			this.changeIgnoreRegexToolStripMenuItem.Name = "changeIgnoreRegexToolStripMenuItem";
			this.changeIgnoreRegexToolStripMenuItem.Click += new System.EventHandler(this.changeIgnoreRegexToolStripMenuItem_Click);
			// 
			// rebuildToolStripMenuItem
			// 
			resources.ApplyResources(this.rebuildToolStripMenuItem, "rebuildToolStripMenuItem");
			this.rebuildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rebuildCurrentToolStripMenuItem,
            this.rebuildAllToolStripMenuItem});
			this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
			this.rebuildToolStripMenuItem.Click += new System.EventHandler(this.rebuildCurrentToolStripMenuItem_Click);
			// 
			// rebuildCurrentToolStripMenuItem
			// 
			resources.ApplyResources(this.rebuildCurrentToolStripMenuItem, "rebuildCurrentToolStripMenuItem");
			this.rebuildCurrentToolStripMenuItem.Name = "rebuildCurrentToolStripMenuItem";
			this.rebuildCurrentToolStripMenuItem.Click += new System.EventHandler(this.rebuildCurrentToolStripMenuItem_Click);
			// 
			// rebuildAllToolStripMenuItem
			// 
			resources.ApplyResources(this.rebuildAllToolStripMenuItem, "rebuildAllToolStripMenuItem");
			this.rebuildAllToolStripMenuItem.Name = "rebuildAllToolStripMenuItem";
			this.rebuildAllToolStripMenuItem.Click += new System.EventHandler(this.rebuildAllToolStripMenuItem_Click);
			// 
			// pluginToolStripMenuItem
			// 
			resources.ApplyResources(this.pluginToolStripMenuItem, "pluginToolStripMenuItem");
			this.pluginToolStripMenuItem.Name = "pluginToolStripMenuItem";
			this.pluginToolStripMenuItem.Click += new System.EventHandler(this.pluginToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.donateToolStripMenuItem,
            this.bugReportToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			// 
			// helpToolStripMenuItem1
			// 
			resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
			// 
			// donateToolStripMenuItem
			// 
			resources.ApplyResources(this.donateToolStripMenuItem, "donateToolStripMenuItem");
			this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
			this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
			// 
			// bugReportToolStripMenuItem
			// 
			resources.ApplyResources(this.bugReportToolStripMenuItem, "bugReportToolStripMenuItem");
			this.bugReportToolStripMenuItem.Name = "bugReportToolStripMenuItem";
			this.bugReportToolStripMenuItem.Click += new System.EventHandler(this.bugReportToolStripMenuItem_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tabPage1
			// 
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.tabPage1.Name = "tabPage1";
			this.toolTip.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			this.toolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
			// 
			// iconList
			// 
			this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
			this.iconList.TransparentColor = System.Drawing.Color.Transparent;
			this.iconList.Images.SetKeyName(0, "document.png");
			this.iconList.Images.SetKeyName(1, "folder.png");
			// 
			// imgLoadTimer
			// 
			this.imgLoadTimer.Enabled = true;
			this.imgLoadTimer.Tick += new System.EventHandler(this.imgLoadTimer_Tick);
			// 
			// iconLoadTimer
			// 
			this.iconLoadTimer.Tick += new System.EventHandler(this.iconLoadTimer_Tick);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.mainMenu);
			this.KeyPreview = true;
			this.MainMenuStrip = this.mainMenu;
			this.MinimumSize = this.Size;
			this.Name = "MainForm";
			this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        
        #endregion
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem rebuildToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Timer timer1;
        private TabPage tabPage1;
        private Panel panel1;
        private ToolStripMenuItem instanceToolStripMenuItem;
        private ToolStripMenuItem newInstanceToolStripMenuItem;
        private ToolStripMenuItem editNameToolStripMenuItem;
        private ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private ToolStripSeparator exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private ToolStripMenuItem rebuildCurrentToolStripMenuItem;
        private ToolStripMenuItem rebuildAllToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem changeIgnoreRegexToolStripMenuItem;
        private ImageList iconList;
        public Timer imgLoadTimer;
        public Timer iconLoadTimer;
        private ToolStripMenuItem pluginToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem archiveToolStripMenuItem;
        private ToolStripMenuItem archiveManagerToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ToolTip toolTip;
		private ToolStripMenuItem bugReportToolStripMenuItem;
	}
}

