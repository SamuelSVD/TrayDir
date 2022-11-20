using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrayDir {
	internal class TrayUtils {
		internal static string BrowseForIconPath() {
			return BrowseForIconPath(string.Empty);
		}
		internal static string BrowseForIconPath(string startingPath) {
			OpenFileDialog iconFileDialog = new OpenFileDialog();
			iconFileDialog.DereferenceLinks = false;
			iconFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(startingPath);
			iconFileDialog.FileName = startingPath;
			DialogResult d = iconFileDialog.ShowDialog();
			if (d == DialogResult.OK) {
				return iconFileDialog.FileName;
			} else {
				return null;
			}
		}
		internal static byte[] IconToBytes(System.Drawing.Icon icon) {
			using (MemoryStream ms = new MemoryStream()) {
				icon.ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
				return ms.ToArray();
			}
		}
		internal static System.Drawing.Icon BytesToIcon(byte[] bytes) {
			using (MemoryStream ms = new MemoryStream(bytes)) {
				Bitmap bmp = new Bitmap(ms);
				IntPtr Hicon = bmp.GetHicon();
				return Icon.FromHandle(Hicon);
			}
		}
	}
}
