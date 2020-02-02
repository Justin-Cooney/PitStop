using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class WaveScreen : MonoBehaviour
{
	[Inject]
	public IObserver<NextWave> _nextWave;

	[Inject]
	public IObservable<PlayerDead> _playerDead;

	[Inject]
	public IObserver<ToggleDoor> _toggleDoor;


	public AudioClip ClownMusic;
	public AudioClip ActionMusic;
	public AudioClip ScaryMusic;

	private AudioSource _audioSource;

	private int _waveNumber = 0;

	private TextMesh _text;
	private float _timeLeftInWave = 6f;

	private int _deaths = 0;
	private bool _gameOver = false;

	[Inject]
	private void Initalize()
	{
		_text = GetComponent<TextMesh>();
		_playerDead.Subscribe(e => {
			_deaths += 1;
			if (_deaths >= 4)
				EndGame();
		});
		_audioSource = GetComponent<AudioSource>();
	}

	public void Update()
	{
		_timeLeftInWave -= 1 * Time.deltaTime;
		if(_timeLeftInWave <= 0 && !_gameOver)
		{
			_waveNumber++;
			_nextWave.OnNext(new NextWave(_waveNumber));
			_text.text = $"Wave {_waveNumber}";
			_timeLeftInWave = 8f;
			_deaths = 0;

			if(_waveNumber == 0)
			{
				_audioSource.clip = ScaryMusic;
				_audioSource.Play();
			}
			if (_waveNumber == 4)
			{
				_audioSource.clip = ClownMusic;
				_audioSource.Play();
			}
			if (_waveNumber == 8)
			{
				_audioSource.clip = ActionMusic;
				_audioSource.Play();
				_toggleDoor.OnNext(new ToggleDoor(1));
				_toggleDoor.OnNext(new ToggleDoor(2));
			}
		}
	}

	private void EndGame()
	{
		//_gameOver = true;
	}
}
