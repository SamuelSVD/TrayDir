﻿using System;
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
                //ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer
                ,true);
            DoubleBuffered = true;
            AllowDrop = true;
        }

        /// <summary>
        ///     A random page will be used to store a tab that will be deplaced in the run-time
        /// </summary>
        private TabPage predraggedTab;

        public event EventHandler<TabClickedArgs> OnTabClick;
        public event EventHandler<TabSwappedArgs> OnTabsSwapped;

        public List<TabPage> IgnoreDragTabPages;
        /// <summary>
        ///     Drags the selected tab
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            var draggedTab = (TabPage)drgevent.Data.GetData(typeof(TabPage));
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
            predraggedTab = getPointedTab();
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
            for (var i = 0; i <= TabPages.Count - 1; i++)
            {
                if (GetTabRect(i).Contains(PointToClient(Cursor.Position)))
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


    }
}
