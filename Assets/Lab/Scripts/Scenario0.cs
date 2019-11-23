using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scenario0 : MonoBehaviour
{
    public List<GameObject> Hints;
    public OVRGrabbable colba;
    public DebugPool debugPool;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
    public int SaltOut;
    public bool EmptyPlaced;
    public bool SaltyPlaced;
    float RestTime;
    public GameObject NextPhase;
    public GameObject FirstPlace;
    public GameObject SecondPlace;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        number = -1;
        RestTime = 5;
        FirstPlace.SetActive(true);
        Hints[0].SetActive(true);
    }

    void PhaseOne()
    {
        if (SaltyPlaced && !text3.gameObject.active && !text4.gameObject.active)
        {
            text1.color = Color.green;
            text2.gameObject.SetActive(true);
            SecondPlace.SetActive(true);
            Hints[0].SetActive(false);
            Hints[1].SetActive(true);
        }
        else
        {
            text1.color = Color.white;
        }
    }

    void ChangeHint(bool forward)
    {
        if (forward)
        {
            number++;
            Hints[number].SetActive(true);
            if(number > 0)
            {
                Hints[number - 1].SetActive(false);
            }
        }
        else
        {
            number--;
            Hints[number].SetActive(true);
            if (number < Hints.Count)
            {
                Hints[number + 1].SetActive(false);
            }
            
        }
    }
    
    
    void PhaseTwo()
    {
        if (EmptyPlaced && !text3.gameObject.active && !text4.gameObject.active)
        {
            text2.color = Color.green;
        }
        else
        {
            text2.color = Color.white;
        }
    }

    void MistakeOne()
    {
        if (SaltOut > 10)
        {
            text3.gameObject.SetActive(true);
        }
        else
        {
            text3.gameObject.SetActive(false);
        }
    }

    void MistaceTwo()
    {
        if (debugPool.Splited)
        {
            text4.gameObject.SetActive(true);
        }
        else
        {
            text4.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        PhaseOne();
        PhaseTwo();
        MistakeOne();
        MistaceTwo();
        if (SaltyPlaced && EmptyPlaced && !text3.gameObject.active && !text4.gameObject.active)
        {
            RestTime -= Time.deltaTime;
            if (RestTime < 0 )
            {
                NextPhase.SetActive(true);
                foreach (GameObject hint in Hints)
                {
                    hint.SetActive(false);
                }
                Destroy(gameObject);
            }
        }
    }
}
