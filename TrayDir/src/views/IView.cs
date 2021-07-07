using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public class IView
    {
        private TrayInstance instance;

        public TabPage InstanceTabPage;

        public Panel p;
        public TableLayoutPanel tlp;


        public ITreeViewForm treeviewForm;
        public IOptionsForm optionsForm;
        public ITray tray;

        public IView(TrayInstance instance)
        {
            this.instance = instance;
            instance.view = this;
            tray = new ITray(instance);
            treeviewForm = new ITreeViewForm(instance);
            optionsForm = new IOptionsForm(instance);

            p = new Panel();
            p.Dock = DockStyle.Top;
            p.AutoSize = true;
            p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (Program.DEBUG) p.BackColor = Color.Violet;

            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            p.Controls.Add(tlp);

            tlp.Controls.Add(treeviewForm.GetControl(), 0, 0);

            tlp.PerformLayout();

        }
        public Control GetControl()
        {
            return p;
        }
    }
}
