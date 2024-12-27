using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;
	[SerializeField] private CharacterController characterController;
	[SerializeField] private float movementSpeed = 3.0f;
	[SerializeField] private float sprintSpeed = 6.0f;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float groundDistance;
	[SerializeField] private LayerMask groundMask;
	[SerializeField] private float gravity = -30.0f;
	[SerializeField] private float jumpHeight = 3.0f;
	private Vector3 velocity;
	private bool isGrounded;
	private bool isSprinting = false;
	[SerializeField] private float dashSpeed;
	[SerializeField] private float dashTime;
	[SerializeField] private float turnSmoothTime = 0.1f;
	private float turnSmoothVelocity;
	[SerializeField] private Transform playerCameraTransform;
	[SerializeField] private Animator playerAnimator;

	private void OnEnable()
	{
		playerController.onJump += Jump;
		playerController.onSprint += ToggleSprint;
		playerController.onDash += Dash;
	}

	private void OnDisable()
	{
		playerController.onJump -= Jump;
		playerController.onSprint -= ToggleSprint;
		playerController.onDash -= Dash;
	}

	private void Update()
	{
		//Gravity();
		//Movement();
	}

	private void Gravity()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2.0f;
			if (playerAnimator.GetBool("isJumping"))
			{
				playerAnimator.SetBool("isJumping", false);
			}
		}
		velocity.y += gravity * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}

	private void Movement()
	{
		Vector3 direction = new Vector3(playerController.MovementInput.x, 0, playerController.MovementInput.y).normalized;
		float inputMagnitude = Mathf.Clamp01(direction.magnitude);
		float currentSpeed = isSprinting ? sprintSpeed : movementSpeed;
		inputMagnitude *= currentSpeed / sprintSpeed;
		playerAnimator.SetFloat("inputMagnitude", inputMagnitude, 0.1f, Time.deltaTime);

		if (direction.magnitude > 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCameraTransform.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

			Vector3 moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
			characterController.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);
		}
	}

	private void Jump()
	{
		if (isGrounded)
		{
			playerAnimator.SetBool("isJumping", true);
			velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
		}
	}

	private void ToggleSprint()
	{
		if (!isGrounded) return;
		isSprinting = !isSprinting;
	}

	private void Dash()
	{
		if (!isGrounded) return;
		StartCoroutine(DashCoroutine());
	}

	private IEnumerator DashCoroutine()
	{
		Vector3 dashDirection = (playerController.MovementInput.y * transform.forward) +
								(playerController.MovementInput.x * transform.right);

		if (dashDirection.magnitude == 0f)
		{
			dashDirection = transform.forward; // Default to forward if no input
		}
		dashDirection.Normalize();

		float startTime = Time.time;

		while (Time.time < startTime + dashTime)
		{
			characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
			yield return null;
		}
	}
}


//Vector3 movement = (playerController.MovementInput.y * transform.forward) + (playerController.MovementInput.x * transform.right);
//if (movement.magnitude > 1f)
//{
//	movement.Normalize();
//}
//float currentSpeed = isSprinting ? sprintSpeed : movementSpeed;

//characterController.Move(movement * currentSpeed * Time.deltaTime);