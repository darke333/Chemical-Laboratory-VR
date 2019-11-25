using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstractionScript : MonoBehaviour
{
    public Transform parent;
    //public Transform ConnectedObj;
    public float MovingSpeed;
    public bool ToMove;
    GameObject par;
    public Scenario0 scenario;
    public Scenario1 Scenario1;
    public Transform NewParent;

    // Start is called before the first frame update
    void Start()
    {
        ToMove = false;
    }

    void OnTriggerStay(Collider other)
    {


        if (other.tag == "bottle")
        {
            if (other.GetComponent<OVRGrabbable>().isGrabbed)
            {
                ToMove = true;
                par = other.gameObject;
            }            
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "bottle")
        {
            if (!gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled)
            {
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                if (gameObject.name == "Sphere (1)")
                {
                    if (scenario.gameObject.activeSelf)
                    {
                        scenario.SaltyPlaced = false;
                    }
                    else
                    {
                        Scenario1.SaltyPlaced = false;
                    }

                }
                else
                {
                    if (scenario.gameObject.activeSelf)
                    {
                        scenario.EmptyPlaced = false;
                    }
                    else
                    {
                        Scenario1.SaltyPlaced = false;
                    }
                }

            }
            //ToMove = false;
        }
    }

    void ToMoveObj()
    {
        if (!par.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled)
            {
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }
            if (!par.GetComponent<Rigidbody>().isKinematic)
            {
                par.GetComponent<Rigidbody>().isKinematic = true;
            }
           
            if ((par.transform.position - gameObject.transform.position).magnitude > 0.2f || Quaternion.Angle(par.transform.rotation, gameObject.transform.rotation) > 4)
            {
                par.transform.position = Vector3.MoveTowards(par.transform.position, gameObject.transform.position, Time.deltaTime * MovingSpeed);
                //par.transform.rotation = gameObject.transform.rotation;
                par.transform.rotation = Quaternion.RotateTowards(par.transform.rotation, gameObject.transform.rotation, Time.deltaTime * MovingSpeed * 30);
                print((par.transform.position - gameObject.transform.position).magnitude);
                print(Quaternion.Angle(par.transform.rotation, gameObject.transform.rotation));
            }
            else
            {
                if(gameObject.name == "Sphere (1)")
                {
                    if (scenario.gameObject.activeSelf)
                    {
                        scenario.SaltyPlaced = true;
                    }
                    else
                    {
                        Scenario1.SaltyPlaced = true;
                    }

                }
                else
                {
                    if (scenario.gameObject.activeSelf)
                    {
                        scenario.EmptyPlaced = true;
                    }
                    else
                    {
                        Scenario1.SaltyPlaced = true;
                    }
                }
                if (parent)
                {
                    par.transform.parent = parent;
                }
                ToMove = false;
            }

        }
        else
        {
            ToMove = false;


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ToMove)
        {
            ToMoveObj();
        }        
    }
}
