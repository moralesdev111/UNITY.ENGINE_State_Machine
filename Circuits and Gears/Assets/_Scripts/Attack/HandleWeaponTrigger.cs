using UnityEngine;

public class HandleWeaponTrigger : MonoBehaviour
{
    [SerializeField] private Collider weaponTrigger;


    public void ToggleWeaponTrigger()
    {
        weaponTrigger.enabled = !weaponTrigger.enabled;
    }
}
