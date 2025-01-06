namespace SaluteWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {



            var salute = new SaluteBall(this, Brushes.DodgerBlue, e.X, e.Y);
            salute.Start();
        }
    }
}
