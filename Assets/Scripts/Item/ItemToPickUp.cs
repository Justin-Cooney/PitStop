using Assets.Scripts.Item.Interfaces;
using Functional;
using System;
using UnityEngine;

namespace Assets.Scripts.Item
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
                    transform.position = p.transform.position;
                },
                () =>
                {
                }
            );;
        }

        public void OnPlaceableAreaEnter(Part part) {
            this.part = part;
        }

        public void OnPlaceableAreaExit() {
            this.part = null;
        }

        public void UseItem () {
            //this.part.PassItem(this.objectType);
            this.part = null;
        }

    }
}