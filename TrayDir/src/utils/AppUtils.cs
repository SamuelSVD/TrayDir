using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TrayDir
{
	class AppUtils
	{
		private static string RUNAS = "runas";
		private static string CMD = "cmd";
		private static string EXPLORER = "explorer.exe";
		public static bool PathIsDirectory(string path)
		{
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
		public static bool PathIsFile(string path)
		{
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
		public static string SplitCamelCase(string input)
		{
			return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
		}
		public static void ProcessStart(string fileName)
		{
			ProcessStart(fileName, false);
		}
		public static void ProcessStart(string fileName, bool runasadmin)
		{
			ProcessStart(fileName, string.Empty, runasadmin);
		}
		public static void ProcessStart(string fileName, string parameters, bool runasadmin)
		{
			ProcessStart(string.Empty, fileName, parameters, runasadmin);
		}
		public static void ProcessStart(string startingPath, string fileName, string parameters, bool runasadmin)
		{
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
				proc.StartInfo.Arguments = parameters != null? parameters.Trim() : string.Empty;
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
				MessageBox.Show(String.Format(Properties.Strings_en.ErrorStartingProcess, fileName, e.Message), Properties.Strings_en.Form_Error);
			}
		}
		public static void OpenPath(string path, bool runAsAdmin)
		{
			if (runAsAdmin)
			{
				ProcessStart(path,true);
			}
			else
			{
				ProcessStart(path);
			}
		}
		public static void OpenCmdPath(string path)
		{
			if (PathIsFile(path))
			{
				ProcessStart(new FileInfo(path).Directory.FullName, CMD, string.Empty, false);
			}
			else
			{
				ProcessStart(path, CMD, string.Empty, false);
			}
		}
		public static void OpenAdminCmdPath(string path)
		{
			if (PathIsFile(path))
			{
				ProcessStart(CMD, String.Format("/k cd \"{0}\"",new FileInfo(path).Directory.FullName), true);
			}
			else
			{
				ProcessStart(CMD, String.Format("/k cd \"{0}\"", path), true);
			}
		}
		public static void ExplorePath(string path)
		{
			if (PathIsFile(path))
			{
				ProcessStart(EXPLORER, new FileInfo(path).Directory.FullName, false);
			}
			else
			{
				ProcessStart(EXPLORER, path, false);
			}
		}
		public static bool StrToBool(string value)
		{
			return value == "1" ? true : false;
		}
		public static void ExportInstance(TrayInstance instance)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			TrayInstance copy_instance = instance.Copy();
			copy_instance.buildAndReferenceInternalPlugin();
			sfd.Filter = "Tray Instance Export | *.tde";
			sfd.FileName = Regex.Replace(copy_instance.instanceName, @"[^0-9a-zA-Z()_ ]+", "_");
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				XMLUtils.SaveToFile(copy_instance, sfd.FileName);
				MessageBox.Show(string.Format(Properties.Strings_en.ExportedTo, sfd.FileName), Properties.Strings_en.Form_ExportDone);
			}
		}
		internal static void Run(IMenuItem menuItem) {
			if (menuItem.isDir) {
				OpenPath(new DirectoryInfo(menuItem.tiPath.path).FullName, false);
			} else if (menuItem.isFile) {
				OpenPath(Path.GetFullPath(menuItem.tiPath.path), false);
			} else if (menuItem.isPlugin) {
				RunPlugin(menuItem.tiPlugin, false);
			}
		}
		internal static void OpenCmd(IMenuItem menuItem) {
			if (menuItem.isDir) {
				OpenCmdPath(new DirectoryInfo(menuItem.tiPath.path).FullName);
			} else if (menuItem.isFile) {
				OpenCmdPath(Path.GetFullPath(menuItem.tiPath.path));
			}
		}
		internal static void RunAs(TrayInstanceNode node) {
			switch(node.type) {
				case TrayInstanceNode.NodeType.Path:
					RunAs(node.GetPath());
					break;
				case TrayInstanceNode.NodeType.Plugin:
					RunAs(node.GetPlugin());
					break;
			}
		}
		internal static void Run(TrayInstanceNode node) {
			switch(node.type) {
				case TrayInstanceNode.NodeType.Path:
					Run(node.GetPath());
					break;
				case TrayInstanceNode.NodeType.Plugin:
					Run(node.GetPlugin());
					break;
			}
		}
		internal static void OpenAdminCmd(IMenuItem menuItem) {
			if (menuItem.isDir) {
				OpenAdminCmdPath(new DirectoryInfo(menuItem.tiPath.path).FullName);
			} else if (menuItem.isFile) {
				OpenAdminCmdPath(Path.GetFullPath(menuItem.tiPath.path));
			}
		}
		internal static void RunAs(IMenuItem menuItem) {
			if (menuItem.isDir) {
				OpenPath(new DirectoryInfo(menuItem.tiPath.path).FullName, true);
			} else if (menuItem.isFile) {
				OpenPath(Path.GetFullPath(menuItem.tiPath.path), true);
			} else if (menuItem.isPlugin) {
				RunPlugin(menuItem.tiPlugin, true);
			}
		}

		internal static void Explore(IMenuItem menuItem) {
			if (menuItem.isDir) {
				ExplorePath(new DirectoryInfo(menuItem.tiPath.path).FullName);
			} else if (menuItem.isFile) {
				ExplorePath(Path.GetFullPath(menuItem.tiPath.path));
			} else if (menuItem.isPlugin) {
				if (menuItem.tiPlugin != null) {
					if (menuItem.tiPlugin.plugin != null) {
						ExplorePath(menuItem.tiPlugin.plugin.path);
					}
				}
			}
		}

		public static TrayInstance ImportInstance(string path)
		{
			TrayInstance i = null;
			i = XMLUtils.LoadFromFile<TrayInstance>(path);
			i.FixPaths();
			i.FixNodes();
			i.nodes.SetInstance(i);
			i.nodes.FixChildren();
			return i;
		}

		public static void ExportPlugin(TrayPlugin plugin)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Tray Plugin Export | *.tpe";
			sfd.FileName = Regex.Replace(plugin.name, @"[^0-9a-zA-Z()_ ]+", "_");
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				XMLUtils.SaveToFile(plugin, sfd.FileName);
				MessageBox.Show(string.Format(Properties.Strings_en.ExportedTo, sfd.FileName), Properties.Strings_en.Form_ExportDone);
			}
		}

		internal static void Open(IMenuItem menuItem) {
			if (menuItem.isDir && (menuItem.instance.settings.ExploreFoldersInTrayMenu || menuItem.tiPath.shortcut)) {
				OpenPath(new DirectoryInfo(menuItem.tiPath.path).FullName, menuItem.instance.settings.RunAsAdmin);
			} else if (menuItem.isFile) {
				OpenPath(Path.GetFullPath(menuItem.tiPath.path), menuItem.instance.settings.RunAsAdmin);
			} else if (menuItem.tiPlugin != null) {
				RunPlugin(menuItem.tiPlugin, menuItem.instance.settings.RunAsAdmin);
			}
		}
		public static TrayPlugin ImportPlugin(string path)
		{
			TrayPlugin i = null;
			i = XMLUtils.LoadFromFile<TrayPlugin>(path);
			return i;
		}
		public static void RunPlugin(TrayInstancePlugin p, bool runasadmin)
		{
			if (!p.isValid()) {
				MessageBox.Show(Properties.Strings_en.Form_PluginInvalid, Properties.Strings_en.Form_Error);
				return;
			}
			bool runExternally = (p.plugin != null ? p.plugin.OpenIndirect : false);
			if ((!runExternally) && (runasadmin || (p.plugin != null ? p.plugin.AlwaysRunAsAdmin : false)))
			{
				RunAs(p);
			}
			else if (runExternally) {
				RunPluginExternally(p);
			}
			else
			{
				Run(p);
			}
		}
		public static void Run(TrayInstancePlugin tip) {
			TrayPlugin plugin = tip.plugin;
			if (plugin != null && plugin.path != null && PathIsFile(plugin.path)) {
				string parameters = BuildPluginCliParams(tip);
				ProcessStart(plugin.path, parameters,false);
			}
		}
		public static void RunPluginExternally(TrayInstancePlugin tip) {
			TrayPlugin plugin = tip.plugin;
			if (plugin != null && plugin.path != null && PathIsFile(plugin.path)) {
				string parameters = BuildPluginCliParams(tip);
				if (parameters != string.Empty) {
					parameters = " " + parameters;
				}
				parameters = String.Format("/c start \"TrayDir - Open Indirectly\" /d \"{0}\" \"{1}\"{2}", Path.GetDirectoryName(plugin.path), Path.GetFileName(plugin.path), parameters);
				ProcessStart(CMD, parameters,false);
			}
		}
		public static void Run(TrayInstancePath tip) {
			if (tip.isDir) {
				OpenPath(new DirectoryInfo(tip.path).FullName, false);
			} else if (tip.isFile) {
				OpenPath(Path.GetFullPath(tip.path), false);
			}
		}
		public static void RunAs(TrayInstancePlugin tip)
		{
			TrayPlugin plugin = tip.plugin;
			if (plugin != null)
			{
				string parameters = BuildPluginCliParams(tip);
				ProcessStart(plugin.path, parameters, true);
			}
		}
		public static void RunAs(TrayInstancePath tip) {
			if (tip.isDir) {
				OpenPath(new DirectoryInfo(tip.path).FullName, false);
			} else if (tip.isFile) {
				OpenPath(Path.GetFullPath(tip.path), true);
			}
		}
		public static string BuildPluginCliParams(TrayInstancePlugin tip) {
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
		public static string BuildPluginParameter(TrayInstancePluginParameter tipp, TrayPluginParameter tpp) {
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
						}
						else {
							return string.Empty;
						}
					}
					else {
						return tipp.value;
					}
				}
			}
		}
	}
}
