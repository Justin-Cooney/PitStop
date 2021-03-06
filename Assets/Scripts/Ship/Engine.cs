﻿
public class Engine : Part, I_Critical
{

    protected float fuel = 1f;

    new public void receiveItem(ObjectType item)
    {
        base.receiveItem(item);
        if (item.resource == ObjectType.Resource.FUEL)
        {
            addFuel(item.value);
        }
    }
    public void Start()
    {
        ShowIntegrityLevelIdicator();
    }

    public void useFuel(float fuelUsage)
    {
        this.fuel -= fuelUsage;
    }

    public float getFuel()
    {
        return this.fuel;
    }

    protected void addFuel(float fuelAdded)
    {
        this.fuel += fuelAdded;
    }

    public bool atCriticalIntegrity()
    {
        return this.integrity <= 0.25;
    }
}
