//base for any player states
public abstract class PlayerBaseState : State
{
	//reference to playerstate machine
	protected PlayerStateMachine playerStateMachine;

	//constructor takes in and sets a state machine
	public PlayerBaseState(PlayerStateMachine playerStateMachine)
	{
		this.playerStateMachine = playerStateMachine;
	}
}
