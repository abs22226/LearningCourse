using GeniusIdiotCommon;
using System.Text;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        private Quiz quiz;
        private User user;
        private int ticks;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            userAnswerTextBox.GotFocus += UserAnswerTextBox_GotFocus;
            userAnswerTextBox.KeyDown += UserAnswerTextBox_KeyDown;

            MeetNewUser();
            StartNewQuiz();
        }

        private void UserAnswerTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                nextButton.Focus();
                NextButton_Click(sender, e);
            }
        }

        private void UserAnswerTextBox_GotFocus(object? sender, EventArgs e)
        {
            commentLabel.Text = string.Empty;
        }

        private void MeetNewUser()
        {
            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();

            user = new User();
            user.Name = welcomeForm.UserNameTextBox.Text;
        }

        private void StartNewQuiz()
        {
            ClearForms();

            quiz = new Quiz(user);
            quiz.ResetUserResult();

            if (quiz.Length != 0)
            {
                questionNumberLabel.Text = "Начинаем новый квиз:";
                string preview = $"У вас будет 10 секунд на ответ, после чего, при отсутствии ответа, он будет засчитан как неверный, и появится следующий вопрос.";
                questionTextLabel.Text = preview;
                userAnswerTextBox.Visible = false;
                nextButton.Visible = true;
            }
            else
            {
                questionNumberLabel.Text = "Список вопросов пуст.";
                questionTextLabel.Text = "Необходимо добавить хотя бы один вопрос через соответствующую форму меню.";
                userAnswerTextBox.Visible = false;
                nextButton.Visible = false;
            }
        }

        private void ClearForms()
        {
            questionNumberLabel.Text = string.Empty;
            timerLabel.Text = string.Empty;
            questionTextLabel.Text = string.Empty;
            userAnswerTextBox.Clear();
            commentLabel.Text = string.Empty;

            questionTextLabel.ForeColor = Color.Black;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (questionNumberLabel.Text == "Начинаем новый квиз:")
            {
                userAnswerTextBox.Visible = true;
                ShowRandomQuestion();
            }
            else
            {
                var userAnswer = GetNumericAnswer();

                if (userAnswer != null)
                {
                    quiz.AcceptUserAnswer(userAnswer);

                    if (quiz.IsEnded)
                    {
                        FinishTheQuiz();
                    }
                    else
                    {
                        ShowRandomQuestion();
                    }
                }
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
                userAnswerTextBox.Clear();
                commentLabel.Text = "Введите число от -2*10^9 до 2*10^9!";
                return null;
            }
        }

        private void ShowRandomQuestion()
        {
            ClearForms();

            quiz.RandomizeCurrentQuestion();

            questionNumberLabel.Text = "Вопрос № " + quiz.CurrentQuestionNumber;
            questionTextLabel.Text = quiz.CurrentQuestion.Text;

            userAnswerTextBox.Focus();

            timerLabel.Text = ":10";
            StartTimer();
        }

        private void StartTimer()
        {
            ticks = 0;
            questionTimer.Start();
        }

        private void FinishTheQuiz()
        {
            StopTimer();

            quiz.SetUserScore();
            quiz.SetUserDiagnosis();

            ShowDiagnosis();

            UsersStorage.Append(user);
        }

        private void StopTimer()
        {
            questionTimer.Stop();
            ticks = 0;
        }

        private void ShowDiagnosis()
        {
            ClearForms();
            userAnswerTextBox.Visible = false;
            nextButton.Visible = false;

            var userIsPathetic = user.Diagnosis == "идиот" || user.Diagnosis == "кретин" || user.Diagnosis == "дурак";
            questionTextLabel.ForeColor = userIsPathetic ? Color.Red : Color.Green;
            questionTextLabel.Text = $"Количество правильных ответов: {user.Score}\n{user.Name}, ваш диагноз: {user.Diagnosis.ToUpper()}";

            commentLabel.Text = "Перейдите в меню в левом верхнем углу!";
        }

        private void НачатьНовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopTimer();
            StartNewQuiz();
        }

        private void ПоказатьИсториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var quizInProcess = !string.IsNullOrEmpty(questionNumberLabel.Text);
            if (quizInProcess)
            {
                StopTimer();
                ClearForms();
            }

            var historyForm = new HistoryForm();
            historyForm.ShowDialog();

            if (quizInProcess)
            {
                StartNewQuiz();
            }
        }

        private void СписокВопросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var quizInProcess = !string.IsNullOrEmpty(questionNumberLabel.Text);
            if (quizInProcess)
            {
                StopTimer();
                ClearForms();
            }

            var questionsListForm = new QuestionsListForm();
            questionsListForm.ShowDialog();

            if (quizInProcess)
            {
                StartNewQuiz();
            }
        }

        private void ДобавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var quizInProcess = !string.IsNullOrEmpty(questionNumberLabel.Text);
            if (quizInProcess)
            {
                StopTimer();
                ClearForms();
            }

            var addQuestionForm = new AddQuestionForm();
            addQuestionForm.ShowDialog();

            if (quizInProcess)
            {
                StartNewQuiz();
            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ПерезапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            var remainingSeconds = 10 - ticks;
            timerLabel.Text = $":0{remainingSeconds}";

            if (remainingSeconds < 0)
            {
                quiz.RemoveCurrentQuestion();

                if (quiz.IsEnded)
                {
                    FinishTheQuiz();
                }
                else
                {
                    ShowRandomQuestion();
                }
            }

        }
    }
}
