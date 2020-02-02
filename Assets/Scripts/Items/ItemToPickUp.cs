using Assets.Scripts.Item.Interfaces;
using Functional;
using System;
using UnityEngine;

namespace Assets.Scripts.Items
{
    class ItemToPickUp : MonoBehaviour, ICanBePickedUp
    {
        private Rigidbody _RigidBody;
        private Option<PlayerController> _carryingPlayer = Option.None<PlayerController>();
        public ObjectType objectType;
        private Part part;

        public bool CanBePickedUp => !_carryingPlayer.HasValue();
        public bool IsPickedUp => _carryingPlayer.HasValue();

        bool ICanBePickedUp.CanBePlaced => this.part != null;

        void Start() {
            _RigidBody = GetComponent<Rigidbody> ();
        }

        public void DropItem()
        {
            _carryingPlayer = Option.None<PlayerController>();
            transform.SetParent (null);
        }

        public void PickUpItem(PlayerController player)
        {
            _carryingPlayer = Option.Some(player);
            transform.SetParent (player.transform);
            transform.localRotation = player.transform.rotation;
            transform.localPosition = Vector3.zero + new Vector3(0, 0, 1.1f);
        }

        void Update()
        {
            
        }

        public void OnPlaceableAreaEnter(Part part) {
            this.part = part;
        }

        public void OnPlaceableAreaExit() {
            this.part = null;
        }

        public void UseItem ()
        {
            //remove item from player
            _carryingPlayer = Option.None<PlayerController> ();
            //give item to the ship part
            this.part.receiveItem(this.objectType);
            this.part = null;
            //destroy self
            Destroy (gameObject);
        }

    }
}