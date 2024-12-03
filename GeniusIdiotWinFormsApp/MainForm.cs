using GeniusIdiotCommon;
using System.Xml.Linq;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<Question> questions;
        private int startingQuestionsCount;
        private Question currentQuestion;
        private int questionNumber;
        private User user;
        private int rightAnswersCount;
        private string newQuestionText;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserAnswerTextBox.GotFocus += UserAnswerTextBox_GotFocus;

            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();

            user = new User(welcomeForm.UserNameTextBox.Text);

            StartNewQuiz();
        }

        private void UserAnswerTextBox_GotFocus(object? sender, EventArgs e)
        {
            CommentTextLabel.Text = string.Empty;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (QuestionNumberLabel.Text.StartsWith("Вопрос № "))
            {
                HandleGettingNumericAnswer();
            }
            else if (QuestionTextLabel.Text.StartsWith("Введите"))
            {
                HandleQuestionsStorageModification();
            }
            else
            {
                HandleGettingDecision();
            }
        }

        private void StartNewQuiz()
        {
            ResetScoring();
            ClearForms();

            questions = QuestionsStorage.GetAll();
            startingQuestionsCount = questions.Count;

            ShowRandomQuestion();
        }

        private void ResetScoring()
        {
            startingQuestionsCount = 0;
            questionNumber = 0;
            rightAnswersCount = 0;
        }

        private void ClearForms()
        {
            QuestionNumberLabel.Text = string.Empty;
            QuestionTextLabel.Text = string.Empty;
            UserAnswerTextBox.Clear();
            CommentTextLabel.Text = string.Empty;

            QuestionNumberLabel.ForeColor = Color.Black;
        }

        private void ShowRandomQuestion()
        {
            ClearForms();

            questionNumber++;
            QuestionNumberLabel.Text = "Вопрос № " + questionNumber;

            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            QuestionTextLabel.Text = currentQuestion.Text;

            UserAnswerTextBox.Focus();
        }



        private void HandleGettingNumericAnswer()
        {
            var userAnswer = GetNumericAnswer();

            if (userAnswer != null)
            {
                if (userAnswer == currentQuestion.Answer)
                {
                    rightAnswersCount++;
                }

                questions.Remove(currentQuestion);

                if (questions.Count > 0)
                {
                    ShowRandomQuestion();
                }
                else
                {
                    FinishTheQuiz();
                }
            }
        }

        private int? GetNumericAnswer()
        {
            string userInput = UserAnswerTextBox.Text;
            int userAnswer;
            if (int.TryParse(userInput, out userAnswer))
            {
                return userAnswer;
            }
            else
            {
                UserAnswerTextBox.Clear();
                CommentTextLabel.Text = "Введите число от -2*10^9 до 2*10^9!";
                return null;
            }
        }

        private void FinishTheQuiz()
        {
            ClearForms();

            user.SetScore(rightAnswersCount, startingQuestionsCount);
            user.SetDiagnosis(rightAnswersCount, startingQuestionsCount);

            var userIsPathetic = user.Diagnosis == "идиот" || user.Diagnosis == "кретин" || user.Diagnosis == "дурак";
            QuestionNumberLabel.ForeColor = userIsPathetic ? Color.Red : Color.Green;

            QuestionNumberLabel.Text = $"Количество правильных ответов: {user.Score}\n{user.Name}, ваш диагноз: {user.Diagnosis.ToUpper()}";

            UsersStorage.Save(user);

            QuestionTextLabel.Text = "Хотите посмотреть историю результатов? (да/нет)";

            UserAnswerTextBox.Focus();
        }

        private void HandleQuestionsStorageModification()
        {
            if (QuestionTextLabel.Text == "Введите текст вопроса:\n- символ # недопустим")
            {
                var questionText = GetNewQuestionText();
                if (!string.IsNullOrEmpty(questionText))
                {
                    newQuestionText = questionText;

                    DisplayText("Введите числовой ответ:");
                }
            }
            else if (QuestionTextLabel.Text == "Введите числовой ответ:")
            {
                var numericAnswer = GetNumericAnswer();
                if (numericAnswer != null)
                {
                    QuestionsStorage.Add(new Question(newQuestionText, (int)numericAnswer));

                    DisplayText("Хотите удалить какой-то вопрос? (да/нет)");
                }
            }
            else if (QuestionTextLabel.Text == "Введите номер вопроса для удаления:")
            {
                var number = GetQuestionNumber(questions.Count);
                if (number != null)
                {
                    var index = (int)number - 1;
                    var question = questions[index];
                    QuestionsStorage.Remove(question);

                    DisplayText("Хотите пройти тест снова? (да/нет)");
                }
            }
        }

        private string? GetNewQuestionText()
        {
            var userInput = UserAnswerTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Contains('#'))
            {
                CommentTextLabel.Text = "Необходимо ввести корректный текст!";
                UserAnswerTextBox.Clear();
                return null;
            }
            else
            {
                var newQuestionText = userInput.Trim();
                return newQuestionText;
            }
        }

        private int? GetQuestionNumber(int questionsCount)
        {
            var userInput = UserAnswerTextBox.Text;
            int number;
            if (int.TryParse(userInput, out number) && number >= 1 && number <= questionsCount)
            {
                return number;
            }
            else
            {
                UserAnswerTextBox.Clear();
                CommentTextLabel.Text = $"Введите число от 1 до {questionsCount}!";
                return null;
            }
        }

        private void HandleGettingDecision()
        {
            var userIsReady = GetUserDecision();
            if (userIsReady.HasValue)
            {
                if (QuestionTextLabel.Text == "Хотите добавить новый вопрос? (да/нет)")
                {
                    if ((bool)userIsReady) DisplayText("Введите текст вопроса:\n- символ # недопустим");
                    else DisplayText("Хотите удалить какой-то вопрос? (да/нет)");
                }
                else if (QuestionTextLabel.Text == "Хотите удалить какой-то вопрос? (да/нет)")
                {
                    if ((bool)userIsReady) InitiateQuestionRemoval();
                    else DisplayText("Хотите пройти тест снова? (да/нет)");
                }
                else if (QuestionTextLabel.Text == "Хотите пройти тест снова? (да/нет)")
                {
                    if ((bool)userIsReady) StartNewQuiz();
                    else CloseTheApp();
                }
            }
        }

        private bool? GetUserDecision()
        {
            var userInput = UserAnswerTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Trim().ToLower() != "да" && userInput.Trim().ToLower() != "нет")
            {
                CommentTextLabel.Text = "Необходимо ввести: да или нет!";
                UserAnswerTextBox.Clear();
                return null;
            }
            else
            {
                var userDecision = userInput.Trim().ToLower();
                if (userDecision.Length < userInput.Length)
                {
                    UserAnswerTextBox.Text = userDecision;
                }
                return userDecision == "да" ? true : false;
            }
        }

        private void DisplayText(string text)
        {
            QuestionTextLabel.Text = text;
            UserAnswerTextBox.Clear();
            CommentTextLabel.Text = string.Empty;

            UserAnswerTextBox.Focus();
        }

        private void InitiateQuestionRemoval()
        {
            questions = QuestionsStorage.GetAll();

            var text = string.Empty;
            for (int i = 0; i < questions.Count; i++)
            {
                text += $"\n{i + 1}. {questions[i].Text}";
            }

            DisplayText("Запомните номер вопроса для удаления:");

            var pressedMessageBoxButton = MessageBox.Show(text);
            if (pressedMessageBoxButton == DialogResult.OK || pressedMessageBoxButton == DialogResult.Cancel)
            {
                DisplayText("Введите номер вопроса для удаления:");
            }
        }

        private void CloseTheApp()
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void показатьИсториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm();
            historyForm.ShowDialog();
        }
    }
}
