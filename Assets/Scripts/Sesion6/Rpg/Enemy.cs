using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rpg
{

    public class Enemy : MonoBehaviour, IGetData
    {
        public FCharacterData characterData;

        public FCharacterData GetCharacterData()
        {
            return characterData;
        }

        public void InitializeEnemy()
        {
            characterData.hp = 10;
            characterData.speed= Random.Range(5f, 16f);

        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        
    }
}
