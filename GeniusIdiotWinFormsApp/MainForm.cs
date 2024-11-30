using GeniusIdiotConsApp;
using System;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<Question> questions;
        private int initialQuestionsCount;
        private Question currentQuestion;
        private User user;
        private int rightAnswersCount;

        public MainForm()
        {
            InitializeComponent();

            SetSizes();

            userAnswerTextBox.GotFocus += UserAnswerTextBox_GotFocus;
        }

        private void SetSizes()
        {
            this.MaximumSize = new Size(430, 489);
            this.MinimumSize = new Size(430, 489);

            questionTextLabel.MaximumSize = new Size(296, 90);

            commentTextLabel.MaximumSize = new Size(296, 90);
        }

        private void UserAnswerTextBox_GotFocus(object? sender, EventArgs e)
        {
            commentTextLabel.Text = string.Empty;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionsStorage.GetAll();
            initialQuestionsCount = questions.Count;

            user = new User("Гость");

            ShowRandomQuestion();



        }

        private void ShowRandomQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);

            currentQuestion = questions[randomIndex];
            questionTextLabel.Text = currentQuestion.Text;

            userAnswerTextBox.Clear();

            commentTextLabel.Text = string.Empty;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = GetNumericAnswer();

            if (userAnswer != null)
            {
                if (userAnswer == currentQuestion.Answer)
                {
                    rightAnswersCount++;
                }
                questions.Remove(currentQuestion);

                ShowRandomQuestion();
            }
        }

        private int? GetNumericAnswer()
        {
            string userInput = userAnswerTextBox.Text;
            int userAnswer;
            if (int.TryParse(userInput, out userAnswer))
            {
                return userAnswer;
            }
            else
            {
                commentTextLabel.Text = "Введите число от -2*10^9 до 2*10^9!";
                userAnswerTextBox.Clear();
                return null;
            }
        }
    }
}
