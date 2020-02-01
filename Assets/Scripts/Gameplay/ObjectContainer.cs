using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectContainer : ScriptableObject {

    public ObjectType type;
    public List<ObjectProperty> properties;

}
