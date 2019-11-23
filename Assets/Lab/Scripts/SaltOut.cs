using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltOut : MonoBehaviour
{
    public Scenario1 scenario1;
    public Scenario0 scenario0;
    public Scenario3 scenario3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Salt")
        {
            scenario1.SaltOut++;
            scenario0.SaltOut++;
            scenario3.SaltOut++;

            Destroy(other, 5);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
