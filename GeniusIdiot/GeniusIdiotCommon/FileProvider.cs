using System.Text;

namespace GeniusIdiotCommon
{
    public class FileProvider
    {
        public static void Replace(string fileName, string value)
        {
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(value);
            }
        }

        public static string Get(string fileName)
        {
            var value = string.Empty;
            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                value = reader.ReadToEnd();
            }
            return value;
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }     
    }
}
