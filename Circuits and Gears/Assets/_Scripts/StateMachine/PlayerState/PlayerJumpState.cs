using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
	private readonly int IsJumpingHash = Animator.StringToHash("isJumping");
	public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		playerStateMachine.PlayerController.onSprint += playerStateMachine.Sprint;
		Jump();
	}

	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.MovementSpeed);
		if (playerStateMachine.IsGrounded && playerStateMachine.Velocity.y <= 0)
		{
			playerStateMachine.SwitchState(new PlayerFreeLookState(playerStateMachine));
		}
	}

	public override void Exit()
	{
		playerStateMachine.PlayerAnimator.SetBool(IsJumpingHash, false);
		playerStateMachine.PlayerController.onSprint -= playerStateMachine.Sprint;
	}

	private void Jump()
	{
		if (playerStateMachine.IsGrounded)
		{
			playerStateMachine.PlayerAnimator.SetBool(IsJumpingHash, true);
			playerStateMachine.Velocity.y = Mathf.Sqrt(playerStateMachine.JumpHeight * -2.0f * playerStateMachine.Gravity);
		}
	}
}
