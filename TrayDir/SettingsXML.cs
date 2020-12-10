using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TrayDir
{
    class SettingsXML
    {
        public static void XMLWrite(XmlWriter writer)
        {
            writer.WriteStartElement("TrayDir");
            XMLWrite_Instances(writer);
            XMLWrite_OptionGroup(writer);
            writer.WriteEndElement();
        }
        private static void XMLWrite_Instances(XmlWriter writer)
        {
            writer.WriteStartElement("instances");
            for (int i = 0; i < TrayInstance.instances.Count; i++)
            {
                XMLUtils.XmlSerializeToWriter(TrayInstance.instances[i].settings, writer);
            }
            writer.WriteEndElement();
        }
        private static void XMLWrite_OptionGroup(XmlWriter writer)
        {
            XMLUtils.XmlSerializeToWriter(Settings.settings, writer);
        }
        public static void XMLRead(XmlElement root)
        {
            XMLRead_Options(root);
            XMLRead_Instances(root);
        }
        private static void XMLRead_Options(XmlElement root)
        {
            try
            {
                XmlElement options = root.GetElementsByTagName("OptionGroup")[0] as XmlElement;
                OptionGroup og = XMLUtils.XmlDeserializeFromString<OptionGroup>(options.OuterXml);
                Settings.settings = og;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Parsing Options: " + e.Message);
            }
        }
        private static void XMLRead_Instances(XmlElement root)
        {
            try
            {
                XmlElement instances = root.GetElementsByTagName("instances")[0] as XmlElement;
                XmlNodeList list = instances.GetElementsByTagName("TrayInstanceSettings");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlElement path = (XmlElement)list[i];
                        try
                        {
                            TrayInstanceSettings insts = XMLUtils.XmlDeserializeFromString<TrayInstanceSettings>(path.OuterXml);
                            TrayInstance instance = new TrayInstance(insts);
                            TrayInstance.instances.Add(new TrayInstance(insts));
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error Parsing Path: " + e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Parsing Paths: " + e.Message);
            }
        }

    }
}
