using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://stackoverflow.com/questions/19994722/how-to-add-contextmenustrip-to-toolstripmenuitem
namespace TrayDir
{
	public class NativeContextMenuStrip : NativeWindow
	{
		public class ShowContextMenuEventArgs : EventArgs
		{
			public ToolStripDropDown ContextMenuToShow { get; set; }
		}
		public delegate void ShowContextMenuEventHandler(ShowContextMenuEventArgs e);
		public event ShowContextMenuEventHandler ShowContextMenu;
		private Color previousItemBackColor;
		public ToolStripItem SourceItem { get; set; }
		bool keepOpen;
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == 0x204)
			{//WM_RBUTTONDOWN
				OnShowContextMenu(new ShowContextMenuEventArgs());
			}
		}
		protected virtual void OnShowContextMenu(ShowContextMenuEventArgs e)
		{
			var handler = ShowContextMenu;
			if (handler != null)
			{
				handler(e);
				if (e.ContextMenuToShow != null)
				{
					ContextMenuStrip toolStrip = (ContextMenuStrip)Control.FromHandle(Handle);
					Point client = toolStrip.PointToClient(Control.MousePosition);
					SourceItem = toolStrip.GetItemAt(client);
					previousItemBackColor = SourceItem.BackColor;
					SourceItem.BackColor = SystemColors.MenuHighlight;
					e.ContextMenuToShow.Closed -= restoreItemState;
					e.ContextMenuToShow.Closed += restoreItemState;
					keepOpen = true;
					e.ContextMenuToShow.Show(Control.MousePosition);
					keepOpen = false;
				}
			}
		}
		protected override void OnHandleChange()
		{
			base.OnHandleChange();
			ContextMenuStrip toolStrip = Control.FromHandle(Handle) as ContextMenuStrip;
			if (toolStrip != null)
			{
				toolStrip.Closing += toolStripClosing;
			}
		}
		private void restoreItemState(object sender, EventArgs e)
		{
			SourceItem.BackColor = previousItemBackColor;
			SourceItem.Owner.Show();
		}
		private void toolStripClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			e.Cancel = keepOpen;
		}
	}
}
