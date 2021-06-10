using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 namespace StealthGame
{
    public enum AIState {  NONE,PATROL,CHASE,ATTACK}
    public class Enemy : MonoBehaviour
    {
        NavMeshAgent agent;

        public AIState aIState;


        public float wanderArea = 2f;
        public float remainMinDistance = .5f;
        public float remainingDistance = 0;
        [Header("aI STATUS")]
        public NavMeshPathStatus navMeshPathStatus;
        public bool pathPending;
        public delegate void FNotifyPlayerFound(Enemy instigator,Vector3 LastPositionSeen);
        public static event FNotifyPlayerFound OnPlayerDetected;


        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();

        }


        private void OnDisable()
        {
            Enemy.OnPlayerDetected -= Enemy_OnPlayerDetected;
        }
        
        private void OnEnable()
        {
            Enemy.OnPlayerDetected += Enemy_OnPlayerDetected;
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
                    StopAI();
                    break;
                case EGameStates.GameOver:
                    StopAI();
                    break;
                default:
                    break;
            }
        }

        void StopAI()
        {
            aIState = AIState.NONE;
            if(agent!=null)
            agent.isStopped = true;
        }
        private void Enemy_OnPlayerDetected(Enemy instigator, Vector3 LastPositionSeen)
        {
            if (instigator.GetInstanceID() == this.GetInstanceID())
            {
                aIState = AIState.ATTACK;
                return;
            }
            aIState = AIState.CHASE;
            agent.SetDestination(LastPositionSeen);

        }
        public void PlayerDetected(PlayerController player)
        {

            OnPlayerDetected?.Invoke(this, player.transform.position);

        }
        // Start is called before the first frame update
        void Start()
        {
            FindRandomPointPatrol();
        }

        void FindRandomPointPatrol()
        {
           
         Vector3 randomPosition=      Random.insideUnitSphere* wanderArea;
         randomPosition.y = transform.position.y;

            agent.SetDestination(randomPosition);

            navMeshPathStatus = agent.pathStatus;
            pathPending = agent.pathPending;
            
        }
        private void Update()
        {
            BehaviourTree();
        }
        void BehaviourTree()
        {

            switch(aIState)
            {
                case AIState.PATROL:
                    navMeshPathStatus = agent.pathStatus;
                    pathPending = agent.pathPending;
                    remainingDistance = agent.remainingDistance;
                    if (agent.remainingDistance < remainMinDistance)
                    {
                        Debug.Log("Change path again");
                        FindRandomPointPatrol();
                    }else if(navMeshPathStatus==NavMeshPathStatus.PathPartial)
                    {
                        FindRandomPointPatrol();
                    }
                       
                    break;
            }
        }
        
    }

}

