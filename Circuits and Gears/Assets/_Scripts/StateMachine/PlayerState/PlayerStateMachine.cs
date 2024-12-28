using System.Collections;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController => playerController;
	[SerializeField] private float movementSpeed = 3.0f;
	public float MovementSpeed => movementSpeed;
	[SerializeField] private float sprintSpeed = 6.0f;
	public float SprintSpeed => sprintSpeed;
	private bool isGrounded;
	public bool IsGrounded
	{
		get => isGrounded;
		set => isGrounded = value;
	}
	private bool isSprinting = false;
	public bool IsSprinting
	{
		get => isSprinting;
		set => isSprinting = value;
	}
	[SerializeField] private Animator playerAnimator;
	public Animator PlayerAnimator => playerAnimator;
	[SerializeField] private float turnSmoothTime = 0.1f;
	public float TurnSmoothTime => turnSmoothTime;
	public float TurnSmoothVelocity;
	[SerializeField] private Transform playerCameraTransform;
	public Transform PlayerCameraTransform => playerCameraTransform;
	[SerializeField] private Transform playerTransform;
	public Transform PlayerTransform => playerTransform;
	[SerializeField] private CharacterController characterController;
	public CharacterController CharacterController => characterController;
	[SerializeField] private Transform groundCheck;
	public Transform GroundCheck => groundCheck;
	[SerializeField] private float groundDistance;
	public float GroundDistance => groundDistance;
	[SerializeField] private LayerMask groundMask;
	public LayerMask GroundMask => groundMask;
	public Vector3 Velocity;

	[SerializeField] private float gravity = -30.0f;
	public float Gravity => gravity;
	[SerializeField] private float jumpHeight = 3.0f;
	public float JumpHeight => jumpHeight;
	[SerializeField] private float dashSpeed;
	public float DashSpeed => dashSpeed;
	[SerializeField] private float dashTime;
	public float DashTime => dashTime;
	[SerializeField] private Attack[] attacks;
	public Attack[] Attacks => attacks;
	[SerializeField] private WeaponTriggerToggle weaponTriggerToggle;
	public WeaponTriggerToggle WeaponTriggerToggle => weaponTriggerToggle;
	[SerializeField] private WeaponDamage weaponDamage;
	public WeaponDamage WeaponDamage => weaponDamage;
	private readonly int inputMagnitudeHash = Animator.StringToHash("inputMagnitude");


	private void Start()
    {
        SwitchState(new PlayerFreeLookState(this));
    }

	public void HandleMovement(float deltaTime, float speed)
	{
		Vector3 direction = new Vector3(PlayerController.MovementInput.x, 0, PlayerController.MovementInput.y).normalized;

		if (direction.magnitude > 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + PlayerCameraTransform.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(PlayerTransform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
			PlayerTransform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

			Vector3 moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
			CharacterController.Move(moveDirection.normalized * speed * deltaTime);
		}
		float inputMagnitude = Mathf.Clamp01(direction.magnitude) * (speed / SprintSpeed);
		PlayerAnimator.SetFloat(inputMagnitudeHash, inputMagnitude, 0.1f, deltaTime);
	}

	public void HandleGravity(float deltaTime)
	{
		IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

		if (IsGrounded && Velocity.y < 0)
		{
			Velocity.y = -1.5f;
		}
		Velocity.y += Gravity * deltaTime;
		CharacterController.Move(Velocity * deltaTime);
	}

	public void Sprint()
	{
		if (!IsGrounded) return;
		IsSprinting = !IsSprinting;
	}

	public void Dash()
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
			dashDirection = transform.forward;
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
