using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private HealthComponent playerHealthComponent;


	private void OnEnable()
	{
		playerHealthComponent.onHealthChanged += SetHealthBarSlider;
	}

	private void OnDisable()
	{
		playerHealthComponent.onHealthChanged -= SetHealthBarSlider;
	}

	private void SetHealthBarSlider(int value)
    {
        healthbarSlider.value = value;
    }
}
