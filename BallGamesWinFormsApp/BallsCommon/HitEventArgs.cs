namespace BallsCommon
{
    public class HitEventArgs
    {
        public Edges Edge { get; set; }

        public HitEventArgs(Edges edge)
        {
            Edge = edge;
        }
    }
}
