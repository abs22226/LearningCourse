using System.Text;

namespace GeniusIdiotConsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int questionsCount = 5;
            var questions = GetQuestions(questionsCount);
            var rightAnswers = GetRightAnswers(questionsCount);

            Console.WriteLine("Введите ваше имя:\n(до 20 символов, cимвол '#' недопустим)");
            var userName = GetUserNameInput();

            var userWantsToTestHimself = true;

            var random = new Random();

            var alreadyUsedQuestionsIndexes = new List<int>();

            var correctUserAnswersCount = 0;

            while (userWantsToTestHimself)
            {
                for (int i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    var randomQuestionIndex = GetRandomQuestionIndex(random, questionsCount, alreadyUsedQuestionsIndexes);
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

                var userDiagnosis = GetUserDiagnosis(questionsCount, correctUserAnswersCount);
                Console.WriteLine(userName + ", ваш диагноз: " + userDiagnosis);

                SaveUserResult(userName, correctUserAnswersCount, questionsCount, userDiagnosis);

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

        static string[] GetQuestions(int questionsCount)
        {
            var questions = new string[questionsCount];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        static int[] GetRightAnswers(int questionsCount)
        {
            var rightAnswers = new int[questionsCount];
            rightAnswers[0] = 6;
            rightAnswers[1] = 9;
            rightAnswers[2] = 25;
            rightAnswers[3] = 60;
            rightAnswers[4] = 2;
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
            var userInput = Console.ReadLine();
            int userAnswer;
            while (!int.TryParse(userInput, out userAnswer))
            {
                Console.Write("\x1b[1A"); // перевод курсора в начало предыдущей строки
                Console.Write(userInput != null ? new string(' ', userInput.Length) + "\r" : string.Empty);
                Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                userInput = Console.ReadLine();
            }
            return userAnswer;
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
            Console.WriteLine($"|| {"Имя:",-15} || {"Результат:",-15} || {"Диагноз:",-15} ||");

            var allLines = File.ReadAllLines("GeniusIdiotConsAppResultsHistory.txt");
            foreach (var line in allLines)
            {
                var result = line.Split('#');
                string userName = result[0];
                string userScore = result[1];
                string userDiagnosis = result[2];

                Console.WriteLine($"|| {userName,-15} || {userScore,-15} || {userDiagnosis,-15} ||");
            }
        }
    }
}
