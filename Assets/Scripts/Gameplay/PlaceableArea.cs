using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableArea : MonoBehaviour {

    public List<ObjectType> acceptableObjectTypes;

    private void OnTriggerEnter (Collider other) {
        ObjectController objController = other.GetComponent<ObjectController> ();
        if(objController != null) {
            foreach(ObjectType objType in acceptableObjectTypes) {
                bool acceptable = objController.CompareObjectType (objType);
                if(acceptable) {

                }
            }
        }
    }

    private void OnTriggerExit (Collider other) {

    }

}
