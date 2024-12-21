namespace BallGamesWinFormsApp
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(MainForm mainForm) : base(mainForm)
        {
            size = random.Next(30, 80);
        }
    }
}
