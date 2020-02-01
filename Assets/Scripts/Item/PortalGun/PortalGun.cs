using Assets.Scripts.Item.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Item.PortalGun
{
    class PortalGun : MonoBehaviour, ICanBePickedUp
    {
        public bool IsPickedUp => throw new NotImplementedException();

        public bool CanBePickedUp => throw new NotImplementedException();

        public void DropItem()
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(PlayerController Player)
        {
            throw new NotImplementedException();
        }
    }
}
