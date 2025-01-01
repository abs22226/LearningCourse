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
                var ball = new BilliardBall(this);
                ball.OnHittingEdge += Ball_OnEdgeHitting;
                ball.Start();
            }
        }

        private void Ball_OnEdgeHitting(object? sender, HitEventArgs e)
        {
            switch (e.Edge)
            {
                case Edges.Left: leftLabel.Text = (Convert.ToInt32(leftLabel.Text) + 1).ToString(); break;
                case Edges.Right: rightLabel.Text = (Convert.ToInt32(rightLabel.Text) + 1).ToString(); break;
                case Edges.Top: topLabel.Text = (Convert.ToInt32(topLabel.Text) + 1).ToString(); break;
                case Edges.Bottom: bottomLabel.Text = (Convert.ToInt32(bottomLabel.Text) + 1).ToString(); break;
            }
        }
    }
}