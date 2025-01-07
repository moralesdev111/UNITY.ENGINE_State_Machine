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
				onDeath?.Invoke();
				isDead = true;
			}
		}
	}
	public event Action<int> onHealthChanged;
	public event Action onDeath;
	private bool isDead = false;
	public bool IsDead => isDead;
	private bool isInvulnerable = false;
	public bool IsInvulnerable
	{
		get => isInvulnerable;
		set => isInvulnerable = value;
	}


	//set starting health
	private void Start()
	{
		CurrentHealth = maxHealth;
	}

	//change health given input damage
	public void ChangeHealth(int damage)
	{
		if (IsInvulnerable) return;

		CurrentHealth -= damage;
	}
}