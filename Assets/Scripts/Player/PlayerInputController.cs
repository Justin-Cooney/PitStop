﻿using UnityEngine;
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
			_playerController.InitAndSpawn();
		}
		
		public void OnActionButton(InputValue value)
		{
			_playerController.HandleActionButtonClick();
		}

		public void OnMove(InputValue value)
		{
			_playerController.OnMove(value);
		}

		public void OnSprint(InputValue value)
		{
			_playerController.OnSprint(value);
		}

		public void OnUseItem(InputValue value)
		{
			_playerController.OnUseItem(value);
		}
	}
}
