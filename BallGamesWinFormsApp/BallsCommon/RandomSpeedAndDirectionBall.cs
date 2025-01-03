namespace BallsCommon
{
    public class RandomSpeedAndDirectionBall : RandomPointBall
    {
        //public RandomSpeedAndDirectionBall(Form mainForm) : base(mainForm)
        //{
        //    do
        //    {
        //        xMove = random.Next(-5, 6);
        //        yMove = random.Next(-5, 6);
        //    }
        //    while (xMove == 0 && yMove == 0);
        //}

        public RandomSpeedAndDirectionBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            do
            {
                xMove = random.Next(-5, 6);
                yMove = random.Next(-5, 6);
            }
            while (xMove == 0 && yMove == 0);
        }
    }
}
