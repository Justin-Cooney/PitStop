using Assets.Scripts.Events;
using System;
using UnityEngine;
using Zenject;

public class DoorPanel : MonoBehaviour, IDoorPanel
{
    [Inject]
    public IObserver<ToggleDoor> _toggleDoor;
    public int DoorId;

    public void ToggleDoor()
    {
        Debug.Log("OPEN DOOR");
        _toggleDoor.OnNext(new ToggleDoor(DoorId));
    }
}
