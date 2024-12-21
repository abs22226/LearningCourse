using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class StartForm : Form
    {
        public List<RadioButton> radioButtons;
        private bool startButtonIsPressed;

        public StartForm()
        {
            InitializeComponent();

            radioButtons = new List<RadioButton>()
            {
                radioButton1, radioButton2, radioButton3, radioButton4
            };

            radioButton1.Checked = true;

            FormClosing += StartForm_FormClosing;
            userNameTextBox.KeyDown += UserNameTextBox_KeyDown;
        }

        private void StartForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!startButtonIsPressed)
            {
                userNameTextBox.Text = "Аноним";
            }
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            startButtonIsPressed = true;

            var userInput = userNameTextBox.Text;
            if (string.IsNullOrEmpty(userInput) || userInput.Trim() == string.Empty)
            {
                userNameTextBox.Text = "Аноним";
                Close();
            }
            else
            {
                userNameTextBox.Text = userInput.Trim();
                Close();
            }
        }
    }
}
