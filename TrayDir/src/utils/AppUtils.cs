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
			if (path != "" && path != null) {
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
			if (path != "" && path != null) {
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
			return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
		}
		public static void ProcessStart(string fileName)
		{
			ProcessStart(fileName, false);
		}
		public static void ProcessStart(string fileName, bool runasadmin)
		{
			ProcessStart(fileName, "", runasadmin);
		}
		public static void ProcessStart(string fileName, string parameters, bool runasadmin)
		{
			ProcessStart("", fileName, parameters, runasadmin);
		}
		public static void ProcessStart(string startingPath, string fileName, string parameters, bool runasadmin)
		{
			Process proc = new Process();
			if ((startingPath == null || startingPath == "")) {
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
				proc.StartInfo.Arguments = parameters != null? parameters.Trim() : "";
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
				ProcessStart(new FileInfo(path).Directory.FullName, CMD, "", false);
			}
			else
			{
				ProcessStart(path, CMD, "", false);
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
		public static TrayPlugin ImportPlugin(string path)
		{
			TrayPlugin i = null;
			i = XMLUtils.LoadFromFile<TrayPlugin>(path);
			return i;
		}
		public static void RunPlugin(TrayInstancePlugin p, bool runasadmin)
		{
			bool runExternally = (p.plugin != null ? p.plugin.OpenIndirect : false);
			if ((!runExternally) && (runasadmin || (p.plugin != null ? p.plugin.AlwaysRunAsAdmin : false)))
			{
				RunPluginAsAdmin(p);
			}
			else if (runExternally) {
				RunPluginExternally(p);
			}
			else
			{
				RunPlugin(p);
			}
		}
		public static void RunPlugin(TrayInstancePlugin tip) {
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
				if (parameters != "") {
					parameters = " " + parameters;
				}
				parameters = String.Format("/c start \"TrayDir - Open Indirectly\" /d \"{0}\" \"{1}\"{2}", Path.GetDirectoryName(plugin.path), Path.GetFileName(plugin.path), parameters);
				ProcessStart(CMD, parameters,false);
			}
		}
		public static void RunPluginAsAdmin(TrayInstancePlugin tip)
		{
			TrayPlugin plugin = tip.plugin;
			if (plugin != null)
			{
				string parameters = BuildPluginCliParams(tip);
				ProcessStart(plugin.path, parameters, true);
			}
		}
		public static string BuildPluginCliParams(TrayInstancePlugin tip) {
			string parameters = "";
			TrayPlugin tp = tip.plugin;
			for (int i = 0; i < tip.parameters.Count; i++) {
				TrayInstancePluginParameter param = tip.parameters[i];
				TrayPluginParameter tpp = null;
				if (i < tp.parameters.Count) {
					tpp = tp.parameters[i];
				}
				string parameter = BuildPluginParameter(param, tpp);
				parameters += parameter;
				if ((parameter != "") && (i < (tip.parameters.Count - 1))) {
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
						return "";
					}
				} else {
					if (tpp.prefix != "") {
						if (tpp.alwaysIncludePrefix || tipp.value != "") {
							return String.Format("{0}{1}", tpp.prefix, tipp.value != "" ? " " + tipp.value : "");
						}
						else {
							return "";
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
