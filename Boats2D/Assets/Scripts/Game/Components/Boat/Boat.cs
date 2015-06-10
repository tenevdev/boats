using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class Boat : Creatable
    {
        private int passengerCount = 0;

        public HitPointsBar hitPointsBar;

        public void Start()
        {
            base.Start();
            if (this.hitPointsBar == null)
            {
                this.hitPointsBar = this.GetComponentInChildren<HitPointsBar>();
            }

            this.HitReceived += this.hitPointsBar.UpdateBar;
        }
    }
}
