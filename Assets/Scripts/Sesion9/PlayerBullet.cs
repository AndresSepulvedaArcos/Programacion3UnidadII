using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{

    public class PlayerBullet : MonoBehaviour
    {
        Rigidbody2D rb;
        public float Initialspeed = 2f;

        bool isSinusoidal=false;

        public float frequency = 0.5f;
        public float amplitude = 1f;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void ShootTo(Vector2 Direction)
        {
            rb.velocity = Direction * Initialspeed;
        }

        public void ShootTo(Vector2 Direction,bool MakeSinusoidal)
        {
            isSinusoidal = MakeSinusoidal;
            ShootTo(Direction);

        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        void SinusoidalMovement()
        {
            Vector2 tempPosition = transform.position;
            tempPosition.x = Mathf.Sin(2*Mathf.PI* Time.time * amplitude) * frequency;
            transform.position = tempPosition;

        }

        private void FixedUpdate()
        {
            if (isSinusoidal)
                SinusoidalMovement();

        }

    }
}
