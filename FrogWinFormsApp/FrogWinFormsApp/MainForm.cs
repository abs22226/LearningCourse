namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distanceToEmptyPictureBox = Math.Abs(clickedPictureBox.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distanceToEmptyPictureBox > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clickedPictureBox.Location;
                clickedPictureBox.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
            }
        }
    }
}
