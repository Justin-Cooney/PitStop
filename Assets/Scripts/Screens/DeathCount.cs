using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Events;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
	[Inject]
	private IObservable<IncrementDeathCount> _events;

	private int _deathCount = 0;
	private TextMesh _text; 

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_events.Subscribe(OnIncrementDeathCount);
	}

	private void OnIncrementDeathCount(IncrementDeathCount e)
	{
		_deathCount += e.NumberOfDeaths;
		_text.text = $"Casualties: {_deathCount}";
	}
}
