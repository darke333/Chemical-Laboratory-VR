using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class WaterControll : MonoBehaviour
{
    public ObiEmitter emitter;
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
            emitter.speed = 0;
            Emitting = false;
        }
        else
        {
            emitter.speed = 1.5f;
            Emitting = true;
        }

    }
}
