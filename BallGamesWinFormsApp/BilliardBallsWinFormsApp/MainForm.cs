using BallsCommon;

namespace BilliardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<BilliardBall> billiardBalls;
        private System.Windows.Forms.Timer billiardBallsTimer;
        private const int ballsCount = 20;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            billiardBalls = new List<BilliardBall>();
            for (int i = 0; i < ballsCount / 2; i++)
            {
                var blueBall = new BilliardBall(this, Brushes.DodgerBlue);
                blueBall.OnEdgeHitting += BlueBall_OnEdgeHitting;
                blueBall.Start();
                billiardBalls.Add(blueBall);

                var redBall = new BilliardBall(this, Brushes.Red);
                redBall.OnEdgeHitting += RedBall_OnEdgeHitting;
                redBall.Start();
                billiardBalls.Add(redBall);
            }

            billiardBallsTimer = new System.Windows.Forms.Timer();
            billiardBallsTimer.Interval = 15;
            billiardBallsTimer.Tick += BilliardBallsTimer_Tick;
            billiardBallsTimer.Start();
        }

        private void BilliardBallsTimer_Tick(object? sender, EventArgs e)
        {
            ShowMiddleVerticalLine();

            var leftBlueBallsCount = 0;
            var rightBlueBallsCount = 0;

            var leftRedBallsCount = 0;
            var rightRedBallsCount = 0;

            foreach (var ball in billiardBalls)
            {
                leftBlueBallsCount += ball.IsLeftFromCenter && ball.Brush == Brushes.DodgerBlue ? 1 : 0;
                rightBlueBallsCount += ball.IsRightFromCenter && ball.Brush == Brushes.DodgerBlue ? 1 : 0;

                leftRedBallsCount += ball.IsLeftFromCenter && ball.Brush == Brushes.Red ? 1 : 0;
                rightRedBallsCount += ball.IsRightFromCenter && ball.Brush == Brushes.Red ? 1 : 0;
            }

            if (leftBlueBallsCount == leftRedBallsCount && rightBlueBallsCount == rightRedBallsCount &&
                leftBlueBallsCount == rightBlueBallsCount &&
                leftBlueBallsCount + leftRedBallsCount + rightBlueBallsCount + rightRedBallsCount == ballsCount)
            {
                foreach (var ball in billiardBalls)
                {
                    ball.Stop();
                }
                billiardBallsTimer.Stop();
                MessageBox.Show("Произошло полное перемешивание");
                Close();
            }
        }

        private void ShowMiddleVerticalLine()
        {
            var graphics = CreateGraphics();
            graphics.DrawLine(Pens.Black, ClientSize.Width / 2, 0, ClientSize.Width / 2, ClientSize.Height);
        }

        private void BlueBall_OnEdgeHitting(object? sender, HitEventArgs e)
        {
            switch (e.Edge)
            {
                case Edges.Left: blueLeftLabel.Text = (Convert.ToInt32(blueLeftLabel.Text) + 1).ToString(); break;
                case Edges.Right: blueRightLabel.Text = (Convert.ToInt32(blueRightLabel.Text) + 1).ToString(); break;
                case Edges.Top: blueTopLabel.Text = (Convert.ToInt32(blueTopLabel.Text) + 1).ToString(); break;
                case Edges.Bottom: blueBottomLabel.Text = (Convert.ToInt32(blueBottomLabel.Text) + 1).ToString(); break;
            }
        }

        private void RedBall_OnEdgeHitting(object? sender, HitEventArgs e)
        {
            switch (e.Edge)
            {
                case Edges.Left: redLeftLabel.Text = (Convert.ToInt32(redLeftLabel.Text) + 1).ToString(); break;
                case Edges.Right: redRightLabel.Text = (Convert.ToInt32(redRightLabel.Text) + 1).ToString(); break;
                case Edges.Top: redTopLabel.Text = (Convert.ToInt32(redTopLabel.Text) + 1).ToString(); break;
                case Edges.Bottom: redBottomLabel.Text = (Convert.ToInt32(redBottomLabel.Text) + 1).ToString(); break;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var ball in billiardBalls)
            {
                if (ball.IsInMotion())
                {
                    ball.Stop();
                }
                else
                {
                    ball.Start();
                }
            }
        }
    }
}