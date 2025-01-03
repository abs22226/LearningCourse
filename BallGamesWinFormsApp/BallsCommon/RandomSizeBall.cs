namespace BallsCommon
{
    public class RandomSizeBall : RandomPointBall
    {
        public RandomSizeBall(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            radius = random.Next(10, 40);
        }
    }
}
