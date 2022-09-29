using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrayDir {
	public abstract class TrayInstanceItem : Model {
		[XmlAttribute]
		public bool visible = true;
		[XmlAttribute]
		public string alias;
	}
}
