namespace BallsCommon
{
    public class FirstSaluteBall : SaluteBall
    {
        public event EventHandler<TopIsReachedEventArgs> TopIsReached;

        public FirstSaluteBall(Form mainForm, Brush brush) : base(mainForm, brush, mainForm.ClientSize.Width / 2, mainForm.ClientSize.Height)
        {
            MoveY = (float)random.NextDouble() * -6 - 7;
            MoveX = 0;
        }

        protected override void Go()
        {
            base.Go();

            if (MoveY > 0)
            {
                Stop();
                Clear();
                TopIsReached?.Invoke(this, new TopIsReachedEventArgs(centerX, centerY));
            }
        }
    }
}
