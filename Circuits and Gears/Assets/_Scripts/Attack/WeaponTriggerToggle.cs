using UnityEngine;

public class WeaponTriggerToggle : MonoBehaviour
{
    [SerializeField] private GameObject weaponTriggerGameObject;

    //toggle weapons trigger
    public void ToggleWeaponTrigger()
    {
		weaponTriggerGameObject.SetActive(!weaponTriggerGameObject.activeSelf);
    }
}
