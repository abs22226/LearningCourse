namespace BallGamesWinFormsApp
{
    public class PointBall : Ball
    {
        public PointBall(Form mainForm, int x, int y) : base(mainForm)
        {
            this.centerX = x;
            this.centerY = y;
        }
    }
}
