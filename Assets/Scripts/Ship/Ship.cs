using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum ShipPhase
{
    FIGHT, WAIT, DANGER_WAIT, HANGAR
}

public class Ship : MonoBehaviour
{

    //CONSTANTS
    private float HANGAR_MIN_TIME = 5f;
    private float HANGAR_MAX_TIME = 20f;

    [Inject]
    private IObserver<ShipCreatedEvent> _creationBus;

    private float currentPhaseLength;
    private float phaseCountdown;
    private ShipPhase phase = ShipPhase.HANGAR;
    public int shipID;
    private bool inHangar = false;

    private static int NEXT_SHIP_ID = 1;
    private static int COUNT = 0;

    private List<Part> parts = new List<Part>();
    [Inject]
    public void Initialize()
    {
        this.shipID = Ship.NEXT_SHIP_ID;
        //tell manager we exist
        _creationBus.OnNext(new ShipCreatedEvent(this));
        //put 1st ship in hangar (with very short timer). the rest are already fighting
        if (Ship.COUNT == 1)        {
            this.phase = ShipPhase.HANGAR;
            leaveHangar();
        }
        else
        {

        }
        Ship.NEXT_SHIP_ID++;
        Ship.COUNT++;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.phaseCountdown -= Time.deltaTime;
        if (this.phaseCountdown <= 0)
        {
            this.endPhase();
        }
    }

    private void endPhase()
    {
        switch (this.phase)
        {
            case ShipPhase.FIGHT:
                //BATTLE FUNCTIONS!
                break;
            case ShipPhase.WAIT:
                //OUTTA FUEL. ENTER DANGER_WAIT/ EMERGENCY LAND SEQUENCE
                break;
            case ShipPhase.DANGER_WAIT:
                //UNABLE TO MAKE EMERGENCY LANDING. RIP
                break;
            case ShipPhase.HANGAR:
                //GET BACK OUT AND FIGHT (enter FIGHT phase)
                leaveHangar();
                break;
        }
    }

    private float getHangarTime()
    {
        return UnityEngine.Random.Range(HANGAR_MIN_TIME, HANGAR_MAX_TIME);
    }

    private void enterHangar()
    {
        enterHangar(this.getHangarTime());
    }

    private void enterHangar(float repairTime)
    {

    }


    private void leaveHangar()
    {

    }
}

