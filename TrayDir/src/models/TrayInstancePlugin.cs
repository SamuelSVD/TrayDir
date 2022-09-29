using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrayDir {
	public class TrayInstancePlugin : TrayInstanceItem {
		[XmlAttribute]
		public int id = -1;
		public List<TrayInstancePluginParameter> parameters = new List<TrayInstancePluginParameter>();
		[XmlIgnore]
		public TrayPlugin plugin {
			get {
				if (id >= 0 && id < ProgramData.pd.plugins.Count) {
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

		public override object Copy() {
			TrayInstancePlugin tip = new TrayInstancePlugin();
			tip.id = id;
			tip.alias = alias;
			foreach (TrayInstancePluginParameter tipp in parameters) {
				tip.parameters.Add((TrayInstancePluginParameter)tipp.Copy());
			}
			return tip;
		}
		public override void Apply(object model) {
			if (model.GetType() == typeof(TrayInstancePlugin)) {
				this.id = ((TrayInstancePlugin)model).id;
				this.alias = ((TrayInstancePlugin)model).alias;
				for (int i = 0; i < ((TrayInstancePlugin)model).parameters.Count; i++) {
					if (this.parameters.Count > i) {
						this.parameters[i].Apply(((TrayInstancePlugin)model).parameters[i]);
					} else {
						TrayInstancePluginParameter tipp = new TrayInstancePluginParameter();
						tipp.Apply(((TrayInstancePlugin)model).parameters[i]);
						this.parameters.Add(tipp);
					}
				}
				while (this.parameters.Count > ((TrayInstancePlugin)model).parameters.Count) {
					this.parameters.RemoveAt(parameters.Count - 1);
				}
			}
		}
		public override bool Equals(object b) {
			if (b.GetType() == typeof(TrayInstancePlugin)) {
				TrayInstancePlugin a = this;
				bool equals = true;
				equals &= (a.id == ((TrayInstancePlugin)b).id);
				equals &= (a.alias == ((TrayInstancePlugin)b).alias);
				equals &= (a.visible == ((TrayInstancePlugin)b).visible);
				equals &= (a.parameters.Count == ((TrayInstancePlugin)b).parameters.Count);
				if (equals) {
					int count = a.parameters.Count;
					for (int i = 0; i < count; i++) {
						equals &= (a.parameters[i].Equals(((TrayInstancePlugin)b).parameters[i]));
					}
				}
				return equals;
			}
			return false;
		}

		internal bool isValid() {
			TrayPlugin p = plugin;
			bool valid = true;
			if (p != null) {
				for (int i = 0; i < p.parameters.Count; i++) {
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
