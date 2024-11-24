using System.Text;

namespace GeniusIdiotConsApp
{
    public class UsersStorage
    {
        public static void Save(User user)
        {
            using (StreamWriter writer = new("GeniusIdiotConsAppUsersStorage.txt", true, Encoding.UTF8))
            {
                writer.WriteLine($"{user.Name}#{user.Score}#{user.Diagnosis}");
            }
        }

        public static List<User> GetAll()
        {
            var allLines = File.ReadAllLines("GeniusIdiotConsAppUsersStorage.txt");
            var users = new List<User>();            
            foreach (var line in allLines)
            {
                var result = line.Split('#');
                var name = result[0];
                var score = result[1];
                var diagnosis = result[2];

                users.Add(new User(name, score, diagnosis));
            }
            return users;
        }
    }
}
