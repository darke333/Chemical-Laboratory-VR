using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scenario3 : MonoBehaviour
{
    public List<GameObject> Hints;
    public OVRGrabbable colba;
    //public DebugPool debugPool;
    public TextMeshPro text0;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
    
    public OnPump onPump;
    public int SaltOut;
    public int necessaryTemp;
    public UIPanelControll Temperature;
    public ControlIsparitel contr;
    public NewWaterControll water;
    float RestTime;
    int number;
    public bool DownReached;
    public Transform TEstingDOwnObject;
    public Transform DownPosition;

    // Start is called before the first frame update
    void Start()
    {
        DownReached = false;
        //Hints[0].SetActive(true);
        Hints[1].SetActive(true);
        string s = necessaryTemp.ToString();
        text1.text += s;

    }

    void TestIfMovingPartOnPos()
    {
        if ((TEstingDOwnObject.position - DownPosition.position).magnitude < 0.0001f)
        {
            DownReached = true;

        }
        else
        {
            DownReached = false;
        }
    }



    void PhaseZero()
    {
        if (DownReached)
        {
            text0.color = Color.green;
            text1.gameObject.SetActive(true);
        }
        else
        {
            text0.color = Color.white;
        }
    }

    void PhaseOne()
    {
        if (Temperature.CurrentNumber == necessaryTemp)
        {
            text1.color = Color.green;
            text2.gameObject.SetActive(true);
            Hints[0].SetActive(false);
            Hints[1].SetActive(false);
            Hints[2].SetActive(true);
        }
        else
        {
            text1.color = Color.white;
        }
    }

    void PhaseTwo()
    {
        if (contr.Started)
        {
            text2.color = Color.green;
            text3.gameObject.SetActive(true);
            Hints[2].SetActive(false);
            Hints[4].SetActive(true);



        }
        else
        {
            text2.color = Color.white;
        }
    }

    void PhaseThree()
    {
        if (onPump.PumpOn)
        {
            text3.color = Color.green;
            text4.gameObject.SetActive(true);
            Hints[4].SetActive(false);
            Hints[3].SetActive(true);
            contr.Smoke[1].emissionRate = 10;
            contr.Smoke[2].emissionRate = 10;


        }
        else
        {
            text3.color = Color.white;
        }
    }

    void PhaseFour()
    {
        if (onPump.enabled)
        {
            if (water.Emitting)
            {
                text4.color = Color.green;
                contr.Finished = true;
                foreach (GameObject hint in Hints)
                {
                    hint.SetActive(false);
                }
            }
            else
            {
                text4.color = Color.white;
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        TestIfMovingPartOnPos();
        PhaseZero();
        PhaseOne();
        PhaseTwo();
        PhaseThree();
        PhaseFour();

    }
}
