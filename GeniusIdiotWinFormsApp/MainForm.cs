using GeniusIdiotConsApp;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;

        public MainForm()
        {
            InitializeComponent();

            SetSizes();
        }

        private void SetSizes()
        {
            this.MaximumSize = new Size(430, 489);
            this.MinimumSize = new Size(430, 489);

            questionTextLabel.MaximumSize = new Size(296, 90);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionsStorage.GetAll();
            
            ShowRandomQuestion();

            
            
        }

        private void ShowRandomQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);

            currentQuestion = questions[randomIndex];
            questionTextLabel.Text = currentQuestion.Text;
        }
    }
}
