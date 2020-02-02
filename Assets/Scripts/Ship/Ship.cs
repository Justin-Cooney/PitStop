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
    public static float FUEL_TIME_RATIO = 0.04f;
    public static float EVASION_FUEL_COST = 0.1f;
    public static float AMMO_TIME_RATIO = 1;
    public static float AMMO_DAMAGE_RATTIO = 1;

    public static float ENEMY_ATTACK_RATE = 0.5f;
    public static float ENEMY_ACCURACY_THRESHOLD = 0.6f;
    public static float ENEMY_ATTACK_DAMAGE_MIN = 0.05f;
    public static float ENEMY_ATTACK_DAMAGE_MAX = 0.3f;

    public static float TOTAL_INTEGRITY_CRITICAL_THRESHOLD = 0.25f;
    public static float TOTAL_INTEGRITY_DEATHLY_THRESHOLD = 0.12f;

    [Inject]
    private IObserver<ShipCreatedEvent> _creationBus;

    [Inject]
    private IObserver<DamageEnemyEvent> _damageBus;

    [Inject]
    private IObserver<ShipPhaseEvent> _phaseBus;


    private float currentPhaseLength;
    private float phaseCountdown;
    private float totalFuel;
    private float fuelConsumptionModifier;

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

    private Animator animator;
    private Transform tform;

    [Inject]
    public void Initialize()
    {

        //quick and dirty collection of all child parts by type/interface
        parts = this.GetComponentsInChildren<Part>();
        weapons = this.GetComponentsInChildren<Weapon>();
        engines = this.GetComponentsInChildren<Engine>();
        criticalParts = this.GetComponentsInChildren<I_Critical>();
        vulnerableParts = this.GetComponentsInChildren<I_Vulnerable>();
        explosiveParts = this.GetComponentsInChildren<I_Explosive>();
        animator = this.GetComponent<Animator> ();
        tform = this.GetComponent<Transform> ();

        //ID stuff

        Ship.COUNT++;
        this.shipID = Ship.NEXT_SHIP_ID;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        //tell manager we exist
        _creationBus.OnNext(new ShipCreatedEvent(this));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("UPDATE: phaseCountdown: "+ phaseCountdown);
        if (Mathf.Pow(this.phaseCountdown, 2) > float.Epsilon)
        {
            this.phaseCountdown -= Time.deltaTime;
            if (this.phaseCountdown <= 0)
            {
                this.endPhase();
            }

        }
    }

    private void switchPhase(float phaseTimeInSeconds, ShipPhase newPhase)
    {
        this.currentPhaseLength = phaseTimeInSeconds;
        this.phaseCountdown = phaseTimeInSeconds;
        this.phase = newPhase;
        Debug.Log("SWITCH PHASE. TIMER: " + phaseTimeInSeconds + ", NEW PHASE: " + newPhase);
    }

    private void endPhase()
    {
        switch (this.phase)
        {
            case ShipPhase.FIGHT:
                //BATTLE FUNCTIONS!
                Debug.Log("END OF FIGHT PHASE. CALCULATE DAMAGE");
                endBattle();
                break;
            case ShipPhase.WAIT:
                //OUTTA FUEL. ENTER DANGER_WAIT/ EMERGENCY LAND SEQUENCE
                Debug.Log("END OF WAIT PHASE. HALP");
                enterDangerWait();
                break;
            case ShipPhase.DANGER_WAIT:
                //UNABLE TO MAKE EMERGENCY LANDING. RIP
                Debug.Log("END OF DANGER PHASE. R I P");
                dieTerribleSpaceDeath();
                break;
            case ShipPhase.HANGAR:
                //GET BACK OUT AND FIGHT (enter FIGHT phase)
                Debug.Log("END OF HANGAR PHASE. FIGHT FIGHT FIGHT ");
                startBattle();
                break;
        }
    }

    private float calculateRepairTime()
    {
        return UnityEngine.Random.Range(HANGAR_MIN_TIME, HANGAR_MAX_TIME);
    }

    public void enterHangar()
    {
        if(this.phase == ShipPhase.DANGER_WAIT) {
            tform.rotation = Quaternion.identity;
            tform.position = new Vector3 (50, 15, -5);
            animator.SetTrigger ("FlyInCritical");
        } else {
            tform.rotation = Quaternion.identity;
            tform.position = new Vector3 (100, 25, -5);
            animator.SetTrigger ("FlyIn");
        }

        //determine how much fuel was spend just FLYING AROUND and WAITING        
        float timeElapsed = currentPhaseLength - phaseCountdown;
        consumeFuel(this.fuelConsumptionModifier * timeElapsed * FUEL_TIME_RATIO);
        enterHangar(this.calculateRepairTime());
    }

    public void enterHangar(float repairTime)
    {
        switchPhase(repairTime, ShipPhase.HANGAR);
    }

    public void startBattle()
    {
        tform.rotation = Quaternion.identity;
        tform.position = new Vector3 (0, 2, -5);
        animator.SetTrigger ("FlyOut");
        //tell the ship manager that we are leaving
        _phaseBus.OnNext(new ShipPhaseEvent(this.shipID, ShipPhaseEvent.EType.LEAVING_HANGAR));
        //calculate fuel usage and thus calculate the time spent in battle
        checkFuel();
        float maxBattleTime = totalFuel / this.fuelConsumptionModifier / FUEL_TIME_RATIO;
        Debug.Log("FUEL CALC: " + maxBattleTime + " = " + totalFuel + " / " + this.fuelConsumptionModifier + " / " + FUEL_TIME_RATIO);
        switchPhase(UnityEngine.Random.Range(maxBattleTime * 0.25f, maxBattleTime), ShipPhase.FIGHT);
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
        this.fuelConsumptionModifier = (2 - averageEngineIntegrity);
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

    private void endBattle()
    {
        //consume fuel (fuzzy)
        consumeFuel(this.fuelConsumptionModifier * this.currentPhaseLength * FUEL_TIME_RATIO);
        //flip coin for INITIATIVE (enemy or WE attack first)
        if (UnityEngine.Random.value < 0.5)
        {
            enemyOffensive();
            shipOffensive();
        }
        else
        {
            shipOffensive();
            enemyOffensive();
        }
        //determine whether we are DEAD, okay to WAIT or need to make an EMERGENCY LANDING
        float averageIntegrity = 0f;
        if (this.parts.Length > 0)
        {
            foreach (Part iPart in this.parts)
            {
                averageIntegrity += iPart.getIntegrity();
            }
            averageIntegrity /= this.parts.Length;
        }

        //check for death
        bool fookinDeed = false;
        if (averageIntegrity <= TOTAL_INTEGRITY_DEATHLY_THRESHOLD)
        {
            fookinDeed = true;
        }
        if (!fookinDeed)
        {
            //check for any vulnerable parts being damaged beyond repair
            foreach (I_Vulnerable iWeakLink in this.vulnerableParts)
            {
                if (iWeakLink.atDeathlyIntegrity())
                {
                    fookinDeed = true;
                    break;
                }
            }
        }
        if (fookinDeed)
        {
            dieTerribleSpaceDeath();
            return;
        }

        //check for dire circumstances prompting an EMERGENCY LANDING
        bool thisIsAnEmergency = false;
        if (averageIntegrity <= TOTAL_INTEGRITY_CRITICAL_THRESHOLD || this.totalFuel <= 0f)
        {
            thisIsAnEmergency = true;
        }
        if (!thisIsAnEmergency)
        {
            //check for any important parts being hit a little too hard
            foreach (I_Critical iCritHitShit in this.criticalParts)
            {
                if (iCritHitShit.atCriticalIntegrity())
                {
                    thisIsAnEmergency = true;
                    break;
                }
            }
        }
        if (thisIsAnEmergency)
        {
            enterDangerWait();
            return;
        }

        //take a number and fly around until we run out of fuel or there is a vacancy in the hangar
        enterWait();
    }

    private void enemyOffensive()
    {
        //calculate # of attacks in time period. make that many attacks
        int enemyAttacks = Mathf.RoundToInt(this.currentPhaseLength * ENEMY_ATTACK_RATE);
        Debug.LogWarning("Enemy makes " + enemyAttacks + " attacks");
        for (int i = 0; i < enemyAttacks; i++)
        {
            enemiesShootAtShip();
        }
    }

    private void enemiesShootAtShip()
    {
        Debug.LogWarning("ENEMY SHOOTS");
        //roll for hit/miss
        bool hit = UnityEngine.Random.value < ENEMY_ACCURACY_THRESHOLD;
        if (hit)
        {
            Debug.LogWarning("ENEMY HITS");
            //allow for ship to burn extra fuel to reroll and take 2nd outcome
            if (this.totalFuel >= EVASION_FUEL_COST)
            {
                Debug.LogWarning("SHIP DODGES. " + this.totalFuel + " Fuel remaining");
                this.consumeFuel(EVASION_FUEL_COST);
                hit = UnityEngine.Random.value < ENEMY_ACCURACY_THRESHOLD;
            }
        }
        if (hit)
        {
            Debug.LogWarning("ENEMY STILL HITS!");
            //roll for target
            int targetPartIndex = UnityEngine.Random.Range(0, this.parts.Length);
            float enemyDamage = UnityEngine.Random.Range(ENEMY_ATTACK_DAMAGE_MIN, ENEMY_ATTACK_DAMAGE_MAX);
            Debug.LogWarning("ENEMY STILL HITS! Targets part at index " + targetPartIndex + " and deals " + enemyDamage + " damage!");
            this.parts[targetPartIndex].dealDamage(enemyDamage);
        }
    }

    private void shipOffensive()
    {
        //loop through weapons
        for (int i = 0; i < this.weapons.Length; i++)
        {
            Weapon iWeapon = this.weapons[i];
            //check if this is a missile that has been badly damaged
            I_Explosive fireZeMissile = iWeapon as I_Explosive;
            if (fireZeMissile != null && fireZeMissile.atDeathlyIntegrity())
            {
                //explossion!!!!!!!1!! damage all ship parts
                for (int j = 0; j < this.parts.Length; j++)
                {
                    this.parts[j].dealDamage(fireZeMissile.damageDoneIfDestroyed());
                }
                //reset missile hanger integrity to FULL
                iWeapon.fullRestore();
            }
            else
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
        checkFuel();
        float maxWaitTime = totalFuel / this.fuelConsumptionModifier / FUEL_TIME_RATIO;
        switchPhase(maxWaitTime, ShipPhase.WAIT);
        _phaseBus.OnNext(new ShipPhaseEvent(this.shipID, ShipPhaseEvent.EType.TAKE_A_NUMBER));
    }

    private void enterDangerWait()
    {
        switchPhase(5f, ShipPhase.DANGER_WAIT);
        _phaseBus.OnNext (new ShipPhaseEvent (this.shipID, ShipPhaseEvent.EType.EMERGENCY_LANDING));
    }

    private void dieTerribleSpaceDeath()
    {
        _phaseBus.OnNext(new ShipPhaseEvent(this.shipID, ShipPhaseEvent.EType.DEATH));
        //attempt to do clean-up
        _creationBus = null;
        _damageBus = null;
        _phaseBus = null;
        parts = null;
        weapons = null;
        engines = null;
        criticalParts = null;
        vulnerableParts = null;
        explosiveParts = null;
        //commit sudoku
        Destroy(gameObject);
    }

}
