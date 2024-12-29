using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] private Animator enemyAnimator;
    public Animator EnemyAnimator => enemyAnimator;
    [SerializeField] private float chasingRange;
    public float ChasingRange => chasingRange;
	[SerializeField] private float attackRange;
	public float AttackRange => attackRange;
    [SerializeField] private int attackDamage;
    public int AttackDamage => attackDamage;
	[SerializeField] private HealthComponent playerHealthComponent;
    public HealthComponent PlayerHealthComponent => playerHealthComponent;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;
	[SerializeField] private WeaponTriggerToggle weaponTriggerToggle;
    public WeaponTriggerToggle WeaponTriggerToggle => weaponTriggerToggle;
    [SerializeField] private WeaponDamage weaponDamage;
	public WeaponDamage WeaponDamage => weaponDamage;
	[SerializeField] private Ragdoll ragdoll;
	public Ragdoll Ragdoll => ragdoll;


	private void OnEnable()
	{
		healthComponent.onDeath += HandleDeath;
	}

	private void OnDisable()
	{
		healthComponent.onDeath += HandleDeath;
	}


	private void Start()
    {
		playerHealthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();
        SwitchState(new EnemyIdleState(this));
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
	}

	private void HandleDeath()
	{
		SwitchState(new EnemyDeadState(this));
	}
}
