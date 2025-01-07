using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
	private readonly int freeLookBlendTreeHash = Animator.StringToHash("MovingBlendTree");

	public PlayerFreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) {}

	//unsub to player trigger
	private void OnDisable()
	{
		if (playerStateMachine.ActorTrigger != null)
		{
			playerStateMachine.ActorTrigger.onPlayerEnterTrigger -= playerStateMachine.ToggleRaycast;
		}
	}
	public override void Enter()
	{
		playerStateMachine.PlayerController.CanBlock = true;
		playerStateMachine.PlayerController.onJump += OnJump;
		playerStateMachine.PlayerController.onSprint += playerStateMachine.Sprint;
		playerStateMachine.PlayerController.onDash += playerStateMachine.Dash;
		playerStateMachine.PlayerController.onAttack += OnAttack;
		playerStateMachine.PlayerController.onBlock += OnBlock;

		AnimatorStateInfo currentAnimation = playerStateMachine.PlayerAnimator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimation.IsName("Falling Idle")) return;

		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(freeLookBlendTreeHash, 0.15f);
	}
	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.IsSprinting ? playerStateMachine.SprintSpeed : playerStateMachine.MovementSpeed);

		if (playerStateMachine.CanRaycast) playerStateMachine.Raycasting();
												
	}

	public override void Exit()
	{
		playerStateMachine.PlayerController.onJump -= OnJump;
		playerStateMachine.PlayerController.onSprint -= playerStateMachine.Sprint;
		playerStateMachine.PlayerController.onDash -= playerStateMachine.Dash;
		playerStateMachine.PlayerController.onAttack -= OnAttack;
		playerStateMachine.PlayerController.onBlock -= OnBlock;
	}

	private void OnJump()
	{
		playerStateMachine.SwitchState(new PlayerJumpState(playerStateMachine));
	}

	private void OnAttack(bool toggle)
	{
		if(toggle) playerStateMachine.SwitchState(new PlayerAttackState(playerStateMachine, 0));
	}

	private void OnBlock(bool toggle)
	{
		if (toggle) playerStateMachine.SwitchState(new PlayerBlockState(playerStateMachine));
	}
}

