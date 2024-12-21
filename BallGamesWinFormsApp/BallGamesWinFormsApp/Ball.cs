namespace BallGamesWinFormsApp
{
    public class Ball
    {
        private MainForm mainForm;
        protected int x = 150;
        protected int y = 150;
        protected int size = 70;

        public Ball(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void Show()
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x - size / 2, y - size / 2, size, size); // координаты площади, куда надо вписать эллипс
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
