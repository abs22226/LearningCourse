namespace FrogWinFormsApp
{
    public class CustomMessageBox : Form
    {
        private PictureBox pictureBox;
        private Label label;

        public CustomMessageBox(string message, Image image)
        {
            Text = "Конец игры";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Size = new Size(224, 260);
            MaximumSize = Size;
            MinimumSize = Size;

            pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(3, 3);

            label = new Label();
            label.Text = message;
            label.AutoSize = false;
            label.Location = new Point(3, 180);
            label.Size = new Size(218, 100);

            Controls.Add(pictureBox);
            Controls.Add(label);
        }

        public static void Show(string message, Image image)
        {
            CustomMessageBox dialog = new CustomMessageBox(message, image);
            dialog.ShowDialog();
        }
    }
}
