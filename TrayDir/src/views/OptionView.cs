using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    class OptionView
    {
        public Label label;
        public CheckBox checkbox;
        public ToolTip tp;
        public OptionView(string text, bool boxChecked)
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

            checkbox = new CheckBox();
            checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            checkbox.AutoSize = true;
            checkbox.CheckAlign = ContentAlignment.MiddleCenter;
            checkbox.Location = new Point(688, 9);
            checkbox.Size = new Size(116, 27);
            checkbox.TabIndex = 1;
            checkbox.UseVisualStyleBackColor = true;
            checkbox.Checked = boxChecked;

            if (Program.DEBUG) checkbox.BackColor = Color.Red;
        }
        public void AddTo(TableLayoutPanel tlp, int row)
        {
            tlp.Controls.Add(label, 0, row);
            tlp.Controls.Add(checkbox, 1, row);
            tlp.RowCount = row + 1;
            tlp.RowStyles.Add(new RowStyle());
        }
        public void SetTooltip(string message)
        {
            tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 500;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            tp.SetToolTip(checkbox, message);
            tp.SetToolTip(label, message);
        }
    }
}
