using System;
using System.Windows.Forms;

namespace TrayDir
{
    class IOptionView
    {
        public GroupBox optionsgb;
        public IOptionView(TrayInstance instance)
        {
            // Options Group
            optionsgb = new GroupBox();
            optionsgb.Text = "Tray Options";
            ControlUtils.ConfigureGroupBox(optionsgb);

            TableLayoutPanel optionstlp = new TableLayoutPanel();
            ControlUtils.ConfigureTableLayoutPanel(optionstlp);
            optionsgb.Controls.Add(optionstlp);

            // Add options into table layout
            CheckBox cb;
            cb = ControlUtils.AddOption(optionstlp, 0, "Run As Admin", instance.settings.RunAsAdmin);
            SetCheckboxCheckedEvent(cb, instance, "RunAsAdmin");

            cb = ControlUtils.AddOption(optionstlp, 1, "Show File Extensions", instance.settings.ShowFileExtensions);
            SetCheckboxCheckedEvent(cb, instance, "ShowFileExtensions");

            cb = ControlUtils.AddOption(optionstlp, 2, "Explore Folders In TrayMenu", instance.settings.ExploreFoldersInTrayMenu);
            SetCheckboxCheckedEvent(cb, instance, "ExploreFoldersInTrayMenu");

            cb = ControlUtils.AddOption(optionstlp, 3, "Expand First Path", instance.settings.ExpandFirstPath);
            SetCheckboxCheckedEvent(cb, instance, "ExpandFirstPath");

            //ControlUtils.AddEmptyOption(optionstlp, 4);
        }
        public Control GetControl()
        {
            return optionsgb;
        }

        private void SetCheckboxCheckedEvent(CheckBox cb, TrayInstance instance, string settingName)
        {
            EventHandler cbClick = new EventHandler(delegate (object obj, EventArgs args)
            {
                instance.settings[settingName] = cb.Checked;
                instance.view.UpdateTrayMenu();
                MainForm.form.pd.Save();
            });
            cb.Click += cbClick;
        }
        public int GetHeight()
        {
            int height = 0;
            height += optionsgb.Padding.Bottom + optionsgb.Padding.Top + optionsgb.Margin.Top + optionsgb.Margin.Bottom + optionsgb.Height;
            return height;
        }
    }
}
