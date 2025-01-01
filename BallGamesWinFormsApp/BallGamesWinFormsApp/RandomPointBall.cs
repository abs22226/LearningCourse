namespace BallGamesWinFormsApp
{
    public class RandomPointBall : Ball
    {
        public RandomPointBall(Form mainForm) : base(mainForm)
        {
            centerX = random.Next(LeftEdge(), RightEdge());
            centerY = random.Next(TopEdge(), BottomEdge());
        }
    }
}
