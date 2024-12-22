namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<MovableBall> movableBalls;
        PointBall pointBall;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < movableBalls.Count; i++)
            {
                movableBalls[i].Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            movableBalls = new List<MovableBall>();

            for (int i = 0; i < 10; i++)
            {
                var movableBall = new MovableBall(this);
                movableBalls.Add(movableBall);
                movableBall.Start();
            }
        }
    }
}
