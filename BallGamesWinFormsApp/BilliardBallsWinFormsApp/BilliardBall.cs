using BallsCommon;

namespace BilliardBallsWinFormsApp
{
    public class BilliardBall : RandomSpeedAndDirectionBall
    {
        public event EventHandler<HitEventArgs> OnHittingEdge;

        public BilliardBall(Form mainForm) : base(mainForm)
        {
        }

        public BilliardBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
        }

        protected override void Go()
        {
            base.Go();

            if (centerX <= LeftEdge())
            {
                xMove = -xMove;
                OnHittingEdge.Invoke(this, new HitEventArgs(Edges.Left));
            }

            if (centerX >= RightEdge())
            {
                xMove = -xMove;
                OnHittingEdge.Invoke(this, new HitEventArgs(Edges.Right));
            }

            if (centerY <= TopEdge())
            {
                yMove = -yMove;
                OnHittingEdge.Invoke(this, new HitEventArgs(Edges.Top));
            }

            if (centerY >= BottomEdge())
            {
                yMove = -yMove;
                OnHittingEdge.Invoke(this, new HitEventArgs(Edges.Bottom));
            }
        }
    }
}
