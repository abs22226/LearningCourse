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
            Ball ball = new BilliardBall(this);
            ball.Start();

            Ball ball2 = new RandomSpeedAndDirectionBall(this);
            ball2.Start();
        }
    }
}
