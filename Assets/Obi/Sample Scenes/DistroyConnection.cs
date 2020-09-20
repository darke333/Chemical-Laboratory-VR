using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyConnection : MonoBehaviour
{
    public Transform NewParent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dont use it, but keep just in case
        /*if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (NewParent)
            {
                transform.parent = NewParent;
            }
            if (GetComponent<Joint>())
            {
                Destroy(GetComponent<Joint>());
            }
        }*/
    }

    public void DestroyAfterAnimation()
    {
        if (NewParent)
        {
            //Destroy(GetComponent<Animator>());
            //Vector3 pos = transform.position; //Это костыль
            //gameObject.transform.SetParent(null, true);
            //transform.position = pos; // И это костыль, но он улетает после смены родятеля, хз как это изменить(((
            //gameObject.AddComponent<Rigidbody>();
            Destroy(gameObject);
        }
    }

}
