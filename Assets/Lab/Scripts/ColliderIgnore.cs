using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnore : MonoBehaviour
{
    [SerializeField] List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Collider col in colliders)
        {
            Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>().GetComponent<Collider>(), col);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
