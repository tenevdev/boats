using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Creatables
{
    public class Boat : Creatable
    {
        private int passengerCount = 0;

        public SpriteRenderer hitPointsBar;

        public void Start()
        {
            base.Start();
            this.hitPointsBar = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            this.HitReceived += UpdateHitPointsBar;
        }

        private void UpdateHitPointsBar(Hittable sender, HitEventArgs args)
        {
            this.hitPointsBar.color = Color.Lerp(Color.red, Color.green, args.HitPointsPercent);
            this.hitPointsBar.transform.localScale = new Vector3(args.HitPointsPercent, 1, 1);
        }
    }
}
