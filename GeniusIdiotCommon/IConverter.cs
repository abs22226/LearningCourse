namespace GeniusIdiotCommon
{
    public interface IConverter
    {
        public string Serialize<T>(T item);
        public T Deserialize<T>(string data);
    }
}
