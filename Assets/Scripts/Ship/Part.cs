using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{

    protected float integrity = 1f;
    public bool onFire = false;

    public void dealDamage(float rawDamage)
    {
        this.integrity -= rawDamage;
    }

    public float getIntegrity()
    {
        return this.integrity;
    }

    protected void repairDamage(float rawRepair)
    {
        this.integrity += rawRepair;
    }

    public void receiveItem(ObjectType item)
    {
        if (item.resource == ObjectType.Resource.INTEGRITY)
        {
            repairDamage(item.value);
        }
    }

}
