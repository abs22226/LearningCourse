using BallsCommon;

namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        private Bird bird;
        private Pig pig;
        private System.Windows.Forms.Timer timer;
        public MainForm()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (bird.IsIntersecting(pig))
            {
                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                CreateNewBird();
                CreateNewPig();
            }

            if (bird.IsStopped() || bird.IsOutside())
            {
                CreateNewBird();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            scoreLabel.Text = "0";
            CreateNewBird();
            CreateNewPig();
        }

        private void CreateNewBird()
        {
            timer.Stop();
            if (bird != null)
            {
                bird.Stop();
                bird.Clear();
            }
            bird = new Bird(this, Brushes.DodgerBlue);
            bird.Show();
        }

        private void CreateNewPig()
        {
            if (pig != null)
            {
                pig.Clear();
            }
            pig = new Pig(this, Brushes.HotPink);
            pig.Show();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (bird.IsInMotion())
            {
                return;
            }
            bird.SetSpeed(e.X, e.Y);
            timer.Start();
            bird.Start();
        }
    }
}
