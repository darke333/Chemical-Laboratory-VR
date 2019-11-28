using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scenario1 : MonoBehaviour
{
    public GameObject FirstPlaceTrigger;
    public bool SaltyPlaced;
    public bool Selected;
    public List<GameObject> Hints;
    public OVRGrabbable colba;
    public WaterControll rechag;
    //public DebugPool debugPool;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
    public TextMeshPro text5;
    public bool Mixed;
    public int SaltOut;
    float RestTime;
    public GameObject NextPhase;
    // Start is called before the first frame update
    void Start()
    {
        RestTime = 5;
        foreach (GameObject hint in Hints)
        {
            hint.SetActive(true);
        }
    }

    void PhaseOne()
    {
        if (colba.isGrabbed)
        {
            text1.color = Color.green;
        }
        else
        {
            text1.color = Color.white;
        }
    }

    void PhaseTwo()
    {
        if (rechag.Emitting)
        {
            text2.color = Color.green;
            text5.gameObject.SetActive(true);

        }
        else
        {
            text2.color = Color.white;
        }
    }

    void PhaseOnePlus()
    {
        if (Selected)
        {
            text3.color = Color.green;
            text4.gameObject.SetActive(true);
            FirstPlaceTrigger.SetActive(true);
        }
        else
        {
            text3.color = Color.white;
        }

    }

    void PhaseTwoPlus()
    {
        if (SaltyPlaced)
        {
            text4.color = Color.green;
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);

        }
        else
        {
            text4.color = Color.white;
        }
    }

    void PhaseFive()
    {
        if (Mixed)
        {
            text4.color = Color.green;
            RestTime -= Time.deltaTime;
            if (RestTime < 0)
            {
                NextPhase.SetActive(true);
                foreach (GameObject hint in Hints)
                {
                    hint.SetActive(false);
                }
                Destroy(gameObject);
            }
            else
            {
                text5.color = Color.white;
            }
        }

    }



    void Update()
    {
        PhaseOnePlus();
        PhaseTwoPlus();
        PhaseOne();
        PhaseTwo();
        PhaseFive();
    }
}
