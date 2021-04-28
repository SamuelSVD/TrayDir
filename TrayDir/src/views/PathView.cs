using FolderSelect;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir
{
    public class PathView
    {
        public TrayInstancePath trayInstancePath;
        public Button upButton;
        public Button downButton;
        public Button addButton;
        public Button deleteButton;
        public Button editButton;
        public TableLayoutPanel buttonsPanel;
        public TextBox textbox;
        public Panel panel;
        public Button fileButton;
        public Button folderButton;
        private EventHandler fileSelect;
        private EventHandler folderSelect;
        private EventHandler upSelect;
        private EventHandler downSelect;
        private EventHandler addSelect;
        private EventHandler editSelect;
        private EventHandler deleteSelect;

        public PathView()
        {
            CreateTextField();
            CreateFileButton();
            CreateFolderButton();

            CreateUpButton();
            CreateDownButton();
            CreateAddButton();
            CreateDeleteButton();
            CreateEditButton();
            CreateButtonsPanel();

            buttonsPanel.Controls.Add(upButton, 0, 0);
            buttonsPanel.Controls.Add(downButton, 0, 1);
            buttonsPanel.Controls.Add(addButton, 1, 0);
            buttonsPanel.Controls.Add(editButton, 2, 0);
            buttonsPanel.Controls.Add(deleteButton, 3, 0);
            buttonsPanel.SetRowSpan(addButton, 2);
            buttonsPanel.SetRowSpan(editButton, 2);
            buttonsPanel.SetRowSpan(deleteButton, 2);
        }
        private void CreateTextField()
        {
            textbox = new TextBox();
            textbox.BorderStyle = BorderStyle.None;
            textbox.Dock = DockStyle.Fill;
            textbox.Margin = new Padding(10);
            textbox.AutoSize = true;
            textbox.ReadOnly = true;
            
            panel = new Panel();
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Cursor = textbox.Cursor;
            panel.BackColor = textbox.BackColor;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(2, 3, 2, 3);
            panel.Padding = new Padding(0);

            EventHandler textbox_select = new EventHandler(delegate (object obj, EventArgs args)
            {
                textbox.Select();
            });
            panel.Click += textbox_select;

            panel.Controls.Add(textbox);
        }
        internal void RemoveFromControl(Control c)
        {
            c.Controls.Remove(buttonsPanel);
            c.Controls.Remove(panel);
            c.Controls.Remove(fileButton);
            c.Controls.Remove(folderButton);
        }
        private void CreateButtonsPanel()
        {
            buttonsPanel = new TableLayoutPanel();
            if (Program.DEBUG) buttonsPanel.BackColor = Color.Green;
            ControlUtils.ConfigureTableLayoutPanel(buttonsPanel);

            ColumnStyle cs = new ColumnStyle();
            cs.SizeType = SizeType.AutoSize;
            buttonsPanel.ColumnStyles.Add(cs);
            RowStyle rs1 = new RowStyle();
            rs1.SizeType = SizeType.AutoSize;
            buttonsPanel.RowStyles.Add(rs1);
            RowStyle rs2 = new RowStyle();
            rs2.SizeType = SizeType.AutoSize;
            buttonsPanel.RowStyles.Add(rs2);
        }
        private void CreateUpButton()
        {

            upButton = new Button();
            upButton.Text = "▲";
            upButton.Padding = new Padding();
            upButton.Margin = new Padding();
            upButton.UseCompatibleTextRendering = true;
            upButton.Font = new Font("Microsoft Sans Serif", fileButton.Font.Size / 2, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }
        private void CreateDownButton()
        {
            downButton = new Button();
            downButton.Text = "▼";
            downButton.Padding = new Padding();
            downButton.Margin = new Padding();
            downButton.UseCompatibleTextRendering = true;
            downButton.Font = new Font("Microsoft Sans Serif", fileButton.Font.Size / 2, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            downButton.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void CreateAddButton()
        {
            addButton = new Button()
            {
                Text = "+",
                Padding = new Padding(),
                Margin = new Padding(),
                AutoSize = false,
                UseCompatibleTextRendering = true,
                //Font = new Font("Microsoft Sans Serif", fileButton.Font.Size / 2, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                TextAlign = ContentAlignment.MiddleCenter
            };
            addButton.FlatAppearance.BorderSize = 1;
        }
        private void CreateDeleteButton()
        {
            deleteButton = new Button()
            {
                Text = "-",
                Padding = new Padding(),
                Margin = new Padding(),
                AutoSize = false,
                UseCompatibleTextRendering = true,
                //Font = new Font("Microsoft Sans Serif", fileButton.Font.Size / 2, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                TextAlign = ContentAlignment.MiddleCenter
            };
            deleteButton.FlatAppearance.BorderSize = 1;
        }
        private void CreateEditButton()
        {
            editButton = new Button()
            {
                Text = "?",
                Padding = new Padding(),
                Margin = new Padding(),
                AutoSize = false,
                UseCompatibleTextRendering = true,
                //Font = new Font("Microsoft Sans Serif", fileButton.Font.Size / 2, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                TextAlign = ContentAlignment.MiddleCenter
            };
            editButton.FlatAppearance.BorderSize = 1;
        }
        private void CreateFileButton()
        {
            fileButton = new Button();
            fileButton.AutoSize = true;
            fileButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fileButton.TabIndex = 1;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Dock = DockStyle.Top;
        }
        private void CreateFolderButton()
        {
            folderButton = new Button();
            folderButton.AutoSize = true;
            folderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            folderButton.Text = "Folder";
            folderButton.UseVisualStyleBackColor = true;
            folderButton.Dock = DockStyle.Top;
        }
        private static void ConfigurePathTableStyles(TableLayoutPanel tlp, int buttonWidth)
        {
            RowStyle rs = new RowStyle();
            rs.SizeType = SizeType.AutoSize;
            tlp.RowStyles.Add(rs);
            for (int i = 0; i < 3; i++)
            {
                if (tlp.ColumnStyles.Count < (i + 1))
                {
                    tlp.ColumnStyles.Add(new ColumnStyle());
                }
                ColumnStyle style = tlp.ColumnStyles[i];
                style.SizeType = SizeType.Percent;
                switch (i)
                {
                    case 0:
                        style.SizeType = SizeType.Percent;
                        style.Width = 5;
                        break;
                    case 1:
                        style.SizeType = SizeType.Percent;
                        style.Width = 65;
                        break;
                    case 2:
                        style.SizeType = SizeType.Percent;
                        style.Width = 15;
                        break;
                    default:
                        style.SizeType = SizeType.Percent;
                        style.Width = 15;
                        break;
                }
            }
        }
        public void ResizeButtons(int height)
        {
            upButton.Width = height;
            upButton.Height = height / 2;
            downButton.Width = height;
            downButton.Height = height / 2;
            addButton.Height = height;
            addButton.Width = height;
            editButton.Height = height;
            editButton.Width = height;
            deleteButton.Height = height;
            deleteButton.Width = height;
        }
        public void SetEvents(TrayInstance instance, int pathIndex)
        {
            if (fileSelect != null)
            {
                fileButton.Click -= fileSelect;
            }
            fileSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.fd.DereferenceLinks = false;
                if (trayInstancePath.path == null || trayInstancePath.path == "")
                {
                    MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                else
                {
                    MainForm.form.fd.InitialDirectory = trayInstancePath.path;
                }
                DialogResult d = MainForm.form.fd.ShowDialog();
                if (d == DialogResult.OK)
                {
                    textbox.Text = MainForm.form.fd.FileName;
                    instance.paths[pathIndex].path = MainForm.form.fd.FileName;
                    instance.view.Rebuild();
                    MainForm.form.BuildExploreDropdown();
                    MainForm.form.pd.Save();
                }
            });
            if (folderSelect != null)
            {
                folderButton.Click -= folderSelect;
            }
            folderSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                FolderSelectDialog fs = new FolderSelectDialog();
                if (trayInstancePath.path == null || trayInstancePath.path == "")
                {
                    MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                else
                {
                    MainForm.form.fd.InitialDirectory = trayInstancePath.path;
                }
                if (fs.ShowDialog())
                {
                    textbox.Text = fs.FileName;
                    instance.paths[pathIndex].path = fs.FileName;
                    instance.view.Rebuild();
                    MainForm.form.BuildExploreDropdown();
                    MainForm.form.pd.Save();
                }
            });
            folderButton.Click += folderSelect;
            fileButton.Click += fileSelect;
            if (downSelect != null)
            {
                downButton.Click -= downSelect;
            }
            downSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.SwapPaths(pathIndex, pathIndex + 1);
            });
            downButton.Click += downSelect;
            if (upSelect != null)
            {
                upButton.Click -= upSelect;
            }
            upSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.SwapPaths(pathIndex, pathIndex - 1);
            });
            upButton.Click += upSelect;
            if (addSelect != null)
            {
                addButton.Click -= addSelect;
            }
            addSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.InsertPath(pathIndex + 1);
            });
            addButton.Click += addSelect;
            if (editSelect != null)
            {
                editButton.Click -= editSelect;
            }
            editSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.EditPath(pathIndex + 1);
            });
            editButton.Click += editSelect;
            if (deleteSelect != null)
            {
                deleteButton.Click -= deleteSelect;
            }
            deleteSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                MainForm.form.RemovePath(pathIndex);
            });
            deleteButton.Click += deleteSelect;
        }
    }
}
