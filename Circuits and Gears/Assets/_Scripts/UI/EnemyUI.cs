using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
	[SerializeField] private Slider healthbarSlider;
	[SerializeField] private TextMeshProUGUI damagePopupText;
	[SerializeField] private HealthComponent enemyHealthComponent;
	[SerializeField] private float damagePopupTime = 0.5f;
	private Camera playerCamera;
	[SerializeField] private Transform enemyCanvasTransform;
	private bool healthBarSliderOn = false;


	private void OnEnable()
	{
		playerCamera = GameManager.Instance.PlayerCamera;
		enemyHealthComponent.onHealthChanged += SetHealthBarSlider;
		enemyHealthComponent.onDeath += TurnOffHealthBarSlider;
		enemyHealthComponent.onHealthChanged += SetDamagePopupText;
		enemyHealthComponent.onHealthChanged += OnHealthChangedHandling;
	}

	private void OnDisable()
	{
		enemyHealthComponent.onHealthChanged -= SetHealthBarSlider;
		enemyHealthComponent.onDeath -= TurnOffHealthBarSlider;
		enemyHealthComponent.onHealthChanged -= SetDamagePopupText;
		enemyHealthComponent.onHealthChanged -= OnHealthChangedHandling;
	}

	private void Update()
	{
		if (!healthBarSliderOn) return;
		enemyCanvasTransform.LookAt(playerCamera.transform);
	}

	private void SetHealthBarSlider(int value)
	{
		healthbarSlider.value = value;
		if (healthbarSlider.value >= 100) return;

		healthbarSlider.gameObject.SetActive(true);
		healthBarSliderOn = true;
	}

	private void TurnOffHealthBarSlider()
	{
		healthbarSlider.gameObject.SetActive(false);
		healthBarSliderOn = false;
	}

	private IEnumerator ShowDamagePopupAndTurnOff()
	{
		damagePopupText.gameObject.SetActive(true);
		yield return new WaitForSeconds(damagePopupTime);
		damagePopupText.gameObject.SetActive(false);
	}

	private void SetDamagePopupText(int value)
	{
		damagePopupText.text = (100 - value).ToString();
	}

	private void OnHealthChangedHandling(int value)
	{
		if (healthbarSlider.value >= 100) return;
		StartCoroutine(ShowDamagePopupAndTurnOff());
	}
}
