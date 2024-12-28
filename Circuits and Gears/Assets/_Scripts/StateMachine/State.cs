//describes what a base state is and can do
public abstract class State 
{
	//enter state logic
	public abstract void Enter();

	//update state logic
	public abstract void Tick(float deltaTime);

	//exit state logic
	public abstract void Exit();
}
