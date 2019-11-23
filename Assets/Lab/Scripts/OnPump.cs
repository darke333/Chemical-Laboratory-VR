using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPump : MonoBehaviour
{

    public bool PumpOn;
    public Transform OnPos;
    public Transform OffPos;
    // Start is called before the first frame update
    void Start()
    {
        PumpOn = false;
        gameObject.transform.rotation = OffPos.rotation;

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "FingerContact")
        {
            if (PumpOn)
            {
                PumpOn = false;
                gameObject.transform.rotation = OffPos.rotation;
            }
            else
            {
                PumpOn = true;
                gameObject.transform.rotation = OnPos.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
