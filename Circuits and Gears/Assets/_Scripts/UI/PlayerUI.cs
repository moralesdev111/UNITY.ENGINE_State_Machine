using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private HealthComponent playerHealthComponent;
	[SerializeField] private GameObject interactPanel;
	[SerializeField] private PlayerStateMachine playerStateMachine;


	private void OnEnable()
	{
		playerHealthComponent.onHealthChanged += SetHealthBarSlider;
		playerStateMachine.onSuccessfullRaycast += ToggleInteractPanel;
	}

	private void OnDisable()
	{
		playerHealthComponent.onHealthChanged -= SetHealthBarSlider;
		playerStateMachine.onSuccessfullRaycast -= ToggleInteractPanel;
	}

	private void SetHealthBarSlider(int value)
    {
        healthbarSlider.value = value;
    }

	private void ToggleInteractPanel(bool toggle)
	{
		interactPanel.SetActive(toggle);
	}
}
