using Newtonsoft.Json;

namespace _2048WinFormsApp
{
    public class UserManager
    {
        private static string path = "Results.json";

        public static List<User> GetAll()
        {
            if (FileProvider.Exists(path))
            {
                var jsonData = FileProvider.GetValue(path);
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }

            return new List<User>();
        }

        public static void Add(User newUser)
        {
            var users = GetAll();
            users.Add(newUser);

            var jsonData = JsonConvert.SerializeObject(users);
            FileProvider.Replace(path, jsonData);
        }
    }
}
