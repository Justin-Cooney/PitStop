using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Events;
using UnityEngine.UI;
using System.Linq;

public class OxygenCriticalScreen : MonoBehaviour
{
	[Inject]
	private IObservable<OxygenCritical> _oxygenCriticalEvents;

	[Inject]
	private void Initalize()
	{
		_oxygenCriticalEvents.Subscribe(e => gameObject.SetActive(e.IsCritical));
	}
}
