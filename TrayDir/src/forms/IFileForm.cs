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
    public partial class IFileForm : Form
    {
        TrayInstancePath tip;
        public IFileForm(TrayInstancePath tip)
        {
            InitializeComponent();
            this.tip = tip;
        }
        public void browse()
        {
/*            ITreeNode itn = selectedNode;
            MainForm.form.fd.DereferenceLinks = false;
            string path = instance.paths[itn.tin.id].path;
            if (path == null || path == "") {
                MainForm.form.fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            } else {
                MainForm.form.fd.InitialDirectory = Path.GetDirectoryName(path);
            }
            MainForm.form.fd.FileName = Path.GetFileName(path);
            DialogResult d = MainForm.form.fd.ShowDialog();
            if (d == DialogResult.OK) {
                instance.paths[itn.tin.id].path = MainForm.form.fd.FileName;
                selectedNode.Refresh();
                MainForm.form.BuildExploreDropdown();
                Save();
            }
*/
        }
    }
}
