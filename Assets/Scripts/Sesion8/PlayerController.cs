using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StealthGame
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rb;

        Vector3 moveDirection=Vector3.zero;
        public float moveSpeed = 1f;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }
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
            switch (gameState)
            {
                case EGameStates.Waiting:
                    break;
                case EGameStates.Gameplay:
                    break;
                case EGameStates.RoundOver:
                    break;
                case EGameStates.GameOver:
                    break;
                default:
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if(other.CompareTag("Finish"))
            {
                GameManager.Instance.ChangeState(EGameStates.RoundOver);
            }
        }
        void MoveCharacter()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            moveDirection.z= v;
            moveDirection.x = h;

            rb.velocity = moveDirection * moveSpeed;

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            MoveCharacter();
        }
    }

}
