using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePressFunc : MonoBehaviour
{
    // Create Controller and Put that script
    public GameObject PushColliderPrefab;
    public GameObject PushTriggerPrefab;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;


    // Update is called once per frame
    void Update()
    {

        if (!LeftTrigger) //If left trigger NOT created
        {
            if (GameObject.Find("hands:b_l_index_ignore")) //If Left Hand Models Spawned and trigger not v
            {
                LeftTrigger = Instantiate(PushTriggerPrefab, GameObject.Find("hands:b_l_index_ignore").transform);
                LeftTrigger.GetComponent<EnablePush>().PushCollider = Instantiate(PushColliderPrefab, GameObject.Find("hands:b_l_index_ignore").transform);
            }
        }
        else
        {
            CheckIfPressed(OVRInput.NearTouch.PrimaryIndexTrigger, OVRInput.Controller.LTouch, LeftTrigger);
        }


        if (!RightTrigger) //If right trigger NOT created
        {
            if (GameObject.Find("hands:b_r_index_ignore")) //If Right Hand Models Spawned
            {
                RightTrigger = Instantiate(PushTriggerPrefab, GameObject.Find("hands:b_r_index_ignore").transform);
                RightTrigger.GetComponent<EnablePush>().PushCollider = Instantiate(PushColliderPrefab, GameObject.Find("hands:b_r_index_ignore").transform);
            }
        }
        else
        {
            CheckIfPressed(OVRInput.NearTouch.SecondaryIndexTrigger, OVRInput.Controller.RTouch, RightTrigger);
        }
    }


    void CheckIfPressed(OVRInput.NearTouch button, OVRInput.Controller controller, GameObject trigger)
    {
        if (!OVRInput.Get(button)) // If index trigger not touched
        {
            ActivateTrigger(controller);
        }
        else
        {

            if (trigger.activeSelf) // Is trigger active
            {
                trigger.GetComponent<EnablePush>().PushCollider.SetActive(false);
                trigger.SetActive(false);
            }
        }
    }

    void ActivateTrigger(OVRInput.Controller controller)
    {
        if(controller == OVRInput.Controller.LTouch)
        {
            LeftTrigger.SetActive(true);
        }
        else
        {
            RightTrigger.SetActive(true);
        }
    }


}
