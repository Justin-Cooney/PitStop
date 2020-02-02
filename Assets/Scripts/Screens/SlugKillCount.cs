using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class SlugKillCount : MonoBehaviour
{
	[Inject]
	public IObservable<SlugKilled> _slugKilled;

	private float _kills = 0;
	private TextMesh _text;

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_slugKilled.Subscribe(OnKill);
	}

	private void OnKill(SlugKilled e)
	{
		_kills += 1;
		_text.text = $"Zombie Slugs Eliminated: {_kills}";
	}
}
