using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaterControll : MonoBehaviour
{
    public WaterDown controller;
    public float a;
    public float maxAng;
    public float minAng;
    public bool Emitting;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = gameObject.transform.rotation.z;
        a = angle;
        if (angle > minAng && angle < maxAng)
        {
            if (Emitting)
            {
                controller.ChangeBehavior();
                Emitting = false;
            }            
        }
        else
        {
            if (!Emitting)
            {
                controller.ChangeBehavior();
                Emitting = true;
            }
        }

    }
}
