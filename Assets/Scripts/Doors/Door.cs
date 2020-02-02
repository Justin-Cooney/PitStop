using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using UniRx;

namespace Assets.Scripts.Doors
{
	public class Door : MonoBehaviour
	{
		[Inject]
		IObservable<ToggleDoor> _toggleDoor;

		[Inject]
		IObserver<DoorUpdated> _doorUpdated;

		private AudioSource audioSource;

		public int DoorId;
		public bool _isOpen;

		[Inject]
		public void Initialize()
		{
			audioSource = GetComponent<AudioSource>();
			_toggleDoor.Where(e => e.DoorId == DoorId).Subscribe(OnToggleDoor);
		}

		public void OnToggleDoor(ToggleDoor e)
		{
			_isOpen = !_isOpen;
			audioSource.Play();
		}

		public void Update()
		{
			if (_isOpen)
			{
				var position = transform.position;
				position.y = 40;
				transform.position = Vector3.Lerp(transform.position, position, 8 * Time.deltaTime);
				_doorUpdated.OnNext(new DoorUpdated(DoorId, true));
			}
			else
			{
				var position = transform.position;
				position.y = 25;
				transform.position = Vector3.Lerp(transform.position, position, 10 * Time.deltaTime);
				_doorUpdated.OnNext(new DoorUpdated(DoorId, false));
			}
		}
	}
}
