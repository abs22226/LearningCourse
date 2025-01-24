namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int moveCount;

        public MainForm()
        {
            InitializeComponent();

            MaximumSize = Size;
            MinimumSize = Size;
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
                    StartOver();
                }
            }
            else
            {
                //MessageBox.Show("Ура! Вы выиграли за минимальное количество шагов.");
                Image image = Properties.Resources.frog;
                CustomMessageBox.Show("Ура! Вы выиграли за минимальное количество шагов.", image);
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

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartOver();
        }

        private void StartOver()
        {
            moveCount = 0;
            ShowMoveCount();
            OrganizePictureBoxes();
            EnablePictureBoxes();
        }

        private void OrganizePictureBoxes()
        {
            leftPictureBox1.Location = new Point(0, 25);
            leftPictureBox2.Location = new Point(110, 25);
            leftPictureBox3.Location = new Point(220, 25);
            leftPictureBox4.Location = new Point(330, 25);
            emptyPictureBox.Location = new Point(440, 25);
            rightPictureBox1.Location = new Point(550, 25);
            rightPictureBox2.Location = new Point(660, 25);
            rightPictureBox3.Location = new Point(770, 25);
            rightPictureBox4.Location = new Point(880, 25);
        }

        private void EnablePictureBoxes()
        {
            leftPictureBox1.Enabled = true;
            leftPictureBox2.Enabled = true;
            leftPictureBox3.Enabled = true;
            leftPictureBox4.Enabled = true;
            rightPictureBox1.Enabled = true;
            rightPictureBox2.Enabled = true;
            rightPictureBox3.Enabled = true;
            rightPictureBox4.Enabled = true;
        }

        private void показатьПравилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры в том, чтобы расположить лягушек, которые смотрят влево, в левую часть, а остальных — в правую часть за минимальное количество перепрыгиваний. Прыгать можно на листок, если он находится рядом или через 1 лягушку.");
        }
    }
}
