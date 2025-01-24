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
            Size = new Size(224, 260);
            MaximumSize = Size;
            MinimumSize = Size;

            _pictureBox = new PictureBox();
            _pictureBox.Image = image;
            _pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox.Location = new Point(3, 3);

            _label = new Label();
            _label.Text = message;
            _label.AutoSize = false;
            _label.Location = new Point(3, 180);
            _label.Size = new Size(218, 100);

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
