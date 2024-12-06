namespace GeniusIdiotCommon
{
    public class QuestionsStorage
    {
        private static string filePath = "QuestionsStorage.txt";

        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists(filePath))
            {
                var value = FileProvider.Get(filePath);
                var lines = value.Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var result = line.Split('#');
                        var text = result[0];
                        var answer = Convert.ToInt32(result[1].TrimEnd('\r'));
                        questions.Add(new Question() { Text = text, Answer = answer });
                    }
                }
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

        public static void Save(List<Question> questions)
        {
            foreach (var question in questions)
            {
                Add(question);
            }
        }

        public static void Add(Question newQuestion)
        {
            FileProvider.Append(filePath, $"{newQuestion.Text}#{newQuestion.Answer}");
        }

        public static void Remove(Question question)
        {
            var questions = GetAll();            
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == question.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }

            FileProvider.Clear(filePath);
            Save(questions);
        }
    }
}
