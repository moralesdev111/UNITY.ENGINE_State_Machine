using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private HealthComponent playerHealthComponent;
	[SerializeField] private GameObject interactPanel;
	[SerializeField] private GameObject notePanel;
	public GameObject NotePanel => notePanel;
	[SerializeField] private PlayerStateMachine playerStateMachine;


	private void OnEnable()
	{
		playerHealthComponent.onHealthChanged += SetHealthBarSlider;
		playerStateMachine.onSuccessfullRaycast += ToggleInteractPanel;
		playerStateMachine.onNotePanel += ToggleNotelPanel;
		playerStateMachine.PlayerController.onEscape += CloseUI;
	}

	private void OnDisable()
	{
		playerHealthComponent.onHealthChanged -= SetHealthBarSlider;
		playerStateMachine.onSuccessfullRaycast -= ToggleInteractPanel;
		playerStateMachine.onNotePanel -= ToggleNotelPanel;
		playerStateMachine.PlayerController.onEscape -= CloseUI;
	}

	private void SetHealthBarSlider(int value)
    {
        healthbarSlider.value = value;
    }

	private void ToggleInteractPanel(bool toggle)
	{
		interactPanel.SetActive(toggle);
	}

	private void ToggleNotelPanel(bool toggle)
	{
		notePanel.SetActive(toggle);
	}

	private void CloseUI()
	{
		if(notePanel.activeInHierarchy)
		{
			notePanel.SetActive(false);
		}
	}
}
