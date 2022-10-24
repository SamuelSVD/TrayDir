using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace TrayDir
{
	public partial class IPluginForm : Form {
		Dictionary<string, int> pluginIndex = new Dictionary<string, int>();
		List<Control> labels = new List<Control>();
		List<Control> controls = new List<Control>();
		TrayPlugin selectedPlugin;
		public TrayInstancePlugin model;
		private int startingCount;
		public IPluginForm(TrayInstancePlugin tip) {
			InitializeComponent();
			this.Icon = Properties.Resources.file_exe;
			this.model = tip;
			hideItemCheckBox.Checked = !model.visible;
			selectedPlugin = model.plugin;
			startingCount = pluginTableLayoutPanel.RowCount;
			LoadPlugins();
		}
		public void LoadPlugins() {
			foreach (TrayPlugin tp in ProgramData.pd.plugins) {
				string t = tp.getSignature();
				pluginIndex[t] = ProgramData.pd.plugins.IndexOf(tp);
				pluginComboBox.Items.Add(t);
			}
			for (int i = 0; i < pluginComboBox.Items.Count; i++) {
				TrayPlugin tp = ProgramData.pd.plugins[pluginIndex[pluginComboBox.Items[i].ToString()]];
				if (tp == selectedPlugin) {
					pluginComboBox.SelectedIndex = i;
					break;
				}
			}
			aliasEdit.Text = model.alias;
		}
		private void pluginComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			string selected = pluginComboBox.SelectedItem.ToString();
			model.id = pluginIndex[selected];
			TrayPlugin tp = model.plugin;
			selectedPlugin = tp;
			foreach (Control c in controls) {
				pluginTableLayoutPanel.Controls.Remove(c);
			}
			controls.Clear();
			foreach (Control c in labels) {
				pluginTableLayoutPanel.Controls.Remove(c);
			}
			labels.Clear();
			if (tp.parameterCount > 0) {
				for (int i = 0; i < tp.parameterCount; i++) {
					TrayPluginParameter tpp = null;
					if (i < tp.parameters.Count) {
						tpp = tp.parameters[i];
					}
					TrayInstancePluginParameter tipp;
					if (model.parameters.Count < i + 1) {
						tipp = new TrayInstancePluginParameter();
						model.parameters.Add(tipp);
					} else {
						tipp = model.parameters[i];
					}
					AddParameterRow(tpp, tipp);
				}
			}
			for (int i = 0; i < pluginTableLayoutPanel.RowCount; i++) {
				RowStyle rs;
				if (pluginTableLayoutPanel.RowStyles.Count > i + 1) {
					rs = pluginTableLayoutPanel.RowStyles[i];
				} else {
					rs = new RowStyle();
					pluginTableLayoutPanel.RowStyles.Add(rs);
				}
				rs.SizeType = SizeType.AutoSize;
			}
			FixTabOrder();
		}
		private void FixTabOrder() {
			int TabIndex = 0;
			for(int i = 0; i < pluginTableLayoutPanel.RowCount; i++) {
				Control c = pluginTableLayoutPanel.GetControlFromPosition(0, i);
				if (c != null) {
					c.TabIndex = TabIndex;
					TabIndex++;
				}
			}
		}
		private void AddParameterRow(TrayPluginParameter tpp, TrayInstancePluginParameter tipp) {
			if (tpp == null) {
				int paramCount = controls.Count;
				int row = controls.Count + labels.Count;
				Label l = new Label();
				l.Text = String.Format(Properties.Strings.Plugin_ParameterN, paramCount + 1);
				pluginTableLayoutPanel.Controls.Add(l, 0, startingCount + row);
				pluginTableLayoutPanel.SetColumnSpan(l, 2);
				row++;
				l.AutoSize = true;
				labels.Add(l);
				ValidateTextBox tb = new ValidateTextBox();
				tb.Dock = DockStyle.Top;
				tb.AutoSize = true;
				controls.Add(tb);
				pluginTableLayoutPanel.SetColumnSpan(tb, 2);
				pluginTableLayoutPanel.Controls.Add(tb, 0, startingCount + row);
				tb.TooltipText = Properties.Strings.Tooltip_ValueRequired;
				tb.TextChanged += new EventHandler(delegate (object obj, EventArgs args)
				{
					tipp.value = tb.Text;
					tb.Valid = (!tpp.required || !(tb.Text == String.Empty || tb.Text == null));
				});
				tb.Text = tipp.value;
			} else {
				if (tpp.isBoolean) {
					AddCheckboxParameterRow(tpp, tipp);
				} else {
					AddTextParameterRow(tpp, tipp);
				}
			}
		}
		private void AddCheckboxParameterRow(TrayPluginParameter tpp, TrayInstancePluginParameter tipp) {
			int paramCount = controls.Count;
			int row = controls.Count + labels.Count;
			CheckBox cb = new CheckBox();
			if (tpp.name != string.Empty && tpp.name != null) {
				cb.Text = tpp.name;
			}
			else {
				cb.Text = String.Format(Properties.Strings.Plugin_ParameterN, paramCount + 1);
			}
			pluginTableLayoutPanel.Controls.Add(cb, 0, startingCount + row);
			row++;
			cb.AutoSize = true;
			controls.Add(cb);
			pluginTableLayoutPanel.SetColumnSpan(cb, 2);
			cb.Checked = tipp.value.ToLower() == "true";
			cb.CheckedChanged += new EventHandler(delegate (object obj, EventArgs args) {
				if (cb.Checked) {
					tipp.value = "true";
				}
				else {
					tipp.value = "false";
				}
			});
		}
		private void AddTextParameterRow(TrayPluginParameter tpp, TrayInstancePluginParameter tipp) {
			int paramCount = controls.Count;
			int row = controls.Count + labels.Count;
			Label l = new Label();
			if (tpp.name != string.Empty && tpp.name != null) {
				l.Text = tpp.name;
			}
			else {
				l.Text = String.Format(Properties.Strings.Plugin_ParameterN, paramCount + 1);
			}
			pluginTableLayoutPanel.Controls.Add(l, 0, startingCount + row);
			pluginTableLayoutPanel.SetColumnSpan(l, 2);
			row++;
			l.AutoSize = true;
			labels.Add(l);
			ValidateTextBox tb = new ValidateTextBox();
			tb.Dock = DockStyle.Top;
			//tb.AutoSize = true;
			controls.Add(tb);
			pluginTableLayoutPanel.SetColumnSpan(tb, 2);
			pluginTableLayoutPanel.Controls.Add(tb, 0, startingCount + row);
			tb.TooltipText = Properties.Strings.Tooltip_ValueRequired;
			tb.TextChanged += new EventHandler(delegate (object obj, EventArgs args)
			{
				tipp.value = tb.Text;
				tb.Valid = (!tpp.required || !(tb.Text == String.Empty || tb.Text == null));
			});
			tb.Text = tipp.value;
		}
		private void IPluginForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (selectedPlugin != null)
			{
				List<TrayInstancePluginParameter> par = new List<TrayInstancePluginParameter>();
				for (int i = selectedPlugin.parameterCount; i < model.parameters.Count; i++)
				{
					par.Add(model.parameters[i]);
				}
				foreach (TrayInstancePluginParameter p in par)
				{
					model.parameters.Remove(p);
				}
			}
			model.alias = aliasEdit.Text;
		}
		private void hideItemCheckBox_CheckedChanged(object sender, EventArgs e) {
			model.visible = !hideItemCheckBox.Checked;
		}

		private void IPluginForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
			HelpUtils.ShowHelp(this, "src/plugins.htm");
		}
		private void OkButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
	}
}
