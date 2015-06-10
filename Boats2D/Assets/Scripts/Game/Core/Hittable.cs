using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Core
{
    public class Hittable : Movable, IHittable, IHitter
    {
        public int HitPoints { get; set; }
        public int HitPower { get; set; }

        public void ReceiveHit(Hittable hitter)
        {
            // Receive damage from hit object
            this.HitPoints -= hitter.HitPower;

            if (this.HitPoints <= 0)
            {
                OnDead(new KilledEventArgs(hitter));
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Hittable hitter = collision.gameObject.GetComponent<Hittable>();

            if (hitter != null)
            {
                this.ReceiveHit(hitter);
            }
        }
    }
}
