namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        private static Random random;
        private System.Windows.Forms.Timer mainFormTimer;
        private System.Windows.Forms.Timer slowdownTimer;
        private int slowdownMultiplier;
        private List<FruitBall> balls;
        private bool thereIsNoCatchedBananas;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            random = new Random();

            mainFormTimer = new System.Windows.Forms.Timer();
            mainFormTimer.Interval = 1000;
            mainFormTimer.Tick += MainFormTimer_Tick;
            mainFormTimer.Start();

            slowdownTimer = new System.Windows.Forms.Timer();
            slowdownTimer.Interval = 3000;
            slowdownTimer.Tick += SlowdownTimer_Tick;

            slowdownLabel.Text = string.Empty;
            slowdownMultiplier = 2;

            balls = new List<FruitBall>();

            thereIsNoCatchedBananas = true;
        }

        private void MainFormTimer_Tick(object? sender, EventArgs e)
        {
            var count = random.Next(4, 11);
            for (int i = 0; i < count; i++)
            {
                FruitBall ball;
                var randomizer = random.Next(5);
                if (randomizer == 4)
                {
                    ball = new BombBall(this, Brushes.Black);

                }
                else if (randomizer == 3)
                {
                    ball = new BananaBall(this, Brushes.Yellow);
                }
                else
                {
                    var r = random.Next(0, 256);
                    var g = random.Next(0, 256);
                    var b = random.Next(0, 256);
                    var randomColorBrush = new SolidBrush(Color.FromArgb(r, g, b));
                    ball = new FruitBall(this, randomColorBrush);
                }

                if (thereIsNoCatchedBananas == false)
                {
                    ball.G /= slowdownMultiplier;
                    ball.MoveX /= slowdownMultiplier;
                    ball.MoveY /= slowdownMultiplier;
                }

                balls.Add(ball);
                ball.Start();
            }

            mainFormTimer.Interval = random.Next(2000, 5000);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var ball in balls)
            {
                if (ball.IsInMotion() && ball.IsUnderCursor(new PointF(e.X, e.Y)))
                {
                    ball.Stop();
                    if (ball is BombBall)
                    {
                        EndGame();
                        return;
                    }
                    if (ball is BananaBall && thereIsNoCatchedBananas)
                    {
                        SlowDownBalls();
                    }
                    ball.Clear();
                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
        }

        private void SlowDownBalls()
        {
            thereIsNoCatchedBananas = false;

            foreach (var ball in balls)
            {
                ball.G /= slowdownMultiplier;
                ball.MoveX /= slowdownMultiplier;
                ball.MoveY /= slowdownMultiplier;
            }

            slowdownTimer.Start();
            slowdownLabel.Text = "ÇÀÌÅÄËÅÍÈÅ";
        }

        private void SlowdownTimer_Tick(object? sender, EventArgs e)
        {
            slowdownTimer.Stop();

            foreach (var ball in balls)
            {
                ball.G *= slowdownMultiplier;
                ball.MoveX *= slowdownMultiplier;
                ball.MoveY *= slowdownMultiplier;
            }

            thereIsNoCatchedBananas = true;

            slowdownLabel.Text = string.Empty;
        }

        private void EndGame()
        {
            mainFormTimer.Stop();
            foreach (var ball in balls)
            {
                ball.Stop();
            }
            MessageBox.Show("ÁÀÁÀÕ! Íà÷èíàåì çàíîâî.");
            Application.Restart();
        }
    }
}
