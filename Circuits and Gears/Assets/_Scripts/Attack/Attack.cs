using UnityEngine;

[System.Serializable]
public class Attack
{
	[SerializeField] private string animationName;
	public string AnimationName => animationName;
	[SerializeField] private float animationTransitionDuration;
	public float AnimationTransitionDuration => animationTransitionDuration;
	[SerializeField] private int comboStateIndex = -1;
	public int ComboStateIndex => comboStateIndex;
	[SerializeField] private float comboAttackTime;
	public float ComboAttackTime => comboAttackTime;
}
