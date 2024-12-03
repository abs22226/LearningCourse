namespace GeniusIdiotWinFormsApp
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            FormClosing += WelcomeForm_FormClosing;
            UserNameTextBox.GotFocus += UserNameTextBox_GotFocus;
            CommentTextLabel.Text = string.Empty;
        }

        private void WelcomeForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var userInput = UserNameTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Contains('#'))
            {
                UserNameTextBox.Text = "Аноним";
            }
        }

        private void UserNameTextBox_GotFocus(object? sender, EventArgs e)
        {
            CommentTextLabel.Text = string.Empty;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var userInput = UserNameTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Contains('#'))
            {
                CommentTextLabel.Text = "Необходимо ввести корректное имя!";
                UserNameTextBox.Clear();
            }
            else
            {
                UserNameTextBox.Text = userInput.Trim();
                Close();
            }
        }
    }
}
