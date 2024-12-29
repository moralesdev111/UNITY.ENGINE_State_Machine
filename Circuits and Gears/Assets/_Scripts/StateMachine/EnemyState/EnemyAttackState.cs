using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
	private readonly int attackHash = Animator.StringToHash("EnemyAttack");
	private const float animationTransitionDuration = 0.15f;

	public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine){}


	public override void Enter()
	{
		enemyStateMachine.WeaponDamage.SetAttack(enemyStateMachine.AttackDamage);
		enemyStateMachine.EnemyAnimator.CrossFadeInFixedTime(attackHash, animationTransitionDuration);
		enemyStateMachine.WeaponTriggerToggle.ToggleWeaponTrigger();
	}
	public override void Tick(float deltaTime)
	{
		if (GetNormalizedAnimationTime(enemyStateMachine.EnemyAnimator) >= 1)
		{
			enemyStateMachine.SwitchState(new EnemyChasingState(enemyStateMachine));
		}
		FacePlayer();
	}

	public override void Exit()
	{
		enemyStateMachine.WeaponTriggerToggle.ToggleWeaponTrigger();
	}

	private void FacePlayer()
	{
		Vector3 directionToPlayer = (enemyStateMachine.PlayerHealthComponent.gameObject.transform.position - enemyStateMachine.transform.position).normalized;
		directionToPlayer.y = 0f;
		enemyStateMachine.transform.rotation = Quaternion.LookRotation(directionToPlayer);
	}
}
