namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        private Bird bird;
        private Pig pig;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            bird = new Bird(this, Brushes.DodgerBlue);
            bird.Show();

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
