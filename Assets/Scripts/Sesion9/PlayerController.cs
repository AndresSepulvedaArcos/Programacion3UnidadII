using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        void Shoot()
        {
            GameObject objTmp = PlayerBulletObjectPool.Instance.GetPooledObject(transform.position);

            objTmp.GetComponent<PlayerBullet>().ShootTo(transform.up);
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

}
