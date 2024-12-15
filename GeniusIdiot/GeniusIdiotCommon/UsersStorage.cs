namespace GeniusIdiotCommon
{
    public class UsersStorage
    {
        private static string fileName = "UsersStorage";
        private static IConverter converter = new JsonConverter();
        //private static IConverter converter = new XMLConverter();

        public static void Append(User user)
        {
            var users = GetAll();
            users.Add(user);
            Save(users);
        }

        public static List<User> GetAll()
        {
            var users = new List<User>();
            if (FileProvider.Exists(fileName))
            {
                var fileData = FileProvider.Get(fileName);
                users = converter.Deserialize<List<User>>(fileData);
            }
            return users;
        }

        private static void Save(List<User> users)
        {
            var data = converter.Serialize(users);
            FileProvider.Replace(fileName, data);
        }
    }
}
