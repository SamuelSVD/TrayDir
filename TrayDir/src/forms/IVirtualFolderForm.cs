using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrayDir
{
    public partial class IVirtualFolderForm : Form
    {
        Dictionary<string, int> pluginIndex = new Dictionary<string, int>();
        List<Control> labels = new List<Control>();
        List<Control> controls = new List<Control>();
        TrayInstanceVirtualFolder tivf;
        public IVirtualFolderForm(TrayInstanceVirtualFolder tivf)
        {
            InitializeComponent();
            this.tivf = tivf;
            aliasEdit.Text = tivf.alias;
        }
        private void IPluginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tivf.alias = aliasEdit.Text;
        }
    }
}
