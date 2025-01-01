namespace BallsCommon
{
    public class Ball
    {
        private Form mainForm;
        protected int centerX = 150;
        protected int centerY = 150;
        protected int radius = 25;
        protected int xMove = 5;
        protected int yMove = -5;
        protected static Random random;
        private System.Windows.Forms.Timer timer;

        public Ball(Form mainForm)
        {
            this.mainForm = mainForm;
            random = new Random();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public void Clear()
        {
            var brush = new SolidBrush(mainForm.BackColor);
            Draw(brush);
        }

        private void Draw(Brush brush)
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var rectangle = new Rectangle(centerX - radius, centerY - radius, 2 * radius, 2 * radius); // координаты площади, куда надо вписать эллипс
            graphics.FillEllipse(brush, rectangle);
        }

        private void Go()
        {
            centerX += xMove;
            centerY += yMove;

            if (centerX <= LeftEdge() || centerX >= RightEdge())
            {
                xMove = -xMove;
            }

            if (centerY <= TopEdge() || centerY >= BottomEdge())
            {
                yMove = -yMove;
            }
        }

        public void Show()
        {
            var brush = Brushes.Aqua;
            Draw(brush);
        }

        public bool IsOnMainForm()
        {
            return centerX >= LeftEdge() && centerX <= RightEdge() &&
                   centerY >= TopEdge() && centerY <= BottomEdge();
        }

        public int LeftEdge()
        {
            return radius;
        }

        public int RightEdge()
        {
            return mainForm.ClientSize.Width - radius;
        }

        public int TopEdge()
        {
            return radius;
        }

        public int BottomEdge()
        {
            return mainForm.ClientSize.Height - radius;
        }

        public bool IsUnderCursor(Point cursorPoint)
        {
            var ballCenter = new Point(centerX, centerY);
            var distanceFromCursorToBallCenter = Math.Sqrt(Math.Pow(cursorPoint.X - ballCenter.X, 2) + Math.Pow(cursorPoint.Y - ballCenter.Y, 2));

            return distanceFromCursorToBallCenter <= radius;
        }

        public bool IsInMotion()
        {
            return timer.Enabled;
        }
    }
}
