using Functional;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Item.PortalGun
{
    public class Teleport : MonoBehaviour, ICanTeleportPlayers
    {
        void OnTriggerEnter(Collider player)
        {
            if (gameObject.name == "Teleport1")
            {
                var teleport2 = GameObject.Find("Teleport2");
                if (teleport2 != null)
                {
                    var teleport2Foward = teleport2.transform.forward;
                    var charecterController = player.GetComponent<CharacterController>();
                    charecterController.enabled = false;
                    player.gameObject.transform.position = (new Vector3(teleport2.transform.position.x, 0, teleport2.transform.position.z) + teleport2Foward * 1.2f);
                    player.gameObject.transform.rotation = teleport2.transform.rotation;
                    charecterController.enabled = true;
                }
            }
            else if (gameObject.name == "Teleport2")
            {
                var teleport1 = GameObject.Find("Teleport1");
                if (teleport1 != null)
                {
                    var teleport1Foward = teleport1.transform.forward;
                    var charecterController = player.GetComponent<CharacterController>();
                    charecterController.enabled = false;
                    player.gameObject.transform.position = (new Vector3(teleport1.transform.position.x, 0, teleport1.transform.position.z) + teleport1Foward * 1.2f);
                    player.gameObject.transform.rotation = teleport1.transform.rotation;
                    charecterController.enabled = true;
                }
            }
        }
    }
}
