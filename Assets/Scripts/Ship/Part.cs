using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using Zenject;

public class Part : MonoBehaviour
{

    protected float integrity = 1f;
    public bool onFire = false;
    private Fire fire;

    public GameObject IntegrityProcentageIndicator;

    private Vector3 _healthLevelIndicatorLocationOffset;

    public void dealDamage(float rawDamage)
    {
        this.integrity -= rawDamage;
        Debug.LogWarning("Integrity at " + this.integrity + " on part " + this.name);
    }

    [Inject]
    public void Initialize()
    {
        //quick and dirty collection of all child parts by type/interface
        fire = this.GetComponentInChildren<Fire>();
    }

    public void ShowIntegrityLevelIdicator()
    {
        if (IntegrityProcentageIndicator != null)
        {
            if (_healthLevelIndicatorLocationOffset != Vector3.zero)
                Instantiate(IntegrityProcentageIndicator, transform.position + _healthLevelIndicatorLocationOffset, Quaternion.identity, transform);
            else
                Instantiate(IntegrityProcentageIndicator, new Vector3(transform.position.x, 5, transform.position.z), Quaternion.identity, transform);

            var textMesh = IntegrityProcentageIndicator.GetComponent<TextMesh>();
            textMesh.text = $"{integrity.ToString("P0", CultureInfo.CreateSpecificCulture("hr-HR"))}";
            textMesh.color = integrity < 0.50f ? HexExtensions.ToColor("F6EB10"): HexExtensions.ToColor("00FF8A");
        }
    }

    public void Update()
    {

    }

    public float getIntegrity()
    {
        return this.integrity;
    }

    protected void repairDamage(float rawRepair)
    {
        this.integrity += rawRepair;
        if (onFire && this.integrity > 0.4)
        {
            toggleFire(false);
        }
        var textMesh = IntegrityProcentageIndicator.GetComponent<TextMesh>();
        textMesh.text = $"{integrity.ToString("P0", CultureInfo.CreateSpecificCulture("hr-HR"))}";
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

    public void toggleFire(bool onFire)
    {
        if (fire !=null)
        {
            this.onFire = onFire;
            fire.gameObject.SetActive(onFire);
        }
    }
}
