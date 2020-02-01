using Assets.Scripts.Player;
using UnityEngine;
using Zenject;
using static UnityEngine.Experimental.Input.InputAction;

public class Player : MonoBehaviour
{
	private PlayerInput _playerInput;
	private CharacterController _characterController;
	private float _speed = 5;

	private bool _moveUp = false;

	[Inject]
	public void Initialize(PlayerInput playerInput)
	{
		_playerInput = playerInput;
		_characterController = this.GetComponent<CharacterController>();
		_playerInput.PlayerControls.Enable();
		_playerInput.PlayerControls.MoveUp.performed += OnMoveUp;
		_playerInput.PlayerControls.MoveDown.performed += OnMoveDown;
		_playerInput.PlayerControls.MoveLeft.performed += OnMoveLeft;
		_playerInput.PlayerControls.MoveRight.performed += OnMoveRight;
	}

	public void Update()
	{
		
	}

	private void OnMoveUp(CallbackContext context)
	{
		_characterController.Move(Vector3.forward * _speed * Time.deltaTime);
	}

	private void OnMoveDown(CallbackContext context)
	{
		_characterController.Move(Vector3.back * _speed * Time.deltaTime);
	}

	private void OnMoveLeft(CallbackContext context)
	{
		_characterController.Move(Vector3.left * _speed * Time.deltaTime);
	}

	private void OnMoveRight(CallbackContext context)
	{
		_characterController.Move(Vector3.right * _speed * Time.deltaTime);
	}
}
