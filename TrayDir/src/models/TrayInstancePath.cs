using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrayDir
{
    public class TrayInstancePath
    {
        [XmlAttribute]
        public string path;
        [XmlAttribute]
        public string alias;
    }
}
