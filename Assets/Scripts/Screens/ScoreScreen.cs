using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Events;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
	[Inject]
	private IObservable<AddPoints> _events;

	private float _points = 0;
	private TextMesh _text; 

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_events.Subscribe(OnAddPoints);
	}

	private void OnAddPoints(AddPoints e)
	{
		_points += e.Points;
		_text.text = $"Workplace Efficiency Rating: { _points}";
	}
}
