namespace BallGamesWinFormsApp
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form mainForm) : base(mainForm)
        {
            size = random.Next(30, 80);
        }
    }
}
