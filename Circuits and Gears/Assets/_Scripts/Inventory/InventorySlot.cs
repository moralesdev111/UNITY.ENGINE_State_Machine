using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] private Image slotImage;
	[SerializeField] private ActorData slotActor;
	[SerializeField] private TextMeshProUGUI slotName;
	[SerializeField] private TextMeshProUGUI slotAmount;

	//check if we need to clear item in slot
	//set slot item to desired item
	//set the slot item sprite to desired item sprite
	public void UpdateSlotUIOnNewItem(ActorData newActorData)
	{
		if (slotImage != null || slotActor != null || slotName != null)
		{
			ClearItem();
		}
		slotActor = newActorData;
		slotImage.sprite = newActorData.actorSprite;
		slotName.text = newActorData.actorName;
	}

	//clear slot
	//set its sprite to null
	public void ClearItem()
	{
		slotActor = null;
		slotImage.sprite = null;
		slotName.text = null;
	}
}