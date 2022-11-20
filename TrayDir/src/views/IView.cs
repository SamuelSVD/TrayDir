using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	internal class IView {
		private TrayInstance instance;

		internal TabPage InstanceTabPage;

		internal Panel p;

		internal ITreeViewForm treeviewForm;
		internal ITray tray;

		internal IView(TrayInstance instance, TabPage tabPage) {
			this.instance = instance;
			this.InstanceTabPage = tabPage;

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

			//Initialize tab page 
			tabPage.Text = instance.instanceName;
			tabPage.Controls.Add(GetControl());
			treeviewForm.setTabPage(tabPage);
			//Add event handlers
			tray.setEventHandlers(new EventHandler(delegate (Object obj, EventArgs args) {
				MainForm.form.onShowInstance = instance;
				MainForm.form.ShowApp(obj, args);
			}), MainForm.form.HideApp,
				MainForm.form.ExitApp);
		}
		internal Control GetControl() {
			return p;
		}

		internal void Rebuild() {
			tray.Rebuild();
			treeviewForm.Rebuild();
		}
	}
}
