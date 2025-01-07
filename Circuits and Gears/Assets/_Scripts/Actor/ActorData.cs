using UnityEngine;

//base actor data class for this game
[System.Serializable]
public class ActorData
{
	//types of actors
	public enum ActorType
	{
		Resource,
		Note
	}

	[SerializeField] private ActorType actorType;
	public ActorType _actorType => actorType;
	public string actorName;
	public Sprite actorSprite;
}