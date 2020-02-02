
public class Cockpit : Part, I_Critical, I_Vulnerable
{
    public bool atCriticalIntegrity()
    {
        return this.integrity <= 0.25;
    }

    public void Start()
    {
        ShowIntegrityLevelIdicator();
    }

    public bool atDeathlyIntegrity()
    {
        return this.integrity <= 0f;
    }

    new public void dealDamage(float rawDamage)
    {
        this.integrity -= (rawDamage * 0.5f);
    }

    new protected void repairDamage(float rawRepair)
    {
        this.integrity += (rawRepair * 0.5f);
    }
}
