using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StealthGame
{
    public enum EGameStates { Waiting,Gameplay,RoundOver,GameOver}
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        public EGameStates gameState;

        public int CurrentLevel = 1;
        public delegate void FNotifyGameState(EGameStates gameState);
        public static event FNotifyGameState OnGameStateChange;
        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            Debug.Log("Call awake");
        }

        private void OnEnable()
        {
            Debug.Log("Call onenable");
        }

        private void OnLevelWasLoaded(int level)
        {
            Debug.Log("Call OnLevelWasLoaded --->" +level);
            ResetLevelStats();
        }

        void ResetLevelStats()
        {
            ChangeState(EGameStates.Waiting);

        }
        public void ChangeState(EGameStates NewGameState)
        {
            gameState = NewGameState;
            OnGameStateChange?.Invoke(gameState);

            switch (gameState)
            {
                case EGameStates.Waiting:
                    break;
                case EGameStates.Gameplay:
                    break;
                case EGameStates.RoundOver:
                    StartCoroutine(ChangeNextLevel());
                    break;
                case EGameStates.GameOver:
                    break;
                default:
                    break;
            }
        }

        IEnumerator ChangeNextLevel()
        {
            
            yield return new WaitForSeconds(2);
            CurrentLevel++;
            SceneManager.LoadScene("Sesion8Level" + CurrentLevel);
        }
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Call Start");
        }

        // Update is called once per frame
        
    }
}
