using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Item.Interfaces
{
    public interface ICanBePickedUp
    {
        bool IsPickedUp { get; }
        bool CanBePickedUp { get; }
        void PickUpItem(PlayerController Player);
        void DropItem();
    }
}
