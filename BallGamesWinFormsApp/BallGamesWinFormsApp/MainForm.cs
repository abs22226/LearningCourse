namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomSizeAndPointBall> randomSizeAndPointBalls = new List<RandomSizeAndPointBall>();
        PointBall pointBall;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                randomSizeAndPointBalls[i].Move();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var randomSizeAndPointBall = new RandomSizeAndPointBall(this);
                randomSizeAndPointBalls.Add(randomSizeAndPointBall);
            }
            timer.Start();
        }
    }
}
