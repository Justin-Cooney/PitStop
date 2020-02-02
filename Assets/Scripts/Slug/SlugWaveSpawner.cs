using Assets.Scripts.Events;
using System;
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
    private IObservable<SlugKilled> _slugKilled;

    public int _slugCount;

    public Transform[] _spawnPoints;

    [Inject]
    public void Initialize()
    {
        _nextWave.Subscribe(e => NextWave());
        _slugKilled.Subscribe(e => _slugCount -= 1);
    }

    private void NextWave()
    {
        _number = _number + 8;
        _frequency = _frequency / 1.1f;
        _timeToSpawn = 0f;
    }

    public void Update()
	{
        _timeToSpawn -= 1 * Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            for(int i = 0; i < _number && _slugCount < 150; i++)
            {
                _slugCount += 1;
                _slugSpawned.OnNext(new SlugSpawned());
                var point = UnityEngine.Random.Range(0, _spawnPoints.Length - 1);
                var slug = slugFactory.Create();
                slug.GetComponent<CharacterController>().enabled = false;
                slug.transform.position = _spawnPoints[point].transform.position;
                slug.SetWaveMode();
                slug.GetComponent<CharacterController>().enabled = true;
                GameObject.Instantiate(SpawnEffects, _spawnPoints[point].transform.position, Quaternion.identity);
            }
            _timeToSpawn = _frequency;
        }
    }
}
