using System.Text;

namespace GeniusIdiotConsApp
{
    public class UsersStorage
    {
        public static void Save(User user)
        {
            FileProvider.Append("UsersStorage.txt", $"{user.Name}#{user.Score}#{user.Diagnosis}");
        }

        public static List<User> GetAll()
        {
            var value = FileProvider.GetValue("UsersStorage.txt");
            var lines = value.Split('\n');
            var users = new List<User>();
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
            return users;
        }
    }
}
