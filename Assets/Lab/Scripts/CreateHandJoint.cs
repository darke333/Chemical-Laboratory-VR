using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHandJoint : MonoBehaviour
{

    public OVRInput.Controller controller;
    public float BreakForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectFixJointGrab>())
        {
            CreateAndDestroyJoint(other);
        }
    }

    void CreateAndDestroyJoint(Collider other)
    {
        if (controller == OVRInput.Controller.LTouch)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                if (!other.gameObject.GetComponent<FixedJoint>())
                {
                    FixedJoint joint = other.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = gameObject.GetComponent<Rigidbody>();
                    joint.breakForce = BreakForce;
                }
                print("Down");
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                print("Up");
                if (other.gameObject.GetComponent<FixedJoint>())
                {
                    Destroy(other.gameObject.GetComponent<FixedJoint>());
                }
            }
        }
        if (controller == OVRInput.Controller.RTouch)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                if (!other.gameObject.GetComponent<FixedJoint>())
                {
                    FixedJoint joint = other.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = gameObject.GetComponent<Rigidbody>();
                    joint.breakForce = BreakForce;
                }
                print("Down");
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            {
                print("Up");
                if (other.gameObject.GetComponent<FixedJoint>())
                {
                    Destroy(other.gameObject.GetComponent<FixedJoint>());
                }
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
