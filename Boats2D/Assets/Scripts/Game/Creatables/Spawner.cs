using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Creatables
{
    public class Spawner : SpawnerBase
    {
        public Creatable creatable;

        public override void Create()
        {
            Vector3 position = this.Position();
            Instantiate(this.creatable, position, Quaternion.identity);
        }
    }
}
