using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	public class IView {
		private TrayInstance instance;

		public TabPage InstanceTabPage;

		public Panel p;

		public ITreeViewForm treeviewForm;
		public ITray tray;

		public IView(TrayInstance instance) {
			this.instance = instance;
			instance.view = this;
			tray = new ITray(instance);
			treeviewForm = new ITreeViewForm(instance);

			p = new Panel();
			p.Dock = DockStyle.Fill;
			p.AutoSize = true;
			p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Control c = treeviewForm.GetControl();
			p.MinimumSize = c.Size;
			if (Program.DEBUG) p.BackColor = Color.Violet;
			p.Controls.Add(c);
		}
		public Control GetControl() {
			return p;
		}

		internal void Rebuild() {
			tray.Rebuild();
			treeviewForm.Rebuild();
		}
	}
}
