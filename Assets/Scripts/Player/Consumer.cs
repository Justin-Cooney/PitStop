using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using UniRx;

namespace Assets.Scripts.Player
{
	public class Consumer : MonoBehaviour
	{
		[Inject]
		private IObservable<Event> _events;

		private int _tile;

		public void Start()
		{
			_events.Where(e => e.SomeProp == 5).Subscribe(SomeFunc);
		}

		private void SomeFunc(Event e)
		{
			Debug.Log(e.SomeProp);
		}

	}
}
