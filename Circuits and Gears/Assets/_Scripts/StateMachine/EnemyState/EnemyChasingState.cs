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
			return;
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
		enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.Player.transform.position);


	}
}
