using Assets.Scripts.Item.Interfaces;
using Functional;
using Assets.Scripts.Events;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using UniRx;

public class PlayerController : MonoBehaviour
{

    private Option<ICanBePickedUp> CarriedItem;
    public Option<GameObject> ReachableGameObject { get; private set; }

    public GameObject _deathEffects;
    public GameObject _spawnEffects;

    public Transform _respawnTransform;

    [Inject]
    private IObserver<AddPoints> _events;

    [Inject]
    private IObserver<IncrementDeathCount> _incrementDeathCount;

    [Inject]
    private IObserver<LogEvent> _logEvent;

    private CharacterController _characterController;
    private float _speed = 15;
    private float _rotationSpeed = 25;
    private Vector2 _velocity;
    private Vector2 _targetRotation;

    private float _sprintSpeed = 30;
    private float _sprintCooldown = 0;
    private float _sprintDuration = 0.7f;
    private bool _sprinting = false;
    private float _stunned = 0;

    private bool _isDead = false;

    [Inject]
    public void Initialize()
    {
        _characterController = this.GetComponent<CharacterController>();
    }

    public void Update()
    {

        if (_stunned <= 0 && !_isDead)
        {
            _characterController.Move(GetVelocity());
            transform.rotation = GetRotation();
        }
        else
        {
            //_characterController.Move(transform.forward * -30 * Time.deltaTime);
            if (_stunned <= 0.42f)
            {
                transform.Rotate(Vector3.up, 5000 * Time.deltaTime);
                if(!_isDead)
                {
                    _isDead = true;
                    PlayerDie();
                }
            }
        }
        _sprintCooldown -= 1 * Time.deltaTime;
        if (_sprintCooldown <= 0.5f)
            _sprinting = false;
        if (_stunned > 0)
            _stunned -= 1 * Time.deltaTime;

        if (_isDead && _stunned <= 0)
        {
            _characterController.enabled = false;
            transform.position = _respawnTransform.position;
            _characterController.enabled = true;
            GameObject.Instantiate(_spawnEffects, transform);
            _isDead = false;
        }
    }

    private Vector3 GetVelocity()
        => new Vector3(_velocity.x, 0, _velocity.y) * (_sprinting ? _sprintSpeed : _speed) * Time.deltaTime;

    private Quaternion GetRotation()
        => Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(new Vector3(0, Mathf.Atan2(_targetRotation.x, _targetRotation.y) * 180 / Mathf.PI, 0)),
            _rotationSpeed * Time.deltaTime);


    public void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();

        if (Math.Abs(direction.x) > 0.31 || Math.Abs(direction.y) > 0.31)
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
                else if(o.GetComponent<IDoorPanel>() is IDoorPanel doorPanel)
                {
                    doorPanel.ToggleDoor();
                }
            }));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.GetComponent<Fire>() != null)
        {
            _stunned = 0.5f;
            DropOrPickupItem();
        }
        else if (other.GetComponent<Slug>() != null)
        {
            _stunned = 0.5f;
            DropOrPickupItem();
        }
        else if (other.GetComponent<Bullet>() != null)
        {
            _stunned = 0.5f;
            DropOrPickupItem();
            GameObject.Destroy(other.gameObject);
        }
        else
        {
            var gameObject = other.gameObject;
            ReachableGameObject = Option.Some(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ReachableGameObject = Option.None<GameObject>();
    }

    private void DropCarriedItem(ICanBePickedUp itemToDrop)
    {
        if(itemToDrop.CanBePlaced) {
            itemToDrop.UseItem ();
        } else {
            itemToDrop.DropItem();
        }
        CarriedItem = Option.None<ICanBePickedUp>();
    }

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() > 0 && _sprintCooldown <= 0)
        {
            _sprinting = true;
            _sprintCooldown = _sprintDuration;
        }
    }

    public void OnUseItem(InputValue value)
    {
        Debug.Log("uSEiTEM");
        CarriedItem.Apply(i => i.ItemAction(this));
    }

    public void PlayerDie()
    {
        _isDead = true;
        GameObject.Instantiate(_deathEffects, transform);
        _incrementDeathCount.OnNext(new IncrementDeathCount(1));
        _logEvent.OnNext(new LogEvent($"Engineer X-{UnityEngine.Random.Range(1000000, 99999999)} has malfunctioned."));
    }
}
