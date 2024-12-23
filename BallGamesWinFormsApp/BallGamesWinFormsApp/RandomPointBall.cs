﻿namespace BallGamesWinFormsApp
{
    public class RandomPointBall : Ball
    {
        public RandomPointBall(MainForm mainForm) : base(mainForm)
        {
            x = random.Next(0, mainForm.ClientSize.Width);
            y = random.Next(0, mainForm.ClientSize.Height);
        }
    }
}
