using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir
{
    public class IOptionsView
    {
        public GroupBox optionsgb;
        public IOptionsView(TrayInstance instance)
        {
            // Options Group
            optionsgb = new GroupBox();
            optionsgb.Text = "Tray Options";
            ControlUtils.ConfigureGroupBox(optionsgb);

            TableLayoutPanel grouptlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(grouptlp);
            optionsgb.Controls.Add(grouptlp);

            TableLayoutPanel optionstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(optionstlp);
            grouptlp.Controls.Add(optionstlp, 0, 0);

            optionstlp.ColumnStyles.Clear();
            optionstlp.ColumnStyles.Add(new ColumnStyle());
            optionstlp.ColumnStyles.Add(new ColumnStyle());
            for (int i = 0; i < 2; i++)
            {
                if (optionstlp.ColumnStyles.Count < (i + 1))
                {
                    optionstlp.ColumnStyles.Add(new ColumnStyle());
                }
                ColumnStyle style = optionstlp.ColumnStyles[i];
                style.SizeType = SizeType.Percent;
                switch (i)
                {
                    case 0:
                        style.Width = 90;
                        break;
                    case 1:
                        style.Width = 10;
                        break;
                    default:
                        style.Width = 50;
                        break;
                }
            }

            VerticalSeparator vs = new VerticalSeparator();
            vs.Dock = DockStyle.Fill;
            if (Program.DEBUG) vs.BackColor = Color.Blue;
            grouptlp.Controls.Add(vs, 1, 0);

            IIconOption io = new IIconOption(instance);
            grouptlp.Controls.Add(io.GetControl(), 2, 0);
            
            for (int i = 0; i < 3; i++)
            {
                if (grouptlp.ColumnStyles.Count < i + 1)
                {
                    ColumnStyle cs = new ColumnStyle();
                    cs.SizeType = SizeType.Percent;
                    grouptlp.ColumnStyles.Add(cs);
                    switch (i)
                    {
                        case 0:
                            cs.Width = 65;
                            break;
                        case 1:
                            cs.Width = 5;
                            break;
                        default:
                            cs.Width = 30;
                            break;
                    }
                }
            }
            // Add options into table layout
            OptionView ov;
            ov = new OptionView("Run As Admin", instance.settings.RunAsAdmin);
            ov.AddTo(optionstlp, 0);
            ov.SetTooltip("Run files as administrator user");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "RunAsAdmin");

            ov = new OptionView("Show File Extensions", instance.settings.ShowFileExtensions);
            ov.AddTo(optionstlp, 1);
            ov.SetTooltip("Show file exensions in tray menu");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ShowFileExtensions");

            ov = new OptionView("Explore Folders In TrayMenu", instance.settings.ExploreFoldersInTrayMenu);
            ov.AddTo(optionstlp, 2);
            ov.SetTooltip("Explore to folder location when folder menu item clicked in tray menu");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ExploreFoldersInTrayMenu");

            ov = new OptionView("Expand First Path", instance.settings.ExpandFirstPath);
            ov.AddTo(optionstlp, 3);
            ov.SetTooltip("Expand first path's contents in the tray menu when only one path is selected");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ExpandFirstPath");
        }
        public Control GetControl()
        {
            return optionsgb;
        }
    }
}
