using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;
using UniRx;

public class FireManager : MonoBehaviour
{
    public GameObject Fire;
    public float _frequencyMin = 15;
    public float _frequencyMax = 30;
    public float _timeToFire;
    public bool IsWaveManager = false;

    [Inject]
    public IObservable<NextWave> _nextWave;

    [Inject]
    private IObserver<ShakeCamera> _shakeCamera;

    void Start()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    [Inject]
    public void Initialize()
    {
        _nextWave.Where(e => e.Number >= 4).Subscribe(e => _waveFire = true);
    }

    private bool _waveFire = false;

    // Update is called once per frame
    void Update()
    {
        _timeToFire -= 1 * Time.deltaTime;
        if (_timeToFire <= 0 && (!IsWaveManager || _waveFire))
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
