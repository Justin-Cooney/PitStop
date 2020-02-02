using UniRx;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ShipManager : MonoBehaviour
{

    public static float ENEMY_FORCE_MAX_HEALTH = 600f;

    [Inject]
    private IObservable<ShipPhaseEvent> _phaseEvents;
    [Inject]
    private IObservable<ShipCreatedEvent> _createEvents;
    [Inject]
    private IObservable<DamageEnemyEvent> _damageEnemyEvents;

    private Dictionary<int, Ship> shipByID = new Dictionary<int, Ship>();
    private int shipInHanger = 0;
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
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.DEATH).Subscribe(handleShipDeath);
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.LEAVING_HANGAR).Subscribe(handleShipDeparture);
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.EMERGENCY_LANDING).Subscribe(handleShipEmergency);
        _phaseEvents.Where(e => e.eType == ShipPhaseEvent.EType.TAKE_A_NUMBER).Subscribe(handleShipDockingRequest); 
        _createEvents.Subscribe(handleShipCreation);
        _damageEnemyEvents.Subscribe(handleEnemyDamage); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void handleShipDeath(ShipPhaseEvent e)
    {
        Debug.LogWarning("YO JUSTIN. CAN WE RIG THIS UP TO THE CASUALTY COUNTER AND/OR DISPLAY SCREEN?");
        shipByID.Remove(e.shipID);
        //if this ship was in the queue, remove it from the queue
        this.hangarQueue.Remove(e.shipID);
    }

    private void handleShipDeparture(ShipPhaseEvent e)
    {
        shipInHanger = 0;
        //check if anybody is in the lineup
        if (this.hangarQueue.Count > 0)
        {
            nextPlease();
        }
    }

    private void handleShipEmergency(ShipPhaseEvent e)
    {
        Debug.LogWarning("YO JUSTIN: NOT SURE HOW WE WANT THIS TO INTERACT WITH DOORS AND ALARMS AND STUFF. THERE IS POTENTIAL");
        //let the busted-ass ship skip the line
        this.hangarQueue.Remove(e.shipID);
        this.hangarQueue.Insert(0, e.shipID);
        //we are going to tell the current ship to GTFO
        if (shipInHanger > 0)
        {
            Ship currentShip = this.shipByID[shipInHanger];
            if (currentShip != null)
            {
                currentShip.startBattle();
            }
        }
    }

    private void handleShipDockingRequest(ShipPhaseEvent e)
    {
        //add this ship to the waiting list
        this.hangarQueue.Add(e.shipID);
        //if there is nobody here, just call them in now
        if (this.hangarQueue.Count == 1 && shipInHanger == 0)
        {
            nextPlease();
        }
    }

    private void nextPlease()
    {
        //tell the next ship in the queue that they may land
        int nextShipID = this.hangarQueue[0];
        this.hangarQueue.RemoveAt(0);
        inviteShipIntoHangar(nextShipID);
    }

    private void inviteShipIntoHangar(int siteID)
    {
        Ship nextShip = this.shipByID[siteID];
        if (nextShip != null)
        {
            nextShip.enterHangar();
            shipInHanger = siteID;
        }
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
