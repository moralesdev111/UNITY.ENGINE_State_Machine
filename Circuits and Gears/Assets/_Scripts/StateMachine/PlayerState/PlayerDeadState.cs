
public class PlayerDeadState : PlayerBaseState
{
	public PlayerDeadState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		playerStateMachine.Ragdoll.ToggleRagdoll(true);
		playerStateMachine.WeaponDamage.gameObject.SetActive(false);
		playerStateMachine.PlayerController.enabled = false;
	}
	public override void Tick(float deltaTime)
	{

	}

	public override void Exit()
	{

	}
}
