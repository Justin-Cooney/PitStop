using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Screens;

public class AlienScreen : MonoBehaviour
{
    [Inject]
    public IObservable<SlugKilled> _slugKilled;

    [Inject]
    public IObservable<SlugSpawned> _slugSpawned;

    [Inject]
    public IObserver<IncrementDeathCount> _incrementDeathCount;

    [Inject]
    public IObserver<LogEvent> _logEvent;

    public int _slugs = 0;
    public float _countdown = 0;
    private TextMesh _text;

    [Inject]
    public void Initialize()
    {
        _text = GetComponent<TextMesh>();
        _slugSpawned.Subscribe(e =>
        {
            _slugs += 1;
            if (_slugs > 1)
                _text.text = "Warning: Alien presence detected";
        });
        _slugKilled.Subscribe(e => {
            _slugs -= 1;
            if (_slugs <= 1)
                _text.text = "";
        });
    }

    public void Update()
    {
        if (_countdown <= 0 && _slugs > 1)
        {
            _countdown = 5f;
        }
        _countdown -= 1 * Time.deltaTime;

        if(_countdown <= 0 && _slugs > 1)
        {
            _incrementDeathCount.OnNext(new IncrementDeathCount(1));
            _logEvent.OnNext(new LogEvent($"{NameGenerator.GetName()} was slugged to death."));
        }
    }

}
