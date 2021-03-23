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
            iconFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(startingPath);
            iconFileDialog.FileName = startingPath;
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
