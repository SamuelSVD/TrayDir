using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TrayDir.utils {
	class IMenuItemIconUtils {
		private static Thread imgLoadThread;
		private static Thread mainThread;
		private static Semaphore imgLoadSemaphore;
		internal static Semaphore urlLoadSemaphore;
		private static Semaphore imgLoadedSemaphore;
		internal static Queue<IMenuItem> urlLoadQueue;
		internal static Queue<IMenuItem> imgLoadQueue;
		internal static Queue<IMenuItem> imgLoadedQueue;
		internal static void Init() {
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
		private static void LoadIconThread() {
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
				Thread.Sleep(1);
			}
		}
		internal static bool PerformIconLoading() {
			if (urlLoadQueue != null && urlLoadQueue.Count > 0) {
				tryLoadIconThread(urlLoadSemaphore, urlLoadQueue);
				return true;
			}
			return false;
		}
		internal static bool tryLoadIconThread(Semaphore sem, Queue<IMenuItem> queue) {
			sem.WaitOne();
			bool result = false;
			if (MainForm.form != null && queue.Count > 0) {
				IMenuItem mi = queue.Dequeue();
				try {
					if (mi.GetType() == typeof(IPathMenuItem)) {
						LoadIcon(queue, (IPathMenuItem)mi);
					} else if (mi.GetType() == typeof(IVirtualFolderMenuItem)) {
						LoadIcon((IVirtualFolderMenuItem)mi);
					} else if (mi.GetType() == typeof(IPluginMenuItem)) {
						LoadIcon((IPluginMenuItem)mi);
					} else if (mi.GetType() == typeof(IWebLinkMenuItem)) {
						LoadIcon((IWebLinkMenuItem)mi);
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
		internal static void LoadIcon(IPluginMenuItem mi) {
			if (mi.isPlugin) {
				TrayPlugin tp = ((TrayInstancePlugin)mi.tiItem).plugin;
				if (tp != null) {
					if (tp.isScript) {
						if (((TrayInstancePlugin)mi.tiItem).isValid()) {
							mi.menuIcon = (Bitmap)IconUtils.RunnableImage;
						} else {
							mi.menuIcon = (Bitmap)IconUtils.RunnableErrorImage;
						}
					} else {
						if (AppUtils.PathIsFile(tp.path)) {
							Bitmap i = IconUtils.lookupIcon(tp.getSignature());
							if (i == null) {
								i = Icon.ExtractAssociatedIcon(tp.path).ToBitmap();
								IconUtils.addIcon(tp.getSignature(), i);
							}
							mi.menuIcon = i;
						}
					}
				} else {
					mi.menuIcon = (Bitmap)IconUtils.QuestionImage;
				}
			}
		}
		internal static void LoadIcon(IVirtualFolderMenuItem mi) {
			if (mi.menuIcon is null && mi.isVFolder) {
				if (ProgramData.pd.settings.app.VFolderIcon != "Yellow Folder") {
					mi.menuIcon = (Bitmap)IconUtils.FolderBlueImage;
				} else {
					mi.menuIcon = (Bitmap)IconUtils.FolderImage;
				}
			}
		}
		internal static void LoadIcon(IWebLinkMenuItem mi) {
			if (mi.menuIcon is null && mi.isWebLink) {
				if (((TrayInstanceWebLink)mi.tiItem).isValidURL) {
					mi.menuIcon = (Bitmap)IconUtils.WebLinkImage;
				} else {
					mi.menuIcon = (Bitmap)IconUtils.WebLinkErrorImage;
				}
			}
		}
		internal static void LoadIcon(Queue<IMenuItem> queue, IPathMenuItem mi) {
				if (mi.menuIcon is null && mi.isErr) {
				mi.menuIcon = (Bitmap)IconUtils.QuestionImage;
			} else if (mi.menuIcon is null && mi.isFile) {
				string ext = Path.GetExtension(((TrayInstancePath)mi.tiItem).path);
				if (ext.Length == 0 || ext == ".ico" || ext == ".lnk" || ext == ".exe" || (queue != imgLoadQueue && ext == ".url")) {
					mi.menuIcon = Icon.ExtractAssociatedIcon(((TrayInstancePath)mi.tiItem).path).ToBitmap();
				} else if (queue == imgLoadQueue && ext == ".url") {
					urlLoadSemaphore.WaitOne();
					MainForm.form.imgLoadTimer.Enabled = true;
					urlLoadQueue.Enqueue(mi);
					urlLoadSemaphore.Release();
				} else {
					mi.menuIcon = IconUtils.lookupIcon(ext);
					if (mi.menuIcon == null) {
						mi.menuIcon = Icon.ExtractAssociatedIcon(((TrayInstancePath)mi.tiItem).path).ToBitmap();
						IconUtils.addIcon(ext, mi.menuIcon);
					}
				}
			} else if (mi.menuIcon is null && mi.isDir) {
				if (mi.tiItem != null && mi.tiItem.GetType() == typeof(TrayInstancePath) && ((TrayInstancePath)mi.tiItem).shortcut) {
					mi.menuIcon = (Bitmap)IconUtils.FolderShortcutImage;
				} else {
					mi.menuIcon = (Bitmap)IconUtils.FolderImage;
				}
			}
		}
		internal static void EnqueueIconLoad(IMenuItem mi) {
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
		internal static void AssignIcons() {
			imgLoadedSemaphore.WaitOne();
			while (imgLoadedQueue.Count > 0) {
				IMenuItem mi = imgLoadedQueue.Dequeue();
				mi.menuItem.Image = mi.menuIcon;
			}
			imgLoadedSemaphore.Release();
		}
	}
}
