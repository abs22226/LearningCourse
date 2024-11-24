using System.Text;

namespace GeniusIdiotConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя:\n(до 20 символов, cимвол '#' недопустим)");
            var name = GetUserName();

            var user = new User(name);

            var userWantsToQuiz = true;

            while (userWantsToQuiz)
            {
                var questions = QuestionsStorage.GetAll();
                var startingQuestionsCount = questions.Count();

                var rightAnswersCount = 0;

                var random = new Random();

                for (int i = 0; i < startingQuestionsCount; i++)
                {
                    var randomQuestionIndex = random.Next(0, questions.Count);

                    Console.WriteLine("Вопрос №" + (i + 1));
                    Console.WriteLine(questions[randomQuestionIndex].Text);

                    var userAnswer = GetUserNumericAnswer();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        rightAnswersCount++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                }

                user.SetScore(rightAnswersCount, startingQuestionsCount);
                Console.WriteLine("Количество правильных ответов: " + user.Score);

                user.Diagnosis = GetUserDiagnosis(rightAnswersCount, startingQuestionsCount);
                Console.WriteLine(user.Name + ", ваш диагноз: " + user.Diagnosis);

                SaveResult(user);

                Console.WriteLine("Хотите посмотреть историю результатов? (Да/Нет)");
                var userWantsToSeeHistory = GetUserDecision();

                if (userWantsToSeeHistory)
                {
                    ShowHistory();
                }

                Console.WriteLine("Хотите пройти тест снова? (Да/Нет)");
                userWantsToQuiz = GetUserDecision();

                if (userWantsToQuiz)
                {
                    Console.Clear();
                    user.ResetResult();
                }
            }
        }

        static string GetUserName()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.CursorTop--;
                }
                else
                {
                    var userName = userInput.Trim();
                    if (userName.Contains('#') || userName.Length > 20)
                    {
                        Console.CursorTop--;
                        Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                    }
                    else
                    {
                        if (userName.Length < userInput.Length)
                        {
                            Console.CursorTop--;
                            Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                            Console.WriteLine(userName);
                        }
                        return userName;
                    }
                }
            }
        }

        private static int GetUserNumericAnswer()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                int userAnswer;
                if (int.TryParse(userInput, out userAnswer))
                {
                    if (userAnswer.ToString().Length < userInput.Length)
                    {
                        Console.CursorTop--;
                        Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                        Console.WriteLine(userAnswer);
                    }
                    return userAnswer;
                }
                else
                {
                    Console.CursorTop--;
                    Console.Write(string.IsNullOrEmpty(userInput) ? "\r" + string.Empty : "\r" + new string(' ', userInput.Length) + "\r");
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                }
            }
        }

        static string GetUserDiagnosis(int rightAnswersCount, int startingQuestionsCount)
        {
            var diagnoses = GetDiagnoses();
            var rightAnswersPercentage = (double)rightAnswersCount / startingQuestionsCount * 100;
            switch (rightAnswersPercentage)
            {
                case < 20: return diagnoses[0];
                case < 40: return diagnoses[1];
                case < 60: return diagnoses[2];
                case < 80: return diagnoses[3];
                case < 100: return diagnoses[4];
                default: return diagnoses[5];
            }
        }

        static string[] GetDiagnoses()
        {
            var diagnoses = new string[6];
            diagnoses[0] = "идиот";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            return diagnoses;
        }

        static void SaveResult(User user)
        {
            using (StreamWriter writer = new("GeniusIdiotConsAppHistory.txt", true, Encoding.UTF8))
            {
                writer.WriteLine($"{user.Name}#{user.Score}#{user.Diagnosis}");
            }
        }

        static bool GetUserDecision()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.CursorTop--;
                }
                else
                {
                    var userAnswer = userInput.Trim().ToLower();
                    if (userAnswer != "да" && userAnswer != "нет")
                    {
                        Console.CursorTop--;
                        Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                    }
                    else
                    {
                        if (userAnswer.Length < userInput.Length)
                        {
                            Console.CursorTop--;
                            Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                            Console.WriteLine(userAnswer);
                        }
                        return userAnswer == "да" ? true : false;
                    }
                }
            }
        }

        static void ShowHistory()
        {
            const int columnWidth = 20;
            Console.WriteLine($"|| {"Имя:",-columnWidth} || {"Результат:",-columnWidth} || {"Диагноз:",-columnWidth} ||");

            var allLines = File.ReadAllLines("GeniusIdiotConsAppHistory.txt");
            foreach (var line in allLines)
            {
                var result = line.Split('#');
                var userName = result[0];
                var userScore = result[1];
                var userDiagnosis = result[2];

                Console.WriteLine($"|| {userName,-columnWidth} || {userScore,-columnWidth} || {userDiagnosis,-columnWidth} ||");
            }
        }
    }
}
