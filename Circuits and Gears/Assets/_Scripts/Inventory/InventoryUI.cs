using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] private GameObject inventoryUI;
	[SerializeField] private GameObject inventorySlot;
	[SerializeField] private Transform inventorySlotParent;
	private Inventory inventory;
	private PlayerController playerController;
	private InventorySlot[] inventorySlots;
	private bool inventoryUi = false;


	//DI references
	//sub method
	private void OnEnable()
	{
		inventory = GameManager.Instance.Player.GetComponent<Inventory>();
		playerController = GameManager.Instance.Player.GetComponent<PlayerController>();
		playerController.onInventory += ToggleInventory;
		inventory.onInventoryChanged += ReDrawUI;
	}

	//unsub
	private void OnDisable()
	{
		playerController.onInventory -= ToggleInventory;
		inventory.onInventoryChanged -= ReDrawUI;
	}

	//initialize inventory ui
	private void Start()
	{
		InitializeInventorySlots();
	}

	//intitialize array
	//for loop over inventory size
	//instantiate slot 
	private void InitializeInventorySlots()
	{
		inventorySlots = new InventorySlot[inventory.InventorySize];
		for (int i = 0; i < inventory.InventorySize; i++)
		{
			GameObject newSlot = Instantiate(inventorySlot, inventorySlotParent);
			inventorySlots[i] = newSlot.GetComponent<InventorySlot>();
		}
	}

	//toggle inventory ui bool
	//set ui according to bool
	private void ToggleInventory()
	{
		inventoryUi = !inventoryUi;
		inventoryUI.SetActive(inventoryUi);
	}

	//for loop over inventory size
	//redraw ui of all slots
	public void ReDrawUI()
	{
		for (int i = 0; i < inventory._Inventory.Count && i < inventorySlots.Length; i++)
		{
			inventorySlots[i].UpdateSlotUIOnNewItem(inventory._Inventory[i]);
		}
	}
}