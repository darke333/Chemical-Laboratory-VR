using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlIsparitel : MonoBehaviour
{
    public List<UIPanelControll> UIs;
    public bool Started;
    public Transform RotationObj;
    public List<ParticleSystem> Smoke;
    public Change2 mist;
    float TimeOperation;
    public GameObject emitter1;
    public GameObject emitter2;
    public GameObject HardSubstActivatel;
    public GameObject Text1;
    public GameObject Text2;
    public bool Finished;
    public ScaleOVRPlayer OVRScaler;


    // Start is called before the first frame update
    void Start()
    {
        TimeOperation = 5;
        //Started = true;
        Time.timeScale = 1;
    }

    void FinishProg()
    {
        if (emitter1)
        {
            emitter1.SetActive(false);
        }
        emitter2.SetActive(true);
        Text1.SetActive(false);
        Text2.SetActive(true);
        if (HardSubstActivatel)
        {
            HardSubstActivatel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        if (Input.GetKeyDown("r")) 
        {
            ReloadSc();

        }
        if (Input.GetKeyDown("s"))
        {
            OVRScaler.ScalePlayer();
        }
    }

    public void ReloadSc()
    {
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Rotation()
    {
        if (Started)
        {
            RotationObj.Rotate(0, UIs[0].CurrentNumber / 60, 0, Space.Self);
            foreach(ParticleSystem particle in Smoke)
            {
                particle.emissionRate = 10;
            }
            mist.mist = true;
            if (Finished)
            {
                TimeOperation -= Time.deltaTime;
                if (TimeOperation < 0)
                {
                    FinishProg();
                }
            }
        }
        else
        {
            foreach (ParticleSystem particle in Smoke)
            {
                particle.emissionRate = 0;

            }
            mist.mist = false;
        }
    }
}
