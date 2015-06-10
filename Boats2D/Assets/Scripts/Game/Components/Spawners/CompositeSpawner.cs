using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class CompositeSpawner : SpawnerBase
    {
        public List<Creatable> creatables;
        public bool randomGeneration = true;

        private int index = 0;

        public override void Create()
        {
            if (this.randomGeneration)
            {
                // Determine creatable type and random position
                index = UnityEngine.Random.Range(0, creatables.Count);
                Instantiate(this.creatables[index], this.Position(), Quaternion.identity);
            }
            else
            {
                Instantiate(this.creatables[index], this.Position(), Quaternion.identity);

                // Increment and reset index to maintain generation order
                if (index == this.creatables.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index += 1;
                }
            }
        }
    }
}
