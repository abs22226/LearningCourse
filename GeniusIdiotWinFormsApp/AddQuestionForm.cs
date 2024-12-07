using GeniusIdiotCommon;

namespace GeniusIdiotWinFormsApp
{
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {
            addedQuestionTextBox.GotFocus += AddedQuestionTextBox_GotFocus;
            numericAnswerTextBox.GotFocus += NumericAnswerTextBox_GotFocus;

            addedQuestionTextBox.KeyDown += AddedQuestionTextBox_KeyDown;
            numericAnswerTextBox.KeyDown += NumericAnswerTextBox_KeyDown;

            questionCommentLabel.Text = string.Empty;
            answerCommentLabel.Text = string.Empty;
        }

        private void NumericAnswerTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AddingButton_Click(sender, e);
            }
        }

        private void AddedQuestionTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AddingButton_Click(sender, e);
            }
        }

        private void AddedQuestionTextBox_GotFocus(object? sender, EventArgs e)
        {
            questionCommentLabel.Text = string.Empty;
        }

        private void NumericAnswerTextBox_GotFocus(object? sender, EventArgs e)
        {
            answerCommentLabel.Text = string.Empty;
        }

        private void AddingButton_Click(object sender, EventArgs e)
        {
            var addedQuestionText = addedQuestionTextBox.Text;
            if (string.IsNullOrEmpty(addedQuestionText))
            {
                questionCommentLabel.Text = "Необходимо ввести текст!";
                addedQuestionTextBox.Clear();
            }
            else
            {
                int numericAnswer;
                if (int.TryParse(numericAnswerTextBox.Text, out numericAnswer))
                {
                    QuestionsStorage.Append(new Question() { Text = addedQuestionText.Trim(), Answer = numericAnswer });
                    Close();
                }
                else
                {
                    addedQuestionTextBox.Text = addedQuestionText.Trim();
                    answerCommentLabel.Text = "Введите число от -2*10^9 до 2*10^9!";
                    numericAnswerTextBox.Clear();
                }
            }
        }
    }
}
