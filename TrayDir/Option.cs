using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayDir
{
    public class Option
    {
        public string name;
        private string sValue;
        public bool bValue
        {
            get { return sValue == "1"; }
            set { sValue = value ? "1" : "0"; }
        }
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
