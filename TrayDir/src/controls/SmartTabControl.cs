using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TrayDir
{

    public class SmartTabControl : TabControl
    {
        // Define a class to hold custom event info
        public class TabClickedArgs : EventArgs
        {
            public TabClickedArgs(TabPage tp, MouseEventArgs e)
            {
                TabPage = tp;
                MouseEventArgs = e;
            }
            public TabPage TabPage { get; set; }
            public MouseEventArgs MouseEventArgs { get; set; }
        }
        public class TabSwappedArgs : EventArgs
        {
            public TabSwappedArgs(TabPage aTabPage, TabPage bTabPage, int aOriginalIndex, int bOriginalIndex)
            {
                this.aTabPage = aTabPage;
                this.bTabPage = bTabPage;
                this.aOriginalIndex = aOriginalIndex;
                this.bOriginalIndex = bOriginalIndex;
            }
            public TabPage aTabPage { get; set; }
            public TabPage bTabPage { get; set; }
            public int aOriginalIndex { get; set; }
            public int bOriginalIndex { get; set; }
        }
        public SmartTabControl()
        {
            IgnoreDragTabPages = new List<TabPage>();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint 
                //| ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer
                ,true);
            DoubleBuffered = true;
            AllowDrop = true;
		}

        /// <summary>
        ///     A random page will be used to store a tab that will be deplaced in the run-time
        /// </summary>
        private CustomTabPage predraggedTab;

        public event EventHandler<TabClickedArgs> OnTabClick;
        public event EventHandler<TabSwappedArgs> OnTabsSwapped;

        public List<TabPage> IgnoreDragTabPages;
        /// <summary>
        ///     Drags the selected tab
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            var draggedTab = (CustomTabPage)drgevent.Data.GetData(typeof(CustomTabPage));
            var pointedTab = getPointedTab();

            if (draggedTab != null && ReferenceEquals(draggedTab, predraggedTab) && pointedTab != null)
            {
                drgevent.Effect = DragDropEffects.Move;

                if (!ReferenceEquals(pointedTab, draggedTab) && (IgnoreDragTabPages.IndexOf(pointedTab) == -1))
                {
                    ReplaceTabPages(draggedTab, pointedTab);
                }
            }

            base.OnDragOver(drgevent);
        }

        /// <summary>
        ///     Handles the selected tab|closes the selected page if wanted.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            predraggedTab = (CustomTabPage)getPointedTab();
            if (IgnoreDragTabPages.IndexOf(predraggedTab) > -1)
            {
                predraggedTab = null;
            }
            base.OnMouseDown(e);
            var p = e.Location;
            for (var i = 0; i < TabCount; i++)
            {
                var r = GetTabRect(i);
                
                if (r.Contains(p) && OnTabClick != null)
                {
                    OnTabClick(this, new TabClickedArgs(TabPages[i], e));
                }
            }
        }

        /// <summary>
        ///     Holds the selected page until it sets down
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && predraggedTab != null)
            {
                DoDragDrop(predraggedTab, DragDropEffects.Move);
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        ///     Abandons the selected tab
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            predraggedTab = null;
            base.OnMouseUp(e);
        }

        /// <summary>
        ///     Gets the pointed tab
        /// </summary>
        /// <returns></returns>
        private TabPage getPointedTab()
        {
			var p = PointToClient(Cursor.Position);
            for (var i = 0; i <= TabPages.Count - 1; i++)
            {
				var r = GetTabRect(i);
                if (r.Contains(p))
                {
                    return TabPages[i];
                }
            }

            return null;
        }

        /// <summary>
        ///     Swaps the two tabs
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        private void ReplaceTabPages(TabPage Source, TabPage Destination)
        {
            var SourceIndex = TabPages.IndexOf(Source);
            var DestinationIndex = TabPages.IndexOf(Destination);

            if (OnTabsSwapped != null)
            {
                OnTabsSwapped(this, new TabSwappedArgs(Source, Destination, SourceIndex, DestinationIndex));
            }
            TabPages[DestinationIndex] = Source;
            TabPages[SourceIndex] = Destination;

            if (SelectedIndex == SourceIndex)
            {
                SelectedIndex = DestinationIndex;
            }
            else if (SelectedIndex == DestinationIndex)
            {
                SelectedIndex = SourceIndex;
            }

            Refresh();
        }
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			int selectedIndex = -2;
			Color c = Color.FromArgb(255, 217, 217, 217);
			Pen borderPen = new Pen(c, 1);
			Rectangle d1 = new Rectangle(DisplayRectangle.X - 3, DisplayRectangle.Y - 3, DisplayRectangle.Width + 6, DisplayRectangle.Height + 6);
			Rectangle d2 = new Rectangle(DisplayRectangle.X - 2, DisplayRectangle.Y - 2, DisplayRectangle.Width + 4, DisplayRectangle.Height + 4);
			e.Graphics.FillRectangle(new SolidBrush(c), d1);
			e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLightLight), d2);
			for (int i = 0; i < this.TabPages.Count; i++) {
				var tabPage = this.TabPages[i] as CustomTabPage;
				var tabSize = GetTabRect(i);
				var contentSize = new Rectangle(Point.Empty, tabSize.Size);
				var textSize = contentSize;
				textSize.Width = textSize.Width - FontHeight;
				textSize.Y = tabPage == SelectedTab ? -1 : 2;
				if (tabPage == SelectedTab) selectedIndex = i;
				Color selectedColor = tabPage == this.SelectedTab ? SystemColors.ControlLightLight : SystemColors.Control;
				Brush selectedBrush = new SolidBrush(selectedColor);
				using (var bm = new Bitmap(contentSize.Width, contentSize.Height)) {
					Rectangle tabRect = new Rectangle(
						(i == selectedIndex + 1) ? -1 : 0,
						(tabPage == SelectedTab) ? 0 : 2,
						(tabPage == SelectedTab || i == TabPages.Count - 1) ? bm.Size.Width - 1 : (i == selectedIndex + 1) ? bm.Size.Width + 1: bm.Size.Width,
						(tabPage == SelectedTab) ? bm.Size.Height : bm.Size.Height - 3
					);
					using (var bmGraphics = Graphics.FromImage(bm)) {
						if (tabPage.Image != null) {
							bmGraphics.FillRectangle(selectedBrush, tabRect);
							bmGraphics.DrawRectangle(borderPen, tabRect);
							var imageSize = new Rectangle(2, (bm.Height - Font.Height) / 2 + tabRect.Y, Font.Height+1, Font.Height+1);
							textSize.X = imageSize.X + imageSize.Width;
							TextRenderer.DrawText(bmGraphics, tabPage.Text, this.Font, textSize, Color.Black, selectedColor);
							bmGraphics.DrawImage(tabPage.Image, imageSize);
						} else {
							bmGraphics.FillRectangle(selectedBrush, tabRect);
							bmGraphics.DrawRectangle(borderPen, tabRect);
							TextRenderer.DrawText(bmGraphics, tabPage.Text, this.Font, textSize, Color.Black, selectedColor);
						}
						e.Graphics.DrawImage(bm, tabSize);
					}
				}
			}
		}
		public class CustomTabPage : TabPage {
			public Image Image { get; set; }
			public CustomTabPage(string text) : this(null, text) { }
			public CustomTabPage(Image image, string text)
				: base(text) {
				Image = image;
			}
		}

	}
}
