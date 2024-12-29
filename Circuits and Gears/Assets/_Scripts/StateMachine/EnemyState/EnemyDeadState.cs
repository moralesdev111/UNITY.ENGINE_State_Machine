
public class EnemyDeadState : EnemyBaseState
{
	public EnemyDeadState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine){}

	public override void Enter()
	{
		enemyStateMachine.Ragdoll.ToggleRagdoll(true);
		enemyStateMachine.WeaponDamage.gameObject.SetActive(false);
	}
	public override void Tick(float deltaTime)
	{

	}

	public override void Exit()
	{
		
	}
}
