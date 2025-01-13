namespace BallsCommon
{
    public class FruitBall : RandomSpeedAndDirectionBall
    {
        public float G;
        public float InitialMoveX;
        public float InitialMoveY;

        public FruitBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            radius = 15;
            centerY = mainForm.ClientSize.Height + radius;
            MoveY = (float)random.NextDouble() * -6 - 7;

            G = 0.2f;
            InitialMoveX = MoveX;
            InitialMoveY = MoveY;
        }

        protected override void Go()
        {
            base.Go();
            MoveY += G;

            if (centerY > BottomEdge() + 2 * radius)
            {
                Stop();
            }
        }
    }
}
