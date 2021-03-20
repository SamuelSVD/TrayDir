using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
    public class ProgramData
    {
        [XmlElement(ElementName = "Settings")]
        public Settings settings;
        public List<TrayInstance> trayInstances;
        private static string config = "config.xml";
        public ProgramData()
        {
            settings = new Settings();
            trayInstances = new List<TrayInstance>();
        }
        public static ProgramData Load()
        {
            ProgramData pd = XMLUtils.LoadFromFile<ProgramData>(config);
            if (pd is null)
            {
                pd = new ProgramData();
            }
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
                if (instance.settings.paths.Count == 0)
                {
                    instance.settings.paths.Add(".");
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

    }
}
