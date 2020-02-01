using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item;

public class PlaceableArea : MonoBehaviour {

    public List<ObjectType> acceptableObjectTypes;
    public Part part;

    private void OnTriggerEnter (Collider other) {
        ItemToPickUp objController = other.GetComponent<ItemToPickUp> ();
        if(objController != null) {
            foreach(ObjectType objType in acceptableObjectTypes) {
                bool acceptable = objController.objectType == objType;
                if(acceptable) {

                }
            }
        }
    }

    private void OnTriggerExit (Collider other) {

    }

}
