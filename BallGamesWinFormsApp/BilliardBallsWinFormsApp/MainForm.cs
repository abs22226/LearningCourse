using BallsCommon;

namespace BilliardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var ball = new BilliardBall(this, Brushes.DodgerBlue);
                ball.OnHittingEdge += BlueBall_OnEdgeHitting;
                ball.Start();

                ball = new BilliardBall(this, Brushes.Red);
                ball.OnHittingEdge += RedBall_OnEdgeHitting;
                ball.Start();
            }
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
    }
}