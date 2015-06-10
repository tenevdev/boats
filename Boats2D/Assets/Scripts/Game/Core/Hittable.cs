using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Core
{
    public class Hittable : Movable, IHittable, IHitter
    {
        protected int startHitPoints;

        public int hitPoints;
        public int hitPower;

        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
            set
            {
                this.hitPoints = value;
            }
        }
        public int HitPower
        {
            get
            {
                return this.hitPower;
            }
            set
            {
                this.hitPower = value;
            }
        }

        public void Start()
        {
            base.Start();
            this.startHitPoints = this.HitPoints;
        }

        public void ReceiveHit(Hittable hitter)
        {
            // Receive damage from hit object
            this.HitPoints -= hitter.HitPower;

            // Raise hit event
            OnHitReceived(new HitEventArgs(this.startHitPoints, this.HitPoints));

            if (this.HitPoints <= 0)
            {
                // Raise dead event
                OnDead(new KilledEventArgs(hitter));
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                this.ReceiveHit(collision.gameObject.GetComponent<Hittable>());
            }
        }


        public event HitReceivedEventHandler HitReceived;
        protected virtual void OnHitReceived(HitEventArgs e)
        {
            if (HitReceived != null)
            {
                HitReceived(this, e);
            }
        }
    }
}
