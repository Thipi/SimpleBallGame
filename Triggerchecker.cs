using UnityEngine;
using System.Collections;

public class Triggerchecker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 1.5f); //after 1.5 seconds the FallDown function is called.
            FallDown();
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true; //turns gravity on in parent
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 1.5f); // after 1.5 seconds the parentobject will be destroyed. 
    }
}