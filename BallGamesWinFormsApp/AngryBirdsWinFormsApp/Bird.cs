using BallsCommon;

namespace AngryBirdsWinFormsApp
{
    public class Bird : RandomSpeedAndDirectionBall
    {
        private float g = 0.2f;
        private float elasticity = 2;

        public Bird(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            centerX = LeftEdge();
            centerY = BottomEdge();

            Brush = Brushes.DodgerBlue;
        }

        protected override void Go()
        {
            base.Go();

            if (centerY > BottomEdge())
            {
                MoveY = -MoveY;
            }

            MoveY += g;
        }
    }
}
