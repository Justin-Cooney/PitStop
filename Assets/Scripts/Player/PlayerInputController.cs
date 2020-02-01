using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	public class PlayerInputController : MonoBehaviour
	{
		private PlayerController _playerController;
		private static int _nextPlayerId = 1;
		private int _playerNumber;
		public void Awake()
		{
			_playerNumber = _nextPlayerId;
			_nextPlayerId++;
			_playerController = GameObject.Find($"Player{_playerNumber}").GetComponent<PlayerController>();
		}

		public void OnMove(InputValue value)
		{
			_playerController.OnMove(value);
		}
	}
}
