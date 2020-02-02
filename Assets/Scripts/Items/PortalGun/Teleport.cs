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
            if (gameObject.name == "Portal1")
            {
                var portal2 = GameObject.Find("Portal2");
                if (portal2 != null)
                {
                    var teleport2Foward = portal2.transform.forward;
                    var charecterController = player.GetComponent<CharacterController>();
                    charecterController.enabled = false;
                    player.gameObject.transform.position = (new Vector3(portal2.transform.position.x, player.gameObject.transform.position.y, portal2.transform.position.z) + teleport2Foward * 1.2f);
                    charecterController.enabled = true;
                }
            }
            else if (gameObject.name == "Portal2")
            {
                var portal1 = GameObject.Find("Portal1");
                if (portal1 != null)
                {
                    var teleport1Foward = portal1.transform.forward;
                    var charecterController = player.GetComponent<CharacterController>();
                    charecterController.enabled = false;
                    player.gameObject.transform.position = (new Vector3(portal1.transform.position.x, player.gameObject.transform.position.y, portal1.transform.position.z) + teleport1Foward * 1.2f);
                    charecterController.enabled = true;
                }
            }
        }
    }
}
