namespace BallGamesWinFormsApp
{
    public class RandomSpeedMovingBall : MovingBall
    {
        public RandomSpeedMovingBall(MainForm mainForm) : base(mainForm)
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
