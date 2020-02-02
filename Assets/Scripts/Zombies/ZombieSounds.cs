using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class ZombieSounds : MonoBehaviour
{
    public AudioClip Zombie1;
    public AudioClip Zombie2;
    public AudioClip Zombie3;
    public AudioClip Zombie4;
    public AudioClip Zombie5;
    public AudioClip ZombiesMedium;
    public AudioClip ZombiesLarge;

    [Inject]
    public IObservable<NextWave> _nextWave;

    private int _wave;
    private float _minFrequency = 5;
    private float _maxFrequency = 15;

    private AudioSource _audioSource;

    private AudioClip[] _clips = new AudioClip[] { };

    [Inject]
    public void Initialize()
    {
        _audioSource = GetComponent<AudioSource>();
        _nextWave.Subscribe(e => OnWave(e.Number));
    }

    public void OnWave(int wavenumber)
    {
        _wave = wavenumber;

        if(_wave == 1)
        {
            _clips = new[] { Zombie1, Zombie2, Zombie3 };
            Play(Zombie5);
            _timeToNextSound = 3f;
        }
        else if (_wave == 2)
        {
            _clips = new[] { Zombie1, Zombie2, Zombie3, Zombie4, Zombie5 };
            Play(Zombie2);
            _minFrequency = 4;
            _maxFrequency = 12;
        }
        else if (_wave == 3)
        {
            _clips = new[] { Zombie1, Zombie2, Zombie3, Zombie4, Zombie5 };
            Play(Zombie3);
            _minFrequency = 2;
            _maxFrequency = 6;
        }
        else if (_wave == 4)
        {
            _clips = new[] { Zombie1, Zombie2, Zombie3, Zombie4, Zombie5, ZombiesMedium };
            Play(ZombiesMedium);
            _minFrequency = 2;
            _maxFrequency = 4;
        }
        else if (_wave == 5)
        {
            _clips = new[] { Zombie2, Zombie3, Zombie4, Zombie5, ZombiesMedium };
            Play(ZombiesMedium);
            _minFrequency = 1;
            _maxFrequency = 4;
        }
        else if (_wave == 6)
        {
            _clips = new[] { Zombie3, Zombie4, ZombiesMedium };
            Play(ZombiesMedium);
            _minFrequency = 0.8f;
            _maxFrequency = 3;
        }
        else if (_wave == 7)
        {
            _clips = new[] { ZombiesMedium };
            Play(ZombiesMedium);
            _minFrequency = 0.5f;
            _maxFrequency = 2;
        }
        else if (_wave == 8)
        {
            _clips = new[] { ZombiesMedium, ZombiesLarge };
            Play(ZombiesLarge);
            _minFrequency = 0.8f;
            _maxFrequency = 3;
        }
        else
        {
            _clips = new[] { ZombiesMedium, ZombiesLarge };
            Play(ZombiesLarge);
            _minFrequency = 0.8f;
            _maxFrequency = 3;
        }
    }

    private float _timeToNextSound = 50f;

    public void Update()
    {
        _timeToNextSound -= 1 * Time.deltaTime;
        if(_timeToNextSound < 0)
        {
            PlayRandom(_clips);
            _timeToNextSound = UnityEngine.Random.Range(_minFrequency, _maxFrequency);
        }
    }

    private void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    private void PlayRandom(AudioClip[] clips)
    {
        Play(clips[UnityEngine.Random.Range(0, clips.Length - 1)]);
    }

}
