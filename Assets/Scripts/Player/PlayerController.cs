using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{
	[Inject]
	private IObserver<Event> _events;
	private CharacterController _characterController;
	private float _speed = 15;
	private float _rotationSpeed = 25;
	private Vector2 _velocity;
	private Vector2 _targetRotation;

	public int DeviceId;

	[Inject]
	public void Initialize()
	{
		_characterController = this.GetComponent<CharacterController>();
	}

	public void Update()
	{
		_characterController.Move(GetVelocity());
		transform.rotation = GetRotation();
	}

	private Vector3 GetVelocity()
		=> new Vector3(_velocity.x, 0, _velocity.y) * _speed * Time.deltaTime;

	private Quaternion GetRotation()
		=> Quaternion.Lerp(
			transform.rotation,
			Quaternion.Euler(new Vector3(0, Mathf.Atan2(_targetRotation.x, _targetRotation.y) * 180 / Mathf.PI, 0)),
			_rotationSpeed * Time.deltaTime);


	public void OnMove(InputValue value)
	{
		var direction = value.Get<Vector2>();
		if (Math.Abs(direction.x) > 0.1 || Math.Abs(direction.y) > 0.1)
		{
			_velocity = direction;
			_targetRotation = direction;
			_speed = 15;
		}
		else
		{
			_velocity = Vector2.zero;
		}
		_events.OnNext(new Event(5));
	}
}
