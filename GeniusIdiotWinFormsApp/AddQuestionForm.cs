using GeniusIdiotCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            questionCommentLabel.Text = string.Empty;
            answerCommentLabel.Text = string.Empty;
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
            if (string.IsNullOrEmpty(addedQuestionText) || addedQuestionText.Contains('#'))
            {
                questionCommentLabel.Text = "Необходимо ввести корректный текст!";
                addedQuestionTextBox.Clear();
            }
            else
            {
                int numericAnswer;
                if (int.TryParse(numericAnswerTextBox.Text, out numericAnswer))
                {
                    QuestionsStorage.Add(new Question(addedQuestionText.Trim(), numericAnswer));
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
