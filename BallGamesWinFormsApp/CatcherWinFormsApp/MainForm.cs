using BallsCommon;

namespace CatcherWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<RandomSpeedAndDirectionBall> balls;
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

            var cursorPoint = new PointF(e.X, e.Y);
            foreach (var ball in balls)
            {
                if (ball.IsOnMainForm() &&
                    ball.IsInMotion() && 
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

            balls = new List<RandomSpeedAndDirectionBall>();
            for (int i = 0; i < 5; i++)
            {
                var ball = new RandomSpeedAndDirectionBall(this, Brushes.DodgerBlue);
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
