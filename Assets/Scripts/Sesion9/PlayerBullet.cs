using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{

    public class PlayerBullet : MonoBehaviour
    {
        Rigidbody2D rb;
        public float Initialspeed = 2f;
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

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

    }
}
