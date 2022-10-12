using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreePluginNode : ITreeNode {
		public ITreePluginNode(TrayInstanceNode tin) : base(tin) { }
		public override void Refresh() {
			bool hidden = false;
			node.ImageIndex = IconUtils.QUESTION;
			string pluginName = "";
			TrayInstancePlugin iPlugin = tin.GetPlugin();
			TrayPlugin plugin = null;
			if (iPlugin != null) {
				plugin = iPlugin.plugin;
				hidden = !iPlugin.visible;
			}
			if (plugin != null) {
				pluginName = plugin.name;
				if (node.TreeView != null) {
					if (plugin.isScript) {
						if (iPlugin.isValid()) {
							node.ImageIndex = IconUtils.RUNNABLE;
						} else {
							node.ImageIndex = IconUtils.RUNNABLE_ERROR;
						}
					} else {
						if (AppUtils.PathIsFile(plugin.path)) {

							if (ITreeNode.pluginIndex.ContainsKey(plugin.getSignature())) {
								node.ImageIndex = ITreeNode.pluginIndex[plugin.getSignature()];
							} else {
								Bitmap i = IconUtils.lookupIcon(plugin.getSignature());
								if (i == null) {
									i = Icon.ExtractAssociatedIcon(plugin.path).ToBitmap();
									IconUtils.addIcon(plugin.getSignature(), i);
								}
								node.TreeView.ImageList.Images.Add(i);
								node.ImageIndex = node.TreeView.ImageList.Images.Count - 1;
							}
						}
					}
				}
			}
			node.Text = string.Format("{0} ({1})", tin.instance.plugins[tin.id].alias, pluginName);
			node.SelectedImageIndex = node.ImageIndex;
			if (hidden) {
				ITreeNode.strikethroughFont = new Font(node.TreeView.Font.FontFamily, node.TreeView.Font.Size, FontStyle.Strikeout);
				node.NodeFont = strikethroughFont;
			} else {
				node.NodeFont = node.TreeView?.Font;
			}
		}
	}
}
