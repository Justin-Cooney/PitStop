
public abstract class Weapon : Part
{

    protected float ammo = 1f;

    new public void receiveItem(ObjectType item)
    {
        base.receiveItem(item);
        if (item.resource == ObjectType.Resource.AMMO)
        {
            addAmmo(item.value);
        }
    }
    public float useAmmoAndCalculateDamage(float ammoUsage)
    {
        this.ammo -= ammoUsage;
        return this.calculateDamage(ammoUsage);
    }

    public float getAmmo()
    {
        return this.ammo;
    }

    protected void addAmmo(float ammoAdded)
    {
        this.ammo += ammoAdded;
    }
    
    public abstract float getAmmoUsagePerSecond();
    protected abstract float calculateDamage(float ammoUsage);

}
