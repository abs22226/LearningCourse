namespace SaluteWinFormsApp
{
    public class TopIsReachedEventArgs
    {
        public float X;
        public float Y;

        public TopIsReachedEventArgs(float pointX, float pointY)
        {
            X = pointX;
            Y = pointY;
        }
    }
}
