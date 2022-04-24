using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrayDir.utils
{
	class IMenuItemIconUtils
	{
		private static Thread imgLoadThread;
		private static Thread mainThread;
		private static Semaphore imgLoadSemaphore;
		public static Semaphore urlLoadSemaphore;
		private static Semaphore imgLoadedSemaphore;
		public static Queue<IMenuItem> urlLoadQueue;
		public static Queue<IMenuItem> imgLoadQueue;
		public static Queue<IMenuItem> imgLoadedQueue;
		public static void Init()
		{
			if (imgLoadSemaphore is null) {
				imgLoadSemaphore = new Semaphore(1, 1);
			}
			if (imgLoadedSemaphore is null) {
				imgLoadedSemaphore = new Semaphore(1, 1);
			}
			if (imgLoadQueue is null) {
				imgLoadQueue = new Queue<IMenuItem>();
			}
			if (imgLoadedQueue is null) {
				imgLoadedQueue = new Queue<IMenuItem>();
			}
			if (urlLoadSemaphore is null) {
				urlLoadSemaphore = new Semaphore(1, 1);
			}
			if (urlLoadQueue is null) {
				urlLoadQueue = new Queue<IMenuItem>();
			}
			if (imgLoadThread is null) {
				mainThread = Thread.CurrentThread;
				imgLoadThread = new Thread(LoadIconThread);
				imgLoadThread.Start();
			}
		}
		private static void LoadIconThread()
		{
			Stopwatch s = new Stopwatch();
			s.Start();
			while (true && mainThread.IsAlive) {
				if (tryLoadIconThread(imgLoadSemaphore, imgLoadQueue)) {
					s.Reset();
				}
				s.Stop();
				if (s.Elapsed.Seconds > 2) {
					break;
				}
				s.Start();
				Thread.Sleep(0);
			}
		}
		public static bool PerformIconLoading()
		{
			if (urlLoadQueue != null && urlLoadQueue.Count > 0) {
				tryLoadIconThread(urlLoadSemaphore, urlLoadQueue);
				return true;
			}
			return false;
		}
		public static bool tryLoadIconThread(Semaphore sem, Queue<IMenuItem> queue)
		{
			sem.WaitOne();
			bool result = false;
			if (MainForm.form != null && queue.Count > 0) {
				IMenuItem mi = queue.Dequeue();
				try {
					if (mi.menuIcon is null && mi.isFile) {
						string ext = Path.GetExtension(mi.tiPath.path);
						if (ext.Length == 0 || ext == ".ico" || ext == ".lnk" || ext == ".exe" || (queue != imgLoadQueue && ext == ".url")) {
							mi.menuIcon = Icon.ExtractAssociatedIcon(mi.tiPath.path).ToBitmap();
						} else if (queue == imgLoadQueue && ext == ".url") {
							urlLoadSemaphore.WaitOne();
							MainForm.form.imgLoadTimer.Enabled = true;
							urlLoadQueue.Enqueue(mi);
							urlLoadSemaphore.Release();
						} else {
							mi.menuIcon = IconUtils.lookupIcon(ext);
							if (mi.menuIcon == null) {
								mi.menuIcon = Icon.ExtractAssociatedIcon(mi.tiPath.path).ToBitmap();
								IconUtils.addIcon(ext, mi.menuIcon);
							}
						}
					} else if (mi.menuIcon is null && mi.isDir) {
						if (mi.tiPath != null && mi.tiPath.shortcut) {
							mi.menuIcon = new Bitmap(Properties.Resources.folder_shortcut);
						} else {
							mi.menuIcon = new Bitmap(Properties.Resources.folder);
						}
					} else if (mi.menuIcon is null && mi.tiVirtualFolder != null) {
						if (ProgramData.pd.settings.app.VFolderIcon != "Yellow Folder") {
							mi.menuIcon = new Bitmap(Properties.Resources.folder_blue);
						} else {
							mi.menuIcon = new Bitmap(Properties.Resources.folder);
						}
					} else if (mi.tiPlugin != null) {
						TrayPlugin tp = mi.tiPlugin.plugin;
						if (tp != null && AppUtils.PathIsFile(tp.path)) {
							Bitmap i = IconUtils.lookupIcon(tp.getSignature());
							if (i == null) {
								i = Icon.ExtractAssociatedIcon(tp.path).ToBitmap();
								IconUtils.addIcon(tp.getSignature(), i);
							}
							mi.menuIcon = i;
						}
					}
					if (mi.menuIcon != null) {
						imgLoadedSemaphore.WaitOne();
						imgLoadedQueue.Enqueue(mi);
						imgLoadedSemaphore.Release();
					}
				}
				catch { }
				mi.loadedIcon = true;
				result = true;
			}
			sem.Release();
			return result;
		}
		public static void EnqueueIconLoad(IMenuItem mi)
		{
			if (!mi.enqueued) {
				imgLoadSemaphore.WaitOne();
				imgLoadQueue.Enqueue(mi);
				imgLoadSemaphore.Release();
				mi.enqueued = true;
			}
			if (!imgLoadThread.IsAlive) {
				imgLoadThread = new Thread(LoadIconThread);
				imgLoadThread.Start();
			}
		}
		public static void AssignIcons()
		{
			imgLoadedSemaphore.WaitOne();
			while (imgLoadedQueue.Count > 0) {
				IMenuItem mi = imgLoadedQueue.Dequeue();
				mi.menuItem.Image = mi.menuIcon;
			}
			imgLoadedSemaphore.Release();
		}
	}
}
