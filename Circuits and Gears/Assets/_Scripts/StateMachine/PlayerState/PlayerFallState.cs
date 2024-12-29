using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
	private readonly int isFallingHash = Animator.StringToHash("Falling Idle");
	private readonly int isLandingHash = Animator.StringToHash("Landing");
	public PlayerFallState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}


	public override void Enter()
	{
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(isFallingHash, 0.15f);
	}
	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.MovementSpeed);
		if(playerStateMachine.IsGrounded && playerStateMachine.Velocity.y <= 0)
		{
			playerStateMachine.SwitchState(new PlayerFreeLookState(playerStateMachine));
		}
	}
	public override void Exit()
	{
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(isLandingHash, 0.15f);
	}
}
