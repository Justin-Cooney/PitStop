using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Items;

public class PlaceableArea : MonoBehaviour {

    public List<ObjectType> acceptableObjectTypes;
    public Part part;

    private void OnTriggerEnter (Collider other) {
        ItemToPickUp item = other.GetComponent<ItemToPickUp> ();
        if(item != null) {
            foreach(ObjectType objType in acceptableObjectTypes) {
                bool acceptable = item.objectType == objType;
                if(acceptable) {
                    item.OnPlaceableAreaEnter (part);
                }
            }
        }
    }

    private void OnTriggerExit (Collider other) {
        ItemToPickUp item = other.GetComponent<ItemToPickUp> ();
        if (item != null) {
            foreach (ObjectType objType in acceptableObjectTypes) {
                bool acceptable = item.objectType == objType;
                if (acceptable) {
                    item.OnPlaceableAreaExit ();
                }
            }
        }
    }

}
