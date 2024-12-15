namespace GeniusIdiotCommon
{
    public class QuestionsStorage
    {
        private static string fileName = "QuestionsStorage";
        private static IConverter converter = new JsonConverter();
        //private static IConverter converter = new XMLConverter();

        public static void Append(Question newQuestion)
        {
            var questions = GetAll();
            questions.Add(newQuestion);
            Save(questions);
        }

        public static void Remove(Question deletedQuestion)
        {
            var questions = GetAll();
            foreach (var question in questions)
            {
                if (question == deletedQuestion)
                {
                    questions.Remove(question);
                    break;
                }
            }
            Save(questions);
        }

        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists(fileName))
            {
                var fileData = FileProvider.Get(fileName);
                questions = converter.Deserialize<List<Question>>(fileData);
            }
            else
            {
                questions.Add(new Question() { Text = "Сколько будет два плюс два умноженное на два?", Answer = 6 });
                questions.Add(new Question() { Text = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", Answer = 9 });
                questions.Add(new Question() { Text = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", Answer = 25 });
                questions.Add(new Question() { Text = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", Answer = 60 });
                questions.Add(new Question() { Text = "Пять свечей горело, две потухли. Сколько свечей осталось?", Answer = 2 });

                Save(questions);
            }
            return questions;
        }

        private static void Save(List<Question> questions)
        {
            var data = converter.Serialize(questions);
            FileProvider.Replace(fileName, data);
        }
    }
}
