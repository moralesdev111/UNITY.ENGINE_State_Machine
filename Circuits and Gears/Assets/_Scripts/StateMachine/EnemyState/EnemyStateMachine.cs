using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] private Animator enemyAnimator;
    public Animator EnemyAnimator => enemyAnimator;
    [SerializeField] private float chasingRange;
    public float ChasingRange => chasingRange;
    [SerializeField] private GameObject player;
    public GameObject Player => player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;




    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        SwitchState(new EnemyIdleState(this));
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
	}

}
