using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControllerMap.IPlayerMainMapActions
{
	private PlayerControllerMap playerControllerMap;
	public PlayerControllerMap PlayerControllerMap => playerControllerMap;
	private Vector2 movementInput;
	public Vector2 MovementInput => movementInput;
	private Vector2 lookInput;
	public Vector2 LookInput => lookInput;
	private bool playerControlsOverride = false;
	public bool PlayerControlsOverride
	{
		get => playerControlsOverride;
		set { playerControlsOverride = value; }
	}
	public event Action onJump;
	public event Action onSprint;
	public event Action onDash;
	public event Action<bool> onAttack;
	private bool isAttacking = false;
	public bool IsAttacking => isAttacking;


	//enable controller map
	private void OnEnable()
	{
		playerControllerMap = new PlayerControllerMap();
		playerControllerMap.PlayerMainMap.SetCallbacks(this);
		playerControllerMap.Enable();
	}

	//disable controller map
	private void OnDisable()
	{
		playerControllerMap.Disable();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		if (playerControlsOverride) return;
		movementInput = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		if (playerControlsOverride) return;
		lookInput = context.ReadValue<Vector2>();
	}

	public void OnSprint(InputAction.CallbackContext context)
	{
		if (playerControlsOverride || !context.performed)
		onSprint?.Invoke();
	}

	public void OnDash(InputAction.CallbackContext context)
	{
		if (playerControlsOverride || !context.performed) return;
		onDash?.Invoke();
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (playerControlsOverride || !context.performed) return;
		onJump?.Invoke();
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		if (playerControlsOverride) return;
		
		if(context.performed)
		{
			isAttacking = true;
			onAttack?.Invoke(isAttacking);
		}
		else if(context.canceled)
		{
			isAttacking = false;
			onAttack?.Invoke(!isAttacking);
		}
	}
}
