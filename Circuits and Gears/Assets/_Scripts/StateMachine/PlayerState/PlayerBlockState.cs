using UnityEngine;

public class PlayerBlockState : PlayerBaseState
{
	private readonly int blockHash = Animator.StringToHash("Block");
	public PlayerBlockState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		playerStateMachine.PlayerController.CanBlock = true;
		playerStateMachine.HealthComponent.IsInvulnerable = true;

		playerStateMachine.PlayerController.onBlock += OnBlock;
		playerStateMachine.PlayerController.onAttack += OnAttack;
		
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(blockHash, 0.1f);
	}
	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
	}
	public override void Exit()
	{
		playerStateMachine.HealthComponent.IsInvulnerable = false;
		playerStateMachine.PlayerController.CanBlock = false;

		playerStateMachine.PlayerController.onBlock -= OnBlock;
		playerStateMachine.PlayerController.onAttack -= OnAttack;
	}

	private void OnBlock(bool toggle)
	{
		if (toggle) playerStateMachine.SwitchState(new PlayerFreeLookState(playerStateMachine));
	}

	private void OnAttack(bool toggle)
	{
		if(toggle) playerStateMachine.SwitchState(new PlayerAttackState(playerStateMachine, 0));
	}
}
