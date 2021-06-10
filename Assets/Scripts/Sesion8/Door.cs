using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace StealthGame
{
    public class Door : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
             
        }

        public void OpenDoor()
        {
            transform.DOLocalMoveY(2, 1);
        }

        void CloseDoor()
        {
            transform.DOLocalMoveY(0, 1);
        }
    }

}
