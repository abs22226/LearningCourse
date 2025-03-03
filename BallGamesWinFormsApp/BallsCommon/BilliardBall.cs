﻿namespace BallsCommon
{
    public class BilliardBall : RandomSpeedAndDirectionBall
    {
        public event EventHandler<HitEventArgs> OnEdgeHitting;
        public bool IsLeftFromCenter { get { return centerX + radius < mainForm.ClientSize.Width / 2; } }
        public bool IsRightFromCenter { get { return centerX - radius > mainForm.ClientSize.Width / 2; } }

        public BilliardBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            radius = 10;

            centerX = brush == Brushes.DodgerBlue ?
                      random.Next(LeftEdge() + 1, mainForm.ClientSize.Width / 2 - radius) :
                      random.Next(mainForm.ClientSize.Width / 2 + radius + 1, RightEdge());

            centerY = random.Next(TopEdge() + 1, BottomEdge());
        }

        protected override void Go()
        {
            base.Go();

            if (centerX <= LeftEdge())
            {
                MoveX = -MoveX;
                OnEdgeHitting.Invoke(this, new HitEventArgs(Edges.Left));
            }

            if (centerX >= RightEdge())
            {
                MoveX = -MoveX;
                OnEdgeHitting.Invoke(this, new HitEventArgs(Edges.Right));
            }

            if (centerY <= TopEdge())
            {
                MoveY = -MoveY;
                OnEdgeHitting.Invoke(this, new HitEventArgs(Edges.Top));
            }

            if (centerY >= BottomEdge())
            {
                MoveY = -MoveY;
                OnEdgeHitting.Invoke(this, new HitEventArgs(Edges.Bottom));
            }
        }
    }
}
