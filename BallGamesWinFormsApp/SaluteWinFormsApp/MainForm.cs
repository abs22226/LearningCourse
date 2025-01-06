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
            var count = random.Next(1, 11);
            for (int i = 0; i < count; i++)
            {
                var r = random.Next(0, 256);
                var g = random.Next(0, 256);
                var b = random.Next(0, 256);
                var randomColorBrush = new SolidBrush(Color.FromArgb(r, g, b));
                var salute = new SaluteBall(this, randomColorBrush, e.X, e.Y);
                salute.Start();
            }
        }
    }
}
