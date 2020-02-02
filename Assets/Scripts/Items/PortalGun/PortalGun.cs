using Assets.Scripts.Item.Interfaces;
using Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Item.PortalGun
{
    class PortalGun : MonoBehaviour, IPortalGun, ICanBePickedUp
    {
        private Rigidbody _RigidBody;
        private Option<PlayerController> _carryingPlayer = Option.None<PlayerController>();
        public ObjectType objectType;
        private Part part;

        public GameObject Bullet;

        public bool CanBePickedUp => !_carryingPlayer.HasValue();
        public bool IsPickedUp => _carryingPlayer.HasValue();

        bool ICanBePickedUp.CanBePlaced => this.part != null;

        public void DropItem()
        {
            _carryingPlayer = Option.None<PlayerController>();
            transform.SetParent(null);
        }

        public void PickUpItem(PlayerController player)
        {
            _carryingPlayer = Option.Some(player);
            transform.SetParent(player.transform);
            transform.rotation = player.transform.rotation;
            transform.localPosition = Vector3.zero + new Vector3(0, 0, 1.1f);
        }

        void Start()
        {
            _RigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {

        }

        public void OnPlaceableAreaEnter(Part part)
        {
            this.part = part;
        }

        public void OnPlaceableAreaExit()
        {
            this.part = null;
        }

        public void UseItem()
        {
            Debug.Log("UseItem");
            //remove item from player
            _carryingPlayer = Option.None<PlayerController>();
            //give item to the ship part
            this.part.receiveItem(this.objectType);
            this.part = null;
            //destroy self
            Destroy(gameObject);
        }

        public void ItemAction(PlayerController player)
        {
            Debug.Log("Portal - PEWPEW");
            GameObject.Instantiate(Bullet, transform.position, player.gameObject.transform.rotation);
        }

        private const string _portal1 = "Portal1";
        private const string _portal2 = "Portal2";

        private string _nextPortalToSpawn = _portal1;

        public void SpawnNextPortal(Vector3 newPosition)
        {
            if (_nextPortalToSpawn == _portal1)
            {
                _nextPortalToSpawn = _portal2;
                var portal = GameObject.Find(_portal1);
                portal.transform.position = new Vector3(newPosition.x, 1, newPosition.z);
            }
            else if (_nextPortalToSpawn == _portal2)
            {
                _nextPortalToSpawn = _portal1;
                var portal = GameObject.Find(_portal2);
                portal.transform.position = new Vector3(newPosition.x, 1, newPosition.z);
            }
        }
    }
}
