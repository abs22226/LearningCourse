namespace BallGamesWinFormsApp
{
    public class Ball
    {
        private MainForm mainForm;
        protected int vx = 1;
        protected int vy = 1;
        protected int x = 50;
        protected int y = 50;
        protected int size = 70;
        protected static Random random = new Random();

        public Ball(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void Show()
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, size, size); // координаты площади, куда надо вписать эллипс
            graphics.FillEllipse(brush, rectangle);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        private void Go()
        {
            x += vx;
            y += vy;
        }

        private void Clear()
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var brush = new SolidBrush(mainForm.BackColor);
            //var brush = Brushes.White;
            var rectangle = new Rectangle(x, y, size, size); // координаты площади, куда надо вписать эллипс
            graphics.FillEllipse(brush, rectangle);
        }

        public bool IsOnMainForm()
        {
            return x >= 0 && x + size <= mainForm.ClientSize.Width &&
                   y >= 0 && y + size <= mainForm.ClientSize.Height;
        }
    }
}
