﻿namespace GeniusIdiotWinFormsApp
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
            UserNameTextBox.KeyDown += UserNameTextBox_KeyDown;

            commentLabel.Text = string.Empty;
        }

        private void UserNameTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                startButton.Focus();
                StartButton_Click(sender, e);
            }
        }

        private void WelcomeForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var userInput = UserNameTextBox.Text;
            if (string.IsNullOrEmpty(userInput))
            {
                UserNameTextBox.Text = "Аноним";
            }
        }

        private void UserNameTextBox_GotFocus(object? sender, EventArgs e)
        {
            commentLabel.Text = string.Empty;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var userInput = UserNameTextBox.Text; 
            if (string.IsNullOrEmpty(userInput) || userInput.Trim() == string.Empty)
            {
                commentLabel.Text = "Необходимо ввести имя!";
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
