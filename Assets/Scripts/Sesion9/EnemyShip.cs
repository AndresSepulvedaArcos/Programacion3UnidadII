using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{

    public class EnemyShip : MonoBehaviour
    {
        public float fireRate = 1f;

        public int circleBulletAmmount = 20;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ShootSinusoidal());
        }

        IEnumerator ShootForward()
        {
            GameObject bullet;
            while(true)
            {
                bullet = EnemyBulletPool.Instance.GetPooledObject(transform.position);
                bullet.GetComponent<EnemyBullet>().ShootTo(transform.up);

                yield return new WaitForSeconds(fireRate);

            }

        }
        IEnumerator ShootSinusoidal()
        {

            Vector2 ShootDir = transform.up;

            GameObject bullet;
           
            while (true)
            {
                bullet = EnemyBulletPool.Instance.GetPooledObject(transform.position);
                bullet.GetComponent<EnemyBullet>().ShootTo(transform.up,true);

               

                yield return new WaitForSeconds(fireRate);

            }

        }
        IEnumerator ShootSpiral()
        {

            Vector2 ShootDir = transform.up;

            GameObject bullet;
            int i=0;
            while (true)
            {
                   bullet = EnemyBulletPool.Instance.GetPooledObject(transform.position);
                    bullet.GetComponent<EnemyBullet>().ShootTo(Rotate2D(transform.up, Mathf.Deg2Rad * 360 / circleBulletAmmount * i));

                i++;

                if (i > circleBulletAmmount)
                    i = 0;

                yield return new WaitForSeconds(fireRate);

            }

        }
        IEnumerator ShootCircle()
        {

            Vector2 ShootDir = transform.up;
 
            GameObject bullet;
            
            while (true)
            {
                for (int i = 0; i < circleBulletAmmount; i++)
                {
                    bullet = EnemyBulletPool.Instance.GetPooledObject(transform.position);
                    bullet.GetComponent<EnemyBullet>().ShootTo(Rotate2D(transform.up, Mathf.Deg2Rad * 360 / circleBulletAmmount *i));

                }

                yield return new WaitForSeconds(fireRate);

            }

        }

        Vector2 Rotate2D(Vector2 vector, float angle)
        {
            Vector2 rotatedVector = Vector2.zero;
            rotatedVector.x = (vector.x * Mathf.Cos(angle)) - (vector.y * Mathf.Sin(angle));
            rotatedVector.y = (vector.x * Mathf.Sin(angle)) + (vector.y * Mathf.Cos(angle));


            return rotatedVector;
        }

    }
}
