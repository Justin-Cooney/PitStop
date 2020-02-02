using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class Slug : MonoBehaviour
{
    private float timeToChangeDirection;
    private CharacterController _controller;
    private Quaternion _direction;
    public GameObject DeathEffects;
    public GameObject SuperPistol;
    public GameObject DualPistol;

    private bool _waveMode = false;



    [Inject]
    private IObserver<SlugKilled> _slugKilled;

    [Inject]
    public IObservable<NukeExplodes> _nukeExplodes;

    [Inject]
    private Nuke.NukeFactory nukeFactory;

    [Inject]
    public void Initialize()
    {
        _nukeExplodes.Subscribe(e => {
            KillSlug(true);
          });
    }

    // Use this for initialization
    public void Start()
    {
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        _controller = GetComponent<CharacterController>();
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        if (_destroy)
            GameObject.Destroy(gameObject);

        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _direction, 1 * Time.deltaTime);
        _controller.Move(transform.forward * 5f * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        float angle = UnityEngine.Random.Range(0f, 360f);
        _direction = Quaternion.AngleAxis(angle, Vector3.up);
        //_direction = quat.eulerAngles;
        //Vector3 newUp = quat * Vector3.up;
        //newUp.z = 0;
        //newUp.Normalize();
        //transform.up = newUp;
        timeToChangeDirection = 1.5f;
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        if (collision.collider.GetComponent<Bullet>())
        {
            _slugKilled.OnNext(new SlugKilled());
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
        }
    }
    private bool _isNotified = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() && !_isNotified)
        {
            KillSlug();
            Destroy(other.gameObject);
        }
    }
    private bool _destroy = false;
    private void KillSlug(bool wasNuke = false)
    {
        if (_destroy)
            return;
        if (_waveMode && !wasNuke)
            RollForLoot();

        _isNotified = true;
        _slugKilled.OnNext(new SlugKilled());
        if(DeathEffects != null)
            GameObject.Instantiate(DeathEffects, transform.position, transform.rotation);
        _destroy = true;
    }

    public GameObject Nuke;
    private void RollForLoot()
    {
        var powerUp = UnityEngine.Random.Range(0, 5);
        if (powerUp == 0)
        {
            var nuke = nukeFactory.Create();
            nuke.transform.position = transform.position;
            nuke.transform.position = transform.position;
        }
        else if (powerUp == 1)
        {
            GameObject.Instantiate(SuperPistol, this.transform.position, this.transform.rotation);
        }
        else if (powerUp == 2)
        {
            GameObject.Instantiate(DualPistol, this.transform.position, this.transform.rotation);
        }
    }

    public void SetWaveMode()
    {
        _waveMode = true;
    }

    public class SlugFactory : Zenject.Factory<Slug>
    {
    }
}
