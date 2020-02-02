using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Part : MonoBehaviour
{

    protected float integrity = 1f;
    public bool onFire = false;
    private Fire fire;

    public void dealDamage(float rawDamage)
    {
        this.integrity -= rawDamage;
        Debug.LogWarning("Integrity at " + this.integrity + " on part " + this.name);
    }

    [Inject]
    public void Initialize()
    {
        //quick and dirty collection of all child parts by type/interface
        fire = this.GetComponentInChildren<Fire>();
    }

    public void Update()
    {

    }

    public float getIntegrity()
    {
        return this.integrity;
    }

    protected void repairDamage(float rawRepair)
    {
        this.integrity += rawRepair;
        if (onFire && this.integrity > 0.4)
        {
            toggleFire(false);
        }
    }

    public void receiveItem(ObjectType item)
    {
        if (item.resource == ObjectType.Resource.INTEGRITY)
        {
            repairDamage(item.value);
        }
    }

    public void fullRestore()
    {
        this.integrity = 1f;
    }

    public void toggleFire(bool onFire)
    {
        if (fire !=null)
        {
            this.onFire = onFire;
            fire.gameObject.SetActive(onFire);
        }
    }

}
