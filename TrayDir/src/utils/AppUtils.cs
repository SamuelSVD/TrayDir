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
        public static bool PathIsDirectory(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                //detect whether its a directory or file
                return ((attr & FileAttributes.Directory) == FileAttributes.Directory);
            }
            catch
            {
                return false;
            }

        }
        public static bool PathIsFile(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                //detect whether its a directory or file
                return !((attr & FileAttributes.Directory) == FileAttributes.Directory);
            }
            catch
            {
                return false;
            }
        }
        public static string SplitCamelCase(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
        public static void OpenPath(string path, bool runAsAdmin)
        {
            try
            {
                if (runAsAdmin)
                {
                    ExecuteAsAdmin(path);
                }
                else
                {
                    Process.Start(path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Opening: " + path + '\n' + e.Message);
            }
        }
        public static void OpenCmdPath(string path)
        {
            try
            {
                if (PathIsFile(path))
                {
                    Process.Start("cmd", "/k cd \"" + new FileInfo(path).Directory.FullName + "\"");
                }
                else
                {
                    Process.Start("cmd", "/k cd \"" + path + "\"");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Exploring: " + path + '\n' + e.Message);
            }
        }
        public static void OpenAdminCmdPath(string path)
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.Verb = "runas";
            try
            {
                if (PathIsFile(path))
                {
                    proc.StartInfo.Arguments = "/k cd \"" + new FileInfo(path).Directory.FullName + "\"";
                }
                else
                {
                    proc.StartInfo.Arguments = "/k cd \"" + path + "\"";
                }
                proc.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Opening As Admin: " + '\n' + path + '\n' + e.Message, "Error");
            }
        }
        public static void ExplorePath(string path)
        {
            try
            {
                if (PathIsFile(path))
                {
                    Process.Start("explorer.exe", new FileInfo(path).Directory.FullName);
                }
                else
                {
                    Process.Start("explorer.exe", path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Exploring: " + path + '\n' + e.Message);
            }
        }
        private static void ExecuteAsAdmin(string path)
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = path;
            proc.StartInfo.Verb = "runas";
            try
            {
                if (PathIsFile(path))
                {
                    proc.Start();
                }
                else
                {
                    Process.Start("explorer.exe", path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Executing As Admin: " + '\n' + path + '\n' + e.Message, "Error");
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
                MessageBox.Show("Exported to:" + sfd.FileName, "Export Done");
            }
        }
        public static TrayInstance ImportInstance(string path)
        {
            TrayInstance i = null;
            i = XMLUtils.LoadFromFile<TrayInstance>(path);
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
                MessageBox.Show("Exported to:" + sfd.FileName, "Export Done");
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
            if (runasadmin || (p.plugin != null ? p.plugin.AlwaysRunAsAdmin : false))
            {
                RunPluginAsAdmin(p);
            }
            else
            {
                RunPlugin(p);
            }
        }
        public static void RunPlugin(TrayInstancePlugin tip) {
            TrayPlugin plugin = tip.plugin;
            if (plugin != null && plugin.path != null && PathIsFile(plugin.path))
            {
                string parameters = BuildPluginCliParams(tip);
                Process.Start(plugin.path, parameters);
            }
        }
        public static void RunPluginAsAdmin(TrayInstancePlugin tip)
        {
            TrayPlugin plugin = tip.plugin;
            if (plugin != null)
            {
                string parameters = BuildPluginCliParams(tip);
                Process proc = new Process();
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.FileName = plugin.path;
                proc.StartInfo.Verb = "runas";
                proc.StartInfo.Arguments = parameters;
                try
                {
                    if (PathIsFile(plugin.path))
                    {
                        proc.Start();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Executing As Admin: " + '\n' + plugin.path + '\n' + e.Message, "Error");
                }
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
                parameters += BuildPluginParameter(param, tpp) + " ";
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
                    return String.Format("{0} {1}", tpp.prefix, tipp.value);
                }
            }
        }
    }
}
