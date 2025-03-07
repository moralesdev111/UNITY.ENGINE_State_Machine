//base for any player states
using UnityEngine;

public abstract class PlayerBaseState : State
{
	//reference to playerstate machine
	protected PlayerStateMachine playerStateMachine;

	//constructor takes in and sets a state machine
	public PlayerBaseState(PlayerStateMachine playerStateMachine)
	{
		this.playerStateMachine = playerStateMachine;
	}

	protected bool AnimationHasFinished(int animationHash, int layer)
	{
		AnimatorStateInfo currentAnimation = playerStateMachine.PlayerAnimator.GetCurrentAnimatorStateInfo(layer);

		return currentAnimation.shortNameHash == animationHash
		  && currentAnimation.normalizedTime >= 1.0f
		   && !playerStateMachine.PlayerAnimator.IsInTransition(0);
	}
}
