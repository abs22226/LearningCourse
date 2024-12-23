namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomSpeedMovingBall> movingBalls;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            movingBalls = new List<RandomSpeedMovingBall>();

            for (int i = 0; i < 5; i++)
            {
                var movingBall = new RandomSpeedMovingBall(this);
                movingBalls.Add(movingBall);
                movingBall.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ballsCount = 0;
            foreach (var ball in movingBalls)
            {
                ball.Stop();
                if (ball.IsOnMainForm())
                {
                    ballsCount++;
                }
            }

            MessageBox.Show(ballsCount.ToString());
        }
    }
}
