namespace BallGamesWinFormsApp
{
    public class PointBall : Ball
    {
        public PointBall(Form mainForm, int x, int y) : base(mainForm)
        {
            this.x = x;
            this.y = y;
        }
    }
}
