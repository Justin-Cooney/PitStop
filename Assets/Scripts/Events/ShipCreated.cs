using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipCreatedEvent
{
	public ShipCreatedEvent(Ship ship)
	{
		this.ship = ship;
	}

	public Ship ship { get; }
}
