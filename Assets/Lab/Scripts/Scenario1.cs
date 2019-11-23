using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scenario1 : MonoBehaviour
{
    public List<GameObject> Hints;
    public OVRGrabbable colba;
    public WaterControll rechag;
    public DebugPool debugPool;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
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
        if (rechag.Emitting && !text3.gameObject.active && !text4.gameObject.active)
        {
            text2.color = Color.green;
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
        }
        else
        {
            text2.color = Color.white;
        }
    }

    void MistakeOne()
    {
        if(SaltOut > 10)
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
    }
}
