using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Game.Components
{
    public class Passenger : Creatable
    {
        private bool isTransported = false;

        public PassengerState state;
    }

    public enum PassengerState
    {
        Waiting = 0,
        OnBoard = 1,
        Transported = 2,
        Drowning = 3
    }
}
