using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Creatables
{
    interface ICreator
    {
        IEnumerator Run();
        Creatable Create();
    }
}
