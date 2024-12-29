using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    private Collider[] colliders;
    private Rigidbody[] rigidbodies;


    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>(true);
        rigidbodies = GetComponentsInChildren<Rigidbody>(true);
        ToggleRagdoll(false);
    }

    public void ToggleRagdoll(bool toggle)
    {
        for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].CompareTag("Ragdoll"))
                {
                    colliders[i].enabled = toggle;
                }
            }

		for (int i = 0; i < rigidbodies.Length; i++)
		{
			if (rigidbodies[i].CompareTag("Ragdoll"))
			{
				rigidbodies[i].isKinematic = !toggle;
                rigidbodies[i].useGravity = toggle;
			}
		}

		animator.enabled = !toggle;
        if (playerController != null)
		{
            playerController.enabled = !toggle;
        }
	}
}
