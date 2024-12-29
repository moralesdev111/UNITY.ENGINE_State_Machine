using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
	private readonly int isJumpingHash = Animator.StringToHash("isJumping");
	public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		Jump();
	}

	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.MovementSpeed);
		if (playerStateMachine.Velocity.y <= 0)
		{
			playerStateMachine.SwitchState(new PlayerFallState(playerStateMachine));
		}
	}

	public override void Exit()
	{
		playerStateMachine.PlayerAnimator.SetBool(isJumpingHash, false);
	}

	private void Jump()
	{
		if (playerStateMachine.IsGrounded)
		{
			playerStateMachine.PlayerAnimator.SetBool(isJumpingHash, true);
			playerStateMachine.Velocity.y = Mathf.Sqrt(playerStateMachine.JumpHeight * -2.0f * playerStateMachine.Gravity);
		}
	}
}
