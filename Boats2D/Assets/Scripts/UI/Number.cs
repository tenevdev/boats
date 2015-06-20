using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Number : MonoBehaviour
    {
        public DigitTile digitTile;
        public int value;

        public void Start()
        {
            int number = this.value, digit = 0, count = 0;
            while (number > 0)
            {
                digit = number % 10;

                DigitTile tile = Instantiate<DigitTile>(this.digitTile);
                tile.transform.SetParent(this.transform, false);
                tile.transform.Translate(new Vector3(5 * count, 0, 0));

                tile.Current = digit;


                count += 1;
                number /= 10;

            }
        }
    }
}
