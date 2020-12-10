using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TrayDir
{
    public static class XMLUtils
    {
        // Grabbed from stack overflow
        // https://stackoverflow.com/questions/2347642/deserialize-from-string-instead-textreader
        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }
        public static void XmlSerializeToWriter(this object objectInstance, XmlWriter writer)
        {
            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(objectInstance.GetType());
            serializer.Serialize(writer, objectInstance, xns);
        }
        public static T XmlDeserializeFromString<T>(this string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }
        public static object XmlDeserializeFromString(this string objectData, Type t)
        {
            var serializer = new XmlSerializer(t);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
