using UnityEngine;

[CreateAssetMenu]
public class ObjectType : ScriptableObject {

    public enum Resource
    {
        AMMO, INTEGRITY, FUEL
    }

    public Resource resource;
    
    public float value;

}
