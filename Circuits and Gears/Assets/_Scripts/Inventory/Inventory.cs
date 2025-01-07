using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour 
{
	[SerializeField] private List<ActorData> inventory;
	public List<ActorData> _Inventory => inventory;

	[SerializeField] private int inventorySize = 12;
	public int InventorySize { get { return inventorySize; } }
	private int itemCount = 0;
	private bool itemCanBeAdded => inventory.Count < inventorySize;

	public event Action onInventoryChanged;


 	//check if item can be added
	//add item to inventory
	//broadcast event
	public bool AddItem(ActorData item)
	{
		if (itemCanBeAdded)
		{
			inventory.Add(item);
			itemCount++;
			onInventoryChanged?.Invoke();
			return true;
		}
		return false;
	}

	//check if inventory contains item
	//remove item from inventory
	//broadcast event
	public void RemoveItem(ActorData item)
	{
		if (inventory.Contains(item))
		{
			inventory.Remove(item);
			onInventoryChanged?.Invoke();
		}
	}
}
