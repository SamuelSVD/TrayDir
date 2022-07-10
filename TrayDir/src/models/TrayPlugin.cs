using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayPlugin
	{
		[XmlAttribute]
		public string path;
		[XmlAttribute]
		public string name;
		[XmlAttribute]
		public int parameterCount;
		[XmlAttribute]
		public bool AlwaysRunAsAdmin = false;
		[XmlAttribute]
		public bool OpenIndirect = false;
		[XmlAttribute]
		public string Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
		[XmlAttribute]
		public bool isScript;
		[XmlAttribute]
		public string CreationDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
		public List<TrayPluginParameter> parameters = new List<TrayPluginParameter>();
		public string scriptText = "";
		public string getSignature()
		{
			string sig = string.Format("{0} ({1})", name, path);
			return sig;
		}
	}
}
