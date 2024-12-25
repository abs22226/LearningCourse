namespace BallGamesWinFormsApp
{

    public class MovingBall : RandomPointBall
    {
        private System.Windows.Forms.Timer timer;

        public MovingBall(Form mainForm) : base(mainForm)
        {
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

        public bool IsInMotion()
        {
            return timer.Enabled;
        }
    }
}
