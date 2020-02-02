using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipPhaseEvent
{
	public ShipPhaseEvent(Ship ship, EType eType)
	{
		this.ship = ship;
		this.eType = eType;
	}

	public Ship ship { get; }
	public EType eType { get; }

	public enum EType
	{
		DEATH, EMERGENCY_LANDING, LEAVING_HANGAR, TAKE_A_NUMBER
    }
}
