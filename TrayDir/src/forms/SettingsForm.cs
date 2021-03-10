using System;
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
            MainForm.form.pd.Save();
        }

        public void InitializeOptions()
        {
            //foreach (Option option in Settings.settings.options)
            //{
            //    AddOption(option.name);
            //}
        }

    }
}
