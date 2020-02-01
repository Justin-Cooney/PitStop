using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;


public class NewBehaviourScript : MonoBehaviour
{

    [Inject]
    private IObservable<ShipEvent> _events;

    //constants. TODO: test and find logical values
    private static int FUEL_TIME_RATIO = 1;
    private static int AMMO_TIME_RATIO = 1;
    private static int AMMO_DAMAGE_RATTIO = 1;

    private Dictionary<int, Ship> shipByID = new Dictionary<int, Ship>();
    private List<int> hangarQueue = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        _events.Where(e => e.eType == ShipEvent.EType.DEATH).Subscribe(handleShipDeath);
        _events.Where(e => e.eType == ShipEvent.EType.LEAVING_HANGAR).Subscribe(handleShipDeparture);
        _events.Where(e => e.eType == ShipEvent.EType.EMERGENCY_LANDING).Subscribe(handleShipEmergency);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void handleShipDeath(ShipEvent e)
    {

    }

    private void handleShipDeparture(ShipEvent e)
    {

    }

    private void handleShipEmergency(ShipEvent e)
    {

    }
}
