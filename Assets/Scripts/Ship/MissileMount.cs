
public class MissileMount : Weapon, I_Explosive
{
    public float damageDoneIfDestroyed()
    {
        return 0.05f;
    }

    protected override float getAmmoUsagePerSecond()
    {
        return 1f;
    }

    protected override float getDamagePerAmmo()
    {
        return 50f;
    }
}
