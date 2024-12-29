//base for any player states
public abstract class EnemyBaseState : State
{
	//reference to enemyerstate machine
	protected EnemyStateMachine enemyStateMachine;

	//constructor takes in and sets a state machine
	public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        this.enemyStateMachine = enemyStateMachine;
    }

	//ai utility method to check if in range with player
    protected bool IsInChaseRange()
    {
		if (enemyStateMachine.PlayerHealthComponent.IsDead) return false;
		float distanceToPlayerSquare = (enemyStateMachine.PlayerHealthComponent.gameObject.transform.position - enemyStateMachine.transform.position).sqrMagnitude;
		return distanceToPlayerSquare <= enemyStateMachine.ChasingRange * enemyStateMachine.ChasingRange;
	}
}
