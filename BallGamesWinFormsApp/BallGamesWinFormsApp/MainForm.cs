namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomSpeedMovingBall> movingBalls;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            clearButton.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = true;
            startButton.Enabled = false;

            movingBalls = new List<RandomSpeedMovingBall>();
            for (int i = 0; i < 5; i++)
            {
                var movingBall = new RandomSpeedMovingBall(this);
                movingBalls.Add(movingBall);
                movingBall.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
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

            stopButton.Enabled = false;
            clearButton.Enabled = true;
        }        

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var ball in movingBalls)
            {
                ball.Clear();
            }

            clearButton.Enabled = false;
            startButton.Enabled = true;
        }
    }
}
