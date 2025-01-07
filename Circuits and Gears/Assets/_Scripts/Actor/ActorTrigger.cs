using UnityEngine;
using System;

public class ActorTrigger : MonoBehaviour
{
	public event Action<bool> onPlayerEnterTrigger;


	//set actor ref first
	//invoke trigger enter event
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStateMachine>().ActorTrigger = this;
			onPlayerEnterTrigger?.Invoke(true);
		}
	}

	//invoke trigger exit event first
	//set actorTrigger ref to null
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			onPlayerEnterTrigger?.Invoke(false);
			other.GetComponent<PlayerStateMachine>().ActorTrigger = null;
		}
	}
}