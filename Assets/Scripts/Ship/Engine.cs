
public class Engine : Part, I_Critical
{

    protected float fuel;

    new public void receiveItem(ObjectType item)
    {
        base.receiveItem(item);
        if (item.resource == ObjectType.Resource.FUEL)
        {
            addFuel(item.value);
        }
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

    public bool lessThanQuarterIntegrity()
    {
        return this.integrity <= 0.25;
    }
}
