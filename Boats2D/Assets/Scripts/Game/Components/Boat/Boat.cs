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
        private Animator animator;

        public HitPointsBar hitPointsBar;

        public void Start()
        {
            base.Start();
            this.animator = this.GetComponent<Animator>();
            if (this.hitPointsBar == null)
            {
                this.hitPointsBar = this.GetComponentInChildren<HitPointsBar>();
            }

            this.HitReceived += this.hitPointsBar.UpdateBar;
        }

        protected override void PreDead(HitEventArgs args)
        {
            // Do not call base as it will raise dead immediately
            this.animator.SetBool("IsAlive", false);
        }

        public void Sunk()
        {
            // Raise dead to destroy boat
            this.OnDead(new DeadEventArgs(DeadReason.Killed));
        }
    }
}
