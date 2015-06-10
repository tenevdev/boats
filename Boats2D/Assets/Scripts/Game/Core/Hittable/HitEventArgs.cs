using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Game.Core
{
    public class HitEventArgs
    {
        public HitEventArgs(int hpStart, int hpLeft)
        {
            this.HitPointsLeft = hpLeft;
            this.HitPointsPercent = (float)hpLeft / hpStart;
        }

        public int HitPointsLeft { get; set; }
        public float HitPointsPercent { get; set; }
    }
}
