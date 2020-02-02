using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 30);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ExinguisherSmoke>() != null)
            Destroy(gameObject);
    }
}
