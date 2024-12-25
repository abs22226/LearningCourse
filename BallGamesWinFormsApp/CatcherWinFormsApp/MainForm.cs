using BallGamesWinFormsApp;

namespace CatcherWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<RandomSpeedMovingBall> balls;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
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

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var ball = new RandomSpeedMovingBall(this);
                balls.Add(ball);
                ball.Start();
            }
        }
    }
}
