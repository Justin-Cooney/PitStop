using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpaceship : MonoBehaviour
{

    public Animator animator;
    public bool triggerFlyIn = false;
    public bool triggerFlyOut = false;
    public bool triggerFlyInCrit = false;
    private Transform tform;
    // Start is called before the first frame update
    void Start()
    {
        tform = GetComponent<Transform> ();   
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerFlyIn) {
            tform.rotation = Quaternion.identity;
            tform.position = new Vector3 (100, 25, -5);
            animator.SetTrigger ("FlyIn");
            triggerFlyIn = false;
        }
        if(triggerFlyOut) {
            tform.rotation = Quaternion.identity;
            tform.position = new Vector3 (0, 2, -5);
            animator.SetTrigger ("FlyOut");
            triggerFlyOut = false;
        }
        if(triggerFlyInCrit) {
            tform.rotation = Quaternion.identity;
            tform.position = new Vector3 (50, 15, -5);
            animator.SetTrigger ("FlyInCritical");
            triggerFlyInCrit = false;
        }
    }
}
