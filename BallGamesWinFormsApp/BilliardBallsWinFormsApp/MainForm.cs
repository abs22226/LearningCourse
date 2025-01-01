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
            var ball = new BilliardBall(this);
            ball.Start();
        }
    }
}
