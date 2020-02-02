using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyEvent : MonoBehaviour
{
	public DamageEnemyEvent(float damageDealt)
	{
		this.damageDealt = damageDealt;
	}

	public float damageDealt { get; }
}
