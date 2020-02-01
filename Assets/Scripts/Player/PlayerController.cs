using Assets.Scripts.Item.Interfaces;
using Functional;
using Assets.Scripts.Events;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{

    private Option<ICanBePickedUp> CarriedItem;
    public Option<GameObject> ReachableGameObject { get; private set; }

    [Inject]
    private IObserver<AddPoints> _events;
    private CharacterController _characterController;
    private float _speed = 15;
    private float _rotationSpeed = 25;
    private Vector2 _velocity;
    private Vector2 _targetRotation;

    [Inject]
    public void Initialize()
    {
        _characterController = this.GetComponent<CharacterController>();
    }

    public void Update()
    {
        _characterController.Move(GetVelocity());
        transform.rotation = GetRotation();
    }

    private Vector3 GetVelocity()
        => new Vector3(_velocity.x, 0, _velocity.y) * _speed * Time.deltaTime;

    private Quaternion GetRotation()
        => Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(new Vector3(0, Mathf.Atan2(_targetRotation.x, _targetRotation.y) * 180 / Mathf.PI, 0)),
            _rotationSpeed * Time.deltaTime);


    public void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();

        if (Math.Abs(direction.x) > 0.5 || Math.Abs(direction.y) > 0.5)
        {
            _targetRotation = direction;
        }

        if (Math.Abs(direction.x) > 0.1 || Math.Abs(direction.y) > 0.1)
        {
            _velocity = direction;
            _speed = 15;
        }
        else
        {
            _velocity = Vector2.zero;
        }
        _events.OnNext(new AddPoints(1));
    }

    private readonly Quaternion _thirtyFiveDegreesLeft = Quaternion.Euler(0, -35, 0);
    private readonly Quaternion _thirtyFiveDegreesRight = Quaternion.Euler(0, 35, 0);

    void CheckIfRayCastHit()
    {
        if (!ReachableGameObject.HasValue())
        {
            if (Physics.Raycast(transform.position, transform.forward, out var raycastHitFoward, 2))
            {
                print(raycastHitFoward.collider.gameObject.name + "has been destroyed!");
                ReachableGameObject = Option.Some(raycastHitFoward.collider.gameObject);
            }
            else if (Physics.Raycast(transform.position, _thirtyFiveDegreesLeft * transform.forward, out var raycastHitFowardLeft, 1.5F))
            {

                print(raycastHitFowardLeft.collider.gameObject.name + "has been destroyed!");
                ReachableGameObject = Option.Some(raycastHitFowardLeft.collider.gameObject);
            }
            else if (Physics.Raycast(transform.position, _thirtyFiveDegreesRight * transform.forward, out var raycastHitFowardRight, 1.5F))
            {
                print(raycastHitFowardRight.collider.gameObject.name + "has been destroyed!");
                ReachableGameObject = Option.Some(raycastHitFowardRight.collider.gameObject);
            }
            else
                ReachableGameObject = Option.None<GameObject>();
        }
    }

    public void HandleActionButtonClick()
    {

        CheckIfRayCastHit();
        DropOrPickupItem();
    }

    private void DropOrPickupItem()
    {
        CarriedItem.Do(
            i => DropCarriedItem(i),
            () => ReachableGameObject.Do(o =>
            {
                if (o.GetComponent<ICanBePickedUp>() is ICanBePickedUp objectToPickUp)
                {
                    CarriedItem = Option.Some(objectToPickUp);
                    objectToPickUp.PickUpItem(this);
                }
            }));
    }

    private void OnTriggerEnter(Collider other)
    {
        var gameObject = other.gameObject;
        ReachableGameObject = Option.Some(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        ReachableGameObject = Option.None<GameObject>();
    }

    private void DropCarriedItem(ICanBePickedUp itemToDrop)
    {
        itemToDrop.DropItem();
        CarriedItem = Option.None<ICanBePickedUp>();
    }
}
