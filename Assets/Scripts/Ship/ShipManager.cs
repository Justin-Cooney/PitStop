using UniRx;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ShipManager : MonoBehaviour
{

    public static float ENEMY_FORCE_MAX_HEALTH = 600f;

    [Inject]
    private IObservable<ShipePhaseEvent> _phaseEvents;
    [Inject]
    private IObservable<ShipCreatedEvent> _createEvents;
    [Inject]
    private IObservable<DamageEnemyEvent> _damageEnemyEvents;

    private Dictionary<int, Ship> shipByID = new Dictionary<int, Ship>();
    private List<int> hangarQueue = new List<int>();
    private float enemyHealthRemaining;

    [Inject]
    public void Initialize()
    {
        enemyHealthRemaining = ENEMY_FORCE_MAX_HEALTH;
    }

    // Start is called before the first frame update
    void Start()
    {
        _phaseEvents.Where(e => e.eType == ShipePhaseEvent.EType.DEATH).Subscribe(handleShipDeath);
        _phaseEvents.Where(e => e.eType == ShipePhaseEvent.EType.LEAVING_HANGAR).Subscribe(handleShipDeparture);
        _phaseEvents.Where(e => e.eType == ShipePhaseEvent.EType.EMERGENCY_LANDING).Subscribe(handleShipEmergency);
        _createEvents.Subscribe(handleShipCreation);
        _damageEnemyEvents.Subscribe(handleEnemyDamage); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void handleShipDeath(ShipePhaseEvent e)
    {

    }

    private void handleShipDeparture(ShipePhaseEvent e)
    {

    }

    private void handleShipEmergency(ShipePhaseEvent e)
    {

    }

    private void handleShipCreation(ShipCreatedEvent e)
    {
        this.shipByID[e.ship.shipID] = e.ship;
    }

    private void handleEnemyDamage(DamageEnemyEvent e)
    {
        this.enemyHealthRemaining -= e.damageDealt;
        if (this.enemyHealthRemaining < 0)
        {
            Debug.LogWarning("VICTORY! WE HAVE CRUSHED THE ENEMY SLIGHTLY FASTER THAN THEY CRUSHED US!!!!!!!!!!!!!!!!!!!!");
        }
    }
}
