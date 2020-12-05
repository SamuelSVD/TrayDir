
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
            this.MainFormTableLayout = new System.Windows.Forms.TableLayoutPanel();
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
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayItem = new System.Windows.Forms.NotifyIcon(this.components);
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.IconFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DirectoriesGroupBox.SuspendLayout();
            this.DirectoriesGroupBoxLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainFormTableLayout.SuspendLayout();
            this.TrayPropertiesGroupBox.SuspendLayout();
            this.TrayPropertiesBoxLayout.SuspendLayout();
            this.TrayIconTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconDisplay)).BeginInit();
            this.TrayIconPathPanel.SuspendLayout();
            this.TrayTextTableLayout.SuspendLayout();
            this.TrayTextTextBoxPanel.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoriesGroupBox
            // 
            this.DirectoriesGroupBox.AutoSize = true;
            this.DirectoriesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectoriesGroupBox.Controls.Add(this.DirectoriesGroupBoxLayout);
            this.DirectoriesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoriesGroupBox.Location = new System.Drawing.Point(10, 238);
            this.DirectoriesGroupBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.DirectoriesGroupBox.Name = "DirectoriesGroupBox";
            this.DirectoriesGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.DirectoriesGroupBox.Size = new System.Drawing.Size(1112, 87);
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
            this.DirectoriesGroupBoxLayout.Location = new System.Drawing.Point(4, 28);
            this.DirectoriesGroupBoxLayout.Margin = new System.Windows.Forms.Padding(0);
            this.DirectoriesGroupBoxLayout.Name = "DirectoriesGroupBoxLayout";
            this.DirectoriesGroupBoxLayout.RowCount = 2;
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DirectoriesGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DirectoriesGroupBoxLayout.Size = new System.Drawing.Size(1104, 55);
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
            this.DirectoriesGroupLayout.Location = new System.Drawing.Point(3, 3);
            this.DirectoriesGroupLayout.Name = "DirectoriesGroupLayout";
            this.DirectoriesGroupLayout.RowCount = 1;
            this.DirectoriesGroupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DirectoriesGroupLayout.Size = new System.Drawing.Size(1098, 1);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1098, 43);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(772, 4);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(156, 35);
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
            this.RemoveButton.Location = new System.Drawing.Point(936, 4);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(158, 35);
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
            this.MainFormTableLayout.Controls.Add(this.TrayPropertiesGroupBox, 0, 0);
            this.MainFormTableLayout.Controls.Add(this.DirectoriesGroupBox, 0, 1);
            this.MainFormTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTableLayout.Location = new System.Drawing.Point(0, 40);
            this.MainFormTableLayout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MainFormTableLayout.Name = "MainFormTableLayout";
            this.MainFormTableLayout.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.MainFormTableLayout.RowCount = 3;
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormTableLayout.Size = new System.Drawing.Size(1132, 398);
            this.MainFormTableLayout.TabIndex = 3;
            // 
            // TrayPropertiesGroupBox
            // 
            this.TrayPropertiesGroupBox.AutoSize = true;
            this.TrayPropertiesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayPropertiesGroupBox.Controls.Add(this.TrayPropertiesBoxLayout);
            this.TrayPropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayPropertiesGroupBox.Location = new System.Drawing.Point(10, 20);
            this.TrayPropertiesGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.TrayPropertiesGroupBox.Name = "TrayPropertiesGroupBox";
            this.TrayPropertiesGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.TrayPropertiesGroupBox.Size = new System.Drawing.Size(1112, 218);
            this.TrayPropertiesGroupBox.TabIndex = 4;
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
            this.TrayPropertiesBoxLayout.Location = new System.Drawing.Point(4, 28);
            this.TrayPropertiesBoxLayout.Name = "TrayPropertiesBoxLayout";
            this.TrayPropertiesBoxLayout.RowCount = 4;
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrayPropertiesBoxLayout.Size = new System.Drawing.Size(1104, 186);
            this.TrayPropertiesBoxLayout.TabIndex = 0;
            this.TrayPropertiesBoxLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.TrayPropertiesBoxLayout_Paint);
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
            this.TrayIconTableLayout.Location = new System.Drawing.Point(4, 31);
            this.TrayIconTableLayout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TrayIconTableLayout.Name = "TrayIconTableLayout";
            this.TrayIconTableLayout.RowCount = 1;
            this.TrayIconTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrayIconTableLayout.Size = new System.Drawing.Size(1153, 71);
            this.TrayIconTableLayout.TabIndex = 1;
            // 
            // IconDisplay
            // 
            this.IconDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconDisplay.Location = new System.Drawing.Point(983, 4);
            this.IconDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.IconDisplay.Name = "IconDisplay";
            this.IconDisplay.Size = new System.Drawing.Size(166, 63);
            this.IconDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconDisplay.TabIndex = 0;
            this.IconDisplay.TabStop = false;
            // 
            // IconBrowseButton
            // 
            this.IconBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IconBrowseButton.AutoSize = true;
            this.IconBrowseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.IconBrowseButton.Location = new System.Drawing.Point(811, 18);
            this.IconBrowseButton.Margin = new System.Windows.Forms.Padding(4);
            this.IconBrowseButton.Name = "IconBrowseButton";
            this.IconBrowseButton.Size = new System.Drawing.Size(164, 35);
            this.IconBrowseButton.TabIndex = 1;
            this.IconBrowseButton.Text = "Browse";
            this.IconBrowseButton.UseVisualStyleBackColor = true;
            this.IconBrowseButton.Click += new System.EventHandler(this.BrowseIcon);
            // 
            // TrayIconPathPanel
            // 
            this.TrayIconPathPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayIconPathPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconPathPanel.Controls.Add(this.TrayIconPathTextBox);
            this.TrayIconPathPanel.Location = new System.Drawing.Point(3, 16);
            this.TrayIconPathPanel.Name = "TrayIconPathPanel";
            this.TrayIconPathPanel.Padding = new System.Windows.Forms.Padding(5);
            this.TrayIconPathPanel.Size = new System.Drawing.Size(801, 39);
            this.TrayIconPathPanel.TabIndex = 2;
            // 
            // TrayIconPathTextBox
            // 
            this.TrayIconPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrayIconPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayIconPathTextBox.Location = new System.Drawing.Point(5, 5);
            this.TrayIconPathTextBox.MinimumSize = new System.Drawing.Size(15, 15);
            this.TrayIconPathTextBox.Name = "TrayIconPathTextBox";
            this.TrayIconPathTextBox.ReadOnly = true;
            this.TrayIconPathTextBox.Size = new System.Drawing.Size(789, 24);
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
            this.TrayTextTableLayout.Location = new System.Drawing.Point(4, 137);
            this.TrayTextTableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.TrayTextTableLayout.Name = "TrayTextTableLayout";
            this.TrayTextTableLayout.RowCount = 1;
            this.TrayTextTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrayTextTableLayout.Size = new System.Drawing.Size(1153, 45);
            this.TrayTextTableLayout.TabIndex = 2;
            // 
            // TrayTextApplyButton
            // 
            this.TrayTextApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayTextApplyButton.AutoSize = true;
            this.TrayTextApplyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayTextApplyButton.Location = new System.Drawing.Point(811, 5);
            this.TrayTextApplyButton.Margin = new System.Windows.Forms.Padding(4);
            this.TrayTextApplyButton.Name = "TrayTextApplyButton";
            this.TrayTextApplyButton.Size = new System.Drawing.Size(164, 35);
            this.TrayTextApplyButton.TabIndex = 3;
            this.TrayTextApplyButton.Text = "Apply";
            this.TrayTextApplyButton.UseVisualStyleBackColor = true;
            this.TrayTextApplyButton.Click += new System.EventHandler(this.TrayTextApplyButton_Click);
            // 
            // TrayTextCancelButton
            // 
            this.TrayTextCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrayTextCancelButton.AutoSize = true;
            this.TrayTextCancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrayTextCancelButton.Location = new System.Drawing.Point(983, 5);
            this.TrayTextCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.TrayTextCancelButton.Name = "TrayTextCancelButton";
            this.TrayTextCancelButton.Size = new System.Drawing.Size(166, 35);
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
            this.TrayTextTextBoxPanel.Location = new System.Drawing.Point(3, 3);
            this.TrayTextTextBoxPanel.Name = "TrayTextTextBoxPanel";
            this.TrayTextTextBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.TrayTextTextBoxPanel.Size = new System.Drawing.Size(801, 39);
            this.TrayTextTextBoxPanel.TabIndex = 2;
            // 
            // TrayTextTextBox
            // 
            this.TrayTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrayTextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayTextTextBox.Location = new System.Drawing.Point(5, 5);
            this.TrayTextTextBox.MinimumSize = new System.Drawing.Size(15, 15);
            this.TrayTextTextBox.Name = "TrayTextTextBox";
            this.TrayTextTextBox.Size = new System.Drawing.Size(789, 24);
            this.TrayTextTextBox.TabIndex = 0;
            // 
            // TrayHoverTextLabel
            // 
            this.TrayHoverTextLabel.AutoSize = true;
            this.TrayHoverTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayHoverTextLabel.Location = new System.Drawing.Point(10, 108);
            this.TrayHoverTextLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.TrayHoverTextLabel.Name = "TrayHoverTextLabel";
            this.TrayHoverTextLabel.Size = new System.Drawing.Size(1148, 25);
            this.TrayHoverTextLabel.TabIndex = 3;
            this.TrayHoverTextLabel.Text = "Tray Hover Text";
            // 
            // TrayIconLabel
            // 
            this.TrayIconLabel.AutoSize = true;
            this.TrayIconLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayIconLabel.Location = new System.Drawing.Point(10, 0);
            this.TrayIconLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.TrayIconLabel.Name = "TrayIconLabel";
            this.TrayIconLabel.Size = new System.Drawing.Size(1148, 25);
            this.TrayIconLabel.TabIndex = 4;
            this.TrayIconLabel.Text = "Tray Icon";
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(113, 36);
            this.exploreToolStripMenuItem.Text = "Explore";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbout);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.mainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.rebuildToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1132, 40);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 36);
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
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(121, 36);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // rebuildToolStripMenuItem
            // 
            this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            this.rebuildToolStripMenuItem.Size = new System.Drawing.Size(115, 36);
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
            // IconFileDialog
            // 
            this.IconFileDialog.FileName = "IconFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1132, 438);
            this.Controls.Add(this.MainFormTableLayout);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "TrayDir";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DirectoriesGroupBox.ResumeLayout(false);
            this.DirectoriesGroupBox.PerformLayout();
            this.DirectoriesGroupBoxLayout.ResumeLayout(false);
            this.DirectoriesGroupBoxLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainFormTableLayout.ResumeLayout(false);
            this.MainFormTableLayout.PerformLayout();
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
        private GroupBox TrayPropertiesGroupBox;
        private TableLayoutPanel TrayPropertiesBoxLayout;
        private TableLayoutPanel TrayIconTableLayout;
        private PictureBox IconDisplay;
        private Button IconBrowseButton;
        private Panel TrayIconPathPanel;
        private TextBox TrayIconPathTextBox;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private OpenFileDialog IconFileDialog;
        private TableLayoutPanel TrayTextTableLayout;
        private Button TrayTextApplyButton;
        private Button TrayTextCancelButton;
        private Panel TrayTextTextBoxPanel;
        private TextBox TrayTextTextBox;
        private Label TrayHoverTextLabel;
        private Label TrayIconLabel;
    }
}

