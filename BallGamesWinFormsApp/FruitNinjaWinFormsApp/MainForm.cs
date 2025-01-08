namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        private static Random random;
        private System.Windows.Forms.Timer timer;
        private List<FruitBall> balls;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            random = new Random();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            balls = new List<FruitBall>();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var count = random.Next(4, 11);
            for (int i = 0; i < count; i++)
            {
                var r = random.Next(0, 256);
                var g = random.Next(0, 256);
                var b = random.Next(0, 256);
                var randomColorBrush = new SolidBrush(Color.FromArgb(r, g, b));

                var ball = random.Next(5) == 4 ? new BombBall(this, Brushes.Black) : new FruitBall(this, randomColorBrush); // 20% of bombs                
                balls.Add(ball);
                ball.Start();
            }

            timer.Interval = random.Next(2000, 5000);
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

                    ball.Clear();
                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
        }

        private void EndGame()
        {
            timer.Stop();
            foreach (var ball in balls)
            {
                ball.Stop();
            }
            MessageBox.Show("Game over, mofo!");
        }
    }
}
