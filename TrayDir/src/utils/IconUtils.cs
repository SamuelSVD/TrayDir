using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace TrayDir.utils {
	internal class IconUtils {
		private static Dictionary<string, Bitmap> imgKnownIcons = new Dictionary<string, Bitmap>();
		private static Semaphore imgLoadSemaphore = new Semaphore(1, 1);
		internal static ImageList imageList;
		internal static int DOCUMENT;
		internal static int FOLDER;
		internal static int FOLDER_BLUE;
		internal static int RUNNABLE;
		internal static int FOLDER_BLUE_NEW;
		internal static int UP;
		internal static int DOWN;
		internal static int RUNNABLE_NEW;
		internal static int DOCUMENT_NEW;
		internal static int FOLDER_NEW;
		internal static int EDIT;
		internal static int DELETE;
		internal static int QUESTION;
		internal static int INDENT_IN;
		internal static int INDENT_OUT;
		internal static int FOLDER_SHORTCUT;
		internal static int SEPARATOR;
		internal static int SEPARATOR_NEW;
		internal static int RUNNABLE_ERROR;
		internal static int EMPTY;
		internal static int WEBLINK;
		internal static int WEBLINK_NEW;
		internal static int WEBLINK_ERROR;
		internal static bool initialized = false;
		internal static Image DocumentImage { get { return imageList.Images[DOCUMENT]; } }
		internal static Image FolderImage { get { return imageList.Images[FOLDER]; } }
		internal static Image FolderBlueImage { get { return imageList.Images[FOLDER_BLUE]; } }
		internal static Image RunnableImage { get { return imageList.Images[RUNNABLE]; } }
		internal static Image FolderBlueNewImage { get { return imageList.Images[FOLDER_BLUE_NEW]; } }
		internal static Image UpImage { get { return imageList.Images[UP]; } }
		internal static Image DownImage { get { return imageList.Images[DOWN]; } }
		internal static Image RunnableNewImage { get { return imageList.Images[RUNNABLE_NEW]; } }
		internal static Image DocumentNewImage { get { return imageList.Images[DOCUMENT_NEW]; } }
		internal static Image FolderNewImage { get { return imageList.Images[FOLDER_NEW]; } }
		internal static Image DeleteImage { get { return imageList.Images[DELETE]; } }
		internal static Image QuestionImage { get { return imageList.Images[QUESTION]; } }
		internal static Image IndentInImage { get { return imageList.Images[INDENT_IN]; } }
		internal static Image IndentOutImage { get { return imageList.Images[INDENT_OUT]; } }
		internal static Image FolderShortcutImage { get { return imageList.Images[FOLDER_SHORTCUT]; } }
		internal static Image EditImage { get { return imageList.Images[EDIT]; } }
		internal static Image SeparatorImage { get { return imageList.Images[SEPARATOR]; } }
		internal static Image SeparatorNewImage { get { return imageList.Images[SEPARATOR_NEW]; } }
		internal static Image RunnableErrorImage { get { return imageList.Images[RUNNABLE_ERROR]; } }
		internal static Image Empty { get { return imageList.Images[EMPTY]; } }
		internal static Image WebLinkImage { get { return imageList.Images[WEBLINK]; } }
		internal static Image WebLinkNewImage { get { return imageList.Images[WEBLINK_NEW]; } }
		internal static Image WebLinkErrorImage { get { return imageList.Images[WEBLINK_ERROR]; } }
		internal static void Init(int sizeWH) {
			imageList = new ImageList();
			imageList.ImageSize = new Size(sizeWH, sizeWH);
			imageList.ColorDepth = ColorDepth.Depth16Bit;
			imageList.Images.Add(TrayDir.Properties.Resources.document);       //0
			IconUtils.DOCUMENT = 0;
			imageList.Images.Add(TrayDir.Properties.Resources.folder);         //1
			IconUtils.FOLDER = 1;
			imageList.Images.Add(TrayDir.Properties.Resources.folder_blue);    //2
			IconUtils.FOLDER_BLUE = 2;
			imageList.Images.Add(TrayDir.Properties.Resources.runnable);       //3
			IconUtils.RUNNABLE = 3;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.folder_blue, TrayDir.Properties.Resources.overlay_new));//4
			IconUtils.FOLDER_BLUE_NEW = 4;
			imageList.Images.Add(TrayDir.Properties.Resources.up);             //5
			IconUtils.UP = 5;
			imageList.Images.Add(TrayDir.Properties.Resources.down);           //6
			IconUtils.DOWN = 6;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.runnable, TrayDir.Properties.Resources.overlay_new));   //7
			IconUtils.RUNNABLE_NEW = 7;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.document, TrayDir.Properties.Resources.overlay_new));   //8
			IconUtils.DOCUMENT_NEW = 8;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.folder, TrayDir.Properties.Resources.overlay_new));     //9
			IconUtils.FOLDER_NEW = 9;
			imageList.Images.Add(TrayDir.Properties.Resources.delete);        //10
			IconUtils.DELETE = 10;
			imageList.Images.Add(TrayDir.Properties.Resources.question);       //11
			IconUtils.QUESTION = 11;
			imageList.Images.Add(TrayDir.Properties.Resources.indent_in);      //12
			IconUtils.INDENT_IN = 12;
			imageList.Images.Add(TrayDir.Properties.Resources.indent_out);     //13
			IconUtils.INDENT_OUT = 13;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.folder, TrayDir.Properties.Resources.overlay_shortcut));//14
			IconUtils.FOLDER_SHORTCUT = 14;
			imageList.Images.Add(TrayDir.Properties.Resources.edit);
			IconUtils.EDIT = 15;
			imageList.Images.Add(TrayDir.Properties.Resources.separator);
			IconUtils.SEPARATOR = 16;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.runnable, TrayDir.Properties.Resources.overlay_error));
			IconUtils.RUNNABLE_ERROR = 17;
			imageList.Images.Add(TrayDir.Properties.Resources.empty);
			IconUtils.EMPTY = 18;
			imageList.Images.Add(TrayDir.Properties.Resources.weblink);
			IconUtils.WEBLINK = 19;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.weblink, TrayDir.Properties.Resources.overlay_new));
			IconUtils.WEBLINK_NEW = 20;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.separator, TrayDir.Properties.Resources.overlay_new));
			IconUtils.SEPARATOR_NEW = 21;
			imageList.Images.Add(Overlay(TrayDir.Properties.Resources.weblink, TrayDir.Properties.Resources.overlay_error));
			IconUtils.WEBLINK_ERROR = 22;
			initialized = true;
		}
		private static Bitmap Overlay(Bitmap source, Bitmap overlay) {
			Bitmap img = new Bitmap(source.Width, source.Height);
			using (Graphics g = Graphics.FromImage(img)) {
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.DrawImage(source, 0, 0, source.Width, source.Height);
				g.DrawImage(overlay, 0, 0, source.Width, source.Height);
			}
			return img;
		}
		internal static Bitmap lookupIcon(string key) {
			imgLoadSemaphore.WaitOne();
			Bitmap icon;
			if (imgKnownIcons.ContainsKey(key)) {
				icon = imgKnownIcons[key];
			} else {
				icon = null;
			}
			imgLoadSemaphore.Release();
			return icon;
		}
		internal static void addIcon(string key, Bitmap icon) {
			imgLoadSemaphore.WaitOne();
			imgKnownIcons[key] = icon;
			imgLoadSemaphore.Release();
		}
		public static void ChangeButtonEnableDisable(Button button, Bitmap enabledImage, Bitmap disabledImage) {
			if (button.Enabled) {
				button.BackgroundImage = enabledImage;
			} else {
				button.BackgroundImage = disabledImage;
			}
		}
	}
}
