using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
	private readonly int freeLookBlendTreeHash = Animator.StringToHash("MovingBlendTree");
	private readonly int sheathHash = Animator.StringToHash("Sheath");
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
		playerStateMachine.PlayerController.onInteract += OnInteract;
		playerStateMachine.PlayerController.onSheath += OnSheath;

		AnimatorStateInfo currentAnimation = playerStateMachine.PlayerAnimator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimation.IsName("Falling Idle")) return;

		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(freeLookBlendTreeHash, 0.15f);
	}
	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);
		playerStateMachine.HandleMovement(deltaTime, playerStateMachine.IsSprinting ? playerStateMachine.SprintSpeed : playerStateMachine.MovementSpeed);

		if (playerStateMachine.CanRaycast) playerStateMachine.Raycasting();
		AnimatorStateInfo currentAnimation = playerStateMachine.PlayerAnimator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimation.IsName("Sheath"))
		{
			if(AnimationHasFinished(sheathHash) && !playerStateMachine.HasSheated)
			{
				playerStateMachine.Sheath();
				playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(freeLookBlendTreeHash, 0.15f);
			}
		}
	}

	public override void Exit()
	{
		playerStateMachine.PlayerController.onJump -= OnJump;
		playerStateMachine.PlayerController.onSprint -= playerStateMachine.Sprint;
		playerStateMachine.PlayerController.onDash -= playerStateMachine.Dash;
		playerStateMachine.PlayerController.onAttack -= OnAttack;
		playerStateMachine.PlayerController.onBlock -= OnBlock;
		playerStateMachine.PlayerController.onInteract -= OnInteract;
		playerStateMachine.PlayerController.onSheath -= OnSheath;
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

	private void OnInteract(ActorData actorData)
	{
		playerStateMachine.SwitchState(new PlayerInteractState(playerStateMachine, actorData));
	}

	private void OnSheath()
	{
		playerStateMachine.HasSheated = false;
		playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(sheathHash, 0.15f);
	}
}

