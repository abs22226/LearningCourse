using BallsCommon;

namespace AngryBirdsWinFormsApp
{
    public class Bird : Ball
    {
        private float g = 0.2f;
        private float frictionCoefficient = 0.5f;

        public Bird(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            centerX = LeftEdge();
            centerY = BottomEdge();
        }

        protected override void Go()
        {
            base.Go();

            if (centerY > BottomEdge())
            {
                MoveY = -MoveY;

                centerY = BottomEdge();

                MoveY *= frictionCoefficient;
                MoveX *= frictionCoefficient;
            }

            if (MoveX < 0.1 && MoveY < 0.1)
            {
                Stop();
            }

            MoveY += g;
        }

        public void SetSpeed(int x, int y)
        {
            MoveX = (x - centerX) / 25;
            MoveY = (y - centerY) / 25;
        }

        public bool IsOutside()
        {
            return centerX - radius > mainForm.ClientSize.Width;
        }

        public bool IsStopped()
        {
            return !IsInMotion();
        }
    }
}
