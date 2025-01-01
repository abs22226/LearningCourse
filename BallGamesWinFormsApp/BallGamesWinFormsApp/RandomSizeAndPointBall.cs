namespace BallGamesWinFormsApp
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form mainForm) : base(mainForm)
        {
            radius = random.Next(10, 40);
        }
    }
}
