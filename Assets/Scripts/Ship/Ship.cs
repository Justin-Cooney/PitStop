using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ShipPhase
{
    FIGHT, WAIT, DANGER_WAIT, HANGAR
}

public class Ship : MonoBehaviour
{

    private float currentPhaseLength;
    private float phaseCountdown;
    private ShipPhase phase = ShipPhase.HANGAR;

    private List<Part> parts = new List<Part>();

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
                break;
        }
    }
}

