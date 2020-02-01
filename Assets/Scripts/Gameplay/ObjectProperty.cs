using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class ObjectProperty : ScriptableObject {

    public abstract void ActivateProperty (GameObject propertyHolder);

}
