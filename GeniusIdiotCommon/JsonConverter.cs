using Newtonsoft.Json;

namespace GeniusIdiotCommon
{
    public class JsonConverter : IConverter
    {
        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
