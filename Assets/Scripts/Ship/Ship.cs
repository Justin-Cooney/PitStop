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

    private static int NEXT_SHIP_ID = 1;
    private static int COUNT = 0;

    public Part[] parts;
    public Weapon[] weapons;
    public Engine[] engines;
    public I_Critical[] criticalParts;
    public I_Vulnerable[] vulnerableParts;
    public I_Explosive[] explosiveParts;

    [Inject]
    public void Initialize()
    {

        Ship.COUNT++;
        this.shipID = Ship.NEXT_SHIP_ID;
        //tell manager we exist
        _creationBus.OnNext(new ShipCreatedEvent(this));
        //put 1st ship in hangar (with very short timer). the rest are already fighting
        if (Ship.COUNT == 1)
        {
            enterHangar(3f);
        }
        else
        {
            enterBattle();
        }
        Ship.NEXT_SHIP_ID++;

        //quick and dirty collection of all child parts by type/interface
        parts = this.GetComponents<Part>();
        weapons = this.GetComponents<Weapon>();
        engines = this.GetComponents<Engine>();
        criticalParts = this.GetComponents<I_Critical>();
        vulnerableParts = this.GetComponents<I_Vulnerable>();
        explosiveParts = this.GetComponents<I_Explosive>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.phaseCountdown > 0)
        {
            this.phaseCountdown -= Time.deltaTime;
            if (this.phaseCountdown <= 0)
            {
                this.endPhase();
            }

        }
    }

    private void endPhase()
    {
        switch (this.phase)
        {
            case ShipPhase.FIGHT:
                //BATTLE FUNCTIONS!
                leaveBattle();
                break;
            case ShipPhase.WAIT:
                //OUTTA FUEL. ENTER DANGER_WAIT/ EMERGENCY LAND SEQUENCE
                break;
            case ShipPhase.DANGER_WAIT:
                //UNABLE TO MAKE EMERGENCY LANDING. RIP
                break;
            case ShipPhase.HANGAR:
                //GET BACK OUT AND FIGHT (enter FIGHT phase)
                enterBattle();
                break;
        }
    }

    private float calculateRepairTime()
    {
        return UnityEngine.Random.Range(HANGAR_MIN_TIME, HANGAR_MAX_TIME);
    }

    private void enterHangar()
    {
        enterHangar(this.calculateRepairTime());
    }

    private void enterHangar(float repairTime)
    {
        this.currentPhaseLength = repairTime;
        this.phaseCountdown = repairTime;
    }


    private void enterBattle()
    {
        //TODO: calculate fuel usage and thus calculate the time spent in battle

        //TODO: remove this shitty and fake code
        this.currentPhaseLength = 15f;
        this.phaseCountdown = 15f;
        this.randomizeShipCondition();
    }

    /**
     * This trash is for testing purposes. It will randomly deal some damage, use some fuel and use some ammo
     */
    private void randomizeShipCondition()
    {
        foreach(Part iPart in this.parts)
        {
            iPart.dealDamage(UnityEngine.Random.Range(0f, 0.3f));
        }
        foreach(Engine iEngine in this.engines)
        {
            iEngine.useFuel(UnityEngine.Random.Range(0f, 0.3f));
        }
        foreach(Weapon iWeapon in this.weapons)
        {
            iWeapon.useAmmo(1f);
        }
    }

    private void leaveBattle()
    {
        //TODO
        //consume fuel
        //flip coin for INITIATIVE (enemy or WE attack first)
        //----->deal damage to enemy
        //----->take damage 
        //check for death
        //determine whether to enter WAIT or EMERGENY LANDING phase

        //TODO: remove this shitty and fake code
        this.enterHangar();
    }

    private void enterWait()
    {

    }

    private void enterDangerWait()
    {

    }

    private void dieTerribleSpaceDeath()
    {

    }
}

