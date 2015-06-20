using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class LevelObjective : MonoBehaviour
    {
        public void Start()
        {
            this.GetComponent<Assets.Scripts.UI.Number>().value = LevelManager.Instance.objective;
        }
    }
}
