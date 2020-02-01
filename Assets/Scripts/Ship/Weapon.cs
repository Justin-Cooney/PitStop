
public abstract class Weapon : Part
{

    protected float ammo;

    new public void receiveItem(ObjectType item)
    {
        base.receiveItem(item);
        if (item.resource == ObjectType.Resource.AMMO)
        {
            addAmmo(item.value);
        }
    }
    public void useAmmo(float ammoUsage)
    {
        this.ammo -= ammoUsage;
    }

    public float getAmmo()
    {
        return this.ammo;
    }

    protected void addAmmo(float ammoAdded)
    {
        this.ammo += ammoAdded;
    }
    
    protected abstract float getAmmoUsagePerSecond();
    protected abstract float getDamagePerAmmo();

}
