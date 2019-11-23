using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIPanelControll : MonoBehaviour
{

    public GameObject Rotate;
    float StartRotation;

    int StartNumber;

    bool IsBlink;
    public int MaxValue;
    public int MinValue;

    bool StartWorking;

    public int CurrentNumber;

    float timer;
    float BlinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNumber = Convert.ToInt32(gameObject.GetComponent<TextMeshPro>().text.ToString());
        timer = 0;
        BlinkTimer = 0;
    }

    public void StartChangeNumber()
    {
        IsBlink = true;
        timer = 0;
        BlinkTimer = 0;
        StartRotation = Rotate.transform.rotation.z;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        StartNumber = Convert.ToInt32(gameObject.GetComponent<TextMeshPro>().text.ToString());
    }

    public void StopChangeNumber()
    {
        IsBlink = false;
        timer = 0;
        BlinkTimer = 0;
        StartRotation = Rotate.transform.rotation.z;
        gameObject.GetComponent<MeshRenderer>().enabled = true;

    }



    // Update is called once per frame
    void Update()
    {
        if (IsBlink)
        {
            timer += Time.deltaTime;
            BlinkTimer += Time.deltaTime;
            if (BlinkTimer > 0.3f)
            {
                if (gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    BlinkTimer = 0;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    BlinkTimer = 0;
                }
            }
            float CurrentRotation = (StartRotation - Rotate.transform.rotation.z);
            CurrentNumber = StartNumber + (int)(CurrentRotation * -20);
            if(CurrentNumber > MaxValue)
            {
                StartNumber = MaxValue;
                CurrentNumber = MaxValue;
            }
            if (CurrentNumber < MinValue)
            {
                StartNumber = MinValue;
                CurrentNumber = MinValue;
            }
            gameObject.GetComponent<TextMeshPro>().text = CurrentNumber.ToString();
            if (timer > 10)
            {
                StopChangeNumber();
            }
        }
    }
}
