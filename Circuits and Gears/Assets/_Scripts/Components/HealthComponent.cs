using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int currentHealth;
	public int CurrentHealth
	{
		get => currentHealth;
		set
		{
			currentHealth = Mathf.Clamp(value, 0, maxHealth);
			onHealthChanged?.Invoke(currentHealth);
			if (currentHealth == 0)
			{
				Destroy(gameObject);
				onDeath?.Invoke();
			}
		}
	}
	public event Action<int> onHealthChanged;
	public event Action onDeath;


	//set starting health
	private void Start()
	{
		CurrentHealth = maxHealth;
	}

	//change health given input damage
	public void ChangeHealth(int damage)
	{
		CurrentHealth -= damage;
	}
}