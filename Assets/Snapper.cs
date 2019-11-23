using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    public Transform whereToSnap;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "bottle")
            return;
        var grabbable = other.GetComponent<OVRGrabbable>();
        if (grabbable != null)
        {
            if (!grabbable.isGrabbed)
            {
                other.transform.position = whereToSnap.position;
                other.transform.rotation = whereToSnap.rotation;
                other.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
