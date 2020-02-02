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
        }

        public void PickUpItem(PlayerController player)
        {
            _carryingPlayer = Option.Some(player);
        }

        void Update()
        {
            _carryingPlayer.Do(
                p =>
                {
                    transform.position = p.transform.position + (p.transform.forward * 1.1f);
                    transform.rotation = p.transform.rotation;
                },
                () =>
                {
                }
            );
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
            DropItem();
            //give item to the ship part
            this.part.receiveItem(this.objectType);
            this.part = null;
            //destroy self
            GameObject.Destroy(this);
        }

    }
}