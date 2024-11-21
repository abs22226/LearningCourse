using System.Text;

namespace GeniusIdiotConsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var questions = GetQuestions();
            var rightAnswers = GetRightAnswers();

            Console.WriteLine("Введите ваше имя:\n(до 20 символов, cимвол '#' недопустим)");
            var userName = GetUserNameInput();

            var userWantsToTestHimself = true;

            var random = new Random();

            var alreadyUsedQuestionsIndexes = new List<int>();

            var correctUserAnswersCount = 0;

            while (userWantsToTestHimself)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    var randomQuestionIndex = GetRandomQuestionIndex(random, questions.Count, alreadyUsedQuestionsIndexes);
                    Console.WriteLine(questions[randomQuestionIndex]);

                    alreadyUsedQuestionsIndexes.Add(randomQuestionIndex);

                    var userAnswer = GetUserNumericAnswer();

                    var rightAnswer = rightAnswers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        correctUserAnswersCount++;
                    }
                }

                Console.WriteLine("Количество правильных ответов: " + correctUserAnswersCount);

                var userDiagnosis = GetUserDiagnosis(questions.Count, correctUserAnswersCount);
                Console.WriteLine(userName + ", ваш диагноз: " + userDiagnosis);

                SaveUserResult(userName, correctUserAnswersCount, questions.Count, userDiagnosis);

                Console.WriteLine("Хотите посмотреть историю результатов? (Да/Нет)");
                var userWantsToSeeResultsHistory = GetUserDecision();

                if (userWantsToSeeResultsHistory)
                {
                    ShowResultsHistory();
                }

                Console.WriteLine("Хотите пройти тест снова? (Да/Нет)");
                userWantsToTestHimself = GetUserDecision();

                if (userWantsToTestHimself)
                {
                    Console.Clear();
                    alreadyUsedQuestionsIndexes.Clear();
                    correctUserAnswersCount = 0;
                }
            }
        }

        static List<string> GetQuestions()
        {
            var questions = new List<string>();
            questions.Add("Сколько будет два плюс два умноженное на два?");
            questions.Add("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?");
            questions.Add("Пять свечей горело, две потухли. Сколько свечей осталось?");
            return questions;
        }

        static List<int> GetRightAnswers()
        {
            var rightAnswers = new List<int>();
            rightAnswers.Add(6);
            rightAnswers.Add(9);
            rightAnswers.Add(25);
            rightAnswers.Add(60);
            rightAnswers.Add(2);
            return rightAnswers;
        }

        static string GetUserNameInput()
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

        static int GetRandomQuestionIndex(Random random, int questionsCount, List<int> alreadyUsedQuestionsIndexes)
        {
            var randomQuestionIndex = random.Next(0, questionsCount);
            while (alreadyUsedQuestionsIndexes.Contains(randomQuestionIndex))
            {
                randomQuestionIndex = random.Next(0, questionsCount);
            }
            return randomQuestionIndex;
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

        static string GetUserDiagnosis(int questionsCount, int correctUserAnswersCount)
        {
            var diagnoses = GetDiagnoses();
            var correctUserAnswersPercent = (double)correctUserAnswersCount / questionsCount * 100;
            switch (correctUserAnswersPercent)
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

        static void SaveUserResult(string userName, int correctUserAnswersCount, int questionsCount, string userDiagnosis)
        {
            using (StreamWriter writer = new("GeniusIdiotConsAppResultsHistory.txt", true, Encoding.UTF8))
            {
                writer.WriteLine($"{userName}#{correctUserAnswersCount}/{questionsCount}#{userDiagnosis}");
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

        static void ShowResultsHistory()
        {
            const int columnWidth = 20;
            Console.WriteLine($"|| {"Имя:",-columnWidth} || {"Результат:",-columnWidth} || {"Диагноз:",-columnWidth} ||");

            var allLines = File.ReadAllLines("GeniusIdiotConsAppResultsHistory.txt");
            foreach (var line in allLines)
            {
                var result = line.Split('#');
                string userName = result[0];
                string userScore = result[1];
                string userDiagnosis = result[2];

                Console.WriteLine($"|| {userName,-columnWidth} || {userScore,-columnWidth} || {userDiagnosis,-columnWidth} ||");
            }
        }
    }
}
