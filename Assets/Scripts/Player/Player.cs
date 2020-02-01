using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using static UnityEngine.InputSystem.InputAction;
using PlayerInput = Assets.Scripts.Player.PlayerInput;

public class Player : MonoBehaviour
{
	private PlayerInput _playerInput;
	private CharacterController _characterController;
	private float _speed = 5;
	private Vector2 _velocity;

	[Inject]
	public void Initialize(PlayerInput playerInput)
	{
		_playerInput = playerInput;
		_characterController = this.GetComponent<CharacterController>();
		_playerInput.PlayerControls.Enable();

		_playerInput.PlayerControls.Move.performed += OnMove;
		_playerInput.PlayerControls.Move.canceled += OnMoveCancelled;
	}

	public void Update()
	{
		_characterController.Move(new Vector3(_velocity.x, 0, _velocity.y) * _speed * Time.deltaTime);
	}

	private void OnMove(CallbackContext context)
	{
		_velocity = context.ReadValue<Vector2>();
	}

	private void OnMoveCancelled(CallbackContext context)
	{
		_velocity = Vector2.zero;
	}
}
