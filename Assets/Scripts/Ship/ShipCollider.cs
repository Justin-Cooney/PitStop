﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ship
{
	public class ShipCollider : MonoBehaviour
	{
		public void OnTriggerEnter(Collider other)
		{
			Debug.Log("Collide");
			if(other.GetComponent<DoorPanel>())
				Debug.Log("DOOR HURT ME!");
		}
	}
}
