using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SlugSpawner : MonoBehaviour
{
	public GameObject Slug;
    public GameObject SpawnEffects;
    public float _frequencyMin = 20;
	public float _frequencyMax = 40;
	public float _timeToSpawn;

    [Inject]
    private Slug.SlugFactory slugFactory;

    public void Update()
	{
        _timeToSpawn -= 1 * Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            var position = new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10));
            slugFactory.Create();
            GameObject.Instantiate(SpawnEffects, position, Quaternion.identity);
            _timeToSpawn = UnityEngine.Random.Range(_frequencyMin, _frequencyMax);
        }
    }
}
