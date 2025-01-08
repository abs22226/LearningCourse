using BallsCommon;

namespace FruitNinjaWinFormsApp
{
    public class FruitBall : RandomSpeedAndDirectionBall
    {
        private float g = 0.2f;

        public FruitBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            radius = 15;
            centerY = mainForm.ClientSize.Height + radius;
            yMove = (float)random.NextDouble() * -6 - 7;
        }

        protected override void Go()
        {
            base.Go();
            yMove += g;

            if (centerY > BottomEdge() + 2 * radius)
            {
                Stop();
            }
        }
    }
}
