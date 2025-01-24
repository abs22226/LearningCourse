namespace FrogWinFormsApp
{
    public class CustomMessageBox : Form
    {
        private PictureBox _pictureBox;
        private Label _label;

        public CustomMessageBox(string message, Image image)
        {
            Text = "Конец игры";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Width = 224;
            Height = 260;

            _pictureBox = new PictureBox();
            _pictureBox.Image = image;
            _pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox.Location = new Point(3, 3);

            _label = new Label();
            _label.Text = message;
            _label.AutoSize = false;
            _label.Location = new Point(3, 180);
            _label.Width = 218;
            _label.Height = 100;

            Controls.Add(_pictureBox);
            Controls.Add(_label);
        }

        public static void Show(string message, Image image)
        {
            CustomMessageBox dialog = new CustomMessageBox(message, image);
            dialog.ShowDialog();
        }
    }
}
