using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class SettingsForm : Form
    {
        public static SettingsForm form;
        private int OptionCount = 0;
        public static void Init()
        {
            if (form is null)
            {
                form = new SettingsForm();
                form.InitializeComponent();
                form.InitializeOptions();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }

        public void InitializeOptions()
        {
            foreach (Option option in Settings.settings.options)
            {
                AddOption(option.name);
            }
        }
        private void AddOption(string name)
        {
            string text = AppUtils.SplitCamelCase(name);
            Label label = new Label();

            label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 55);
            label.Margin = new Padding(10, 5, 3, 5);
            label.Name = name + "Label";
            label.Size = new System.Drawing.Size(670, 25);
            label.TabIndex = 2;
            label.Text = text;

            CheckBox checkbox = new CheckBox();
            checkbox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            checkbox.AutoSize = true;
            checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkbox.Location = new System.Drawing.Point(688, 9);
            checkbox.Name = name + "CheckBox";
            checkbox.Size = new System.Drawing.Size(116, 27);
            checkbox.TabIndex = 1;
            checkbox.UseVisualStyleBackColor = true;
            checkbox.Checked = Settings.getOptionBool(name);

            EventHandler folderSelect = new EventHandler(delegate (object obj, EventArgs args)
            {
                Settings.setOption(name, checkbox.Checked);
                TrayInstance.UpdateAllMenus();
            });

            checkbox.Click += folderSelect;

            int n = SettingsForm.form.OptionsGroupLayout.RowCount;
            SettingsForm.form.OptionsGroupLayout.Controls.Add(label, 0, OptionCount);
            SettingsForm.form.OptionsGroupLayout.Controls.Add(checkbox, 1, OptionCount);
            OptionCount += 1;
            SettingsForm.form.OptionsGroupLayout.RowCount = OptionCount;
        }
    }
}
