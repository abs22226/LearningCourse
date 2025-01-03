namespace BallsCommon
{
    public class RandomPointBall : Ball
    {
        //public RandomPointBall(Form mainForm) : base(mainForm)
        //{
        //    centerX = random.Next(LeftEdge(), RightEdge());
        //    centerY = random.Next(TopEdge(), BottomEdge());
        //}

        public RandomPointBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            centerX = random.Next(LeftEdge(), RightEdge());
            centerY = random.Next(TopEdge(), BottomEdge());
        }
    }
}
