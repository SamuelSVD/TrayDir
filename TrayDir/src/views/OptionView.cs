using System.Windows.Forms;

namespace TrayDir
{
    class OptionView
    {
        public Label label;
        public CheckBox checkbox;
        public void SetTooltip(string message)
        {
            ToolTip tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 500;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            tp.SetToolTip(checkbox, message);
            tp.SetToolTip(label, message);
        }
    }
}
