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
        public static ToolStripMenuItem RecursivePathFollow(TrayInstanceSettings settings, string path)
        {
            return RecursivePathFollow(settings, path, 0);
        }
        public static ToolStripMenuItem RecursivePathFollow(TrayInstanceSettings settings, string path, int depth)
        {
            ToolStripMenuItem menuitem = new ToolStripMenuItem();
            menuitem.Size = new Size(359, 44);
            menuitem.Text = "";
            try
            {
                //detect whether its a directory or file
                if (PathIsDirectory(path))
                {
                    menuitem.Text = new DirectoryInfo(path).Name;
                    if (depth < 4)
                    {
                        List<string> dirs = new List<string>();
                        List<string> paths = new List<string>();
                        if (ProgramData.pd.settings.app.MenuSorting != "None")
                        {
                            string[] dirpaths = Directory.GetFileSystemEntries(path);
                            if (dirpaths.Length == 0)
                            {
                                menuitem.DropDownItems.Add("(Empty)");
                            }
                            foreach (string fp in dirpaths)
                            {
                                if (PathIsDirectory(fp))
                                {
                                    dirs.Add(fp);
                                }
                                else
                                {
                                    paths.Add(fp);
                                }
                            }
                            if (ProgramData.pd.settings.app.MenuSorting == "Folders Top")
                            {
                                foreach (string dp in dirs)
                                {
                                    menuitem.DropDownItems.Add(RecursivePathFollow(settings, dp));
                                }
                                foreach (string fp in paths)
                                {
                                    menuitem.DropDownItems.Add(RecursivePathFollow(settings, fp));
                                }
                            } else
                            {
                                foreach (string fp in paths)
                                {
                                    menuitem.DropDownItems.Add(RecursivePathFollow(settings, fp));
                                }
                                foreach (string dp in dirs)
                                {
                                    menuitem.DropDownItems.Add(RecursivePathFollow(settings, dp));
                                }
                            }
                        }
                        else
                        {
                            foreach (string fp in Directory.GetFileSystemEntries(path))
                            {
                                menuitem.DropDownItems.Add(RecursivePathFollow(settings, fp));
                            }
                        }
                    }
                }
                else if (PathIsFile(path))
                {
                    menuitem.Text = Path.GetFileName(path);
                    if (settings.ShowFileExtensions)
                    {
                        menuitem.Text = Path.GetFileName(path);
                    }
                    else
                    {
                        menuitem.Text = Path.GetFileNameWithoutExtension(path);
                    }
                    if (ProgramData.pd.settings.app.ShowIconsInMenus)
                    {
                        try
                        {
                            menuitem.Image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                        }
                        catch { }
                    }
                }
                else
                {
                    if (Program.DEBUG) MessageBox.Show("Problem Parsing " + path);
                }
            }
            catch
            {
                if (Program.DEBUG) MessageBox.Show("Problem Parsing " + path);
            }


            EventHandler textbox_select = new EventHandler(delegate (object obj, EventArgs args)
            {
                if (PathIsDirectory(path) & settings.ExploreFoldersInTrayMenu)
                {
                    OpenPath(new DirectoryInfo(path).FullName, settings.RunAsAdmin);
                }
                else if (PathIsFile(path))
                {
                    OpenPath(Path.GetFullPath(path), settings.RunAsAdmin);
                }
            });

            menuitem.Click += textbox_select;
            return menuitem;
        }
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
                MessageBox.Show("Error Executing As Admin: " + path + '\n' + e.Message);
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
                MessageBox.Show(sfd.FileName);
                XMLUtils.SaveToFile(instance, sfd.FileName);
            }
        }
        public static TrayInstance ImportInstance()
        {
            TrayInstance i = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tray Instance Export | *.tde";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);
                i = XMLUtils.LoadFromFile<TrayInstance>(ofd.FileName);
            }
            return i;
        }
    }
}
