using BallGamesWinFormsApp;

namespace CatcherWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<RandomSpeedMovingBall> balls;
        private int score = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(balls == null)
            { 
                return;
            }

            var cursorPoint = new Point(e.X, e.Y);
            foreach (var ball in balls)
            {
                if (ball.IsInMotion() && 
                    ball.IsUnderCursor(cursorPoint))
                {
                    ball.Stop();
                    score++;
                    break;
                }
            }
            scoreLabel.Text = score.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            clearButton.Enabled = true;

            balls = new List<RandomSpeedMovingBall>();
            for (int i = 0; i < 5; i++)
            {
                var ball = new RandomSpeedMovingBall(this);
                balls.Add(ball);
                ball.Start();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Stop();
                ball.Clear();
            }

            clearButton.Enabled = false;
            startButton.Enabled = true;
            scoreLabel.Text = "0";
            score = 0;
        }
    }
}
