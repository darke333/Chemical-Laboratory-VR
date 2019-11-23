using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOVRPlayer : MonoBehaviour
{
    public Transform NormalPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ScalePlayer()
    {
        float difference = NormalPosition.position.y - gameObject.transform.position.y;
        float change = difference / 0.7f;
        Vector3 addVector = new Vector3(change, change, change);
        gameObject.transform.position += new Vector3(0, difference + 0.5f, 0);
        gameObject.transform.localScale += addVector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
