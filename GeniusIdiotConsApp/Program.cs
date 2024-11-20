namespace GeniusIdiotConsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int questionsCount = 5;
            string[] questions = GetQuestions(questionsCount);
            int[] rightAnswers = GetRightAnswers(questionsCount);

            Console.WriteLine("Введите ваше имя:");
            string userName = GetUserNameInput();

            bool userWantsToTestHimself = true;

            Random random = new Random();

            List<int> alreadyUsedQuestionsIndexes = new List<int>();

            int correctUserAnswersCount = 0;

            while (userWantsToTestHimself)
            {
                for (int i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    int randomQuestionIndex = GetRandomQuestionIndex(random, questionsCount, alreadyUsedQuestionsIndexes);
                    Console.WriteLine(questions[randomQuestionIndex]);

                    alreadyUsedQuestionsIndexes.Add(randomQuestionIndex);

                    int userAnswer = GetUserNumericAnswer();

                    int rightAnswer = rightAnswers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        correctUserAnswersCount++;
                    }
                }

                Console.WriteLine("Количество правильных ответов: " + correctUserAnswersCount);

                string[] diagnoses = GetDiagnoses();
                Console.WriteLine(userName + ", ваш диагноз: " + diagnoses[correctUserAnswersCount]);

                Console.WriteLine("Хотите повторить? (Да/Нет)");
                userWantsToTestHimself = GetUserDecisionAboutTesting();

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
            string[] questions = new string[questionsCount];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        static int[] GetRightAnswers(int questionsCount)
        {
            int[] rightAnswers = new int[questionsCount];
            rightAnswers[0] = 6;
            rightAnswers[1] = 9;
            rightAnswers[2] = 25;
            rightAnswers[3] = 60;
            rightAnswers[4] = 2;
            return rightAnswers;
        }

        static string GetUserNameInput()
        {
            string? userInput = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(userInput))
            {
                Console.Write("\x1b[1A"); // перевод курсора в начало предыдущей строки
                userInput = Console.ReadLine()?.Trim();
            }
            return userInput;
        }

        static int GetRandomQuestionIndex(Random random, int questionsCount, List<int> alreadyUsedQuestionsIndexes)
        {
            int randomQuestionIndex = random.Next(0, questionsCount);
            while (alreadyUsedQuestionsIndexes.Contains(randomQuestionIndex))
            {
                randomQuestionIndex = random.Next(0, questionsCount);
            }
            return randomQuestionIndex;
        }

        private static int GetUserNumericAnswer()
        {
            string? userInput = Console.ReadLine();
            int userAnswer;
            while (!int.TryParse(userInput, out userAnswer))
            {
                Console.Write("\x1b[1A"); // перевод курсора в начало предыдущей строки
                Console.Write(userInput != null ? new string(' ', userInput.Length) + "\r" : string.Empty);
                Console.WriteLine("Пожалуйста, введите число!");
                userInput = Console.ReadLine();
            }
            return userAnswer;
        }

        static string[] GetDiagnoses()
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "идиот";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            return diagnoses;
        }

        static bool GetUserDecisionAboutTesting()
        {
            string? userInput = Console.ReadLine();
            string? userAnswer = userInput?.Trim().ToLower();
            while (String.IsNullOrEmpty(userInput) || userAnswer != "да" && userAnswer != "нет")
            {
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.Write("\x1b[1A"); // перевод курсора в начало предыдущей строки
                    userInput = Console.ReadLine();
                    userAnswer = userInput?.Trim().ToLower();

                }
                else
                {
                    Console.Write("\x1b[1A"); // перевод курсора в начало предыдущей строки
                    Console.Write(new string(' ', userInput.Length) + "\r");
                    userInput = Console.ReadLine();
                    userAnswer = userInput?.Trim().ToLower();
                }
            }
            return userAnswer == "да" ? true : false; ;
        }
    }
}
