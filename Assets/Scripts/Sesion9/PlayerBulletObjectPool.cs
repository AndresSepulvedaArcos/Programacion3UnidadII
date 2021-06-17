using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shmup
{
    public class PlayerBulletObjectPool : MonoBehaviour
    {
        private static PlayerBulletObjectPool instance;
        public static PlayerBulletObjectPool Instance { get { return instance; } }

        //esto es del pool
        public List<GameObject> pool = new List<GameObject>();
        public GameObject prefab;
        public int initialSize = 10;

        private void Awake()
        {
            instance = this;
        }

        void Initialize()
        {
            GameObject objTmp;
            for (int i = 0; i < initialSize; i++)
            {
                objTmp= Instantiate(prefab);
                objTmp.SetActive(false);
                pool.Add(objTmp);

            }
        }

        public GameObject GetPooledObject(Vector3 ObjectPosition)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if(!pool[i].activeInHierarchy)
                {
                    pool[i].transform.position = ObjectPosition;
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }

            GameObject objTmp;
            objTmp = Instantiate(prefab);
            objTmp.transform.position = ObjectPosition;
            pool.Add(objTmp);
            return objTmp;
        }

        private void OnEnable()
        {
            Initialize();
        }


    }
}

