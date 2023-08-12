using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrayDir {
	class ComboBoxView {
		internal Label label;
		internal ComboBox combobox;
		internal ToolTip tp;
		StringIndexable settingGroup;
		string settingName;
		private Dictionary<string, string> comboBoxOptions;
		private Dictionary<string, string> inverseComboBoxOptions = new Dictionary<string, string>();

		internal ComboBoxView(string text, Dictionary<string, string> options, StringIndexable settingGroup, string settingName) {
			label = new Label();

			label.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
			label.AutoSize = true;
			label.Location = new Point(10, 55);
			label.Margin = new Padding(10, 5, 3, 5);
			label.Size = new Size(670, 25);
			label.TabIndex = 2;
			label.Text = text;

			if (Program.DEBUG) label.BackColor = Color.Orange;

			combobox = new ComboBox();
			combobox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
			combobox.AutoSize = true;
			combobox.Location = new Point(688, 9);
			combobox.Size = new Size(116, 27);
			combobox.TabIndex = 1;
			combobox.DropDownStyle = ComboBoxStyle.DropDownList;
			combobox.SelectedIndexChanged += Combobox_SelectedIndexChanged;

			comboBoxOptions = options;
			this.settingGroup = settingGroup;
			this.settingName = settingName;

			foreach (string s in options.Keys) {
				combobox.Items.Add(options[s]);
				inverseComboBoxOptions.Add(options[s], s);
			}
			if (Program.DEBUG) combobox.BackColor = Color.Red;
		}

		private void Combobox_SelectedIndexChanged(object sender, EventArgs e) {
			settingGroup[settingName] = inverseComboBoxOptions[combobox.SelectedItem.ToString()];
			MainForm.form.pd.Update();
			MainForm.form.pd.Save();
		}

		internal void AddTo(TableLayoutPanel tlp, int row) {
			tlp.Controls.Add(label, 0, row);
			tlp.Controls.Add(combobox, 1, row);
			tlp.RowCount = row + 1;
			RowStyle rs = new RowStyle();
			rs.SizeType = SizeType.AutoSize;
			tlp.RowStyles.Add(rs);

			for (int i = 0; i < 3; i++) {
				if (tlp.ColumnStyles.Count < (i + 1)) {
					tlp.ColumnStyles.Add(new ColumnStyle());
				}
				ColumnStyle style = tlp.ColumnStyles[i];
				style.SizeType = SizeType.Percent;
				switch (i) {
					case 0:
						style.Width = 60;
						break;
					case 1:
						style.Width = 40;
						break;
					default:
						style.Width = 50;
						break;
				}
			}
		}
		internal void SetTooltip(string message) {
			tp = new ToolTip();
			tp.AutoPopDelay = 5000;
			tp.InitialDelay = 500;
			tp.ReshowDelay = 100;
			tp.ShowAlways = true;
			tp.SetToolTip(combobox, message);
			tp.SetToolTip(label, message);
		}
	}
}
