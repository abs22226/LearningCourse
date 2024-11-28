namespace GeniusIdiotConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя:\n(до 20 символов, cимвол '#' недопустим)");
            var name = GetUserName();

            var user = new User(name);

            user.IsReady = true;

            while (user.IsReady)
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

                    var userAnswer = GetNumber();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        rightAnswersCount++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                }

                user.SetScore(rightAnswersCount, startingQuestionsCount);
                Console.WriteLine("Количество правильных ответов: " + user.Score);

                user.SetDiagnosis(rightAnswersCount, startingQuestionsCount);
                Console.WriteLine(user.Name + ", ваш диагноз: " + user.Diagnosis);

                UsersStorage.Save(user);

                Console.WriteLine("Хотите посмотреть историю результатов? (Да/Нет)");
                user.IsReady = GetUserDecision();
                if (user.IsReady)
                {
                    ShowHistory();
                }

                Console.WriteLine("Хотите добавить новый вопрос? (Да/Нет)");
                user.IsReady = GetUserDecision();
                if (user.IsReady)
                {
                    AddNewQuestion();
                }

                Console.WriteLine("Хотите пройти тест снова? (Да/Нет)");
                user.IsReady = GetUserDecision();
                if (user.IsReady)
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

        static int GetNumber()
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
            const int columnWidth = -20;
            Console.WriteLine($"|| {"Имя:",columnWidth} || {"Результат:",columnWidth} || {"Диагноз:",columnWidth} ||");

            var allUsers = UsersStorage.GetAll();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"|| {user.Name,columnWidth} || {user.Score,columnWidth} || {user.Diagnosis,columnWidth} ||");
            }
        }

        static void AddNewQuestion()
        {
            Console.WriteLine("Введите текст вопроса:");
            var text = GetNewQuestionText();
            Console.WriteLine("Введите ответ на вопрос:");
            var answer = GetNumber();

            QuestionsStorage.Add(new Question(text, answer));
        }

        static string GetNewQuestionText()
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
                    var newQuestionText = userInput.Trim();
                    if (newQuestionText.Length < userInput.Length)
                    {
                        Console.CursorTop--;
                        Console.Write("\r" + new string(' ', userInput.Length) + "\r");
                        Console.WriteLine(newQuestionText);
                    }
                    return newQuestionText;
                }
            }
        }
    }
}
