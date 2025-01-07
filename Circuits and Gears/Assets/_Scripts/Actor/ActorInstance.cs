using UnityEngine;

public class ActorInstance : MonoBehaviour
{
	[SerializeField] private ActorData actorData;
	public ActorData ActorData
	{
		get => actorData;
		set => actorData = value;
	}
}