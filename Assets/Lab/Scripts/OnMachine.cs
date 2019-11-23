using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMachine : MonoBehaviour
{
    public ControlIsparitel controll;
    public Transform OnPos;
    public Transform OffPos;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.rotation = OffPos.rotation;

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "FingerContact")
        {

            if (controll.Started)
            {
                controll.Started = false;
                gameObject.transform.rotation = OffPos.rotation;

            }
            else
            {
                controll.Started = true;
                gameObject.transform.rotation = OnPos.rotation;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
