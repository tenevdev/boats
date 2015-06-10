using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Game.Components
{
    /// <summary>
    /// Create waves based on user input
    /// </summary>
    public class WaveController : MonoBehaviour
    {
        public Transform ripple;

        public void OnMouseUp()
        {
            Debug.Log(Input.mousePosition);
            Instantiate(this.ripple, Input.mousePosition, Quaternion.identity);
        }
    }
}