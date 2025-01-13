using BallsCommon;

namespace AngryBirdsWinFormsApp
{
    public class Pig : RandomPointBall
    {
        public Pig(Form mainForm, Brush brush) : base(mainForm, brush)
        {
            Brush = Brushes.HotPink;
            radius = 30;
        }
    }
}
