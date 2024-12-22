namespace BallGamesWinFormsApp
{
    public class MovableBall : RandomPointBall
    {
        private System.Windows.Forms.Timer timer;

        public MovableBall(MainForm mainForm) : base(mainForm)
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
    }
}
