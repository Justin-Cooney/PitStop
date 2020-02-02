﻿using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;
using UniRx;

public class ShipExitingScreen : MonoBehaviour
{
    [Inject]
    public IObservable<ShipExitingDock> _shipExitingDock;

    private float _showtime;
    private TextMesh _textMesh;

    [Inject]
    public void Initialize()
    {
        _textMesh = GetComponent<TextMesh>();
        _textMesh.text = "";
        _shipExitingDock.Subscribe(e => {
            _showtime = 5f;
            _textMesh.text = "SHIP\nEXITING\nDOCK";
        });
    }

    // Update is called once per frame
    void Update()
    {
        _showtime -= 1 * Time.deltaTime;
        if (_showtime <= 0)
            _textMesh.text = "";
    }
}