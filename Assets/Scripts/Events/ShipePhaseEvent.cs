using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipePhaseEvent
{
	public ShipePhaseEvent(int shipID, EType eType)
	{
		this.shipID = shipID;
		this.eType = eType;
	}

	public int shipID { get; }
	public EType eType { get; }

	public enum EType
	{
		DEATH, EMERGENCY_LANDING, LEAVING_HANGAR
    }
}
