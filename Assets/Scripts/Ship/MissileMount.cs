
public class MissileMount : Weapon, I_Explosive
{

    private Fire fire;

    public float damageDoneIfDestroyed()
    {
        return 0.05f;
    }

    public override float getAmmoUsagePerSecond()
    {
        return 1f;
    }

    protected override float calculateDamage(float ammoUsage)
    {
        return ammoUsage * 50f;
    }

    new public void dealDamage(float rawDamage)
    {
        //the mount cannot be damaged.. only the missile itself. then... boom
        if (this.ammo > 0.1f)
        {
            this.integrity -= rawDamage;
        }
    }

    public bool atDeathlyIntegrity()
    {
        return this.integrity <= 0.25;
    }
}
