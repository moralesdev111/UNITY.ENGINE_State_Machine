using UnityEngine;

public class PlayerInteractState : PlayerBaseState
{
	private readonly int gatherHash = Animator.StringToHash("Gather");
	private readonly int readHash = Animator.StringToHash("Read");
	
	private ActorData actorDataInstance = null;
	private bool uiSet = false;

	public PlayerInteractState(PlayerStateMachine playerStateMachine, ActorData actorData) : base(playerStateMachine)
	{
		actorDataInstance = actorData;
	}

	public override void Enter()
	{
		if(actorDataInstance._actorType == ActorData.ActorType.Resource)
		{
			playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(gatherHash, 0.15f);
		}
		else if(actorDataInstance._actorType == ActorData.ActorType.Note)
		{
			playerStateMachine.PlayerAnimator.CrossFadeInFixedTime(readHash, 0.15f);
		}
		
	}

	public override void Tick(float deltaTime)
	{
		playerStateMachine.HandleGravity(deltaTime);

		if (AnimationHasFinished(gatherHash, 0))
		{
			playerStateMachine.SwitchState(new PlayerFreeLookState(playerStateMachine));
		}
		else if(AnimationHasFinished(readHash, 0))
		{
			if (uiSet == false)
			{
				playerStateMachine.BroadcastNotePanel(true);
				uiSet = true;
			}
		}
	}

	public override void Exit()
	{
		if (actorDataInstance._actorType == ActorData.ActorType.Note) return;
		playerStateMachine.Inventory.AddItem(playerStateMachine.ActorInstance.ActorData);
	}
}
//bool isGatherFinished = currentAnimation.shortNameHash == gatherHash && currentAnimation.normalizedTime >= 1.0f && !playerStateMachine.PlayerAnimator.IsInTransition(0);
//bool isReadFinished = currentAnimation.shortNameHash == readHash && currentAnimation.normalizedTime >= 1.0f && !playerStateMachine.PlayerAnimator.IsInTransition(0);

//return isGatherFinished || isReadFinished;