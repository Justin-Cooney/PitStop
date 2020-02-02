using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Slug : MonoBehaviour
{
    private float timeToChangeDirection;
    private CharacterController _controller;
    private Quaternion _direction;

    [Inject]
    private IObserver<SlugKilled> _slugKilled;

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

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        if (other.GetComponent<Bullet>())
        {
            _slugKilled.OnNext(new SlugKilled());
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    public class SlugFactory : Zenject.Factory<Slug>
    {
    }
}
