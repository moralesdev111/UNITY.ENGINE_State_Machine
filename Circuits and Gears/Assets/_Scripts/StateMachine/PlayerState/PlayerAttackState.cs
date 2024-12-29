using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
	private AttackData currentAttackData;


	public PlayerAttackState(PlayerStateMachine playerStateMachine, int attackID) : base(playerStateMachine)
	{
		currentAttackData = playerStateMachine.AttackDataArray[attackID];
	}

	public override void Enter()
	{
		playerStateMachine.WeaponDamage.SetAttack(currentAttackData.AttackDamage);
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(currentAttackData.AnimationName, currentAttackData.AnimationTransitionDuration);
		playerStateMachine.Dash();
		playerStateMachine.WeaponTriggerToggle.ToggleWeaponTrigger();
	}

	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		float normalizedTime = GetNormalizedAnimationTime(playerStateMachine.PlayerAnimator);
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

	private void TryComboAttack(float normalizedTime)
	{
		if (currentAttackData.ComboStateIndex == -1) return;
		if (normalizedTime < currentAttackData.ComboAttackTime) return;

		playerStateMachine.SwitchState
			(
			new PlayerAttackState
			(
				playerStateMachine,
			currentAttackData.ComboStateIndex
			)
		);
	}
}
