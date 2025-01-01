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
                Ball ball = new BilliardBall(this);
                ball.Start();
            }
        }
    }
}
