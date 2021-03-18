using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
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
        public static T LoadFromFile<T>(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.Load(filepath);
                XmlElement root = doc.DocumentElement;
                return XmlDeserializeFromString<T>(root.OuterXml);
            }
            catch
            {
                return default(T);
            }
        }
        public static void SaveToFile(this object obj, string filepath)
        {
            try
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                xmlSettings.IndentChars = ("    ");
                xmlSettings.CloseOutput = true;
                xmlSettings.OmitXmlDeclaration = false;
                XmlWriter writer = XmlWriter.Create(filepath, xmlSettings);
                XmlSerializeToWriter(obj, writer);
                writer.Flush();
                writer.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Exception caught: " + e.Message);
            }
        }
    }
}
