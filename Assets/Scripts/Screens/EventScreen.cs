using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Events;
using UnityEngine.UI;

public class EventScreen : MonoBehaviour
{
	[Inject]
	private IObservable<LogEvent> _events;
	private TextMesh _text; 

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_events.Subscribe(OnEvent);
	}

	private void OnEvent(LogEvent e)
	{
		_text.text = e.Message;
	}
}
