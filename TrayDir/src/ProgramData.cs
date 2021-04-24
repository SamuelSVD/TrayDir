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
        private static string config;
        public static ProgramData pd;
        public ProgramData()
        {
            settings = new Settings();
            trayInstances = new List<TrayInstance>();
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
            XMLUtils.SaveToFile(this, config);
        }
        public void Update()
        {
            if (trayInstances != null)
            {
                foreach (TrayInstance instance in trayInstances)
                {
                    instance.view.UpdateTrayMenu();
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
                    instance.view.SetFormHiddenMenu();
                }
            }
        }
        public void FormShowed()
        {
            if (trayInstances != null)
            {
                foreach (TrayInstance instance in trayInstances)
                {
                    instance.view.SetFormShownMenu();
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
            }
        }
        public void CheckStartup()
        {
            //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (settings.app.StartWithWindows)
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
                    ti.view.Rebuild();
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
