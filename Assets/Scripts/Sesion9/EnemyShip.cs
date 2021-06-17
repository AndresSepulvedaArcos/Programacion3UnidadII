using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{

    public class EnemyShip : MonoBehaviour
    {
        public float fireRate = 1f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            GameObject bullet;
            while(true)
            {
                bullet = EnemyBulletPool.Instance.GetPooledObject(transform.position);
                bullet.GetComponent<EnemyBullet>().ShootTo(transform.up);

                yield return new WaitForSeconds(fireRate);

            }

        }
    }
}
