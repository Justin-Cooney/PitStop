using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{

    protected float integrity = 1f;
    public bool onFire = false;
    Renderer rend;
    Color startColor;
    Color damageColor = Color.black;

    public void dealDamage(float rawDamage)
    {
        this.integrity -= rawDamage;
        Debug.LogWarning("Integrity at " + this.integrity + " on part "+this.name);
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void Update()
    {
        rend.material.color = Color.Lerp(damageColor, startColor, this.integrity);
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

    public void fullRestore()
    {
        this.integrity = 1f;
    }

}
