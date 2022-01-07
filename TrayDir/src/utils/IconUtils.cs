using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrayDir.utils
{
    class IconUtils
    {
        private static Dictionary<string, Bitmap> imgKnownIcons = new Dictionary<string, Bitmap>();
        private static Semaphore imgLoadSemaphore = new Semaphore(1, 1);
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
        public static int DELETE;
        public static int QUESTION;
        public static int INDENT_IN;
        public static int INDENT_OUT;
        public static int FOLDER_SHORTCUT;

        public static Bitmap lookupIcon(string key)
        {
            imgLoadSemaphore.WaitOne();
            Bitmap icon;
            if (imgKnownIcons.ContainsKey(key))
            {
                icon = imgKnownIcons[key];
            }
            else
            {
                icon = null;
            }
            imgLoadSemaphore.Release();
            return icon;
        }
        public static void addIcon(string key, Bitmap icon)
        {
            imgLoadSemaphore.WaitOne();
            imgKnownIcons[key] = icon;
            imgLoadSemaphore.Release();
        }
    }
}
