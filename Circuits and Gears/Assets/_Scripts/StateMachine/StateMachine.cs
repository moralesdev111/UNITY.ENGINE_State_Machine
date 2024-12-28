using UnityEngine;
//describes what a base state machine is and can do
public abstract class StateMachine : MonoBehaviour
{
	//current state the entity is in
    private State currentState;

	//run the current state update logic
	private void Update()
	{
		currentState?.Tick(Time.deltaTime);
	}

	//exit state logic
	//set new state
	//enter state logic
	public void SwitchState(State newState)
	{
		currentState?.Exit();
		currentState = newState;
		currentState?.Enter();
	}
}
