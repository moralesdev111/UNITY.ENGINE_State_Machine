using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
	public PlayerDeadState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

	public override void Enter()
	{
		playerStateMachine.Ragdoll.ToggleRagdoll(true);
		playerStateMachine.WeaponDamage.gameObject.SetActive(false);
	}
	public override void Tick(float deltaTime)
	{

	}

	public override void Exit()
	{

	}
}
