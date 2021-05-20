using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace Rpg
{
    [System.Serializable]
    public struct FCharacterData
    {
        public float hp;
        public float speed;

         
        FCharacterData(float NewHP,float NewSpeed)
        {
            hp = NewHP;
            speed = NewSpeed;
        }

    }

}