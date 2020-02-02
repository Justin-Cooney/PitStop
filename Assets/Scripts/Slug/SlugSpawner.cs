using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class SlugSpawner : MonoBehaviour
{
	public GameObject Slug;
    public GameObject SpawnEffects;
    private float _frequencyMin = 15;
    private float _frequencyMax = 40;
	public float _timeToSpawn;

    [Inject]
    private Slug.SlugFactory slugFactory;

    [Inject]
    private IObserver<SlugSpawned> _slugSpawned;

    public void Update()
	{
        Debug.Log(_timeToSpawn);
        _timeToSpawn -= 1 * Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            var position = new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10));
            var slug = slugFactory.Create();
            slug.GetComponent<CharacterController>().enabled = false;
            slug.transform.position = position;
            slug.GetComponent<CharacterController>().enabled = true;
            GameObject.Instantiate(SpawnEffects, position, Quaternion.identity);
            _timeToSpawn = UnityEngine.Random.Range(_frequencyMin, _frequencyMax);
            _slugSpawned.OnNext(new SlugSpawned());
        }
    }
}
