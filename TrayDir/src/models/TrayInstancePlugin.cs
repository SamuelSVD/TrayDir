﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir
{
	public class TrayInstancePlugin : Model<TrayInstancePlugin>
	{
		[XmlAttribute]
		public int id = -1;
		[XmlAttribute]
		public string alias;
		[XmlAttribute]
		public bool visible = true;
		public List<TrayInstancePluginParameter> parameters = new List<TrayInstancePluginParameter>();
		[XmlIgnore]
		public TrayPlugin plugin
		{
			get
			{
				if (id >= 0 && id < ProgramData.pd.plugins.Count)
				{
					return ProgramData.pd.plugins[id];
				}
				return null;
			}
		}
		[XmlIgnore]
		internal string[] ParametersAsStringArray {
			get {
				List<string> list = new List<string>();
				foreach (TrayInstancePluginParameter tipp in parameters) {
					list.Add(tipp.value.ToString());
				}
				return list.ToArray();
			}
		}

		public override TrayInstancePlugin Copy()
		{
			TrayInstancePlugin tip = new TrayInstancePlugin();
			tip.id = id;
			tip.alias = alias;
			foreach(TrayInstancePluginParameter tipp in parameters)
			{
				tip.parameters.Add(tipp.Copy());
			}
			return tip;
		}

		public override bool Equals(TrayInstancePlugin b) {
			//id alias visible parameters
			TrayInstancePlugin a = this;
			bool equals = true;
			equals &= (a.id == b.id);
			equals &= (a.alias == b.alias);
			equals &= (a.visible == b.visible);
			equals &= (a.parameters.Count == b.parameters.Count);
			if (equals) {
				int count = a.parameters.Count;
				for(int i = 0; i < count; i++) {
					equals &= (a.parameters[i].Equals(b.parameters[i]));
				}
			}
			return equals;
		}

		internal bool isValid() {
			TrayPlugin p = plugin;
			bool valid = true;
			if (p != null) {
				for(int i = 0; i < p.parameters.Count; i++) {
					TrayPluginParameter tpp = p.parameters[i];
					valid &= tpp.isBoolean || !(tpp.required && (parameters.Count > i) && parameters[i].value == "");
				}
			} else {
				valid = false;
			}
			return valid;
		}
	}
}
