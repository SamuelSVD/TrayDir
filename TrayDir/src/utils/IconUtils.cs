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
