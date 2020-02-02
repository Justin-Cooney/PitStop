using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;
using UniRx;

public class ShipEnteringScreen : MonoBehaviour
{
    [Inject]
    public IObservable<ShipEnteringDock> _shipEnteringDock;

    private float _showtime;
    private TextMesh _textMesh;

    [Inject]
    public void Initialize()
    {
        _textMesh = GetComponent<TextMesh>();
        _textMesh.text = "";
        _shipEnteringDock.Subscribe(e => {
            _showtime = 5f;
            _textMesh.text = "SHIP\nENTERING\nDOCK";
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
