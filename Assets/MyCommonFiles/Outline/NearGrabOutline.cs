using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearGrabOutline : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OutlineObject>())
        {
            other.GetComponent<OutlineObject>().EnableOutline = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<OutlineObject>())
        {
            other.GetComponent<OutlineObject>().EnableOutline = false;
        }
    }
}
