using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    class ComboBoxView
    {
        public Label label;
        public ComboBox combobox;
        public ToolTip tp;

        public ComboBoxView(string text, string[] options)
        {
            label = new Label();

            label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            label.AutoSize = true;
            label.Location = new Point(10, 55);
            label.Margin = new Padding(10, 5, 3, 5);
            label.Size = new Size(670, 25);
            label.TabIndex = 2;
            label.Text = text;

            if (Program.DEBUG) label.BackColor = Color.Orange;

            combobox = new ComboBox();
            combobox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            combobox.AutoSize = true;
            combobox.Location = new Point(688, 9);
            combobox.Size = new Size(116, 27);
            combobox.TabIndex = 1;
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach( string s in options)
            {
                combobox.Items.Add(s);
            }
            if (Program.DEBUG) combobox.BackColor = Color.Red;
        }
        public void AddTo(TableLayoutPanel tlp, int row)
        {
            tlp.Controls.Add(label, 0, row);
            tlp.Controls.Add(combobox, 1, row);
            tlp.RowCount = row + 1;
            tlp.RowStyles.Add(new RowStyle());

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
                        style.Width = 60;
                        break;
                    case 1:
                        style.Width = 40;
                        break;
                    default:
                        style.Width = 50;
                        break;
                }
            }
        }
        public void SetTooltip(string message)
        {
            tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 500;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            tp.SetToolTip(combobox, message);
            tp.SetToolTip(label, message);
        }
    }
}
