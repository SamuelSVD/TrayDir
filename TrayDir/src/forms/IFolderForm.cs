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
    public partial class IFolderForm : Form
    {
        TrayInstancePath tip;
        public IFolderForm(TrayInstancePath tip)
        {
            InitializeComponent();
            this.tip = tip;
        }
        private void browse()
        {
/*            FolderSelectDialog fs = new FolderSelectDialog();
            string path = tip.path;
            if (path == null || path == "") {
                fs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            } else {
                fs.InitialDirectory = Path.GetDirectoryName(path);
            }
            if (fs.ShowDialog()) {
                instance.paths[selectedNode.tin.id].path = fs.FileName;
                itn.Refresh();
                MainForm.form.BuildExploreDropdown();
                Save();
            } */
        }
    }
}
