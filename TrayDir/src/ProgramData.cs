﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TrayDir
{
	public class ProgramData
	{
		[XmlElement(ElementName = "Settings")]
		public Settings settings;
		public List<TrayInstance> trayInstances;
		public List<TrayInstance> archivedInstances;
		public List<TrayPlugin> plugins;
		private static string config;
		public static ProgramData pd;
		[XmlAttribute]
		public string Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
		[XmlAttribute]
		//This version is meant to track the last ignored version through the updater. 
		public string LatestVersion;
		[XmlIgnore]
		public bool initialized;
		public ProgramData()
		{
			initialized = false;
			settings = new Settings();
			trayInstances = new List<TrayInstance>();
			archivedInstances = new List<TrayInstance>();
			plugins = new List<TrayPlugin>();
			ProgramData.pd = this;
		}
		public static ProgramData Load()
		{
			config = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\config.xml";
			ProgramData pd = XMLUtils.LoadFromFile<ProgramData>(config);
			if (pd is null)
			{
				//Check Virtual Folder or previous path location for config file.
				if (!Debugger.IsAttached) {
					string oldPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VirtualStore\\Program Files (x86)\\samver\\TrayDir\\config.xml";
					if (File.Exists(oldPath)) {
						pd = XMLUtils.LoadFromFile<ProgramData>(oldPath);
					}
					if (pd is null) {
						oldPath = "C:\\Program Files (x86)\\samver\\TrayDir\\TrayDir.exe";
						if (File.Exists(oldPath)) {
							pd = XMLUtils.LoadFromFile<ProgramData>(oldPath);
						}
					}
				}
				if (pd is null) {
					pd = new ProgramData();
				}
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
			if (initialized) {
				XMLUtils.SaveToFile(this, config);
			}
		}
		public void SaveAs()
		{
			if (initialized) {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "TrayDir XML Export | *.xml";
				sfd.FileName = "TrayDir";
				if (sfd.ShowDialog() == DialogResult.OK) {
					XMLUtils.SaveToFile(this, sfd.FileName);
					MessageBox.Show("Saved to:" + sfd.FileName, "Export Done");
				}
			}
		}
		public void Update()
		{
			if (initialized) {
				if (trayInstances != null) {
					foreach (TrayInstance instance in trayInstances) {
						instance.view.tray.BuildTrayMenu();
					}
				}
			}
			if (!Program.IGNORESTARTUP) CheckStartup();
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
				instance.FixNodes();
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
				ti.view?.Rebuild();
			}
		}
		private void PerformUpdate()
		{
			foreach(TrayInstance ti in trayInstances)
			{
				ti.FixPaths();
				ti.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
			foreach(TrayInstance ti in archivedInstances) {
				ti.FixPaths();
				ti.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
			foreach(TrayPlugin tp in plugins) {
				tp.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
			Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
		}
		public void RemovedPlugin(int i) {
			foreach(TrayInstance ti in trayInstances) {
				foreach(TrayInstancePlugin tip in ti.plugins) {
					if (tip.id > i) tip.id--;
				}
			}
			foreach(TrayInstance ti in archivedInstances) {
				foreach(TrayInstancePlugin tip in ti.plugins) {
					if (tip.id > i) tip.id--;
				}
			}
		}
	}
}
