using System;
using System.Windows.Forms;

namespace TrayDir
{
    class IOptionsView
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

            IIconOption io = new IIconOption(instance);
            grouptlp.Controls.Add(io.GetControl(), 1, 0);
            
            for (int i = 0; i < 2; i++)
            {
                if (grouptlp.ColumnStyles.Count < i + 1)
                {
                    ColumnStyle cs = new ColumnStyle();
                    cs.SizeType = SizeType.Percent;
                    grouptlp.ColumnStyles.Add(cs);
                    switch (i)
                    {
                        case 0:
                            cs.Width = 70;
                            break;
                        case 1:
                            cs.Width = 30;
                            break;
                        default:
                            cs.Width = 30;
                            break;
                    }
                }
            }
            // Add options into table layout
            OptionView ov;
            ov = ControlUtils.AddOption(optionstlp, 0, "Run As Admin", instance.settings.RunAsAdmin);
            ov.SetTooltip("Run files as administrator user");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "RunAsAdmin");

            ov = ControlUtils.AddOption(optionstlp, 1, "Show File Extensions", instance.settings.ShowFileExtensions);
            ov.SetTooltip("Show file exensions in tray menu");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ShowFileExtensions");

            ov = ControlUtils.AddOption(optionstlp, 2, "Explore Folders In TrayMenu", instance.settings.ExploreFoldersInTrayMenu);
            ov.SetTooltip("Explore to folder location when folder menu item clicked in tray menu");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ExploreFoldersInTrayMenu");

            ov = ControlUtils.AddOption(optionstlp, 3, "Expand First Path", instance.settings.ExpandFirstPath);
            ov.SetTooltip("When only one path and is directed to folder, use folder contents in tray menu instead of grouped in folder");
            ControlUtils.SetCheckboxCheckedEvent(ov.checkbox, instance, "ExpandFirstPath");

            //ControlUtils.AddEmptyOption(optionstlp, 4);
        }
        public Control GetControl()
        {
            return optionsgb;
        }
        public int GetHeight()
        {
            int height = 0;
            height += optionsgb.Padding.Bottom + optionsgb.Padding.Top + optionsgb.Margin.Top + optionsgb.Margin.Bottom + optionsgb.Height;
            return height;
        }
    }
}
