using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TrayDir
{
    public class ProgramData
    {
        [XmlElement(ElementName = "Settings")]
        public Settings settings;
        public List<TrayInstance> trayInstances;
        public List<TrayPlugin> plugins;
        private static string config;
        public static ProgramData pd;
        [XmlIgnore]
        public bool initialized;
        public ProgramData()
        {
            initialized = false;
            settings = new Settings();
            trayInstances = new List<TrayInstance>();
            plugins = new List<TrayPlugin>();
            ProgramData.pd = this;
        }
        public static ProgramData Load()
        {
            config = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\config.xml";
            ProgramData pd = XMLUtils.LoadFromFile<ProgramData>(config);
            if (pd is null)
            {
                pd = new ProgramData();
            }
            pd.PerformUpdate();
            return pd;
        }
        public void CreateDefaultInstance()
        {
            TrayInstance ti = new TrayInstance();
            trayInstances.Add(ti);
        }
        public void Save()
        {
            if (initialized)
            {
                XMLUtils.SaveToFile(this, config);
            }
        }
        public void Update()
        {
            if (trayInstances != null)
            {
                foreach (TrayInstance instance in trayInstances)
                {
                    instance.view.tray.BuildTrayMenu();
                }
            }
            CheckStartup();
        }
        public void FormHidden()
        {
            if (trayInstances != null)
            {
                foreach (TrayInstance instance in trayInstances)
                {
                    instance.view.tray.SetFormHiddenMenu();
                }
            }
        }
        public void FormShowed()
        {
            if (trayInstances != null)
            {
                foreach (TrayInstance instance in trayInstances)
                {
                    if (instance.view != null)
                    {
                        instance.view.tray.SetFormShownMenu();
                    }
                }
            }
        }
        public void FixInstances()
        {
            foreach (TrayInstance instance in trayInstances)
            {
                if (instance.PathCount == 0)
                {
                    instance.paths.Add(new TrayInstancePath(TrayInstance.defaultPath));
                }
                if (instance.PathCount != instance.NodeCount)
                {
                    instance.nodes.children.Clear();
                    foreach(TrayInstancePath tip in instance.paths)
                    {
                        TrayInstanceNode tin = new TrayInstanceNode();
                        tin.id = instance.paths.IndexOf(tip);
                        tin.type = TrayInstanceNode.NodeType.Path;
                        instance.nodes.children.Add(tin);
                        tin.parent = instance.nodes;
                    }
                }
                instance.nodes.SetInstance(instance);
                instance.nodes.FixChildren();
            }
            
        }
        public void CheckStartup()
        {
            //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (settings.win.StartWithWindows)
            {
                key.SetValue("TrayDir", System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            else
            {
                if (Array.Find(key.GetValueNames(), v => v == "TrayDir") != null)
                {
                    key.DeleteValue("TrayDir");
                }
            }
            key.Close();
        }
        public void RebuildAll()
        {
            foreach (TrayInstance ti in pd.trayInstances)
            {
                if (ti.view != null)
                {
                    ti.view.tray.Rebuild();
                }
            }
        }
        private void PerformUpdate()
        {
            foreach(TrayInstance ti in trayInstances)
            {
                if (ti.settings.paths.Count > 0)
                {
                    foreach(string path in ti.settings.paths)
                    {
                        ti.paths.Add(new TrayInstancePath(path));
                    }
                }
                ti.settings.paths = null;
            }
        }
    }
}
