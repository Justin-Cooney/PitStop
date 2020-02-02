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
    private static float HANGAR_MIN_TIME = 5f;
    private static float HANGAR_MAX_TIME = 20f;
    public static float FUEL_TIME_RATIO = 0.01f;
    public static float EVASION_FUEL_COST = 0.1f;
    public static float AMMO_TIME_RATIO = 1;
    public static float AMMO_DAMAGE_RATTIO = 1;
    public static float ENEMY_ATTACK_RATE = 0.5f;
    public static float ENEMY_ACCURACY_THRESHOLD = 0.6f;
    public static float ENEMY_ATTACK_DAMAGE_MIN = 0.05f;
    public static float ENEMY_ATTACK_DAMAGE_MAX = 0.3f;

    [Inject]
    private IObserver<ShipCreatedEvent> _creationBus;

    [Inject]
    private IObserver<DamageEnemyEvent> _damageBus;

    private float currentPhaseLength;
    private float phaseCountdown;
    private float totalFuel;
    private float fuelConsumptionRate;

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
            startBattle();
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

    private void setPhaseDuration(float phaseTimeInSeconds)
    {
        this.currentPhaseLength = phaseTimeInSeconds;
        this.phaseCountdown = phaseTimeInSeconds;
    }

    private void endPhase()
    {
        switch (this.phase)
        {
            case ShipPhase.FIGHT:
                //BATTLE FUNCTIONS!
                endBattle();
                break;
            case ShipPhase.WAIT:
                //OUTTA FUEL. ENTER DANGER_WAIT/ EMERGENCY LAND SEQUENCE
                break;
            case ShipPhase.DANGER_WAIT:
                //UNABLE TO MAKE EMERGENCY LANDING. RIP
                break;
            case ShipPhase.HANGAR:
                //TODO: trigger animation

                //GET BACK OUT AND FIGHT (enter FIGHT phase)
                startBattle();
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
        setPhaseDuration(repairTime);
    }


    private void startBattle()
    {
        //TODO: remove this shitty and fake code
        setPhaseDuration(15f);
        this.randomizeShipCondition();
    }
    private void startBattleREAL()
    {
        //calculate fuel usage and thus calculate the time spent in battle
        checkFuel();
        float maxBattleTime = totalFuel / this.fuelConsumptionRate / FUEL_TIME_RATIO;
        setPhaseDuration(UnityEngine.Random.Range(maxBattleTime * 0.25f, maxBattleTime));
    }

    private void checkFuel()
    {
        this.totalFuel = 0f;
        float averageEngineIntegrity = 0f;
        if (this.engines.Length > 0)
        {
            foreach (Engine iEngine in this.engines)
            {
                totalFuel += iEngine.getFuel();
                averageEngineIntegrity += iEngine.getIntegrity();
            }
            averageEngineIntegrity /= this.engines.Length;
        }
        this.fuelConsumptionRate = (2 - averageEngineIntegrity);
    }

    private void consumeFuel(float totalFuelUsage)
    {
        if (this.engines.Length > 0)
        {
            float averageFuelUsage = totalFuelUsage / this.engines.Length;
            foreach (Engine iEngine in this.engines)
            {
                iEngine.useFuel(averageFuelUsage);
            }
        }
        this.totalFuel -= totalFuelUsage;
    }

    /**
     * This trash is for testing purposes. It will randomly deal some damage, use some fuel and use some ammo
     */
    private void randomizeShipCondition()
    {
        foreach (Part iPart in this.parts)
        {
            iPart.dealDamage(UnityEngine.Random.Range(0f, 0.3f));
        }
        foreach (Engine iEngine in this.engines)
        {
            iEngine.useFuel(UnityEngine.Random.Range(0f, 0.3f));
        }
        foreach (Weapon iWeapon in this.weapons)
        {
            iWeapon.useAmmoAndCalculateDamage(1f);
        }
    }

    private void endBattle()
    {
        //consume fuel (fuzzy)
        consumeFuel(this.fuelConsumptionRate * this.currentPhaseLength * FUEL_TIME_RATIO);
        //flip coin for INITIATIVE (enemy or WE attack first)
        if (
        UnityEngine.Random.value < 0.5)
        {
            enemyOffensive();
            shipOffensive();
        }
        else
        {
            shipOffensive();
            enemyOffensive();
        }
        //----->deal damage to enemy
        //----->take damage 
        //check for death
        //determine whether to enter WAIT or EMERGENY LANDING phase

        //TODO: remove this shitty and fake code
        this.enterHangar();
    }

    private void enemyOffensive()
    {
        //calculate # of attacks in time period. make that many attacks
        int enemyAttacks = Mathf.RoundToInt(this.currentPhaseLength * ENEMY_ATTACK_RATE);
        for (int i = 0; i < enemyAttacks; i++)
        {
            enemiesShootAtShip();
        }
    }

    private void enemiesShootAtShip()
    {
        //roll for hit/miss
        bool hit = UnityEngine.Random.value < ENEMY_ACCURACY_THRESHOLD;
        if (hit)
        {
            //allow for ship to burn extra fuel to reroll and take 2nd outcome
            if (this.totalFuel >= EVASION_FUEL_COST)
            {
                this.consumeFuel(EVASION_FUEL_COST);
                hit = UnityEngine.Random.value < ENEMY_ACCURACY_THRESHOLD;
            }
        }
        if (hit)
        {
            //roll for target
            int targetPartIndex = UnityEngine.Random.Range(0, this.parts.Length);
            this.parts[targetPartIndex].dealDamage(UnityEngine.Random.Range(ENEMY_ATTACK_DAMAGE_MIN, ENEMY_ATTACK_DAMAGE_MAX));
        }
    }

    private void shipOffensive()
    {
        //loop through weapons
        for (int i =0; i < this.weapons.Length; i++)
        {
            Weapon iWeapon = this.weapons[i];
            //check if this is a missile that has been badly damaged
            I_Explosive fireZeMissile = iWeapon as I_Explosive;
            if (fireZeMissile != null && fireZeMissile.atDeathlyIntegrity())
            {
                //explossion!!!!!!!1!!
                for (int j = 0; j < this.parts.Length; j++)
                {
                    this.parts[j].dealDamage(fireZeMissile.damageDoneIfDestroyed());
                }
            } else
            {
                //the number of shots taken is limited by time and ammunition
                float maxAttackTime = iWeapon.getAmmo() / iWeapon.getAmmoUsagePerSecond();
                float attackTime = maxAttackTime < this.currentPhaseLength ? maxAttackTime : this.currentPhaseLength;
                float ammoUsed = attackTime * iWeapon.getAmmoUsagePerSecond();
                //tell the sihp manager how much damage we dealt
                _damageBus.OnNext(new DamageEnemyEvent(iWeapon.useAmmoAndCalculateDamage(ammoUsed)));
            }
        }
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

