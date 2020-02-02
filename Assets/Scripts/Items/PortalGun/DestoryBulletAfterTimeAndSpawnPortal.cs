using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class DestoryBulletAfterTimeAndSpawnPortal : MonoBehaviour
	{
		public float TimeToSpawnPortal;

		public void Update()
		{
			TimeToSpawnPortal -= 1 * Time.deltaTime;
			if (TimeToSpawnPortal <= 0)
			{
				var portalGun = GameObject.Find("PortalGun").GetComponent<IPortalGun>();

				if (portalGun != null)
					portalGun.SpawnNextPortal(gameObject.transform.position);

				Destroy(gameObject, 0);
			}
			
		}
	}
}
