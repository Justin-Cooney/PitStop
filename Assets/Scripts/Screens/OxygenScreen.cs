using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Events;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts.Screens;

public class OxygenScreen : MonoBehaviour
{
	[Inject]
	private IObservable<DoorUpdated> _doorUpdated;
	[Inject]
	private IObserver<IncrementDeathCount> _deathCount;
	[Inject]
	private IObserver<LogEvent> _logEvent;
	[Inject]
	private IObserver<OxygenCritical> _oxygenCriticalEvents;

	private float _oxygen = 100.0f;
	private TextMesh _text;
	private float _reduceSpeed = 40f;
	private float _increaseSpeed = 20f;

	private bool[] _doorState = { false, false };
	
	private bool _oxygenCritical = false;
	private float _oxygenCriticalTime = 0;

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_doorUpdated.Subscribe(OnDoorUpdated);
	}

	private void OnDoorUpdated(DoorUpdated e)
	{
		_doorState[e.DoorId - 1] = e.Opened;
	}

	public void Update()
	{
		_oxygen -= _doorState.Where(s => s == true).Count() * _reduceSpeed * Time.deltaTime;

		if(!_doorState.Any(s => s == true))
			_oxygen += _increaseSpeed * Time.deltaTime;

		_oxygen = Mathf.Clamp(_oxygen, 0, 100);

		_oxygenCritical = _oxygen < 20;

		_oxygenCriticalEvents.OnNext(new OxygenCritical(_oxygenCritical));

		if (_oxygenCritical)
		{
			_oxygenCriticalTime += 1 * Time.deltaTime;
			if (_oxygenCriticalTime > 5)
			{
				KillSomeone();
				_oxygenCriticalTime = 0;
			}
		}
		else
			_oxygenCriticalTime = 0;

		_text.text = $"Oxygen Levels: {(int) _oxygen}%";
	}

	private void KillSomeone()
	{
		_deathCount.OnNext(new IncrementDeathCount(1));
		_logEvent.OnNext(new LogEvent($"{NameGenerator.GetName()} has suffocated and died."));
	}
}
