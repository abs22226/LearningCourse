
namespace GeniusIdiotConsApp
{
    public class QuestionsStorage
    {
        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists("GeniusIdiotConsAppQuestionsStorage.txt"))
            {
                var value = FileProvider.GetValue("GeniusIdiotConsAppQuestionsStorage.txt");
                var lines = value.Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var result = line.Split('#');
                        var text = result[0];
                        var answer = Convert.ToInt32(result[1].TrimEnd('\r'));
                        questions.Add(new Question(text, answer));
                    }
                }
            }
            else
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

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
            FileProvider.Append("GeniusIdiotConsAppQuestionsStorage.txt", $"{newQuestion.Text}#{newQuestion.Answer}");
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

            FileProvider.Clear("GeniusIdiotConsAppQuestionsStorage.txt");
            Save(questions);
        }
    }
}
