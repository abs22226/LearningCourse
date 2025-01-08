using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaluteWinFormsApp
{
    public class FirstSaluteBall : SaluteBall
    {
        public event EventHandler<TopIsReachedEventArgs> TopIsReached;

        public FirstSaluteBall(Form mainForm, Brush brush) : base(mainForm, brush, mainForm.ClientSize.Width / 2, mainForm.ClientSize.Height)
        {
            yMove = (float)random.NextDouble() * -6 - 7;
            xMove = 0;
        }

        protected override void Go()
        {
            base.Go();

            if (yMove > 0)
            {
                Stop();
                Clear();
                TopIsReached?.Invoke(this, new TopIsReachedEventArgs(centerX, centerY));
            }
        }
    }
}
