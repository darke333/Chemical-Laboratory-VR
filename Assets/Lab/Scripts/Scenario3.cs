using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scenario3 : MonoBehaviour
{
    public List<GameObject> Hints;
    public OVRGrabbable colba;
    public DebugPool debugPool;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;

    public OnPump onPump;
    public int SaltOut;
    public UIPanelControll Temperature;
    public ControlIsparitel contr;
    public NewWaterControll water;
    float RestTime;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        //Hints[0].SetActive(true);
        Hints[1].SetActive(true);

    }



    void PhaseOne()
    {
        if (Temperature.CurrentNumber == 100)
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
        PhaseOne();
        PhaseTwo();
        PhaseThree();
        PhaseFour();

    }
}
