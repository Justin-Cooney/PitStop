using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Items;

public class PlaceableArea : MonoBehaviour {

    public List<ObjectType> acceptableObjectTypes;
    public Part part;

    void OnTriggerEnter (Collider other) {
        ItemToPickUp item = other.GetComponent<ItemToPickUp> ();
        Debug.Log ("ENTER");
        if(item != null) {
            foreach(ObjectType objType in acceptableObjectTypes) {
                bool acceptable = item.objectType == objType;
                if(acceptable) {
                    item.OnPlaceableAreaEnter (part);
                }
            }
        }
    }

    void OnTriggerExit (Collider other) {
        ItemToPickUp item = other.GetComponent<ItemToPickUp> ();
        Debug.Log ("EXIT");
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
