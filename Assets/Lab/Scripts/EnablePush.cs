using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePush : MonoBehaviour
{
    //For Fingers Collider On Finger;
    public GameObject PushCollider;

    // Start is called before the first frame update
    void Start()
    {
        PushCollider.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PushObj>() || other.gameObject.tag == "button")
        {
            PushCollider.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PushObj>() || other.gameObject.tag == "button")
        {
            PushCollider.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
