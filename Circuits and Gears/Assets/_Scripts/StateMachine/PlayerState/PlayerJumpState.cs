using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
	private readonly int jumpHash = Animator.StringToHash("Jump");
	public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		Jump();
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(jumpHash, 0.15f);
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

	}

	private void Jump()
	{
		if (playerStateMachine.IsGrounded)
		{
			playerStateMachine.Velocity.y = Mathf.Sqrt(playerStateMachine.JumpHeight * -2.0f * playerStateMachine.Gravity);
		}
	}
}
