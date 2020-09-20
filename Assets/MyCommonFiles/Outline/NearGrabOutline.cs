using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearGrabOutline : MonoBehaviour
{
    [SerializeField] OVRInput.Button button;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OutlineObject>())
        {
            other.GetComponent<OutlineObject>().EnableOutline = true;
        }
    }

    //Userfull for ChemLab project only
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DistroyConnection>())
        {
            if (other.GetComponent<Animator>())
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    other.GetComponent<Animator>().Play("Cup");
                }
            }            
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
