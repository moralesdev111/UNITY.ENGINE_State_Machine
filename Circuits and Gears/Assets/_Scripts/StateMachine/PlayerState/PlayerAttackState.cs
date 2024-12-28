using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
	private Attack currentAttack;


	public PlayerAttackState(PlayerStateMachine playerStateMachine, int attackID) : base(playerStateMachine)
	{
		currentAttack = playerStateMachine.Attacks[attackID];
	}

	public override void Enter()
	{
		playerStateMachine.WeaponDamage.SetAttack(currentAttack.AttackDamage);
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(currentAttack.AnimationName, currentAttack.AnimationTransitionDuration);
		playerStateMachine.Dash();

		playerStateMachine.WeaponTriggerToggle.ToggleWeaponTrigger();
	}

	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		float normalizedTime = GetNormalizedAnimationTime();
		if (normalizedTime < 1.0f)
		{
			if(playerStateMachine.PlayerController.IsAttacking)
			{
				TryComboAttack(normalizedTime);
			}
		}
		else
		{
			playerStateMachine.SwitchState(new PlayerFreeLookState(playerStateMachine));
		}
	}
	
	public override void Exit()
	{
		playerStateMachine.WeaponTriggerToggle.ToggleWeaponTrigger();
	}

	private float GetNormalizedAnimationTime()
	{
		AnimatorStateInfo currentInformation = playerStateMachine.PlayerAnimator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo nextInformation = playerStateMachine.PlayerAnimator.GetNextAnimatorStateInfo(0);

		if(playerStateMachine.PlayerAnimator.IsInTransition(0) && nextInformation.IsTag("Attack"))
		{
			return nextInformation.normalizedTime;
		}
		else if(!playerStateMachine.PlayerAnimator.IsInTransition(0) && currentInformation.IsTag("Attack"))
		{
			return currentInformation.normalizedTime;
		}
		else
		{
			return 0;
		}
	}

	private void TryComboAttack(float normalizedTime)
	{
		if (currentAttack.ComboStateIndex == -1) return;
		if (normalizedTime < currentAttack.ComboAttackTime) return;

		playerStateMachine.SwitchState
			(
			new PlayerAttackState
			(
				playerStateMachine,
			currentAttack.ComboStateIndex
			)
		);
	}
}
