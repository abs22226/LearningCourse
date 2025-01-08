using BallsCommon;

namespace SaluteWinFormsApp
{
    public partial class MainForm : Form
    {
        private static Random random;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            CreateSalute(e.X, e.Y);
        }

        private void SaluteButton_Click(object sender, EventArgs e)
        {
            var firstBall = new FirstSaluteBall(this, Brushes.DodgerBlue);
            firstBall.TopIsReached += FirstBall_TopIsReached;
            firstBall.Start();
        }

        private void FirstBall_TopIsReached(object? sender, TopIsReachedEventArgs e)
        {
            CreateSalute(e.X, e.Y);
        }

        private void CreateSalute(float xPoint, float yPoint)
        {
            var count = random.Next(4, 11);
            for (int i = 0; i < count; i++)
            {
                var r = random.Next(0, 256);
                var g = random.Next(0, 256);
                var b = random.Next(0, 256);
                var randomColorBrush = new SolidBrush(Color.FromArgb(r, g, b));
                var salute = new SaluteBall(this, randomColorBrush, xPoint, yPoint);
                salute.Start();
            }
        }
    }
}
