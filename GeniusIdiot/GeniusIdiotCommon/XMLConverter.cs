using System.Xml.Serialization;

namespace GeniusIdiotCommon
{
    public class XMLConverter : IConverter
    {
        public string Serialize<T>(T item)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using(var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, item);
                return textWriter.ToString();
            }
        }

        public T Deserialize<T>(string data)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    } 
}
