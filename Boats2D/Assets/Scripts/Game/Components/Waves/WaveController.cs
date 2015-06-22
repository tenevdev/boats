using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Game.Components
{
    /// <summary>
    /// Create waves based on user input
    /// </summary>
    public class WaveController : MonoBehaviour, IPointerClickHandler
    {
        public Transform ripple;

        //public void OnMouseUp()
        //{
        //    Debug.Log(Input.mousePosition);
        //    Instantiate(this.ripple, Input.mousePosition, Quaternion.identity);
        //}

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(Input.mousePosition);
            Instantiate(this.ripple, eventData.position, Quaternion.identity);
        }
    }
}