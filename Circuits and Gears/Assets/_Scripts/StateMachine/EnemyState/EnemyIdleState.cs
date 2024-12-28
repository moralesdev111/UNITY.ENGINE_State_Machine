using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
	public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine){}
	private readonly int locomotionBlendTree = Animator.StringToHash("LocomotionBlendTree");
	private readonly int blendValue = Animator.StringToHash("Blend");
	private const float animationBlendTime = 0.15f;

	public override void Enter()
	{
		enemyStateMachine.EnemyAnimator.CrossFadeInFixedTime(locomotionBlendTree, animationBlendTime);
	}

	public override void Tick(float deltaTime)
	{
		if(IsInChaseRange())
		{
			enemyStateMachine.SwitchState(new EnemyChasingState(enemyStateMachine));
			return;
		}
		enemyStateMachine.EnemyAnimator.SetFloat(blendValue, 0.0f, animationBlendTime, deltaTime);
	}

	public override void Exit()
	{

	}
}
