namespace BallGamesWinFormsApp
{
    public class RandomSpeedMovingBall : MovingBall
    {
        public RandomSpeedMovingBall(MainForm mainForm) : base(mainForm)
        {
            vx = random.Next(-5, 6);
            vy = random.Next(-5, 6);
        }
    }
}
