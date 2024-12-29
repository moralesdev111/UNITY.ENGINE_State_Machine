using UnityEngine;

public class GameManager : MonoBehaviour
{
	//
	//This is the MANAGER for the game
	//
	public static GameManager Instance { get; private set; }
	[SerializeField] private GameObject player;
    public GameObject Player => player;
	[SerializeField] private Camera playerCamera;
	public Camera PlayerCamera => playerCamera;


	//ensure single instance
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
