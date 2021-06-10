using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StealthGame
{

    public class DetectionArea : MonoBehaviour
    {
        Enemy owner;

        private void Awake()
        {
            owner = GetComponentInParent<Enemy>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                owner.PlayerDetected(other.GetComponent<PlayerController>());

            }
        }
    }
}
