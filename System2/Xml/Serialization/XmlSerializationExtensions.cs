using System.IO;

namespace System2.Xml.Serialization
{
    using System.Xml.Serialization;

    public static class XmlSerializationExtensions
    {
        public static void SerializeToXmlStream<T>(this T serializableObject, Stream xmlStream)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(xmlStream, serializableObject);
        }

        public static string SerializeToXmlString<T>(this T serializableObject)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, serializableObject);
                return stringWriter.ToString();
            }
        }

        public static void SerializeToXmlFile<T>(this T serializableObject, string xmlFilePath)
            where T : class
        {
            using (var streamWriter = new StreamWriter(xmlFilePath))
            {
                serializableObject.SerializeToXmlStream(streamWriter.BaseStream);
            }
        }

        public static T DeserializeFromXmlString<T>(this string xmlString)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(stringReader);
            }
        }
    }
}
