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
            sfd.Filter = "Tray Instance Export | *.tde";
            sfd.FileName = Regex.Replace(instance.instanceName, @"[^0-9a-zA-Z()_ ]+", "_");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XMLUtils.SaveToFile(instance, sfd.FileName);
                MessageBox.Show("Exported to:" + sfd.FileName, "Export Done");
            }
        }
        public static TrayInstance ImportInstance(string path)
        {
            TrayInstance i = null;
            i = XMLUtils.LoadFromFile<TrayInstance>(path);
            return i;
        }
        public static void RunPlugin(TrayInstancePlugin p)
        {
            TrayPlugin plugin = p.plugin;
            if (PathIsFile(plugin.path))
            {
                string parameters = "";
                foreach(TrayInstancePluginParameter param in p.parameters)
                {
                    parameters += param.value + " ";
                }
                Process.Start(plugin.path, parameters);
            }
            MessageBox.Show("Plugin!");
        }
    }
}
