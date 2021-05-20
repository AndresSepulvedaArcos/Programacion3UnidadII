using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rpg
{
    public class RpgGameManager : MonoBehaviour
    {
        private static RpgGameManager instance;

        public static RpgGameManager Instance {  get { return instance; } }

        public Enemy enemyPrefab;

        public Character character;

        public List<GameObject> turns=new List<GameObject>();

        private void Awake()
        {
            instance = this;

        }

        private void Start()
        {
            InitializeCombat();
        }
        void InitializeCombat()
        {
            Enemy enemy;

            turns.Add(character.gameObject);

            for (int i = 0; i < Random.Range(1,3); i++)
            {
                enemy= Instantiate<Enemy>(enemyPrefab, Vector3.zero, Quaternion.identity);

                enemy.InitializeEnemy();
                turns.Add(enemy.gameObject);
            }

            ///arreglo o lista auxiliar 
            /// bubble sort
            for (int i = 0; i < turns.Count; i++)
            {
                Debug.LogFormat("el elemento en i: {0} su velocidad es  {1}", i, turns[i].GetComponent<IGetData>()?.GetCharacterData().speed);



            }

        }

    }

}

