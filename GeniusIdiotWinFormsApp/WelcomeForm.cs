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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            UserNameTextBox.GotFocus += UserNameTextBox_GotFocus;

            CommentTextLabel.Text = string.Empty;            
        }

        private void UserNameTextBox_GotFocus(object? sender, EventArgs e)
        {
            CommentTextLabel.Text = string.Empty;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var name = GetUserName();
            if (!string.IsNullOrEmpty(name))
            {
                UserNameTextBox.Text = name;
                Close();
            }
        }

        private string? GetUserName()
        {
            var userInput = UserNameTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Contains('#'))
            {
                CommentTextLabel.Text = "Необходимо ввести корректное имя!";
                UserNameTextBox.Clear();
                return null;
            }
            else
            {
                var userName = userInput.Trim();
                return userName;
            }
        }
    }
}
