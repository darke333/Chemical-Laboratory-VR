using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSearchedSubstance : MonoBehaviour
{
    float time;
    public GameObject Instatieted;
    public GameObject HardSubstance;
    public GameObject LiqSubstance;
    public ObiParticleRenderer WaterEmitter;
    //public GameObject TemperatureText;
    public Scenario3 Scenario3;
    public GameObject Camera;
    List<Subst> Substances = new List<Subst>();


    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
    }


    public void OnClicked(Button button)
    {
        if(Instatieted != null)
        {
            Destroy(Instatieted);
            Instatieted = null;
        }
        string name = button.transform.GetChild(0).GetComponent<Text>().text;
        foreach (Subst subst in Substances)
        {
            if(subst.name == name)
            {
                if (subst.aggregate)
                {
                    Instatieted = Instantiate(HardSubstance);
                    if (subst.solubility)
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = true;
                    }
                    else
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = false;
                    }
                }
                else
                {
                    Instatieted = Instantiate(LiqSubstance);
                    Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().WaterRenderer = WaterEmitter;
                    if (subst.solubility)
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = true;
                    }
                    else
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = false;
                    }
                    Camera.GetComponent<ObiFluidRenderer>().particleRenderers[0] = Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().FluidRederer;
                }
                Scenario3.necessaryTemp = (int)subst.temp;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Substances = gameObject.GetComponent<Request>().Substances;
        }

    }
}
