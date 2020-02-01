using Assets.Scripts.Player;
using UnityEngine;
using Zenject;
using static UnityEngine.Experimental.Input.InputAction;

public class Player : MonoBehaviour
{
	PlayerInput _playerInput;

	[Inject]
	public void Initialize(PlayerInput playerInput)
	{
		_playerInput = playerInput;
		_playerInput.PlayerControls.Enable();
		_playerInput.PlayerControls.MoveUp.performed += OnMoveUp;
	}

	public void Update()
	{
	}

	private void OnMoveUp(CallbackContext context)
	{
		Debug.Log("Up is pressed yo!");
	}
}
