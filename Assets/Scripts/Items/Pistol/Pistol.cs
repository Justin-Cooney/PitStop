﻿using Assets.Scripts.Item.Interfaces;
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

    public bool IsSuperPistol = false;
    public bool IsDualPistol = false;

    bool ICanBePickedUp.CanBePlaced => this.part != null;

    private AudioSource _audioSource;
    void Start()
    {
        _audioSource  = GetComponent<AudioSource>();
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

    private int _superPistolShots = 60;

    public void ItemAction(PlayerController player)
    {
        _audioSource.Play();
        var position = transform.position + (transform.forward * 0.8f);

        if(IsSuperPistol && _superPistolShots > 0)
        {
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
            _superPistolShots -= 1;
        }
        else if(IsDualPistol)
        {
            var position1 = new Vector3(position.x + 0.3f, position.y, position.z);
            var position2 = new Vector3(position.x - 0.3f, position.y, position.z);
            GameObject.Instantiate(Bullet, position1, player.gameObject.transform.rotation);
            GameObject.Instantiate(Bullet, position2, player.gameObject.transform.rotation);
        }
        else
        {
            GameObject.Instantiate(Bullet, position, player.gameObject.transform.rotation);
        }
    }

}
