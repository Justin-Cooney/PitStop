
public class GatGun : Weapon
{
    protected override float getAmmoUsagePerSecond()
    {
        return 0.01f;
    }

    protected override float getDamagePerAmmo()
    {
        return 5f;
    }
}
