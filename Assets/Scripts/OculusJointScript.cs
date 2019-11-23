using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class OculusJointScript : MonoBehaviour
{

    GameObject ColliderObj;


    // Start is called before the first frame update
    void Start()
    {
        ColliderObj = gameObject.transform.Find("GrabVolumeBig").gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {

        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {

        }
        
    }

    

}
