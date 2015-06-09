using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game.Waves
{
    /// <summary>
    /// Used to control the expansion and force of a wave game object
    /// Should modify the radius of the circle collider to expand the wave
    /// Should modify the force magnitude of the area effector to reduce the force in time
    /// When the force magnitude becomes too small destroy the wave object
    /// </summary>
    public class WaveEffector : MonoBehaviour
    {

        private SurfaceEffector2D surfaceEffector;

        public float expansion = 0.6f;

        // Use this for initialization
        public void Start()
        {
            this.surfaceEffector = this.GetComponent<SurfaceEffector2D>();

            this.Expansion = expansion * 10;
        }

        public float Expansion { get; set; }

        // Update is called once per frame
        public void FixedUpdate()
        {
            if (this.transform.localScale.x > 8)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.localScale += new Vector3(this.surfaceEffector.speed / this.Expansion, this.surfaceEffector.speed / this.Expansion, 0);
            }
        }
    }
}
