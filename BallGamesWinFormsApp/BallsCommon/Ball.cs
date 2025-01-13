using System.Drawing;

namespace BallsCommon
{
    public class Ball
    {
        protected Form mainForm;
        protected float centerX = 150;
        protected float centerY = 150;
        protected int radius = 25;
        public float MoveX = 5;
        public float MoveY = -5;
        protected static Random random;
        public System.Windows.Forms.Timer Timer;
        public Brush Brush { get; set; }

        public Ball(Form mainForm, Brush brush)
        {
            this.mainForm = mainForm;
            Brush = brush;
            random = new Random();
            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 20;
            Timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
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
            var backColorBrush = new SolidBrush(mainForm.BackColor);
            Draw(backColorBrush);
        }

        private void Draw(Brush brush)
        {
            var graphics = mainForm.CreateGraphics(); // создаем холст на главной форме, чтобы рисовать на нем
            var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius); // координаты площади, куда надо вписать эллипс
            graphics.FillEllipse(brush, rectangle);
        }

        protected virtual void Go()
        {
            centerX += MoveX;
            centerY += MoveY;
        }

        public void Show()
        {
            Draw(Brush);
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

        public bool IsUnder(PointF point)
        {
            var ballCenter = new PointF(centerX, centerY);
            var distanceFromPointToBallCenter = Math.Sqrt(Math.Pow(point.X - ballCenter.X, 2) + Math.Pow(point.Y - ballCenter.Y, 2));

            return distanceFromPointToBallCenter <= radius;
        }

        public bool IsInMotion()
        {
            return Timer.Enabled;
        }

        public bool IsIntersecting(Ball otherBall)
        {
            var ballCenter = new PointF(centerX, centerY);
            var otherBallCenter = new PointF(otherBall.centerX, otherBall.centerY);
            var distanceBetweenCenters = Math.Sqrt(Math.Pow(otherBallCenter.X - ballCenter.X, 2) + Math.Pow(otherBallCenter.Y - ballCenter.Y, 2));

            return distanceBetweenCenters < radius + otherBall.radius;              
        }
    }
}
