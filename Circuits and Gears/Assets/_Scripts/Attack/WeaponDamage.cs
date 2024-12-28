using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
	[SerializeField] private Collider playerCollider;
	private int damage;
	private List<Collider> alreadyCollidedWith = new List<Collider>();


	private void OnEnable()
	{
		alreadyCollidedWith.Clear();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == playerCollider) return;

		if(alreadyCollidedWith.Contains(other)) return;

		alreadyCollidedWith.Add(other);		

		if(other.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
		{
			if(other.CompareTag("Enemy"))
			{
				healthComponent.ChangeHealth(damage);
			}
		}
	}

	public void SetAttack(int damage)
	{
		this.damage = damage;
	}
}
