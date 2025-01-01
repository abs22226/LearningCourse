namespace BallGamesWinFormsApp
{
    public class RandomSizeBall : RandomPointBall
    {
        public RandomSizeBall(Form mainForm) : base(mainForm)
        {
            radius = random.Next(10, 40);
        }
    }
}
