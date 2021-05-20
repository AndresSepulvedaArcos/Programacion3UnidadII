using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rpg
{

    public class Character : MonoBehaviour,IGetData
    {
        public FCharacterData characterData;

        public FCharacterData GetCharacterData()
        {
            return characterData;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        
    }
}
