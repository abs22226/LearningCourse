﻿namespace BallsCommon
{
    public class SaluteBall : RandomSpeedAndDirectionBall
    {
        private float g = 0.2f;

        public SaluteBall(Form mainForm, Brush brush, float centerX, float centerY) : base(mainForm, brush)
        {
            radius = 15;
            this.centerX = centerX;
            this.centerY = centerY;
            MoveY = -Math.Abs(MoveY);
        }

        protected override void Go()
        {
            base.Go();
            MoveY += g;

        }
    }
}
