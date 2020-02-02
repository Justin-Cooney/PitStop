using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Nuke : MonoBehaviour
{
    [Inject]
    private IObserver<NukeExplodes> _explodes;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("NUKE");
        if (collision.collider.gameObject.GetComponent<PlayerController>())
        {
            _explodes.OnNext(new NukeExplodes());
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("NUKE");
        if (collider.gameObject.GetComponent<PlayerController>())
        {
            _explodes.OnNext(new NukeExplodes());
            Destroy(gameObject);
        }
    }

    public class NukeFactory : Zenject.Factory<Nuke>
    {
    }
}
