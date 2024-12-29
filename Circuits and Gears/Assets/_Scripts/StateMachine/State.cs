//describes what a base state is and can do
using UnityEngine;

public abstract class State 
{
	//enter state logic
	public abstract void Enter();

	//update state logic
	public abstract void Tick(float deltaTime);

	//exit state logic
	public abstract void Exit();

	protected float GetNormalizedAnimationTime(Animator animator)
	{
		AnimatorStateInfo currentInformation = animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo nextInformation = animator.GetNextAnimatorStateInfo(0);

		if (animator.IsInTransition(0) && nextInformation.IsTag("Attack"))
		{
			return nextInformation.normalizedTime;
		}
		else if (!animator.IsInTransition(0) && currentInformation.IsTag("Attack"))
		{
			return currentInformation.normalizedTime;
		}
		else
		{
			return 0.0f;
		}
	}
}
