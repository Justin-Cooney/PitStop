using UniRx;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ShipManager : MonoBehaviour
{

    [Inject]
    private IObservable<ShipPhaseEvent> _phaseEvents;
    [Inject]
    private IObservable<ShipCreatedEvent> _createEvents;

    //constants. TODO: test and find logical values
    public static int FUEL_TIME_RATIO = 1;
    public static int AMMO_TIME_RATIO = 1;
    public static int AMMO_DAMAGE_RATTIO = 1;

    private Dictionary<int, Ship> shipByID = new Dictionary<int, Ship>();
    private List<int> hangarQueue = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.DEATH).Subscribe(handleShipDeath);
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.LEAVING_HANGAR).Subscribe(handleShipDeparture);
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.EMERGENCY_LANDING).Subscribe(handleShipEmergency);
        _createEvents.Subscribe(handleShipCreation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void handleShipDeath(ShipPhaseEvent e)
    {

    }

    private void handleShipDeparture(ShipPhaseEvent e)
    {

    }

    private void handleShipEmergency(ShipPhaseEvent e)
    {

    }

    private void handleShipCreation(ShipCreatedEvent e)
    {
        this.shipByID[e.ship.shipID] = e.ship;
    }
}
