using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerBob : MonoBehaviour
	{
		private float _maxTime = 0.7f;
		private float _maxBob = 0.1f;
		private float _speed = 0.2f;
		private bool _goingUp = false;
		private float _timeLeft = 0;
		public void Update()
		{
			transform.position = new Vector3(transform.position.x, GetY(), transform.position.z);
			_timeLeft -= Time.deltaTime;

			if (_timeLeft <= 0)
			{
				_goingUp = !_goingUp;
				_timeLeft = _maxTime;
			}
		}

		private float GetY()
			=> transform.position.y + (_speed * (_goingUp ? 1 : -1) * Time.deltaTime);
	}
}
