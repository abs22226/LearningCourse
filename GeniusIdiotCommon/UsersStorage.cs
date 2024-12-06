using Newtonsoft.Json;

namespace GeniusIdiotCommon
{
    public class UsersStorage
    {
        private static string filePath = "UsersStorage.json";

        public static void Append(User user)
        {
            var users = GetAll();
            users.Add(user);
            Save(users);
        }

        public static List<User> GetAll()
        {
            var users = new List<User>();
            if (FileProvider.Exists(filePath))
            {
                var fileData = FileProvider.Get(filePath);
                users = JsonConvert.DeserializeObject<List<User>>(fileData);
            }
            return users;
        }

        private static void Save(List<User> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            FileProvider.Replace(filePath, jsonData);
        }
    }
}
