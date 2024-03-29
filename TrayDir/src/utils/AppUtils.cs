﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TrayDir {
	internal class AppUtils {
		internal static string RUNAS = "runas";
		internal static string CMD = "cmd";
		internal static string EXPLORER = "explorer.exe";
		internal static bool PathIsDirectory(string path) {
			if (path != string.Empty && path != null) {
				try {
					FileAttributes attr = File.GetAttributes(path);
					//detect whether its a directory or file
					return ((attr & FileAttributes.Directory) == FileAttributes.Directory);
				}
				catch {
					return false;
				}
			}
			return false;
		}
		internal static bool PathIsFile(string path) {
			if (path != string.Empty && path != null) {
				try {
					FileAttributes attr = File.GetAttributes(path);
					//detect whether its a directory or file
					return !((attr & FileAttributes.Directory) == FileAttributes.Directory);
				}
				catch {
					return false;
				}
			}
			return false;
		}
		internal static string SplitCamelCase(string input) {
			return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
		}
		internal static void ProcessStart(string fileName) {
			ProcessStart(fileName, false);
		}
		internal static void ProcessStart(string fileName, bool runasadmin) {
			ProcessStart(fileName, string.Empty, runasadmin);
		}
		internal static void ProcessStart(string fileName, string parameters, bool runasadmin) {
			ProcessStart(string.Empty, fileName, parameters, runasadmin);
		}
		internal static void ProcessStart(string startingPath, string fileName, string parameters, bool runasadmin) {
			Process proc = new Process();
			if ((startingPath == null || startingPath == string.Empty)) {
				if (PathIsFile(fileName)) {
					proc.StartInfo.WorkingDirectory = new FileInfo(fileName).Directory.FullName;
				}
			} else {
				proc.StartInfo.WorkingDirectory = startingPath;
			}
			if (PathIsDirectory(fileName)) {
				proc.StartInfo.FileName = EXPLORER;
				proc.StartInfo.Arguments = fileName;
			} else {
				proc.StartInfo.FileName = fileName;
				proc.StartInfo.Arguments = parameters != null ? parameters.Trim() : string.Empty;
				if (runasadmin) {
					proc.StartInfo.UseShellExecute = true;
					proc.StartInfo.FileName = fileName;
					proc.StartInfo.Verb = RUNAS;
				}
			}
			try {
				proc.Start();
			}
			catch (Exception e) {
				MessageBox.Show(String.Format(Properties.Strings.ErrorStartingProcess, fileName, e.Message), Properties.Strings.Form_Error);
			}
		}
		internal static void OpenPath(string path, bool runAsAdmin) {
			if (runAsAdmin) {
				ProcessStart(path, true);
			} else {
				ProcessStart(path);
			}
		}
		internal static void OpenCmdPath(string path) {
			if (PathIsFile(path)) {
				ProcessStart(new FileInfo(path).Directory.FullName, CMD, string.Empty, false);
			} else {
				ProcessStart(path, CMD, string.Empty, false);
			}
		}
		internal static void OpenAdminCmdPath(string path) {
			if (PathIsFile(path)) {
				ProcessStart(CMD, String.Format("/k cd \"{0}\"", new FileInfo(path).Directory.FullName), true);
			} else {
				ProcessStart(CMD, String.Format("/k cd \"{0}\"", path), true);
			}
		}
		internal static void ExplorePath(string path) {
			if (PathIsFile(path)) {
				ProcessStart(EXPLORER, new FileInfo(path).Directory.FullName, false);
			} else {
				ProcessStart(EXPLORER, path, false);
			}
		}
		internal static bool StrToBool(string value) {
			return value == "1" ? true : false;
		}
		internal static void ExportInstance(TrayInstance instance) {
			SaveFileDialog sfd = new SaveFileDialog();
			TrayInstance copy_instance = instance.Copy();
			copy_instance.buildAndReferenceInternalPlugin();
			sfd.Filter = "Tray Instance Export | *.tde";
			sfd.FileName = Regex.Replace(copy_instance.instanceName, @"[^0-9a-zA-Z()_ ]+", "_");
			if (sfd.ShowDialog() == DialogResult.OK) {
				XMLUtils.SaveToFile(copy_instance, sfd.FileName);
				MessageBox.Show(string.Format(Properties.Strings.ExportedTo, sfd.FileName), Properties.Strings.Form_ExportDone);
			}
		}
		internal static void Run(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir) {
					OpenPath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName, false);
				} else if (((IPathMenuItem)menuItem).isFile) {
					OpenPath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path), false);
				}
			} else if (menuItem.GetType() == typeof(IPluginMenuItem)) {
				if (((IPluginMenuItem)menuItem).isPlugin) {
					RunPlugin(((TrayInstancePlugin)menuItem.Item.TrayInstanceItem), false);
				}
			} else if (menuItem.GetType() == typeof(IWebLinkMenuItem)) {
				if (((IWebLinkMenuItem)menuItem).isWebLink) {
					Run((TrayInstanceWebLink)menuItem.Item.TrayInstanceItem);
				}
			} else if (menuItem.GetType() == typeof(IVirtualFolderMenuItem)) {
				foreach (IMenuItem imi in menuItem.nodeChildren) {
					Run(imi);
				}
			}
		}
		internal static void OpenCmd(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir) {
					OpenCmdPath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName);
				} else if (((IPathMenuItem)menuItem).isFile) {
					OpenCmdPath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path));
				}
			}
		}
		internal static void RunAs(TrayInstanceNode node) {
			switch (node.type) {
				case TrayInstanceNode.NodeType.Path:
					RunAs(node.GetPath());
					break;
				case TrayInstanceNode.NodeType.Plugin:
					RunAs(node.GetPlugin());
					break;
				case TrayInstanceNode.NodeType.WebLink:
					RunAs(node.GetWebLink());
					break;
			}
		}
		internal static void Run(TrayInstanceNode node) {
			switch (node.type) {
				case TrayInstanceNode.NodeType.Path:
					Run(node.GetPath());
					break;
				case TrayInstanceNode.NodeType.Plugin:
					Run(node.GetPlugin());
					break;
				case TrayInstanceNode.NodeType.VirtualFolder:
					foreach(TrayInstanceNode childNode in node.children) {
						Run(childNode);
					}
					break;
				case TrayInstanceNode.NodeType.WebLink:
					Run(node.GetWebLink());
					break;
			}
		}
		internal static void OpenAdminCmd(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir) {
					OpenAdminCmdPath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName);
				} else if (((IPathMenuItem)menuItem).isFile) {
					OpenAdminCmdPath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path));
				}
			}
		}
		internal static void RunAs(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir) {
					OpenPath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName, true);
				} else if (((IPathMenuItem)menuItem).isFile) {
					OpenPath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path), true);
				}
			} else if (menuItem.GetType() == typeof(IPluginMenuItem)) {
				if (((IPluginMenuItem)menuItem).isPlugin) {
					RunPlugin(((TrayInstancePlugin)menuItem.Item.TrayInstanceItem), true);
				}
			}
		}

		internal static void Explore(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir) {
					ExplorePath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName);
				} else if (((IPathMenuItem)menuItem).isFile) {
					ExplorePath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path));
				}
			} else if (menuItem.GetType() == typeof(IPluginMenuItem)) {
				if (((IPluginMenuItem)menuItem).isPlugin) {
					if (((TrayInstancePlugin)menuItem.Item.TrayInstanceItem).plugin != null) {
						ExplorePath(((TrayInstancePlugin)menuItem.Item.TrayInstanceItem).plugin.path);
					}
				}
			}
		}

		internal static TrayInstance ImportInstance(string path) {
			TrayInstance i = null;
			i = XMLUtils.LoadFromFile<TrayInstance>(path);
			i.FixPaths();
			i.FixNodes();
			i.nodes.SetInstance(i);
			i.nodes.FixChildren();
			return i;
		}

		internal static void ExportPlugin(TrayPlugin plugin) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Tray Plugin Export | *.tpe";
			sfd.FileName = Regex.Replace(plugin.name, @"[^0-9a-zA-Z()_ ]+", "_");
			if (sfd.ShowDialog() == DialogResult.OK) {
				XMLUtils.SaveToFile(plugin, sfd.FileName);
				MessageBox.Show(string.Format(Properties.Strings.ExportedTo, sfd.FileName), Properties.Strings.Form_ExportDone);
			}
		}

		internal static void Open(IMenuItem menuItem) {
			if (menuItem.GetType() == typeof(IPathMenuItem)) {
				if (((IPathMenuItem)menuItem).isDir && (menuItem.instance.settings.ExploreFoldersInTrayMenu || ((TrayInstancePath)menuItem.Item.TrayInstanceItem).shortcut)) {
					OpenPath(new DirectoryInfo(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path).FullName, menuItem.instance.settings.RunAsAdmin);
				} else if (((IPathMenuItem)menuItem).isFile) {
					OpenPath(Path.GetFullPath(((TrayInstancePath)menuItem.Item.TrayInstanceItem).path), menuItem.instance.settings.RunAsAdmin);
				}
			} else if (menuItem.GetType() == typeof(IPluginMenuItem)) {
				if (((IPluginMenuItem)menuItem).isPlugin) {
					RunPlugin(((TrayInstancePlugin)menuItem.Item.TrayInstanceItem), menuItem.instance.settings.RunAsAdmin);
				}
			} else if (menuItem.GetType() == typeof(IWebLinkMenuItem)) {
				if (((IWebLinkMenuItem)menuItem).isWebLink) {
					Run((TrayInstanceWebLink)((IWebLinkMenuItem)menuItem).Item.TrayInstanceItem);
				}
			}
		}
		internal static TrayPlugin ImportPlugin(string path) {
			TrayPlugin i = null;
			i = XMLUtils.LoadFromFile<TrayPlugin>(path);
			return i;
		}
		internal static void RunPlugin(TrayInstancePlugin p, bool runasadmin) {
			if (!p.isValid()) {
				MessageBox.Show(Properties.Strings.Form_PluginInvalid, Properties.Strings.Form_Error);
				return;
			}
			bool runExternally = (p.plugin != null ? p.plugin.OpenIndirect && !p.plugin.isScript : false);
			if ((!runExternally) && (runasadmin || (p.plugin != null ? p.plugin.AlwaysRunAsAdmin : false))) {
				RunAs(p);
			} else if (runExternally) {
				RunPluginExternally(p);
			} else {
				Run(p);
			}
		}
		internal static void Run(TrayInstancePlugin tip) {
			TrayPlugin plugin = tip.plugin;
			if (plugin != null && tip.isValid()) {
				if (plugin.isScript) {
					string command = "";
					string[] commands = String.Format(plugin.scriptText, tip.ParametersAsStringArray).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
					for (int i = 0; i < commands.Length; i++) {
						string cmd = commands[i].Trim();
						if (i != 0 && cmd != "") command += "&";
						command += cmd;
					}
					if (command != "") {
						ProcessStart(CMD, "/C " + command, false);
					}
				} else {
					if (plugin.path != null && PathIsFile(plugin.path)) {
						string parameters = BuildPluginCliParams(tip);
						ProcessStart(plugin.path, parameters, false);
					}
				}
			}
		}
		internal static void RunPluginExternally(TrayInstancePlugin tip) {
			TrayPlugin plugin = tip.plugin;
			if (plugin != null && tip.isValid()) {
				if (plugin.isScript) {
					string command = "";
					string[] commands = String.Format(plugin.scriptText, tip.ParametersAsStringArray).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
					for (int i = 0; i < commands.Length; i++) {
						string cmd = commands[i].Trim();
						if (i != 0 && cmd != "") command += "&";
						command += cmd;
					}
					if (command != "") {
						ProcessStart(CMD, "/C " + command, false);
					}
				} else {
					if (plugin.path != null && PathIsFile(plugin.path)) {
						string parameters = BuildPluginCliParams(tip);
						if (parameters != string.Empty) {
							parameters = " " + parameters;
						}
						parameters = String.Format("/c start \"TrayDir - Open Indirectly\" /d \"{0}\" \"{1}\"{2}", Path.GetDirectoryName(plugin.path), Path.GetFileName(plugin.path), parameters);
						ProcessStart(CMD, parameters, false);
					}
				}
			}
		}
		internal static void Run(TrayInstancePath tip) {
			if (tip.isDir) {
				OpenPath(new DirectoryInfo(tip.path).FullName, false);
			} else if (tip.isFile) {
				OpenPath(Path.GetFullPath(tip.path), false);
			}
		}
		internal static void Run(TrayInstanceWebLink tiwl) {
			Uri uriResult;
			if (Uri.TryCreate(tiwl.URL, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)) {
				OpenPath(tiwl.URL, false);
			}
		}
		internal static void RunAs(TrayInstancePlugin tip) {
			TrayPlugin plugin = tip.plugin;
			if (plugin != null && tip.isValid()) {
				if (plugin.isScript) {
					string command = "";
					string[] commands = String.Format(plugin.scriptText, tip.ParametersAsStringArray).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
					for (int i = 0; i < commands.Length; i++) {
						string cmd = commands[i].Trim();
						if (i != 0 && cmd != "") command += "&";
						command += cmd;
					}
					if (command != "") {
						ProcessStart(CMD, "/C " + command, true);
					}
				} else {
					string parameters = BuildPluginCliParams(tip);
					ProcessStart(plugin.path, parameters, true);
				}
			}
		}
		internal static void RunAs(TrayInstancePath tip) {
			if (tip.isDir) {
				OpenPath(new DirectoryInfo(tip.path).FullName, false);
			} else if (tip.isFile) {
				OpenPath(Path.GetFullPath(tip.path), true);
			}
		}
		internal static void RunAs(TrayInstanceWebLink tiwl) {
			Run(tiwl);
		}
		internal static string BuildPluginCliParams(TrayInstancePlugin tip) {
			string parameters = string.Empty;
			TrayPlugin tp = tip.plugin;
			for (int i = 0; i < tip.parameters.Count; i++) {
				TrayInstancePluginParameter param = tip.parameters[i];
				TrayPluginParameter tpp = null;
				if (i < tp.parameters.Count) {
					tpp = tp.parameters[i];
				}
				string parameter = BuildPluginParameter(param, tpp);
				parameters += parameter;
				if ((parameter != string.Empty) && (i < (tip.parameters.Count - 1))) {
					parameters += " ";
				}
			}
			return parameters;
		}
		internal static string BuildPluginParameter(TrayInstancePluginParameter tipp, TrayPluginParameter tpp) {
			if (tpp == null) {
				return tipp.value;
			} else {
				if (tpp.isBoolean) {
					if (tipp.value.ToLower() == "true") {
						return tpp.prefix;
					} else {
						return string.Empty;
					}
				} else {
					if (tpp.prefix != string.Empty) {
						if (tpp.alwaysIncludePrefix || tipp.value != string.Empty) {
							return String.Format("{0}{1}", tpp.prefix, tipp.value != string.Empty ? " " + tipp.value : string.Empty);
						} else {
							return string.Empty;
						}
					} else {
						return tipp.value;
					}
				}
			}
		}
	}
}
