﻿using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class FlashingLight : MonoBehaviour
{
    private Light _light;
    private bool _increasing;
    public bool AlwaysFlash = false;

    [Inject]
    public IObservable<ShakeCamera> _shakeCamera;

    public float _activeTime = 0;

    [Inject]
    public void Initialize()
    {
        _shakeCamera.Subscribe(e => {
            _activeTime = 3;
        });
    }

    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AlwaysFlash)
        {
            _activeTime -= 1 * Time.deltaTime;
            if (_activeTime <= 0)
                _increasing = false;
        }

        if (_increasing)
            _light.intensity += 2 * Time.deltaTime;
        else
            _light.intensity -= 2 * Time.deltaTime;

        if (_light.intensity <= 0)
            _increasing = true;
        if (_light.intensity >= 3)
            _increasing = false;
    }
}
