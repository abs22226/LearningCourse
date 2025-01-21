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
                if (moveCount > 24)
                {
                    var result = MessageBox.Show("���! �� ��������, �� �� �� ����������� ���������� �����. ���������� ��� ���?", "����� ����", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
                else
                {
                    MessageBox.Show("���! �� �������� �� ����������� ���������� �����.");
                }
            }
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
            moveCountLabel.Text = $"���������� ����� - {moveCount}";
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distanceToEmptyPictureBox = Math.Abs(clickedPictureBox.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distanceToEmptyPictureBox > 2)
            {
                MessageBox.Show("��� ������!");
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
