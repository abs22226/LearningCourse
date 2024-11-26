﻿using System.Text;

namespace GeniusIdiotConsApp
{
    public class FileProvider
    {
        public static void Append(string fileName, string value)
        {
            using (var writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(value);
            }
        }

        public static string GetValue(string fileName)
        {
            var value = string.Empty;
            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                value = reader.ReadToEnd();
            }
            return value;
        }
    }
}