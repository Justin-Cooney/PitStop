using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;

public class FireManager : MonoBehaviour
{
    public GameObject Fire;
    public float _frequencyMin = 20;
    public float _frequencyMax = 40;
    public float _timeToFire;

    [Inject]
    private IObserver<ShakeCamera> _shakeCamera;

    void Start()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        _timeToFire -= 1 * Time.deltaTime;
        if (_timeToFire <= 0)
        {
            GameObject.Instantiate(Fire, new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            GameObject.Instantiate(Fire, new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            GameObject.Instantiate(Fire, new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            GameObject.Instantiate(Fire, new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            _timeToFire = UnityEngine.Random.Range(_frequencyMin, _frequencyMax);
            _shakeCamera.OnNext(new ShakeCamera());
            Debug.Log("start shake");
        }
    }
}
