namespace BallsCommon
{
    public class RandomSpeedAndDirectionBall : RandomPointBall
    {
        public RandomSpeedAndDirectionBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            do
            {
                MoveX = random.Next(-5, 6);
                MoveY = random.Next(-5, 6);
            }
            while (MoveX == 0 || MoveY == 0);
        }
    }
}
