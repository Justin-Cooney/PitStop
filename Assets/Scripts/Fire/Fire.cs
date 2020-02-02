using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool IsWaveFire = false;
    private float _coolTime;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 30);
    }

    public void Update()
    {
        if(IsWaveFire)
            _coolTime -= 1 * Time.deltaTime;
    }

    public bool IsCooled() => _coolTime > 0;

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ExinguisherSmoke>() != null)
            Destroy(gameObject);
    }
}
