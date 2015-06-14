using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class PassengerTransportedState : PassengerState
    {
        private Vector2 PASSENGER_TRANSPORTED_SPEED = -Vector2.up;

        public PassengerTransportedState(Passenger passenger)
            : base(passenger)
        {
            // TODO : Find counter object and increment

            this.Passenger.movementSpeed = PASSENGER_TRANSPORTED_SPEED;

            this.Passenger.animator.Play("Approach");
            this.Passenger.StartCoroutine(this.Move());
        }

        internal override void HandleShore()
        {
            // Do nothing
        }

        internal override void HandleBoat(Boat boat)
        {
            // Do nothing
        }
    }
}
