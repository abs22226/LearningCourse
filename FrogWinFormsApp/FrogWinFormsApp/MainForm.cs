using System.Diagnostics;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int moveCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            ShowMoveCount();
            if (GameOver())
            {                
                ProcessGameFinishing();
            }
        }

        private void ProcessGameFinishing()
        {
            DisablePictureBoxes();

            const int minMoveCount = 24;
            if (moveCount > minMoveCount)
            {
                var result = MessageBox.Show("Ура! Вы выиграли, но не за минимальное количество шагов. Попробуйте еще раз?", "Конец игры", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Ура! Вы выиграли за минимальное количество шагов.");
            }
        }

        private void DisablePictureBoxes()
        {
            leftPictureBox1.Enabled = false;
            leftPictureBox2.Enabled = false;
            leftPictureBox3.Enabled = false;
            leftPictureBox4.Enabled = false;
            rightPictureBox1.Enabled = false;
            rightPictureBox2.Enabled = false;
            rightPictureBox3.Enabled = false;
            rightPictureBox4.Enabled = false;
        }

        private bool GameOver()
        {
            return leftPictureBox1.Location.X > emptyPictureBox.Location.X &&
                   leftPictureBox2.Location.X > emptyPictureBox.Location.X &&
                   leftPictureBox3.Location.X > emptyPictureBox.Location.X &&
                   leftPictureBox4.Location.X > emptyPictureBox.Location.X &&
                   rightPictureBox1.Location.X < emptyPictureBox.Location.X &&
                   rightPictureBox2.Location.X < emptyPictureBox.Location.X &&
                   rightPictureBox3.Location.X < emptyPictureBox.Location.X &&
                   rightPictureBox4.Location.X < emptyPictureBox.Location.X;
        }

        private void ShowMoveCount()
        {
            moveCountLabel.Text = $"Количество ходов - {moveCount}";
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distanceToEmptyPictureBox = Math.Abs(clickedPictureBox.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distanceToEmptyPictureBox > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clickedPictureBox.Location;
                clickedPictureBox.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                moveCount++;
            }
        }
    }
}
