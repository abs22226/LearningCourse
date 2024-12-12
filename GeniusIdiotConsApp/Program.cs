using GeniusIdiotCommon;
using System.Text;

namespace GeniusIdiotConsApp
{
    class Program
    {
        private static StringBuilder inputBuffer = new StringBuilder();
        private static object consoleLock = new object(); // Lock object
        private static ManualResetEvent answerReceived = new ManualResetEvent(false);
        private static int userAnswer;
        private static bool keepInputThreadRunning;


        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя:\n(до 20 символов)");
            var name = GetUserName();

            var user = new User();
            user.Name = name;



            var userIsReady = true;
            while (userIsReady)
            {
                var quiz = new Quiz(user);

                for (int i = 0; i < quiz.Length; i++)
                {
                    quiz.RandomizeCurrentQuestion();

                    lock (consoleLock)
                    {
                        Console.WriteLine("Вопрос №" + (quiz.CurrentQuestionNumber));
                        Console.WriteLine(quiz.CurrentQuestion.Text);
                        Console.WriteLine($"Time left: 10");
                    }

                    userAnswer = int.MinValue;
                    answerReceived.Reset();

                    // Start a new thread for input handling
                    Thread inputThread = new Thread(HandleUserInput);
                    keepInputThreadRunning = true;
                    inputThread.Start();

                    for (int seconds = 10; seconds >= 0; seconds--)
                    {
                        lock (consoleLock)
                        {
                            Console.CursorTop--;
                            Console.WriteLine(seconds < 10 ? $"\rTime left: 0{seconds}" : $"\rTime left: {seconds}");
                            Console.Write(inputBuffer);
                        }
                        Thread.Sleep(1000);

                        if (answerReceived.WaitOne(0)) // Check if the event is set
                        {
                            break; // Exit the countdown loop if an answer is received
                        }

                        if (seconds == 0)
                        {
                            Console.Write("\r" + new string(' ', inputBuffer.Length) + "\r" + string.Empty);
                        }
                    }

                    keepInputThreadRunning = false;

                    quiz.AcceptUserAnswer(userAnswer);

                    inputBuffer.Clear();

                    lock (consoleLock)
                    {
                        Console.WriteLine();
                    }
                }

                ShowUserDiagnosis(user, quiz);

                UsersStorage.Append(user);

                Console.WriteLine("Хотите посмотреть историю результатов? (Да/Нет)");
                userIsReady = GetUserDecision();
                if (userIsReady)
                {
                    ShowHistory();
                }

                Console.WriteLine("Хотите добавить новый вопрос? (Да/Нет)");
                userIsReady = GetUserDecision();
                if (userIsReady)
                {
                    AddNewQuestion();
                }

                Console.WriteLine("Хотите удалить какой-то вопрос? (Да/Нет)");
                userIsReady = GetUserDecision();
                if (userIsReady)
                {
                    RemoveQuestion();
                }

                Console.WriteLine("Хотите пройти тест снова? (Да/Нет)");
                userIsReady = GetUserDecision();
                if (userIsReady)
                {
                    Console.Clear();
                    quiz.ResetUserResult();
                }
            }
        }

        private static void HandleUserInput()
        {
            inputBuffer.Clear();

            while (keepInputThreadRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        var userInput = inputBuffer.ToString();
                        if (int.TryParse(userInput, out userAnswer))
                        {
                            if (userAnswer.ToString().Length < userInput.Length)
                            {                                
                                lock (consoleLock)
                                {
                                    Console.Write(string.IsNullOrEmpty(userInput) ? "\r" + string.Empty : "\r" + new string(' ', userInput.Length) + "\r" + string.Empty);
                                    Console.Write(userAnswer);
                                }
                            }
                            answerReceived.Set();
                        }
                        else
                        {
                            lock (consoleLock)
                            {
                                Console.Write(string.IsNullOrEmpty(userInput) ? "\r" + string.Empty : "\r" + new string(' ', userInput.Length) + "\r" + string.Empty);
                            }
                            inputBuffer.Clear();
                        }
                    }
                    else if (key.Key == ConsoleKey.Backspace && inputBuffer.Length > 0)
                    {
                        lock (consoleLock)
                        {
                            Console.Write("\b \b"); // Erase the last character
                        }
                        inputBuffer.Length--;
                    }
                    else
                    {
                        inputBuffer.Append(key.KeyChar);
                        lock (consoleLock)
                        {
                            Console.Write(key.KeyChar);
                        }
                    }
                }
            }
        }

        private static void ShowUserDiagnosis(User user, Quiz quiz)
        {
            quiz.SetUserScore();
            Console.WriteLine("Количество правильных ответов: " + user.Score);

            quiz.SetUserDiagnosis();
            Console.WriteLine(user.Name + ", ваш диагноз: " + user.Diagnosis);
        }

        static string GetUserName()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    EraseFromConsole(userInput);
                }
                else
                {
                    var userName = userInput.Trim();
                    if (userName.Length > 20)
                    {
                        EraseFromConsole(userInput);
                    }
                    else
                    {
                        if (userName.Length < userInput.Length)
                        {
                            EraseFromConsole(userInput);
                            Console.WriteLine(userName);
                        }
                        return userName;
                    }
                }
            }
        }

        static void EraseFromConsole(string userInput)
        {
            Console.CursorTop--;
            Console.Write(string.IsNullOrEmpty(userInput) ? "\r" + string.Empty : "\r" + new string(' ', userInput.Length) + "\r");
        }

        static int GetNumericAnswer()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                int userAnswer;
                if (int.TryParse(userInput, out userAnswer))
                {
                    if (userAnswer.ToString().Length < userInput.Length)
                    {
                        EraseFromConsole(userInput);
                        Console.WriteLine(userAnswer);
                    }
                    return userAnswer;
                }
                else
                {
                    EraseFromConsole(userInput);
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                }
            }
        }

        static bool GetUserDecision()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    EraseFromConsole(userInput);
                }
                else
                {
                    var userAnswer = userInput.Trim().ToLower();
                    if (userAnswer != "да" && userAnswer != "нет")
                    {
                        EraseFromConsole(userInput);
                    }
                    else
                    {
                        if (userAnswer.Length < userInput.Length)
                        {
                            EraseFromConsole(userInput);
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
            var answer = GetNumericAnswer();

            QuestionsStorage.Append(new Question() { Text = text, Answer = answer });
        }

        static string GetNewQuestionText()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    EraseFromConsole(userInput);
                }
                else
                {
                    var newQuestionText = userInput.Trim();
                    if (newQuestionText.Length < userInput.Length)
                    {
                        EraseFromConsole(userInput);
                        Console.WriteLine(newQuestionText);
                    }
                    return newQuestionText;
                }
            }
        }

        static void RemoveQuestion()
        {
            var questions = QuestionsStorage.GetAll();
            Console.WriteLine("Введите номер вопроса для удаления:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }

            var number = GetQuestionNumber(questions.Count);
            var question = questions[number - 1];

            QuestionsStorage.Remove(question);
        }

        static int GetQuestionNumber(int questionsCount)
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                int number;
                if (int.TryParse(userInput, out number))
                {
                    if (number < 1 || number > questionsCount)
                    {
                        EraseFromConsole(userInput);
                        Console.WriteLine($"Введите число от 1 до {questionsCount}!");
                    }
                    else
                    {
                        if (number.ToString().Length < userInput.Length)
                        {
                            EraseFromConsole(userInput);
                            Console.WriteLine(number);
                        }
                        return number;
                    }
                }
                else
                {
                    EraseFromConsole(userInput);
                    Console.WriteLine($"Введите число от 1 до {questionsCount}!");
                }
            }
        }
    }
}
