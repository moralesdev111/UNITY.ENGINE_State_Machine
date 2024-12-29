using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
	public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }
	private readonly int locomotionBlendTree = Animator.StringToHash("LocomotionBlendTree");
	private readonly int blendValue = Animator.StringToHash("Blend");
	private const float animationBlendTime = 0.15f;
	

	public override void Enter()
	{
		enemyStateMachine.EnemyAnimator.CrossFadeInFixedTime(locomotionBlendTree, animationBlendTime);
	}

	public override void Tick(float deltaTime)
	{
		if (!IsInChaseRange())
		{
			enemyStateMachine.SwitchState(new EnemyIdleState(enemyStateMachine));
		}
		else if(IsInAttackRange())
		{
			enemyStateMachine.SwitchState(new EnemyAttackState(enemyStateMachine));
		}
		MoveToPlayer(deltaTime);
		enemyStateMachine.EnemyAnimator.SetFloat(blendValue, 1.0f, animationBlendTime, deltaTime);
	}


	public override void Exit()
	{
		enemyStateMachine.NavMeshAgent.ResetPath();
	}

	private void MoveToPlayer(float deltaTime)
	{
		enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.PlayerHealthComponent.gameObject.transform.position);
	}

	private bool IsInAttackRange()
	{
		if (enemyStateMachine.PlayerHealthComponent.IsDead) return false;
		float playerDistanceSquare = (enemyStateMachine.PlayerHealthComponent.transform.position - enemyStateMachine.transform.position).sqrMagnitude;
		return playerDistanceSquare <= enemyStateMachine.AttackRange * enemyStateMachine.AttackRange;
	}
}
