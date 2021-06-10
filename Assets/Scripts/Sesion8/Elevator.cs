using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StealthGame
{
    public class Elevator : MonoBehaviour
    {

        public float upSpeed = 2;
        public bool bElevatorReady;
        private void OnDisable()
        {
            GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
        }

        private void OnEnable()
        {
            GameManager.OnGameStateChange += GameManager_OnGameStateChange;
        }

        private void GameManager_OnGameStateChange(EGameStates gameState)
        {
            bElevatorReady= gameState == EGameStates.RoundOver;


        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(bElevatorReady)
            {
                transform.position += Vector3.up * Time.deltaTime * upSpeed;
            }
        }
    }
}

