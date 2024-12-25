namespace BallGamesWinFormsApp
{
    public class Ball
    {
        private Form mainForm;
        protected int x = 150;
        protected int y = 150;
        protected int size = 50;
        protected int xMove = 5;
        protected int yMove = -5;
        protected static Random random = new Random();

        public Ball(Form mainForm)
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
            x += xMove;
            y += yMove;
        }

        public void Clear()
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var brush = new SolidBrush(mainForm.BackColor);
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
