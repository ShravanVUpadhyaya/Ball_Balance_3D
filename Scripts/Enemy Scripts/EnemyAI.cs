using UnityEngine;
using UnityEngine.AI;

namespace ZombieLabyrinth.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] Transform movePositionToPlayer;

        public Animator animator;

        private NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            
            navMeshAgent.destination = movePositionToPlayer.position;
            animator.SetFloat("Speed", 0.5f);
        }

        
    }
}