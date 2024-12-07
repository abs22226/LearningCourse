using GeniusIdiotCommon;

namespace GeniusIdiotWinFormsApp
{
    public partial class QuestionsListForm : Form
    {
        private List<Question> questions;

        public QuestionsListForm()
        {
            InitializeComponent();

            questionRemovalDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void DeleteQuestionForm_Load(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            questions = QuestionsStorage.GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                questionRemovalDataGridView.Rows.Add(questions[i].Text);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedCells = questionRemovalDataGridView.SelectedCells;
            for (int i = 0; i < selectedCells.Count; i++)
            {
                var allRows = questionRemovalDataGridView.Rows;
                for (int j = 0; j < allRows.Count - 1; j++)
                {
                    var row = allRows[j];
                    var selectedCell = selectedCells[i];
                    if (row.Cells.Contains(selectedCell))
                    {
                        var selectedQuestion = GetQuestion(selectedCell);
                        QuestionsStorage.Remove(selectedQuestion);
                        questions = QuestionsStorage.GetAll();

                        questionRemovalDataGridView.Rows.RemoveAt(j);
                        j--;

                        break;
                    }
                }
            }
        }

        private Question GetQuestion(DataGridViewCell selectedCell)
        {
            foreach (var question in questions)
            {
                if (question.Text == selectedCell.FormattedValue.ToString())
                {
                    return question;
                }
            }
            return new Question();
        }
    }
}
