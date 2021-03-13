using System.Windows.Forms;

namespace TrayDir
{
    class IView
    {
        TableLayoutPanel tlp;

        IOptionView options;
        IPathView paths;
        public IView(TrayInstance instance)
        {
            tlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(tlp);

            options = new IOptionView(instance);
            tlp.Controls.Add(options.GetControl(), 0, 0);

            paths = new IPathView(instance);
            tlp.Controls.Add(paths.GetControl(), 0, 1);

            tlp.PerformLayout();
        }
        public Control GetControl()
        {
            return tlp;
        }
        public int GetHeight()
        {
            int height = 0;
            height += tlp.Padding.Bottom + tlp.Padding.Top + tlp.Margin.Top + tlp.Margin.Bottom;
            height += options.GetHeight();
            height += paths.GetHeight();
            return height;
        }
    }
}
