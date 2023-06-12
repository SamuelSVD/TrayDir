using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayDir.utils;

namespace TrayDir.src.views {
	internal class ITreePluginNode : ITreeNode {
		internal ITreePluginNode(IItem item) : base(item) { }
		internal override void Refresh() {
			node.ImageIndex = IconUtils.QUESTION;
			string pluginName = "";
			TrayInstancePlugin iPlugin = Item.TrayInstanceNode.GetPlugin();
			TrayPlugin plugin = null;
			if (iPlugin != null) {
				plugin = iPlugin.plugin;
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
			node.Text = string.Format("{0} ({1})", Item.TrayInstanceNode.instance.plugins[Item.TrayInstanceNode.id].alias, pluginName);
			node.SelectedImageIndex = node.ImageIndex;
		}
		internal override bool Hidden {
			get {
				TrayInstanceItem model = Item.TrayInstanceNode.GetPlugin();
				if (model != null) {
					return !model.visible;
				}
				return false;
			}
		}
	}
}
