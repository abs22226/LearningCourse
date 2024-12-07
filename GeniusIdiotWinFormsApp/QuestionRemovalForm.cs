using GeniusIdiotCommon;

namespace GeniusIdiotWinFormsApp
{
    public partial class questionRemovalForm : Form
    {
        private List<Question> questions;

        public questionRemovalForm()
        {
            InitializeComponent();

            questionRemovalDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void DeleteQuestionForm_Load(object sender, EventArgs e)
        {
            questionNumberTextBox.GotFocus += QuestionNumberTextBox_GotFocus;
            questionNumberTextBox.KeyDown += QuestionNumberTextBox_KeyDown;

            commentLabel.Text = string.Empty;

            ShowQuestions();
        }

        private void QuestionNumberTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                deleteButton.Focus();
                DeleteButton_Click(sender, e);
            }
        }

        private void QuestionNumberTextBox_GotFocus(object? sender, EventArgs e)
        {
            commentLabel.Text = string.Empty;
        }

        private void ShowQuestions()
        {
            questions = QuestionsStorage.GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                questionRemovalDataGridView.Rows.Add($"{i + 1}.", questions[i].Text);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(questionNumberTextBox.Text, out number) && number >= 1 && number <= questions.Count)
            {
                var index = number - 1;
                var question = questions[index];
                QuestionsStorage.Remove(question);
                Close();
            }
            else
            {
                commentLabel.Text = $"Введите число от 1 до {questions.Count}!";
                questionNumberTextBox.Clear();
            }
        }
    }
}
