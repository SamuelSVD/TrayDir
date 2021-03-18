using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Credit to antiduh on https://stackoverflow.com/questions/32845294/how-to-make-a-vertical-separator-in-a-windows-forms-application-c

namespace TrayDir
{
    public class VerticalSeparator : Control
    {
        private Color lineColor;
        private Pen linePen;

        public VerticalSeparator()
        {
            LineColor = Color.LightGray;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;

                linePen = new Pen(lineColor, 1);
                linePen.Alignment = PenAlignment.Inset;

                Refresh();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && linePen != null)
            {
                linePen.Dispose();
                linePen = null;
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            int x = Width / 2;

            g.DrawLine(linePen, x, 0, x, Height);

            base.OnPaint(e);
        }
    }
}
