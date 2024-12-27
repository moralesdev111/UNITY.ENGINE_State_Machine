using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
	public PlayerFreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) {}
	private readonly int FreeLookBlendTreeHash = Animator.StringToHash("MovingBlendTree");

	public override void Enter()
	{
		playerStateMachine.PlayerController.onJump += OnJump;
		playerStateMachine.PlayerController.onSprint += playerStateMachine.Sprint;
		playerStateMachine.PlayerController.onDash += playerStateMachine.Dash;
		playerStateMachine.PlayerController.onAttack += OnAttack;

		playerStateMachine.PlayerAnimator.Play(FreeLookBlendTreeHash);
		
	}
	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.IsSprinting ? playerStateMachine.SprintSpeed : playerStateMachine.MovementSpeed);
	}

	public override void Exit()
	{
		playerStateMachine.PlayerController.onJump -= OnJump;
		playerStateMachine.PlayerController.onSprint -= playerStateMachine.Sprint;
		playerStateMachine.PlayerController.onDash -= playerStateMachine.Dash;
		playerStateMachine.PlayerController.onAttack -= OnAttack;
	}

	private void OnJump()
	{
		playerStateMachine.SwitchState(new PlayerJumpState(playerStateMachine));
	}

	private void OnAttack(bool toggle)
	{
		if(toggle) playerStateMachine.SwitchState(new PlayerAttackState(playerStateMachine, 0));
	}
}

