using System;
using System.Collections.Generic;
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

        public IOptionsView options;

        public ITray tray;


        private ScrapForm scrap;

        public IView(TrayInstance instance)
        {
            this.instance = instance;
            instance.view = this;
            tray = new ITray(instance);
            scrap = new ScrapForm(instance);

            p = new Panel();
            p.Dock = DockStyle.Top;
            p.AutoSize = true;
            p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (Program.DEBUG) p.BackColor = Color.Violet;

            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);
            p.Controls.Add(tlp);

            options = new IOptionsView(instance);
            tlp.Controls.Add(options.GetControl(), 0, 0);

            tlp.Controls.Add(scrap.GetControl(), 0, 1);

            tlp.PerformLayout();

        }
        public Control GetControl()
        {
            return p;
        }
    }
}
