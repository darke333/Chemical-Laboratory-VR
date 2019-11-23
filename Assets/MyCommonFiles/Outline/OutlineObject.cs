using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    public bool EnableOutline;
    [SerializeField] GameObject OutlinedObj;

    // Start is called before the first frame update
    void Start()
    {
        EnableOutline = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableOutline)
        {
            OutlinedObj.GetComponent<Outline>().enabled = true;
        }
        else
        {
            OutlinedObj.GetComponent<Outline>().enabled = false;
        }
    }
}
