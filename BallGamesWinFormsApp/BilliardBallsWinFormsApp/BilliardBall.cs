using BallsCommon;

namespace BilliardBallsWinFormsApp
{
    public class BilliardBall : RandomSpeedAndDirectionBall
    {
        public BilliardBall(Form mainForm) : base(mainForm)
        {


        }

        protected override void Go()
        {
            base.Go();

            xMove = centerX <= LeftEdge() || centerX >= RightEdge() ? -xMove : xMove;
            yMove = centerY <= TopEdge() || centerY >= BottomEdge() ? -yMove : yMove;
        }
    }
}
