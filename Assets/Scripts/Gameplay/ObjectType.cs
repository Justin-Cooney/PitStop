using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectType : ScriptableObject {

    public enum Resource
    {
        AMMO, INTEGRITY, FUEL
    }

    public Resource resource;
    
}
