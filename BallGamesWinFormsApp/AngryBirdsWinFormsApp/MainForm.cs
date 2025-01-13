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
            if (!bird.IsInMotion())
            {
                CreateNewBird();
            }


        }

        private void CreateNewBird()
        {
            if (bird != null)
            {
                bird.Clear();
            }

            bird = new Bird(this, Brushes.DodgerBlue);
            bird.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CreateNewBird();

            pig = new Pig(this, Brushes.HotPink);
            pig.Show();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            bird.SetSpeed(e.X, e.Y);
            bird.Start();
        }
    }
}
