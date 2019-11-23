using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushObj : MonoBehaviour
{

    public float EnablePushDistance;
    public bool DistanceX;
    public bool DistanceY;
    public bool DistanceZ;
    Vector3 StartPos;
    bool CrossedEnbaleDistance;
    public UnityEvent OnPush;
    public UnityEvent OnPushDown;
    public UnityEvent OnPushUp;

    /*
    public delegate void OnPushAction();
    public static event OnPushAction OnPush;
    public delegate void OnPushDownAction();
    public static event OnPushDownAction OnPushDown;
    public delegate void OnPushUpAction();
    public static event OnPushUpAction OnPushUp;*/

    // Start is called before the first frame update
    void Start()
    {
        if (DistanceX || DistanceY || DistanceZ)
        {
            StartPos = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DistanceEnable();
    }

    void DistanceEnable()
    {
        if (DistanceX)
        {
            if (StartPos.x -transform.position.x >= EnablePushDistance)
            {
                OnPush.Invoke();
                if (!CrossedEnbaleDistance)
                {
                    CrossedEnbaleDistance = true;
                    OnPushDown.Invoke();
                }
            }
            else
            {
                if (CrossedEnbaleDistance)
                {
                    OnPushUp.Invoke();
                }
                CrossedEnbaleDistance = false;
            }
        }
        if (DistanceY)
        {
            if (StartPos.y - transform.position.y  >= EnablePushDistance)
            {
                OnPush.Invoke();
                if (!CrossedEnbaleDistance)
                {
                    CrossedEnbaleDistance = true;
                    OnPushDown.Invoke();
                }
            }
            else
            {
                if (CrossedEnbaleDistance)
                {
                    OnPushUp.Invoke();
                }
                CrossedEnbaleDistance = false;
            }
        }
        if (DistanceZ)
        {
            if (StartPos.z - transform.position.z >= EnablePushDistance)
            {
                OnPush.Invoke();
                if (!CrossedEnbaleDistance)
                {
                    CrossedEnbaleDistance = true;
                    OnPushDown.Invoke();
                }
            }
            else
            {
                if (CrossedEnbaleDistance)
                {
                    OnPushUp.Invoke();
                }
                CrossedEnbaleDistance = false;
            }
        }
    }
}
