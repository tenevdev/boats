﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class PassengerWaitingState : PassengerState
    {

        public PassengerWaitingState(Passenger passenger)
            : base(passenger)
        {
            this.Passenger.animator.Play("Stand");
            this.Passenger.StartCoroutine(Wait());
        }

        internal override void HandleShore()
        {
            // Do nothing
        }

        internal override void HandleBoat(Boat boat)
        {
            // Get on board
            this.Passenger.transform.position = Vector3.zero;
            this.Passenger.transform.SetParent(boat.transform, false);

            this.Passenger.SetState(PassengerStates.OnBoat);
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(this.Passenger.waitingTime);

            // The passenger is still waiting
            if(this.Passenger.State == this)
            {
                this.Passenger.SetState(PassengerStates.Leaving);
            }
        }
    }
}
