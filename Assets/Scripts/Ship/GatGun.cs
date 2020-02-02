
public class GatGun : Weapon
{
    public override float getAmmoUsagePerSecond()
    {
        return 0.04f;
    }

    protected override float calculateDamage(float ammoUsage)
    {
        //as the gun is damaged it's "accuracy goes down" (it's DPM decreases)
        return ammoUsage * 35f * this.integrity;
    }
}
