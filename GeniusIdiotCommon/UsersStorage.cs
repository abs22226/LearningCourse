namespace GeniusIdiotCommon
{
    public class UsersStorage
    {
        public static void Save(User user)
        {
            FileProvider.Append("UsersStorage.txt", $"{user.Name}#{user.Score}#{user.Diagnosis}");
        }

        public static List<User> GetAll()
        {
            var users = new List<User>();
            if (FileProvider.Exists("UsersStorage.txt"))
            {
                var value = FileProvider.GetValue("UsersStorage.txt");
                var lines = value.Split('\n');

                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var result = line.Split('#');
                        var name = result[0];
                        var score = result[1];
                        var diagnosis = result[2].TrimEnd('\r');
                        users.Add(new User(name, score, diagnosis));
                    }
                }
            }
            return users;
        }
    }
}
