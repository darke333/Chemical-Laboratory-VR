using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveUPandDown : MonoBehaviour
{
    [SerializeField] Transform UpPoint;
    [SerializeField] Transform DownPoint;
    [SerializeField] Transform MovingObject;
    [SerializeField] int speed;
    [SerializeField] UnityEvent DownReached;
    [SerializeField] UnityEvent UpReached;
    [SerializeField] UnityEvent MovingDownEvent;
    [SerializeField] UnityEvent MovingUpEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MovingUP()
    {
        if ((MovingObject.position - UpPoint.position).magnitude > 0.01f)
        {
            MovingObject.position = Vector3.MoveTowards(MovingObject.position, UpPoint.position, Time.deltaTime * speed);
            MovingUpEvent.Invoke(); 
        }
        else
        {
            UpReached.Invoke();
        }
    }

    public void MovingDown()
    {
        if ((MovingObject.position - DownPoint.position).magnitude > 0.01f)
        {
            MovingObject.position = Vector3.MoveTowards(MovingObject.position, DownPoint.position, Time.deltaTime * speed);
            MovingDownEvent.Invoke();
        }
        else
        {
            DownReached.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
