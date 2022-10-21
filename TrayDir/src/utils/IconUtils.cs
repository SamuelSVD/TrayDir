using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace TrayDir.utils {
	class IconUtils {
		private static Dictionary<string, Bitmap> imgKnownIcons = new Dictionary<string, Bitmap>();
		private static Semaphore imgLoadSemaphore = new Semaphore(1, 1);
		public static ImageList imageList;
		public static int DOCUMENT;
		public static int FOLDER;
		public static int FOLDER_BLUE;
		public static int RUNNABLE;
		public static int FOLDER_BLUE_NEW;
		public static int UP;
		public static int DOWN;
		public static int RUNNABLE_NEW;
		public static int DOCUMENT_NEW;
		public static int FOLDER_NEW;
		public static int EDIT;
		public static int DELETE;
		public static int QUESTION;
		public static int INDENT_IN;
		public static int INDENT_OUT;
		public static int FOLDER_SHORTCUT;
		public static int SEPARATOR;
		public static int SEPARATOR_NEW;
		public static int RUNNABLE_ERROR;
		public static int EMPTY;
		public static int WEBLINK;
		public static int WEBLINK_NEW;
		public static int WEBLINK_ERROR;
		public static bool initialized = false;
		public static Image DocumentImage { get { return imageList.Images[DOCUMENT]; } }
		public static Image FolderImage { get { return imageList.Images[FOLDER]; } }
		public static Image FolderBlueImage { get { return imageList.Images[FOLDER_BLUE]; } }
		public static Image RunnableImage { get { return imageList.Images[RUNNABLE]; } }
		public static Image FolderBlueNewImage { get { return imageList.Images[FOLDER_BLUE_NEW]; } }
		public static Image UpImage { get { return imageList.Images[UP]; } }
		public static Image DownImage { get { return imageList.Images[DOWN]; } }
		public static Image RunnableNewImage { get { return imageList.Images[RUNNABLE_NEW]; } }
		public static Image DocumentNewImage { get { return imageList.Images[DOCUMENT_NEW]; } }
		public static Image FolderNewImage { get { return imageList.Images[FOLDER_NEW]; } }
		public static Image DeleteImage { get { return imageList.Images[DELETE]; } }
		public static Image QuestionImage { get { return imageList.Images[QUESTION]; } }
		public static Image IndentInImage { get { return imageList.Images[INDENT_IN]; } }
		public static Image IndentOutImage { get { return imageList.Images[INDENT_OUT]; } }
		public static Image FolderShortcutImage { get { return imageList.Images[FOLDER_SHORTCUT]; } }
		public static Image EditImage { get { return imageList.Images[EDIT]; } }
		public static Image SeparatorImage { get { return imageList.Images[SEPARATOR]; } }
		public static Image SeparatorNewImage { get { return imageList.Images[SEPARATOR_NEW]; } }
		public static Image RunnableErrorImage { get { return imageList.Images[RUNNABLE_ERROR]; } }
		public static Image Empty { get { return imageList.Images[EMPTY]; } }
		public static Image WebLinkImage { get { return imageList.Images[WEBLINK]; } }
		public static Image WebLinkNewImage { get { return imageList.Images[WEBLINK_NEW]; } }
		public static Image WebLinkErrorImage { get { return imageList.Images[WEBLINK_ERROR]; } }
		public static void Init(int sizeWH) {
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
		public static Bitmap lookupIcon(string key) {
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
		public static void addIcon(string key, Bitmap icon) {
			imgLoadSemaphore.WaitOne();
			imgKnownIcons[key] = icon;
			imgLoadSemaphore.Release();
		}
	}
}
