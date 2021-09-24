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
        private static Dictionary<string, Icon> imgKnownIcons = new Dictionary<string, Icon>();
        private static Semaphore imgLoadSemaphore = new Semaphore(1, 1);

        public static Icon lookupIcon(string key)
        {
            imgLoadSemaphore.WaitOne();
            Icon icon;
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
        public static void addIcon(string key, Icon icon)
        {
            imgLoadSemaphore.WaitOne();
            imgKnownIcons[key] = icon;
            imgLoadSemaphore.Release();
        }
    }
}
