namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomSpeedAndPointBall> balls;

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

            balls = new List<RandomSpeedAndPointBall>();
            for (int i = 0; i < 5; i++)
            {
                var ball = new RandomSpeedAndPointBall(this);
                balls.Add(ball);
                ball.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            var ballsCount = 0;
            foreach (var ball in balls)
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
            foreach (var ball in balls)
            {
                ball.Clear();
            }

            clearButton.Enabled = false;
            startButton.Enabled = true;
        }
    }
}
