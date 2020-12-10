using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrayDir
{
    public class Option
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string sValue;
        public Option() : this("", "") { }
        public Option(string name, string value)
        {
            this.name = name;
            sValue = value;
        }
        public Option(string name, bool value) : this(name, value ? "1" : "0") { }
        public string getValue_string()
        {
            return sValue;
        }
        public bool getValue_bool()
        {
            return sValue == "1" ? true : false;
        }
        public void setValue(string value)
        {
            sValue = value;
        }
        public void setValue(bool value)
        {
            sValue = (value ? "1" : "0");
        }
    }
}
