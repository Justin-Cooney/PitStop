using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class SlugWaveSpawner : MonoBehaviour
{
	public GameObject Slug;
    public GameObject SpawnEffects;
	public float _timeToSpawn = 0f;

    private float _number = 2;
    private float _frequency = 11f;

    [Inject]
    private Slug.SlugFactory slugFactory;

    [Inject]
    private IObserver<SlugSpawned> _slugSpawned;

    [Inject]
    private IObservable<NextWave> _nextWave;

    [Inject]
    public void Initialize()
    {
        _nextWave.Subscribe(e => NextWave());
    }

    private void NextWave()
    {
        _number = _number + 2;
        _frequency = _frequency / 1.25f;
        _timeToSpawn = 0f;
    }

    public void Update()
	{
        _timeToSpawn -= 1 * Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            for(int i = 0; i < _number; i++)
            {
                _slugSpawned.OnNext(new SlugSpawned());
                var position = new Vector3(transform.position.x, 0, transform.position.y);
                var slug = slugFactory.Create();
                slug.GetComponent<CharacterController>().enabled = false;
                slug.transform.position = transform.position;
                slug.SetWaveMode();
                slug.GetComponent<CharacterController>().enabled = true;
                GameObject.Instantiate(SpawnEffects, transform.position, Quaternion.identity);
            }
            _timeToSpawn = _frequency;
        }
    }
}
