using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir
{
    class TrayUtils
    {
        public static string BrowseForIconPath()
        {
            return BrowseForIconPath("");
        }
        public static string BrowseForIconPath(string startingPath)
        {
            OpenFileDialog iconFileDialog = new OpenFileDialog();
            iconFileDialog.DereferenceLinks = false;
            iconFileDialog.InitialDirectory = startingPath;
            DialogResult d = iconFileDialog.ShowDialog();
            if (d == DialogResult.OK)
            {
                return iconFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
