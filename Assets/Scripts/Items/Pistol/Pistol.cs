using Assets.Scripts.Item.Interfaces;
using Functional;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, ICanBePickedUp
{
    private Rigidbody _RigidBody;
    private Option<PlayerController> _carryingPlayer = Option.None<PlayerController>();
    public ObjectType objectType;
    private Part part;

    public GameObject Bullet;

    public bool CanBePickedUp => !_carryingPlayer.HasValue();
    public bool IsPickedUp => _carryingPlayer.HasValue();

    bool ICanBePickedUp.CanBePlaced => this.part != null;

    void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

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
        transform.localPosition = Vector3.forward * 1.1f;
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
        Debug.Log("PEWPEW");
        var position = transform.position + (transform.forward * 0.5f);
        GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
    }

}
